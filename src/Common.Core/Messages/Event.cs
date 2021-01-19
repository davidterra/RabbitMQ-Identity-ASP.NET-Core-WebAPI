using MediatR;
using System;

namespace Common.Core.Messages
{
    public abstract class Event : Message, INotification
    {
        public DateTime Timestamp { get; private set; } = DateTime.Now;
    }
}
