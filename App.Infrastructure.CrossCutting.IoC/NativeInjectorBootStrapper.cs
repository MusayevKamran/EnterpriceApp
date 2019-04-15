using App.Application.Interfaces.Course;
using App.Application.Services;
using App.Domain.CommandHandler.Course;
using App.Domain.Commands.Course.Student;
using App.Domain.Core.Bus;
using App.Domain.Core.Events;
using App.Domain.Core.Notifications;
using App.Domain.EventHandler.Course;
using App.Domain.Events.Course.Student;
using App.Domain.Interfaces;
using App.Domain.Interfaces.Course;
using App.Infrastructure.CrossCutting.Bus;
using App.Infrastructure.CrossCutting.Identity.Authorization;
using App.Infrastructure.CrossCutting.Identity.Models;
using App.Infrastructure.CrossCutting.Identity.Services;
using App.Infrastructure.Data.Context;
using App.Infrastructure.Data.EventSourcing;
using App.Infrastructure.Data.Repository.Course;
using App.Infrastructure.Data.Repository.EventSourcing;
using App.Infrastructure.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;


namespace App.Infrastructure.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<IStudentAppService, StudentAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<StudentRegisteredEvent>, StudentEventHandler>();
            services.AddScoped<INotificationHandler<StudentUpdatedEvent>, StudentEventHandler>();
            services.AddScoped<INotificationHandler<StudentRemovedEvent>, StudentEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewStudentCommand, bool>, StudentCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateStudentCommand, bool>, StudentCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveStudentCommand, bool>, StudentCommandHandler>();

            // Infra - Data
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services.AddScoped<EquinoxContext>();
            services.AddDbContext<AppDbContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();

            //services.AddScoped<EventStoreSQLContext>();
            services.AddDbContext<EventStoreSQLContext>();

            // Infra - Identity Services
           services.AddTransient<IEmailSender, AuthEmailMessageSender>();
           services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
           services.AddScoped<IUser, AspNetUser>();
        }
    }
}
