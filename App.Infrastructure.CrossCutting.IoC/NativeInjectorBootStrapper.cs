using App.Application.Interfaces.Shop;
using App.Application.Services.Shop;
using App.Domain.CommandHandler.Shop;
using App.Domain.Commands.Shop.Category;
using App.Domain.Core.Bus;
using App.Domain.Core.Events;
using App.Domain.Core.Notifications;
using App.Domain.EventHandler.Shop;
using App.Domain.Events.Shop.Category;
using App.Domain.Interfaces;
using App.Domain.Interfaces.Shop;
using App.Infrastructure.CrossCutting.Bus;
using App.Infrastructure.CrossCutting.Identity.Authorization;
using App.Infrastructure.CrossCutting.Identity.Models;
using App.Infrastructure.CrossCutting.Identity.Services;
using App.Infrastructure.Data.Context;
using App.Infrastructure.Data.EventSourcing;
using App.Infrastructure.Data.Repository.EventSourcing;
using App.Infrastructure.Data.Repository.Shop;
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
            services.AddScoped<ICategoryAppService, CategoryAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<CategoryCreatedEvent>, CategoryEventHandler>();
            services.AddScoped<INotificationHandler<CategoryUpdatedEvent>, CategoryEventHandler>();
            services.AddScoped<INotificationHandler<CategoryRemovedEvent>, CategoryEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<CreateNewCategoryCommand, bool>, CategoryCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCategoryCommand, bool>, CategoryCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCategoryCommand, bool>, CategoryCommandHandler>();

            // Infra - Data
            services.AddScoped<ICategoryRepository, CategoryRepository>();
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
