using App.Application.ViewModels.Course;
using App.Domain.Commands.Course.Student;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.AutoMapper.Course
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
