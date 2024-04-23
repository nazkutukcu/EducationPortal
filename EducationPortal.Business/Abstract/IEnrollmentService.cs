using EducationPortal.Entities.DTOs.CourseDtos;
using EducationPortal.Entities.DTOs.EnrollmentDtos;
using EducationPortal.Entities.DTOs.SharedDtos;
using EducationPortal.Entities.DTOs.StudentDtos;
using EducationPortal.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Business.Abstract;

public interface IEnrollmentService
{
    ResponseDto<int> ProcessEnrollment(EnrollmentProcessDtoRequest request);
    List<Enrollment> GetStudentCourses(Guid studentId);
    void Delete(int id);
    ResponseDto<int> CompleteCourse(int enrollmentId);
    List<CompletedCourse> GetAllCompletedCoursesForStudent(Guid studentId);
}
