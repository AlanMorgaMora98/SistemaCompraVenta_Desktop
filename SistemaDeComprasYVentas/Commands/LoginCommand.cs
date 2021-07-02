using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SistemaDeComprasYVentas.ApiRequests;
using SistemaDeComprasYVentas.Models;
using SistemaDeComprasYVentas.Session;
using SistemaDeComprasYVentas.Utilities;
using SistemaDeComprasYVentas.ViewModels;

namespace SistemaDeComprasYVentas.Commands
{
	public class LoginCommand : CommandBase
	{
		private LoginRequests requests;
		private StringValidator validator;
		private ICommand NavigateToHomeCommand { get; }

		public string username { get; set; }
		public SecureString password { get; set; }

		public LoginCommand()
		{
			requests = new LoginRequests();
			validator = new StringValidator();
			NavigateToHomeCommand = new NavigateCommand< BuscarPublicacionesViewModel >( 
										NavigationServiceCreator.GetInstance().CreateBuscarNavigationService() );
		}

		public override void Execute( object parameter )
		{
			if( validator.IsLoginRequestDataValid( new LoginRequestData( username, convertToUNSecureString( password ) ) ) )
			{
				requests.RealizarLogin( username, convertToUNSecureString( password ) ).ContinueWith( Task =>
				{
					if( Task.Exception == null )
					{
						LoginResponseData response = Task.Result;
						if( response != null )
						{
							LoginSession.GetInstance().Login( response.clave_usuario, response.access_token );
							NavigateToHomeCommand.Execute( this );
						}
					}
				} );
			}
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
