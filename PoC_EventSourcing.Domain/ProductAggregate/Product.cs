using System;
using System.Collections.Generic;
using PoC_EventSourcing.Domain.Interfaces;
using PoC_EventSourcing.Domain.ProductAggregate.Events;

namespace PoC_EventSourcing.Domain.ProductAggregate
{
	public class Product : AggregateRoot
	{
		private string name;

		public Product(Guid id, string name)
			: base(id)
		{
			var productCreated = new ProductCreated(id, name);
			ApplyDomainEvent(productCreated);
		}

		public Product(Guid id, IEnumerable<IDomainEvent> domainEvents)
			: base(id, domainEvents)
		{
		}


		public void UpdatePrice(string currency, decimal originalAmmount, decimal actualAmmount)
		{
			var priceUpdated = new PriceUpdated(Id, currency, originalAmmount, actualAmmount);
			ApplyDomainEvent(priceUpdated);
		}

		protected override void RegisterDomainEventAppliers()
		{
			RegisterDomainEventApplier<ProductCreated>(Applier);
			RegisterDomainEventApplier<PriceUpdated>(Applier);
		}

		private void Applier(PriceUpdated obj)
		{
			throw new NotImplementedException();
		}

		private void Applier(ProductCreated domainEvent)
		{
			this.name = domainEvent.Name;
		}
	}
}
