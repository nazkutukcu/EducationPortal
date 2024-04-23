using EducationPortal.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Entities.DTOs.EnrollmentDtos;

public class EnrollmentProcessDtoRequest
{
    public int CourseId { get; set; }
    public Guid StudentId { get; set; }
}
