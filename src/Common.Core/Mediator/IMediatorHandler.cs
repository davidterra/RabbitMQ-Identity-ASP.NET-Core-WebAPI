﻿using Common.Core.Messages;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace Common.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T @event) where T : Event;
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
    }
}
