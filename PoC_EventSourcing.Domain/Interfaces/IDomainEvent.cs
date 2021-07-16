using System;

namespace PoC_EventSourcing.Domain.Interfaces
{
    public interface IDomainEvent
    {
      Guid AggregateId { get; }
    }
}
