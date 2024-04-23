using EducationPortal.Business.Abstract;
using EducationPortal.Business.Concrete;
using EducationPortal.Business.Token;
using EducationPortal.Entities.DTOs.StudentDtos;
using EducationPortal.Entities.DTOs.TokenDtos;
using Microsoft.AspNetCore.Mvc;

namespace EducationPortalWebApp.Controllers
{
    public class StudentController(IStudentService studentService, IdentityService identityService,TokenService tokenService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return View(studentService.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentCreateDtoRequest request)
        {
            var response = await studentService.CreateStudent(request);
            if (response != null)
            {
               return RedirectToAction("GetAll", "Student");
             
            }
            else
            {
                return View("Index");
            }
          
        }
    }
}
