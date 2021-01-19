using Common.Core.Messages;
using System;
using System.Collections.Generic;

namespace Common.Core.DomainObjects
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        private List<Event> _notifications;

        public IReadOnlyCollection<Event> Notifications => _notifications?.AsReadOnly();

        public void AddEvent(Event @event)
        {
            _notifications = _notifications ?? new List<Event>();
            _notifications.Add(@event);
        }

        public void RemoveEvent(Event @event) => _notifications?.Remove(@event);

        public void ClearEvents() => _notifications.Clear();

        public override bool Equals(object obj)
        {
            var compareTo = obj as EntityBase;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(EntityBase obj1, EntityBase obj2)
        {
            if (ReferenceEquals(obj1, null) && ReferenceEquals(obj2, null))
                return true;

            if (ReferenceEquals(obj1, null) || ReferenceEquals(obj2, null))
                return false;

            return obj1.Equals(obj2);
        }

        public static bool operator !=(EntityBase obj1, EntityBase obj2) => !(obj1 == obj2);

        public override int GetHashCode() => (GetType().GetHashCode() * 308) + Id.GetHashCode();

        public override string ToString() => $"{GetType().Name} [Id={Id}]";


    }
}
