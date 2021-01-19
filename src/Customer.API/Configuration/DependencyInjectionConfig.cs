using Common.Core.Mediator;
using Customer.API.Application.Commands;
using Customer.API.Application.Events;
using Customer.API.Data;
using Customer.API.Repository;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Customer.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<CustomerRegisterCommand, ValidationResult>, CustomerCommandHandler>();

            services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<CustomerDbContext>();
        }
    }
}