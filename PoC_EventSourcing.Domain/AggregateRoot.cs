using System;
using System.Collections.Generic;
using System.Linq;
using PoC_EventSourcing.Domain.Interfaces;

namespace PoC_EventSourcing.Domain
{
	public abstract class AggregateRoot
	{
		private readonly DomainEventApplierRegistry domainEventApplierRegistry;
		private readonly IList<IDomainEvent> uncommitedDomainEvents;
		public Guid Id { get; protected set; }
		public int Version { get; private set; }

		protected AggregateRoot(Guid id)
		{
			this.Id = id;

			domainEventApplierRegistry = new DomainEventApplierRegistry();
			uncommitedDomainEvents = new List<IDomainEvent>();

			RegisterDomainEventAppliers();
		}


		protected AggregateRoot(Guid id, IEnumerable<IDomainEvent> domainEvents)
			: this(id)
		{
			foreach (var domainEvent in domainEvents)
			{
				ApplyDomainEvent(domainEvent, true);
			}
		}

		protected void ApplyDomainEvent(IDomainEvent domainEvent, bool isPrevious = false)
		{
			var applier = domainEventApplierRegistry.Find(domainEvent);
			applier.Invoke(domainEvent);
			this.Version ++;

			if (isPrevious)
			{
				return;
			}

			uncommitedDomainEvents.Add(domainEvent);
		}

		protected abstract void RegisterDomainEventAppliers();

		protected void RegisterDomainEventApplier<TDomainEvent>(Action<TDomainEvent> applier)
			where TDomainEvent: class, IDomainEvent
		{
			domainEventApplierRegistry.Register<TDomainEvent>(applier);
		}


		public void ConsumeDomainEventChanges(IDomainEventsConsumer domainEventsConsumer)
		{
			if (!uncommitedDomainEvents.Any())
			{
				return;
			}

			domainEventsConsumer.Consume(this, uncommitedDomainEvents);
			uncommitedDomainEvents.Clear();
		}
  }
}
