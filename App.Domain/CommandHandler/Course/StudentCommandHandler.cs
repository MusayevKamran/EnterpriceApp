using App.Domain.Commands.Course.Student;
using App.Domain.Core.Bus;
using App.Domain.Core.Notifications;
using App.Domain.Events.Course.Student;
using App.Domain.Interfaces.Course;
using App.Domain.Interfaces;
using App.Domain.Models.Course;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Domain.CommandHandler.Course
{
    public class StudentCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewStudentCommand, bool>,
        IRequestHandler<UpdateStudentCommand, bool>,
        IRequestHandler<RemoveStudentCommand, bool>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMediatorHandler _bus;
        public StudentCommandHandler(
            IStudentRepository studentRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _studentRepository = studentRepository;
            _bus = bus;
        }

        public Task<bool> Handle(RegisterNewStudentCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }

            var student = new Student(Guid.NewGuid(), request.Name, request.Email, request.BirthDate);
            if (_studentRepository.GetByEmail(student.Email) != null)
            {
                _bus.RaiseEvent(new DomainNotification(request.MessageType, "The student e-mail has already been taken."));
                return Task.FromResult(false);
            }

            _studentRepository.Add(student);

            if (Commit())
            {
                _bus.RaiseEvent(new StudentRegisteredEvent(student.Id, student.Name, student.Email, student.BirthDate));
            }
            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                Task.FromResult(false);
            }
            var student = new Student(request.Id, request.Name, request.Email, request.BirthDate);
            var existingStudent = _studentRepository.GetByEmail(student.Email);

            if (existingStudent != null && existingStudent.Id != student.Id)
            {
                if (!existingStudent.Equals(student))
                {
                    _bus.RaiseEvent(new DomainNotification(request.MessageType, "The student e-mail has already been taken."));
                    return Task.FromResult(false);
                }
            }

            _studentRepository.Update(student);

            if (Commit())
            {
                _bus.RaiseEvent(new StudentUpdatedEvent(student.Id, student.Name, student.Email, student.BirthDate));
            }
            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }
            _studentRepository.Remove(request.Id);

            if (Commit())
            {
                _bus.RaiseEvent(new StudentRemovedEvent(request.Id));
            }

            return Task.FromResult(true);
        }
        public void Dispose()
        {
            _studentRepository.Dispose();
        }
    }
}
