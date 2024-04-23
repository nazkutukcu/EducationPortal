using Azure.Core;
using EducationPortal.Entities.DTOs.SharedDtos;
using EducationPortal.Entities.DTOs.TokenDtos;
using EducationPortal.Entities.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Business.Token;

public class TokenService(IConfiguration configuration, UserManager<Student> userManager)
{
    public async Task<ResponseDto<TokenCreateResponseDto>> Create(TokenCreateRequestDto request)
    {
        var hasUser = await userManager.FindByNameAsync(request.UserName);
        var checkEmail = await userManager.FindByEmailAsync(request.Email);

        if (hasUser == null || checkEmail == null)
        {
            return ResponseDto<TokenCreateResponseDto>.Fail("Username or email is wrong");
        }

        var signatureKey = configuration.GetSection("TokenOptions")["Key"];
        var tokenExpireAsHour = configuration.GetSection("TokenOptions")["Key"];

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signatureKey));

        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        var claimList = new List<Claim>();

        var userIdAsClaim = new Claim(ClaimTypes.NameIdentifier, hasUser.Id.ToString());
        var userNameAsClaim = new Claim(ClaimTypes.Name, hasUser.UserName!);
        var idAsClaim = new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString());

        claimList.Add(userIdAsClaim);
        claimList.Add(userNameAsClaim);
        claimList.Add(idAsClaim);
        foreach (var role in await userManager.GetRolesAsync(hasUser))
        {
            claimList.Add(new Claim(ClaimTypes.Role, role));
        }

        var token = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(Convert.ToDouble(tokenExpireAsHour)),
                signingCredentials: signingCredentials,
                claims: claimList
                );

        var responseDto = new TokenCreateResponseDto
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
        };

        return ResponseDto<TokenCreateResponseDto>.Success(responseDto);
    }
}
