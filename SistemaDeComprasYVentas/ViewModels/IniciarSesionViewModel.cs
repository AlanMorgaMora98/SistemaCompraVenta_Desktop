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
		private StringValidator validator;
		private OutputMessages messages;
		private string usuario;
		private SecureString contrasena;
		private string errorText;

		public ICommand LoginCommand { get; set; }
		public ICommand NavigateRegistroUsuarioCommand { get; }
		public string Usuario 
		{
			get { return usuario; } 
			set 
			{
				usuario = value;
				IsUsuarioValid( usuario );
				( ( LoginCommand )LoginCommand ).username = usuario;
			} 
		}

		public SecureString Contrasena 
		{
			private get { return contrasena; } 
			set
			{
				contrasena = value;
				IsContrasenaValid( ( ( LoginCommand )LoginCommand ).convertToUNSecureString( contrasena ) );
				( ( LoginCommand )LoginCommand ).password = contrasena;
			}
		}

		public string ErrorText
		{
			get { return errorText; }
			set 
			{
				errorText = value;
				OnPropertyChanged( nameof( ErrorText ) );
			}
		}

		public IniciarSesionViewModel()
		{
			validator = new StringValidator();
			messages = new OutputMessages();
			LoginCommand = new LoginCommand();
			NavigateRegistroUsuarioCommand = new NavigateCommand< RegistrarUsuarioViewModel >( 
											 NavigationServiceCreator.GetInstance().CreateRegistrarUsuarioNavigationService() );
		}

		private void IsUsuarioValid( string usuario )
		{
			ErrorText = "";
			if( !string.IsNullOrEmpty( usuario ) && !validator.IsUsernameValid( usuario ) )
			{
				SetErrorMessage( messages.UsuarioInvalidMessage() );
			}
		}

		private void IsContrasenaValid( string contrasena )
		{
			ErrorText = "";
			if( !string.IsNullOrEmpty( contrasena ) && !validator.IsPasswordValid( contrasena ) )
			{
				SetErrorMessage( messages.ContrasenaInvalidMessage() );
			}
		}

		private void SetErrorMessage( string errorText )
		{
			ErrorText = errorText;
		}
	}
}
