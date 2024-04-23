using AutoMapper;
using EducationPortal.Business.Abstract;
using EducationPortal.DataAccess.Abstract;
using EducationPortal.DataAccess.Repositories;
using EducationPortal.Entities.DTOs.CourseDtos;
using EducationPortal.Entities.DTOs.SharedDtos;
using EducationPortal.Entities.DTOs.StudentDtos;
using EducationPortal.Entities.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Business.Concrete;

public class StudentService(IStudentRepository studentRepository, IMapper mapper, UserManager<Student> userManager, SignInManager<Student> SignInManager) : IStudentService
{
    public List<StudentDto> GetAll()
    {
        var students = studentRepository.GetAll();
        var studentDtos = mapper.Map<List<StudentDto>>(students);

        return studentDtos;
    }
    public async Task<Guid?> CreateStudent(StudentCreateDtoRequest request)
    {
        Student student = new Student()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            UserName = request.FirstName + request.LastName,
            Password = Guid.NewGuid().ToString()
        };

        var result = await userManager.CreateAsync(student, student.Password);

        var user = await userManager.FindByNameAsync(student.UserName);
        if (user != null)
        {
            await userManager.AddToRoleAsync(user, "User");
        }

        return student.Id;
    }

    public void Delete(int id)
    {
        studentRepository.Delete(id);
    }
}
