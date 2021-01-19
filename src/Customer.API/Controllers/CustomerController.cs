using Customer.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Core.Controllers;
using WebAPI.Core.Identity;

namespace Customer.API.Controllers.Admin
{
    [Authorize]
    [Route("api/[controller]")]
    public class CustomerController : MainController
    {
        private readonly IAspNetUser _user;
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(IAspNetUser user, 
            ICustomerRepository customerRepository)
        {
            _user = user;
            _customerRepository = customerRepository;
        }

        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var customer = await _customerRepository.GetByIdAsync(_user.GetUserId());

            return CustomResponse(customer);
        }
    }
}
