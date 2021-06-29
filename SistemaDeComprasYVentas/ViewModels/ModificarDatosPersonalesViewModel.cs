using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SistemaDeComprasYVentas.Commands;
using SistemaDeComprasYVentas.Utilities;

namespace SistemaDeComprasYVentas.ViewModels
{
    public class ModificarDatosPersonalesViewModel : ViewModelBase
    {
		private StringValidator validator;
		private OutputMessages messages;
		public ICommand ModificarDatosCommand { get; }

		private string nombres;
		private string apellidos;
		private string correo;
		private string usuario;
		private string telefono;
		private SecureString contrasena;
		private SecureString confirmarContrasena;
		private string errorText;
		public string Nombres
		{
			get { return nombres; }
			set
			{
				nombres = value;
				AreNombresValid( nombres );
				( ( ModificarDatosUsuarioCommand )ModificarDatosCommand ).nombres = nombres;
			}
		}
		public string Apellidos
		{
			get { return apellidos; }
			set
			{
				apellidos = value;
				AreApellidosValid( apellidos );
				( ( ModificarDatosUsuarioCommand )ModificarDatosCommand ).apellidos = apellidos;
			}
		}
		public string Correo
		{
			get { return correo; }
			set
			{
				correo = value;
				IsCorreoValid( correo );
				( ( ModificarDatosUsuarioCommand )ModificarDatosCommand ).correo = correo;
			}
		}
		public string Usuario
		{
			get { return usuario; }
			set
			{
				usuario = value;
				IsUsuarioValid( usuario );
				( ( ModificarDatosUsuarioCommand )ModificarDatosCommand ).usuario = usuario;
			}
		}
		public string Telefono
		{
			get { return telefono; }
			set
			{
				telefono = value;
				IsTelefonoValid( telefono );
				( ( ModificarDatosUsuarioCommand )ModificarDatosCommand ).telefono = telefono;
			}
		}
		public SecureString Contrasena
		{
			get { return contrasena; }
			set
			{
				contrasena = value;
				IsContrasenaValid( ( ( ModificarDatosUsuarioCommand )ModificarDatosCommand ).convertToUNSecureString( contrasena ) );
				( ( ModificarDatosUsuarioCommand )ModificarDatosCommand ).contrasena = contrasena;
			}
		}
		public SecureString ConfirmarContrasena
		{
			get { return confirmarContrasena; }
			set
			{
				confirmarContrasena = value;
				DoContrasenasMatch( ( ( ModificarDatosUsuarioCommand )ModificarDatosCommand ).convertToUNSecureString( Contrasena ),
								    ( ( ModificarDatosUsuarioCommand )ModificarDatosCommand ).convertToUNSecureString( confirmarContrasena ) );
				( ( ModificarDatosUsuarioCommand )ModificarDatosCommand ).confirmarContrasena = confirmarContrasena;
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

		public ModificarDatosPersonalesViewModel()
		{
			validator = new StringValidator();
			messages = new OutputMessages();
			ModificarDatosCommand = new ModificarDatosUsuarioCommand();
		}

		private void AreNombresValid( string nombres )
		{
			ErrorText = "";
			if( !string.IsNullOrEmpty( nombres ) && !validator.AreNamesValid( nombres ) )
			{
				SetErrorMessage( messages.NombresInvalidosMessage() );
			}
		}

		private void AreApellidosValid( string apellidos )
		{
			ErrorText = "";
			if( !string.IsNullOrEmpty( apellidos ) && !validator.AreLastNamesValid( apellidos ) )
			{
				SetErrorMessage( messages.ApellidosInvalidosMessage() );
			}
		}

		private void IsCorreoValid( string correo )
		{
			ErrorText = "";
			if( !string.IsNullOrEmpty( correo ) && !validator.IsEmailValid( correo ) )
			{
				SetErrorMessage( messages.CorreoInvalidoMessage() );
			}
		}

		private void IsTelefonoValid( string telefono )
		{
			ErrorText = "";
			if( !string.IsNullOrEmpty( telefono ) && !validator.IsTelephoneValid( telefono ) )
			{
				SetErrorMessage( messages.TelefonoInvalidoMessage() );
			}
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

		private void DoContrasenasMatch( string contrasena, string confirmarContrasena )
		{
			ErrorText = "";
			if( !string.IsNullOrEmpty( contrasena ) && !string.IsNullOrEmpty( confirmarContrasena ) &&
				!validator.DoPasswordsMatch( contrasena, confirmarContrasena ) )
			{
				SetErrorMessage( messages.ContrasenasNoCoincidenMessage() );
			}
		}

		private void SetErrorMessage( string errorText )
		{
			ErrorText = errorText;
		}
	}
}
