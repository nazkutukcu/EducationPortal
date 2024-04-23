using EducationPortal.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EducationPortal.Entities.Entity;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate {  get; set; }
    public double PricePerDay {  get; set; }
    public int Quota { get; set; } 
    public int DurationInDays { get; set; } 
    public CourseCategory Category { get; set; } 
    public InstructorType InstructorType { get; set; }
    public List<Enrollment> Enrollments { get; set; }
    public List<CompletedCourse> CompletedCourses { get; set; }

}
