using EducationPortal.Entities.Entity;
using EducationPortal.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EducationPortal.Entities.DTOs.CourseDtos;

public class CourseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate {  get; set; }
    public double PricePerDay { get; set; }
    public int Quota { get; set; }
    public int DurationInDays { get; set; } 
    public CourseCategory Category { get; set; } 
    public InstructorType InstructorType { get; set; }
}
