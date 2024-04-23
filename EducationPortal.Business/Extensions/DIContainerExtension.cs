using EducationPortal.Business.Abstract;
using EducationPortal.Business.Concrete;
using EducationPortal.Business.Token;
using EducationPortal.DataAccess.Abstract;
using EducationPortal.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Business.Extensions;

public static class DIContainerExtension
{
    public static void DIContainerExt(this IServiceCollection services)
    {
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<ICourseService, CourseService>();

        services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
        services.AddScoped<IEnrollmentService, EnrollmentService>();

        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IStudentService, StudentService>();

        services.AddScoped<IFileStorageService, FileStorageService>();

        services.AddScoped<IdentityService>();

        services.AddScoped<TokenService>();

        services.AddScoped<ILoginService, LoginService>();

        services.AddScoped<ICompletedCourseRepository, CompletedCourseRepository>();
    }
}
