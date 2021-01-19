using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.API.Application.Events
{
    public class CustomerEventHandler : INotificationHandler<CustomerRegisteredEvent>
    {
        public Task Handle(CustomerRegisteredEvent notification, CancellationToken cancellationToken)
        {
            // Ex. disparar e-mail de boas vindas.

            return Task.CompletedTask;
        }
    }
}
