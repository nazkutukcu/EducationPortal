using EducationPortal.DataAccess.Abstract;
using EducationPortal.Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.DataAccess.Repositories;

public class EnrollmentRepository(EducationPortalDbContext context) : IEnrollmentRepository
{
    public List<Enrollment> GetAll()
    {
        return context.Enrollments.ToList();
    }

    public Enrollment Add(Enrollment enrollment)
    {
        context.Enrollments.Add(enrollment);
        context.SaveChanges();

        return enrollment;
    }

    public void Delete(int id)
    {
        var enrollment = context.Enrollments.Find(id);

        context.Remove(enrollment!);
        context.SaveChanges();
    }

    public List<Enrollment> GetStudentCourses(Guid studentId)
    {
        var courseEnrollments = context.Enrollments
            .Where(e => e.StudentId == studentId)
            .Include(e => e.Course)
            .ToList();

        return courseEnrollments;
    }

    public Enrollment GetById(int id)
    {
        return context.Enrollments.FirstOrDefault(e => e.Id == id);
    }

}
