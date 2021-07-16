using System;
using System.Collections.Generic;
using PoC_EventSourcing.Domain.Interfaces;

namespace PoC_EventSourcing.Domain
{
	public class AggregateRootFactory<TAggregateRoot>
	  where TAggregateRoot: AggregateRoot
	{
		public TAggregateRoot Create(Guid aggregateId, IEnumerable<IDomainEvent> domainEvents)
		{
			var aggregateRoot = Activator.CreateInstance(typeof(TAggregateRoot), aggregateId, domainEvents);
			return (TAggregateRoot) aggregateRoot;
		}
	}
}
