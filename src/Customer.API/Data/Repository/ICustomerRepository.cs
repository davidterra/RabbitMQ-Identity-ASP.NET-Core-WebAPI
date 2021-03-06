﻿using Common.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.API.Repository
{
    using Customer.API.Models;
    using System;

    public interface ICustomerRepository : IRepository<Customer>
    {
        void Add(Customer customer);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetByCpfAsync(string cpf);
        Task<Customer> GetByIdAsync(Guid id);
        
    }
}
