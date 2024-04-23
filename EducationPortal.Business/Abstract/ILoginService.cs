using EducationPortal.Entities.DTOs.LoginDtos;
using EducationPortal.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Business.Abstract;

public interface ILoginService
{
    Task<Student> Login(LoginCreateRequestDto request);
}
