using System;
using PoC_EventSourcing.Application.Interfaces;
using PoC_EventSourcing.Domain;

namespace PoC_EventSourcing.Application
{
	public class AggregateRepository<TAggregateRoot> : IAggregateRepository<TAggregateRoot>
		where TAggregateRoot : AggregateRoot
	{

		private readonly IEventStore eventStore;
		private readonly AggregateRootFactory<TAggregateRoot> aggregateRootFactory;

		public AggregateRepository(IEventStore eventStore, AggregateRootFactory<TAggregateRoot> aggregateRootFactory)
		{
			this.eventStore = eventStore;
			this.aggregateRootFactory = aggregateRootFactory;
		}


		public TAggregateRoot Get(Guid aggregateId)
		{
			var domainEvents = eventStore.GetEvents(aggregateId.ToString());
			var aggregateRoot = aggregateRootFactory.Create(aggregateId, domainEvents);
			return aggregateRoot;
		}
	}
}
