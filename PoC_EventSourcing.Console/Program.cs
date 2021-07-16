using System;
using PoC_EventSourcing.Application;
using PoC_EventSourcing.Application.CommandHandlers;
using PoC_EventSourcing.Application.Commands;
using PoC_EventSourcing.Application.Interfaces;
using PoC_EventSourcing.Domain;
using PoC_EventSourcing.Domain.Interfaces;
using PoC_EventSourcing.Domain.ProductAggregate;

namespace PoC_EventSourcing.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			IEventStore eventStore = new InMemoryEventStore();
			AggregateRootFactory<Product> productFactory = new AggregateRootFactory<Product>();
			IAggregateRepository<Product> productRepository =
					new AggregateRepository<Product>(eventStore, productFactory);
			IDomainEventsConsumer domainEventsConsumer = new PersisterDomainEventsConsumer(eventStore);
			ICommandHandler<CreateProduct> createProductHandler = new CreateProductHandler(domainEventsConsumer);

			var createProduct =
					new CreateProduct
					{
							Name = "Albondigas"
					};
			var aggregateId = createProductHandler.Handle(createProduct);

			System.Console.WriteLine("Press ENTER to end");
			System.Console.ReadLine();
		}
	}
}
