using App.Application.ViewModels;
using App.Domain.Commands.Student;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<StudentViewModel, RegisterNewStudentCommand>()
                .ConstructUsing(c => new RegisterNewStudentCommand(c.Name, c.Email, c.BirthDate));
            CreateMap<StudentViewModel, UpdateStudentCommand>()
                .ConstructUsing(c => new UpdateStudentCommand(c.Id, c.Name, c.Email, c.BirthDate));
        }
    }
}
