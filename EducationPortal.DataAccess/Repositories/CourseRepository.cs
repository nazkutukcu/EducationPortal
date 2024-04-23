using EducationPortal.DataAccess.Abstract;
using EducationPortal.Entities.Entity;
using EducationPortal.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace EducationPortal.DataAccess.Repositories;

public class CourseRepository(EducationPortalDbContext context) : ICourseRepository
{

    public List<Course> GetAll()
    {
        return context.Courses.ToList();
    }

    public Course GetById(int id)
    {
        return context.Courses.Find(id);
    }

    public Course Add(Course course)
    {
        context.Courses.Add(course);
        context.SaveChanges();

        return course;
    }

    public void Update(Course course)
    {
        context.Courses.Update(course);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        var course = context.Courses.Find(id);

        context.Remove(course!);
        context.SaveChanges();
    }
}
