using App.Application.EventSourcedNormalizers;
using App.Application.Interfaces;
using App.Domain.Interfaces;
using App.Application.ViewModels;
using App.Domain.Commands.Student;
using App.Domain.Core.Bus;
using App.Infrastructure.Data.Repository.EventSourcing;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;

namespace App.Application.Services
{
    public class StudentAppService : IStudentAppService
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public StudentAppService(IMapper mapper,
                                  IStudentRepository studentRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<StudentViewModel> GetAll()
        {
            return _studentRepository.GetAll().ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider);
        }

        public StudentViewModel GetById(Guid id)
        {
            return _mapper.Map<StudentViewModel>(_studentRepository.GetById(id));
        }

        public void Register(StudentViewModel studentViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewStudentCommand>(studentViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(StudentViewModel studentViewModel)
        {
            var updateCommand = _mapper.Map<UpdateStudentCommand>(studentViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveStudentCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public IList<StudentHistoryData> GetAllHistory(Guid id)
        {
            return StudentHistory.ToJavaScriptStudentHistory(_eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}