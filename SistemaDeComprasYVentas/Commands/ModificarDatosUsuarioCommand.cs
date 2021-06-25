using SistemaDeComprasYVentas.ApiRequests;
using SistemaDeComprasYVentas.Enumerations;
using SistemaDeComprasYVentas.Models;
using SistemaDeComprasYVentas.Session;
using SistemaDeComprasYVentas.ViewModels;
using SistemaDeComprasYVentas.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SistemaDeComprasYVentas.Commands
{
	public class ModificarDatosUsuarioCommand : CommandBase
	{
		private UsuarioRequests requests;
		private ICommand NavigatePerfilCommand { get; }

		public string nombres { get; set; }
		public string apellidos { get; set; }
		public string correo { get; set; }
		public string usuario { get; set; }
		public string telefono { get; set; }
		public SecureString contrasena { get; set; }
		public SecureString confirmarContrasena { get; set; }

		public ModificarDatosUsuarioCommand()
		{
			requests = new UsuarioRequests();
			NavigatePerfilCommand = new NavigateCommand< PerfilViewModel >( 
									NavigationServiceCreator.GetInstance().CreatePerfilNavigationService() );
		}

		public override void Execute( object parameter )
		{
			requests.ActualizarUsuarioInformation( LoginSession.GetInstance().ClaveUsuario, LoginSession.GetInstance().AccessToken, 
												   GetUsuario() ).ContinueWith( Task =>
			{
				if( Task.Exception == null )
				{
					LoginSession.GetInstance().Usuario = Task.Result;
					NavigatePerfilCommand.Execute( this );
				}
			} );
		}

		private Usuario GetUsuario()
		{
			return new Usuario( LoginSession.GetInstance().ClaveUsuario, nombres, apellidos, correo, telefono, 
								usuario, convertToUNSecureString( contrasena ), LoginSession.GetInstance().Usuario.calificacion, TipoUsuario.vendedor );
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
