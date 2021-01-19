using Common.Core.Messages;
using Common.Core.Messages.Integration;
using Customer.API.Repository;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.API.Application.Commands
{
    public class CustomerCommandHandler : CommandHandler, IRequestHandler<CustomerRegisterCommand, ValidationResult>
    {

        private readonly ICustomerRepository _customerRepository;

        public CustomerCommandHandler(ICustomerRepository customerRepository) => _customerRepository = customerRepository;

        public async Task<ValidationResult> Handle(CustomerRegisterCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var customer = new Models.Customer(message.Id, message.Name, message.Email, message.Cpf);

            var customerExists = await _customerRepository.GetByCpfAsync(customer.Cpf.Value);

            if (customerExists != null)
            {
                this.AddError("Este CPF já está em uso.");
                return this.ValidationResult;
            }

            _customerRepository.Add(customer);

            customer.AddEvent(new UserRegisteredIntegrationEvent(message.Id, message.Name, message.Email, message.Cpf));

            return await this.SaveChangesAsync(_customerRepository.UnitOfWork);

        }
    }
}
