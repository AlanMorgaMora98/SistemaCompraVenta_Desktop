using SistemaDeComprasYVentas.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.ViewModels
{
	public class IniciarSesionViewModel : ViewModelBase
	{
		private LoginCommand LoginCommand;
		public string Usuario 
		{
			get { return Usuario; } 
			set 
			{
				Usuario = value;
				LoginCommand.Usuario = Usuario;
			} 
		}
		public SecureString Contrasena 
		{
			private get { return Contrasena; } 
			set
			{
				Contrasena = value;
				LoginCommand.Contrasena = Contrasena;
			}
		}

		public IniciarSesionViewModel()
		{
			LoginCommand = new LoginCommand();
		}
	}
}
