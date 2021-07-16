using System;
using PoC_EventSourcing.Domain.Interfaces;

namespace PoC_EventSourcing.Domain.ProductAggregate.Events
{
	public class ProductCreated : IDomainEvent
	{
		public Guid AggregateId { get; }
		public string Name { get; }

		public ProductCreated(Guid aggregateId, string name)
		{
			this.AggregateId = aggregateId;
			this.Name = name;
		}
	}
}
