using SistemaDeComprasYVentas.ApiRequests;
using SistemaDeComprasYVentas.Enumerations;
using SistemaDeComprasYVentas.Models;
using SistemaDeComprasYVentas.Utilities;
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
		private StringValidator validator;
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
			validator = new StringValidator();
		}

		public override void Execute( object parameter )
		{
			if( validator.IsUsuarioDataValid( CreateUsuario(), convertToUNSecureString( ConfirmarContrasena ) ) )
			{
				requests.RegistrarUsuario( CreateUsuario() ).ContinueWith( Task =>
				{
					if( Task.Exception == null )
					{
						Usuario response = Task.Result;
					}
				} );
			}
		}

		public Usuario CreateUsuario()
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