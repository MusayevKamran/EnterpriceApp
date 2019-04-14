using App.Application.ViewModels;
using App.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Student, StudentViewModel>();
        }
    }
}
