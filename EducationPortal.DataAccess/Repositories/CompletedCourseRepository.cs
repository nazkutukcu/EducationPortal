using EducationPortal.DataAccess.Abstract;
using EducationPortal.Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.DataAccess.Repositories;

public class CompletedCourseRepository(EducationPortalDbContext context) : ICompletedCourseRepository
{
    public CompletedCourse Add(CompletedCourse completedCourse)
    {
        context.CompletedCourses.Add(completedCourse);
        context.SaveChanges();

        return completedCourse;
    }

    public List<CompletedCourse> GetAllCompletedCoursesForStudent(Guid studentId)
    {
        var completedCourses = context.CompletedCourses
            .Where(cc => cc.StudentId == studentId)
            .Include(cc => cc.Course)
            .ToList();

        return completedCourses;
    }
}
