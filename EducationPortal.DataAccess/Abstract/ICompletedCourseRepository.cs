using EducationPortal.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.DataAccess.Abstract;

public interface ICompletedCourseRepository
{
    CompletedCourse Add(CompletedCourse completedCourse);
    List<CompletedCourse> GetAllCompletedCoursesForStudent(Guid studentId);
}
