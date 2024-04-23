using EducationPortal.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.DataAccess.Abstract;

public interface ICourseRepository
{
    List<Course> GetAll();
    Course GetById(int id);
    Course Add(Course course);
    void Update(Course course);
    void Delete(int id);
}
