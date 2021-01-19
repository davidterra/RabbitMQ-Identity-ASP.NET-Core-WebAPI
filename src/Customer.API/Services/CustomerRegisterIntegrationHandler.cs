using Common.Core.Mediator;
using Common.Core.Messages.Integration;
using Customer.API.Application.Commands;
using FluentValidation.Results;
using MessageBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.API.Services
{
    public class CustomerRegisterIntegrationHandler : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public CustomerRegisterIntegrationHandler(IMessageBus bus, IServiceProvider serviceProvider)
        {
            _bus = bus;
            _serviceProvider = serviceProvider;
        }

        private void SetResponder()
        {
            _bus.RespondAsync<UserRegisteredIntegrationEvent, ResponseMessage>(async request =>
                await CreateUser(request));

            _bus.AdvancedBus.Connected += OnConnect;
        }

        private async Task<ResponseMessage> CreateUser(UserRegisteredIntegrationEvent message)
        {
            var userCommand = new CustomerRegisterCommand(message.Id, message.Name, message.Email, message.Cpf);

            ValidationResult result;

            using(var scope = _serviceProvider.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
                result = await mediator.SendCommand(userCommand);
            }

            return new ResponseMessage(result);
        }

        private void OnConnect(object sender, EventArgs e) => SetResponder();

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetResponder();
            return Task.CompletedTask;
        }
    }
}
