using EducationPortal.Entities.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Business.Concrete;

public class IdentityService
{
    public UserManager<Student> UserManager { get; set; }
    public RoleManager<AppRole> RoleManager { get; set; }
    public SignInManager<Student> SignInManager { get; set; }
}
