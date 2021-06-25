using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
		public string username { get; set; }
		public SecureString password { get; set; }

		public LoginCommand()
		{
			requests = new LoginRequests();
		}

		public override void Execute( object parameter )
		{
			requests.RealizarLogin( username, convertToUNSecureString( password) ).ContinueWith( Task => 
			{
				if( Task.Exception == null )
				{
					LoginResponseData response = Task.Result;
					LoginSession.GetInstance().Login( response.clave_usuario, response.access_token );
				}
			} );
		}

		public string convertToUNSecureString( SecureString secstrPassword )
		{
			IntPtr unmanagedString = IntPtr.Zero;
			try
			{
				unmanagedString = Marshal.SecureStringToGlobalAllocUnicode( secstrPassword );
				return Marshal.PtrToStringUni( unmanagedString );
			}
			finally
			{
				Marshal.ZeroFreeGlobalAllocUnicode( unmanagedString );
			}
		}
	}
}
