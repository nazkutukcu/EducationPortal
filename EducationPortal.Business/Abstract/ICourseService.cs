using EducationPortal.Entities.DTOs.CourseDtos;
using EducationPortal.Entities.DTOs.SharedDtos;
using EducationPortal.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Business.Abstract;

public interface ICourseService
{
    List<CourseDto> GetAll();
    ResponseDto<int> CreateCourse(CourseCreateDtoRequest request);
    void Update(CourseUpdateDtoRequest request);
    void Delete(int id);
}
