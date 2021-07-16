using System.Collections.Generic;

namespace PoC_EventSourcing.Domain.Interfaces
{
	public interface IDomainEventsConsumer
	{
		void Consume(AggregateRoot aggregateRoot, IEnumerable<IDomainEvent> domainEvents);
	}
}
