using AutoMapper;
using EducationPortal.Business.Abstract;
using EducationPortal.Entities.DTOs.CourseDtos;
using EducationPortal.DataAccess.Abstract;
using EducationPortal.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using EducationPortal.Entities.DTOs.SharedDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace EducationPortal.Business.Concrete;

public class CourseService(IFileProvider fileProvider, IFileStorageService fileStorageService, ICourseRepository courseRepository, IMapper mapper) : ICourseService
{
    public List<CourseDto> GetAll()
    {
        var courses = courseRepository.GetAll();
        var courseDtos = mapper.Map<List<CourseDto>>(courses);

        return courseDtos;
    }
    public ResponseDto<int> CreateCourse(CourseCreateDtoRequest request)
    {
        Course course = new Course()
        {
            Name = request.Name,
            PricePerDay = request.PricePerDay,
            DurationInDays = request.DurationInDays,
            Quota = request.Quota,
            StartDate = request.StartDate.Date,
            InstructorType = request.InstructorType,
            Category = request.Category
        };

        courseRepository.Add(course);
        return ResponseDto<int>.Success(course.Id);
    }

    public void Update(CourseUpdateDtoRequest request)
    {
       
    }

    public void Delete(int id)
    {
        courseRepository.Delete(id);
    }  
}
