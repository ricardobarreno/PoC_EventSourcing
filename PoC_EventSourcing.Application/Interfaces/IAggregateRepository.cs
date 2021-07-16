using System;
using PoC_EventSourcing.Domain;

namespace PoC_EventSourcing.Application
{
    public interface IAggregateRepository<out TAggregateRoot>
      where TAggregateRoot: AggregateRoot
    {
      TAggregateRoot Get(Guid aggregateId);
    }
}
