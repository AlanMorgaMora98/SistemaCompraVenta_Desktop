using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SistemaDeComprasYVentas.Commands;

namespace SistemaDeComprasYVentas.ViewModels
{
    public class ModificarDatosPersonalesViewModel : ViewModelBase
    {
		public ICommand ModificarDatosCommand { get; }

		private string nombres;
		private string apellidos;
		private string correo;
		private string usuario;
		private string telefono;
		private SecureString contrasena;
		private SecureString confirmarContrasena;
		public string Nombres
		{
			get { return nombres; }
			set
			{
				nombres = value;
				( ( ModificarDatosUsuarioCommand )ModificarDatosCommand ).nombres = nombres;
			}
		}
		public string Apellidos
		{
			get { return apellidos; }
			set
			{
				apellidos = value;
				( ( ModificarDatosUsuarioCommand )ModificarDatosCommand ).apellidos = apellidos;
			}
		}
		public string Correo
		{
			get { return correo; }
			set
			{
				correo = value;
				( ( ModificarDatosUsuarioCommand )ModificarDatosCommand ).correo = correo;
			}
		}
		public string Usuario
		{
			get { return usuario; }
			set
			{
				usuario = value;
				( ( ModificarDatosUsuarioCommand )ModificarDatosCommand ).usuario = usuario;
			}
		}
		public string Telefono
		{
			get { return telefono; }
			set
			{
				telefono = value;
				( ( ModificarDatosUsuarioCommand )ModificarDatosCommand ).telefono = telefono;
			}
		}
		public SecureString Contrasena
		{
			get { return contrasena; }
			set
			{
				contrasena = value;
				( ( ModificarDatosUsuarioCommand )ModificarDatosCommand ).contrasena = contrasena;
			}
		}
		public SecureString ConfirmarContrasena
		{
			get { return confirmarContrasena; }
			set
			{
				confirmarContrasena = value;
				( ( ModificarDatosUsuarioCommand )ModificarDatosCommand ).confirmarContrasena = confirmarContrasena;
			}
		}

		public ModificarDatosPersonalesViewModel()
		{
			ModificarDatosCommand = new ModificarDatosUsuarioCommand();
		}
	}
}
