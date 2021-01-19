using Common.Core.Data;
using Customer.API.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.API.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public CustomerRepository(CustomerDbContext context) => _context = context;

        public void Add(Models.Customer customer) => _context.Customers.Add(customer);

        public async Task<IEnumerable<Models.Customer>> GetAllAsync() => await _context.Customers.AsNoTracking().ToListAsync();

        public Task<Models.Customer> GetByCpfAsync(string cpf) => _context.Customers.FirstOrDefaultAsync(c => c.Cpf.Value == cpf);

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
