using EducationPortal.Entities.Enums;
using EducationPortal.Entities.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Entities.DTOs.CourseDtos;

public class CourseCreateDtoRequest
{
    [Required(ErrorMessage = "İsim alanı zorunludur.")]
    [StringLength(30, ErrorMessage = "İsim en fazla 30 karakter olmalıdır.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Başlangıç tarihi alanı zorunludur.")]
    [FutureDate(ErrorMessage = "Başlangıç tarihi geçmiş bir tarih olamaz.")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "Gün başına fiyat alanı zorunludur.")]
    [Range(0, double.MaxValue, ErrorMessage = "Geçersiz fiyat.")]
    public double PricePerDay { get; set; }

    [Required(ErrorMessage = "Kontenjan alanı zorunludur.")]
    [Range(1, 100, ErrorMessage = "Kontenjan 1 ile 100 arasında olmalıdır.")]
    public int Quota { get; set; }

    [Required(ErrorMessage = "Süre (gün) alanı zorunludur.")]
    [Range(1, int.MaxValue, ErrorMessage = "Süre 1'den büyük olmalıdır.")]
    public int DurationInDays { get; set; }

    [Required(ErrorMessage = "Kategori alanı zorunludur.")]
    [EnumDataType(typeof(CourseCategory), ErrorMessage = "Geçersiz kategori.")]
    public CourseCategory Category { get; set; }

    [Required(ErrorMessage = "Eğitmen türü alanı zorunludur.")]
    [EnumDataType(typeof(InstructorType), ErrorMessage = "Geçersiz eğitmen türü.")]
    public InstructorType InstructorType { get; set; }
}
