using EducationPortal.Business.Abstract;
using EducationPortal.Entities.DTOs.LoginDtos;
using EducationPortal.Entities.DTOs.TokenDtos;
using EducationPortal.Entities.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Business.Concrete;

public class LoginService(SignInManager<Student> signInManager, UserManager<Student> userManager) : ILoginService
{
    public async Task<Student> Login(LoginCreateRequestDto request)
    {
        //var student = await userManager.FindByEmailAsync(request.Email);
        var student = await userManager.FindByNameAsync(request.UserName);
        if (student != null)
        {
            var checkPassword = await userManager.CheckPasswordAsync(student, request.Password);
            if (checkPassword)
            {
                await signInManager.PasswordSignInAsync(student, request.Password, false, false);
                return student;
            }
        }
        return null;
    }
}

