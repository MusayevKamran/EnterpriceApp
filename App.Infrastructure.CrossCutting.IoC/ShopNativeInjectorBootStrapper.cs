using App.Application.Interfaces.Shop;
using App.Application.Services.Shop;
using App.Domain.CommandHandler.Shop;
using App.Domain.Commands.Shop.Category;
using App.Domain.Core.Notifications;
using App.Domain.EventHandler.Shop;
using App.Domain.Events.Shop.Category;
using App.Domain.Interfaces.Shop;
using App.Infrastructure.Data.Context;
using App.Infrastructure.Data.Repository.Shop;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastructure.CrossCutting.IoC
{
    public class ShopNativeInjectorBootStrapper
    {
        public static void RegisterShopServices(IServiceCollection services)
        {
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

            //services.AddScoped<EquinoxContext>();
            services.AddDbContext<ShopDbContext>();
        }
    }
}
