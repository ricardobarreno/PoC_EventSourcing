using System;
using System.Collections.Generic;
using System.Linq;
using PoC_EventSourcing.Application.Interfaces;
using PoC_EventSourcing.Domain.Interfaces;

namespace PoC_EventSourcing.Application
{
	public class InMemoryEventStore : IEventStore
	{
		private readonly IDictionary<string, IList<IDomainEvent>> streams;

		public InMemoryEventStore()
		{
			this.streams = new Dictionary<string, IList<IDomainEvent>>();
		}


		public IEnumerable<IDomainEvent> GetEvents(string streamName)
		{
			return this.streams[streamName];
		}

		public void PersistEvents(string streamName, IEnumerable<IDomainEvent> domainEvents)
		{
			var isExisting = this.streams.TryGetValue(streamName, out var storedEvents);
			if (!isExisting)
			{
				this.streams.Add(streamName, domainEvents.ToList());
			}
			else
			{
				var events = storedEvents.ToList();
				events.AddRange(domainEvents);
				this.streams[streamName] = events;
			}
		}
	}
}
