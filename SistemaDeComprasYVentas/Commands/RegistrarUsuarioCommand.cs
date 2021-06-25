using SistemaDeComprasYVentas.ApiRequests;
using SistemaDeComprasYVentas.Enumerations;
using SistemaDeComprasYVentas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.Commands
{
	public class RegistrarUsuarioCommand : CommandBase
    {
		private UsuarioRequests requests;
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Correo_Electronico { get; set; }
        public string Telefono { get; set; }
        public SecureString Contrasena { private get; set; }
        public SecureString ConfirmarContrasena { private get; set; }

		public RegistrarUsuarioCommand()
		{
			requests = new UsuarioRequests();
		}

		public override void Execute( object parameter )
		{
			requests.RegistrarUsuario( CreateUsuario() ).ContinueWith(Task =>
			{
				if (Task.Exception == null)
				{
					Usuario response = Task.Result;
				}
			} );
		}

		private Usuario CreateUsuario()
		{
			return new Usuario( 0, Nombres, Apellidos, Correo_Electronico, Telefono, Nombre_Usuario,
								convertToUNSecureString( Contrasena ), 0.0f, TipoUsuario.vendedor );
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