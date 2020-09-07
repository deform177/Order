using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Domain.Abstraction
{
    public interface IAggregateRoot
    {
         IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

         void AddEvent(IDomainEvent @event);
         void ClearDomainEvents();
    }
}
