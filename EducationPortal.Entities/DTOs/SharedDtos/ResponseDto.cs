﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Entities.DTOs.SharedDtos;

public class ResponseDto<T>
{
    public T? Data { get; set; }
    public List<string>? Errors { get; set; }
    public bool AnyError => Errors is not null && Errors.Count > 0;

    //static factory method design pattern
    public static ResponseDto<T> Success(T data)
    {
        return new ResponseDto<T>
        {
            Data = data,
        };
    }
    public static ResponseDto<T> Fail(List<string> errors)
    {
        return new ResponseDto<T>
        {
            Errors = errors
        };
    }
    public static ResponseDto<T> Fail(string error)
    {
        return new ResponseDto<T>
        {
            Errors = new List<string> { error }
        };
    }
}
