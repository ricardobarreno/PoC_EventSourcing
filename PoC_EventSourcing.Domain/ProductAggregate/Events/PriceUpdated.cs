
using System;
using PoC_EventSourcing.Domain.Interfaces;

namespace PoC_EventSourcing.Domain.ProductAggregate.Events
{
	public class PriceUpdated : IDomainEvent
	{
		public Guid AggregateId { get; }
		public string Currency { get; }
		public decimal OriginalAmmount { get; }
		public decimal ActualAmmount { get; }

		public PriceUpdated(
			Guid aggregateId,
			string currency,
			decimal originalAmmount,
			decimal actualAmmount)
		{
			this.AggregateId = aggregateId;
			this.Currency = currency;
			this.OriginalAmmount = originalAmmount;
			this.ActualAmmount = actualAmmount;
		}
	}
}
