using System;

namespace PoC_EventSourcing.Application.Interfaces
{
	public interface ICommandHandler<in TCommand>
		where TCommand: class, ICommand
	{
		Guid Handle(TCommand command);
	}
}
