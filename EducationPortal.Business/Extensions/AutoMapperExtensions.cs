using EducationPortal.Business.Mapping;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Business.Extensions;

public static class AutoMapperExtension
{
    public static void AutoMapperExt(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(CourseMapper)); 
    }
}
