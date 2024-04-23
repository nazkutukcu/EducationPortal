using EducationPortal.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.DataAccess.Abstract;

public interface IStudentRepository
{
    List<Student> GetAll();
    Student GetById(int id);
    Student Add(Student student);
    void Delete(int id);
}
