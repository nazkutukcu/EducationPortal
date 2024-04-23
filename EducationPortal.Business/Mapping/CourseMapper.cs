using AutoMapper;
using EducationPortal.Entities.DTOs.CourseDtos;
using EducationPortal.Entities.DTOs.StudentDtos;
using EducationPortal.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Business.Mapping;

public class CourseMapper : Profile
{
    public CourseMapper()
    {
        CreateMap<Course, CourseDto>().ReverseMap();
        CreateMap<Student, StudentDto>().ReverseMap();
        CreateMap<CompletedCourse, CompletedCourseDto>().ReverseMap();
        
    }
}
