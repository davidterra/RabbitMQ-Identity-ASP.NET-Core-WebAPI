using Common.Core.DomainObjects;
using System;

namespace Customer.API.Models
{
    public class Customer : EntityBase, IAggregateRoot
    {

        public string Name { get; private set; }
        public Email Email { get; private set; }
        public Cpf Cpf { get; private set; }
        public bool IsInactive { get; private set; }

        // EF
        protected Customer() { }

        public Customer(Guid id, string name, string email, string cpf)
        {
            Id = id;
            Name = name;
            Email = new Email(email);
            Cpf = new Cpf(cpf);
            IsInactive = false;
        }

        public void ChangeEmail(string email) => Email = new Email(email);
        public void SetInactive() => IsInactive = true;
    }
}
