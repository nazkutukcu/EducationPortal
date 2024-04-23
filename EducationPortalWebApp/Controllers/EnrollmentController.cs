using AutoMapper;
using Azure;
using EducationPortal.Business.Abstract;
using EducationPortal.Business.Concrete;
using EducationPortal.DataAccess.Repositories;
using EducationPortal.Entities.DTOs.CourseDtos;
using EducationPortal.Entities.DTOs.EnrollmentDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EducationPortalWebApp.Controllers
{
    public class EnrollmentController(IEnrollmentService enrollmentService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddEnrollment()
        {
            return View();
        }
        public IActionResult GetAllCompletedCourses()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetStudentCourses(Guid id)
        {
            var response = enrollmentService.GetStudentCourses(id);
            return View(response);
        }

        [HttpPost]
        public IActionResult AddEnrollment(EnrollmentProcessDtoRequest request)
        {
            var response = enrollmentService.ProcessEnrollment(request);
            if (response.AnyError)
            {
                ViewBag.ErrorMessage = response.Errors.FirstOrDefault();
                return View("AddEnrollment");
            }
            return View("Index");
        }

        [HttpPost("cancelEnrollment")]
        public IActionResult CancelEnrollment(int id)
        {
            enrollmentService.Delete(id);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        [Route("api/enrollment/complete")]
        public IActionResult CompleteCourse(int id)
        {
            var response = enrollmentService.CompleteCourse(id);

            if (response.AnyError)
            {
                ViewBag.ErrorMessage = response.Errors.FirstOrDefault();
                return Redirect(Request.Headers["Referer"].ToString());
            }
            else
            {
                return Redirect(Request.Headers["Referer"].ToString());
            }
        }

        [HttpGet("GetAllCompletedCoursesForStudent")]
        public IActionResult GetAllCompletedCourses(Guid id)
        {
            var completedCourses = enrollmentService.GetAllCompletedCoursesForStudent(id);
            return View(completedCourses);          
        }

    }
}
