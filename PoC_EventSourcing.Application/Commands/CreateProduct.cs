using PoC_EventSourcing.Application.Interfaces;

namespace PoC_EventSourcing.Application.Commands
{
	public class CreateProduct : ICommand
	{
		public string Name { get; set; }
	}
}
