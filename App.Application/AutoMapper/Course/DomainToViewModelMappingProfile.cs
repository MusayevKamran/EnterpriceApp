using App.Application.ViewModels.Course;
using App.Domain.Models.Course;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.AutoMapper.Course
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Student, StudentViewModel>();
        }
    }
}
