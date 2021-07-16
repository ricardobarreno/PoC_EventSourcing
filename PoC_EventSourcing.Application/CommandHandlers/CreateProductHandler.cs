using System;
using PoC_EventSourcing.Application.Commands;
using PoC_EventSourcing.Application.Interfaces;
using PoC_EventSourcing.Domain.Interfaces;
using PoC_EventSourcing.Domain.ProductAggregate;

namespace PoC_EventSourcing.Application.CommandHandlers
{
  public class CreateProductHandler : ICommandHandler<CreateProduct>
  {
		private readonly IDomainEventsConsumer domainEventsConsumer;

		public CreateProductHandler(IDomainEventsConsumer domainEventsConsumer)
		{
		this.domainEventsConsumer = domainEventsConsumer;
		}

		public Guid Handle(CreateProduct command)
		{
			var newGuid = Guid.NewGuid();
			var product = new Product(newGuid, command.Name);
			product.ConsumeDomainEventChanges(domainEventsConsumer);
			return newGuid;
		}
	}
}
