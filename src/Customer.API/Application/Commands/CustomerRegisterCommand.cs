using Common.Core.Messages;
using FluentValidation;
using System;

namespace Customer.API.Application.Commands
{
    public class CustomerRegisterCommand : Command
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }

        public CustomerRegisterCommand(Guid id, string name, string email, string cpf)
        {
            AggregateId = id;
            Id = id;
            Name = name;
            Email = email;
            Cpf = cpf;
        }

        public override bool IsValid()
        {
            ValidationResult = new UserRegisterValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class UserRegisterValidation : AbstractValidator<CustomerRegisterCommand>
        {
            public UserRegisterValidation()
            {
                RuleFor(c => c.Id)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do cliente inválido");

                RuleFor(c => c.Name)
                    .NotEmpty()
                    .WithMessage("O nome do cliente não foi informado");

                RuleFor(c => c.Cpf)
                    .Must(HasCpfValid)
                    .WithMessage("O CPF informado não é válido.");

                RuleFor(c => c.Email)
                    .Must(HasEmailValid)
                    .WithMessage("O e-mail informado não é válido.");
            }

            protected static bool HasCpfValid(string cpf) => Common.Core.DomainObjects.Cpf.Valid(cpf);

            protected static bool HasEmailValid(string email) => Common.Core.DomainObjects.Email.Valid(email);
        }
    }
}
