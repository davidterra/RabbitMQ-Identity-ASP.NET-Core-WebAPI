using Common.Core.Messages;
using FluentValidation.Results;
using MediatR;
using System.Threading.Tasks;

namespace Common.Core.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator) => _mediator = mediator;

        public Task PublishEvent<T>(T @event) where T : Event => _mediator.Publish(@event);

        public Task<ValidationResult> SendCommand<T>(T command) where T : Command => _mediator.Send(command);
    }
}
