using SistemaDeComprasYVentas.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SistemaDeComprasYVentas.Utilities;

namespace SistemaDeComprasYVentas.ViewModels
{
	public class IniciarSesionViewModel : ViewModelBase
	{
		private string usuario;
		private SecureString contrasena;

		public LoginCommand LoginCommand;
		public ICommand NavigateRegistroUsuarioCommand { get; }
		public string Usuario 
		{
			get { return usuario; } 
			set 
			{
				usuario = value;
				LoginCommand.Usuario = usuario;
			} 
		}
		public SecureString Contrasena 
		{
			private get { return contrasena; } 
			set
			{
				contrasena = value;
				LoginCommand.Contrasena = contrasena;
			}
		}

		public IniciarSesionViewModel()
		{
			LoginCommand = new LoginCommand();
			NavigateRegistroUsuarioCommand = new NavigateCommand< RegistrarUsuarioViewModel >( 
											 NavigationServiceCreator.GetInstance().CreateRegistrarUsuarioNavigationService() );
		}
	}
}
