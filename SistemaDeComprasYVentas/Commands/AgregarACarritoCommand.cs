using SistemaDeComprasYVentas.ApiRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.Commands
{
	public class AgregarACarritoCommand : CommandBase
	{
		private PublicacionesRequests requests;

		public AgregarACarritoCommand()
		{
			requests = new PublicacionesRequests();
		}

		public override void Execute( object parameter )
		{

		}
	}
}
