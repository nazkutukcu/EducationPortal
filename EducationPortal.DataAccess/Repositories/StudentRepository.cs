using EducationPortal.DataAccess.Abstract;
using EducationPortal.Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.DataAccess.Repositories;

public class StudentRepository(EducationPortalDbContext context) : IStudentRepository
{
    public List<Student> GetAll()
    {
        return context.Students.ToList();
    }
    public Student GetById(int id)
    {
        return context.Students.Find(id);
    }
    public Student Add(Student student)
    {
        context.Students.Add(student);
        context.SaveChanges();

        return student;
    }

    public void Delete(int id)
    {
        var student = context.Students.Find(id);

        context.Remove(student!);
        context.SaveChanges();
    }
}
