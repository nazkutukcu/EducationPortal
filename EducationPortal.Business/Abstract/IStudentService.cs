using EducationPortal.Entities.DTOs.CourseDtos;
using EducationPortal.Entities.DTOs.SharedDtos;
using EducationPortal.Entities.DTOs.StudentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Business.Abstract;

public interface IStudentService
{
    List<StudentDto> GetAll();
    Task<Guid?> CreateStudent(StudentCreateDtoRequest request);
    void Delete(int id);
}
