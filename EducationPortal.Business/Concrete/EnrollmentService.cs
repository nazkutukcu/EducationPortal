using AutoMapper;
using EducationPortal.Business.Abstract;
using EducationPortal.DataAccess.Abstract;
using EducationPortal.DataAccess.Repositories;
using EducationPortal.Entities.DTOs.CourseDtos;
using EducationPortal.Entities.DTOs.EnrollmentDtos;
using EducationPortal.Entities.DTOs.SharedDtos;
using EducationPortal.Entities.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Business.Concrete;

public class EnrollmentService(IEnrollmentRepository enrollmentRepository, ICourseRepository courseRepository, IStudentRepository studentRepository, IMapper mapper,
    ICompletedCourseRepository completedCourseRepository) : IEnrollmentService
{
    public ResponseDto<int> ProcessEnrollment(EnrollmentProcessDtoRequest request)
    {
        var course = courseRepository.GetById(request.CourseId);
        if (course == null)
        {
            return ResponseDto<int>.Fail("Kurs bulunamadı.");
        }

        var studentCourses = enrollmentRepository.GetStudentCourses(request.StudentId);
        var existingEnrollment = studentCourses.FirstOrDefault(c => c.Id == request.CourseId);
        if (existingEnrollment != null)
        {
            return ResponseDto<int>.Fail("Bu öğrenci zaten bu kursa kayıtlı.");
        }

        var enrollment = new Enrollment
        {
            EnrollmentDate = DateTime.Now,
            CourseId = request.CourseId,
            StudentId = request.StudentId
        };

        enrollmentRepository.Add(enrollment);

        return ResponseDto<int>.Success(enrollment.Id);
    }

    public List<Enrollment> GetStudentCourses(Guid studentId)
    {
        var enrollments = enrollmentRepository.GetStudentCourses(studentId);
        return enrollments;
    }

    public void Delete(int id)
    {
        enrollmentRepository.Delete(id);
    }

    public ResponseDto<int> CompleteCourse(int enrollmentId)
    {
        var enrollment = enrollmentRepository.GetById(enrollmentId);
        if (enrollment == null)
        {
            return ResponseDto<int>.Fail("Kayıt bulunamadı.");
        }

        var courseId = enrollment.CourseId;
        var studentId = enrollment.StudentId;
        var completedCourse = new CompletedCourse
        {
            CourseId = courseId,
            StudentId = studentId
        };
        completedCourseRepository.Add(completedCourse);
        enrollmentRepository.Delete(enrollmentId);

        return ResponseDto<int>.Success(completedCourse.Id);
    }

    public List<CompletedCourse> GetAllCompletedCoursesForStudent(Guid id)
    {
        var completedCourses = completedCourseRepository.GetAllCompletedCoursesForStudent(id);
        return completedCourses;
    }
}
