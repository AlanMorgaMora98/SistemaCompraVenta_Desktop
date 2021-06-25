using SistemaDeComprasYVentas.ApiRequests;
using SistemaDeComprasYVentas.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.Commands
{
	public class EliminarCuentaCommand : CommandBase
	{
		private UsuarioRequests requests;

		public EliminarCuentaCommand()
		{
			requests = new UsuarioRequests();
		}

		public override void Execute( object parameter )
		{
			requests.DeleteUsuario( LoginSession.GetInstance().ClaveUsuario, LoginSession.GetInstance().AccessToken ).ContinueWith( Task => 
			{
				if( Task.Exception != null )
				{

				}
			} );
		}
	}
}
