using System.Threading;
using System.Threading.Tasks;
using App.Domain.Events.Course.Student;
using MediatR;


namespace App.Domain.EventHandler.Course
{
    public class StudentEventHandler :
        INotificationHandler<StudentRegisteredEvent>,
        INotificationHandler<StudentUpdatedEvent>,
        INotificationHandler<StudentRemovedEvent>
    {
        public Task Handle(StudentRegisteredEvent notification, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail
            return Task.CompletedTask;
        }

        public Task Handle(StudentUpdatedEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            return Task.CompletedTask;
        }

        public Task Handle(StudentRemovedEvent notification, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail
            return Task.CompletedTask;
        }
    }
}
