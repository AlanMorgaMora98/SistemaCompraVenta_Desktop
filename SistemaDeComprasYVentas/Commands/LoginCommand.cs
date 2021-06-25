using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using SistemaDeComprasYVentas.ApiRequests;
using SistemaDeComprasYVentas.Models;
using SistemaDeComprasYVentas.Session;

namespace SistemaDeComprasYVentas.Commands
{
	public class LoginCommand : CommandBase
	{
		private LoginRequests requests;
		public string Usuario { get; set; }
		public SecureString Contrasena { get; set; }

		public LoginCommand()
		{
			requests = new LoginRequests();
		}

		public override void Execute( object parameter )
		{
			requests.RealizarLogin( Usuario, Contrasena.ToString() ).ContinueWith( Task => 
			{
				if( Task.Exception == null )
				{
					LoginResponseData response = Task.Result;
					LoginSession.GetInstance().Login( response.Clave_Usuario, response.Access_Token );
				}
			} );
		}
	}
}
