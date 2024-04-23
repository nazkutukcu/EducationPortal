using EducationPortal.Business.Abstract;
using EducationPortal.Business.Concrete;
using EducationPortal.Entities.DTOs.LoginDtos;
using EducationPortal.Entities.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace EducationPortalWebApp.Controllers
{
    public class LoginController(ILoginService loginService, UserManager<Student> userManager, SignInManager<Student> signInManager) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginStudent(LoginCreateRequestDto request)
        {
            if (request.UserName != null && request.Email != null)
            {
                var result = await loginService.Login(request);
                if (result is Student)
                {
                    var identity = await AddIdentityClaimsForUser(result);
                    await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, new ClaimsPrincipal(identity));

                    return RedirectToAction("Index", "Student");
                }
                else
                {
                    ViewBag.ErrorMessage = "Giriş yapılamadı. Lütfen doğru bilgilerle tekrar deneyin.";
                    return View(); 
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Giriş yapılamadı. Lütfen doğru bilgilerle tekrar deneyin.";
                return View(); 
            }
        }

        [HttpPost]
        public async Task<IActionResult> LoginAdmin(LoginCreateRequestDto request)
        {
            if (request.UserName != null && request.Email != null)
            {
                var result = await loginService.Login(request);
                if (result is Student)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewBag.ErrorMessage = "Giriş yapılamadı. Lütfen doğru bilgilerle tekrar deneyin.";
                    return View();
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Giriş yapılamadı. Lütfen doğru bilgilerle tekrar deneyin.";
                return View(); 
            }
        }

        public IActionResult LoginStudent()
        {
            return View();
        }

        public IActionResult LoginAdmin()
        {
            return View();
        }

        public async Task<ClaimsIdentity> AddIdentityClaimsForUser(Student student)
        {
            var roles = await userManager.GetRolesAsync(student);
            var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, student.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Email, student.Email));

            foreach (var role in roles)
                identity.AddClaim(new Claim(ClaimTypes.Role, role));

            return identity;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
