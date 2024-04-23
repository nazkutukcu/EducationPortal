using EducationPortal.Business.Abstract;
using EducationPortal.Entities.DTOs.SharedDtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Business.Concrete;

public class FileStorageService(IFileProvider fileProvider) : IFileStorageService
{
    public string SavePdf(IFormFile file)
    {
        var pdfDirectory = fileProvider.GetDirectoryContents("wwwroot/pdf");

        var path = Path.Combine(pdfDirectory.First().PhysicalPath, file.Name);

        using var stream = new FileStream(path, FileMode.Create);
        file.CopyTo(stream);
        return $"URL to access the saved PDF file: /pdf/{file.Name}";
    }
}

