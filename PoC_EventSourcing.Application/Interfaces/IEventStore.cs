using System.Collections.Generic;
using PoC_EventSourcing.Domain.Interfaces;

namespace PoC_EventSourcing.Application.Interfaces
{
	public interface IEventStore
	{
		IEnumerable<IDomainEvent> GetEvents(string streamName);
		void PersistEvents(string streamName, IEnumerable<IDomainEvent> domainEvents);
	}
}
