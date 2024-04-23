using EducationPortal.Entities.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.DataAccess;

public class EducationPortalDbContext : IdentityDbContext<Student, AppRole, Guid>
{
    public EducationPortalDbContext(DbContextOptions<EducationPortalDbContext> options) : base(options)
    {

    }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<CompletedCourse> CompletedCourses { get; set; }

}

