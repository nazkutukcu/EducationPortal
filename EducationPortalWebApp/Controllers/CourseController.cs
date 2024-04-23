using AutoMapper;
using EducationPortal.Business.Abstract;
using EducationPortal.DataAccess.Abstract;
using EducationPortal.DataAccess.Repositories;
using EducationPortal.Entities.DTOs.CourseDtos;
using EducationPortal.Entities.Entity;
using EducationPortalWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace EducationPortalWebApp.Controllers;

public class CourseController(ICourseService courseService, ICourseRepository courseRepository, IFileProvider fileProvider) : Controller
{
   
    [HttpGet]
    public IActionResult GetAll()
    {
        return View(courseService.GetAll());
    }

    [HttpPost]
    public IActionResult AddCourse(CourseCreateDtoRequest request)
    {
        var response = courseService.CreateCourse(request);
        if (response.AnyError)
        {
            return RedirectToAction("Index");
        }
        return RedirectToAction("GetAll", "Course");

    }

    [Route("SavePdf")]
    [HttpPost]
    public IActionResult SavePdf(IFormFile file)
    {
        var pdfDirectory = fileProvider.GetDirectoryContents("wwwroot");
        var pdf = pdfDirectory.Where(x => x.Name == "pdf").First();
        var path = Path.Combine(pdf.PhysicalPath, file.Name);

        using var stream = new FileStream(path, FileMode.Create);
        file.CopyTo(stream);

        return Redirect(Request.Headers["Referer"].ToString());
    }

}