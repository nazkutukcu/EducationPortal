using EducationPortal.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.DataAccess.Abstract;

public interface IEnrollmentRepository
{
    List<Enrollment> GetAll();
    Enrollment Add(Enrollment enrollment);
    void Delete(int id);
    List<Enrollment> GetStudentCourses(Guid studentId);
    Enrollment GetById(int id);
}
