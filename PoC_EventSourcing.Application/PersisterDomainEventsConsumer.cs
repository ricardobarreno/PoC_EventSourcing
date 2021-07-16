using System.Collections.Generic;
using PoC_EventSourcing.Application.Interfaces;
using PoC_EventSourcing.Domain;
using PoC_EventSourcing.Domain.Interfaces;

namespace PoC_EventSourcing.Application
{
	public class PersisterDomainEventsConsumer : IDomainEventsConsumer
	{
		private readonly IEventStore eventStore;

		public PersisterDomainEventsConsumer(IEventStore eventStore)
		{
			this.eventStore = eventStore;
		}

		public void Consume(AggregateRoot aggregateRoot, IEnumerable<IDomainEvent> domainEvents)
		{
			eventStore.PersistEvents(aggregateRoot.Id.ToString(), domainEvents);
		}
	}
}
