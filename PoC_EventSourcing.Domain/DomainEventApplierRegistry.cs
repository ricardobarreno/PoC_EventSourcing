using System;
using System.Collections.Generic;
using PoC_EventSourcing.Domain.Interfaces;

namespace PoC_EventSourcing.Domain
{
	public  class DomainEventApplierRegistry
	{
		private readonly IDictionary<Type, Action<IDomainEvent>> appliers;

		public void Register<TDomainEvent>(Action<TDomainEvent> applier)
			where TDomainEvent: class, IDomainEvent
		{
			void Applier(IDomainEvent domainEvent) => applier((TDomainEvent) domainEvent);
			appliers.Add(typeof(TDomainEvent), Applier);
		}


		public Action<IDomainEvent> Find(IDomainEvent domainEvent)
		{
			var domainEventType = domainEvent.GetType();
			var isFound = appliers.TryGetValue(domainEventType, out var applier);
			if (!isFound)
			{
				throw new KeyNotFoundException($"Applier not registered for domain event type {domainEventType}");
			}

			return applier;
		}


		public DomainEventApplierRegistry()
		{
			this.appliers = new Dictionary<Type, Action<IDomainEvent>>();
		}

	}
}