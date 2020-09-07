using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Domain.Abstraction
{
    public class AggregateRootBase : IAggregateRoot
    {
         public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.Values;

        private readonly Dictionary<string, IDomainEvent> _domainEvents = new Dictionary<string, IDomainEvent>();

        public void AddEvent(IDomainEvent @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));

            var eventTypeName = @event.GetType().FullName;

            var shouldNotBeDuplicated = @event is INonDuplicatableDomainEvent;
            if (shouldNotBeDuplicated && _domainEvents.ContainsKey(eventTypeName))
                _domainEvents.Remove(eventTypeName);

            _domainEvents.Add(eventTypeName, @event);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }

}
