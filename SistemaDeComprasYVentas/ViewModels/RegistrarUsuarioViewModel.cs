using SistemaDeComprasYVentas.Commands;
using SistemaDeComprasYVentas.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SistemaDeComprasYVentas.ViewModels
{
    public class RegistrarUsuarioViewModel : ViewModelBase
    {
        private StringValidator validator;
        private OutputMessages messages;
        public ICommand RegistrarUsuarioCommand { get; set; }

        private string nombres;
        private string apellidos;
        private string nombre_usuario;
        private string correo_electronico;
        private string telefono;
        private SecureString contrasena;
        private SecureString confirmarcontrasena;
        private string errorText;

        public string Nombres 
        {
            get { return nombres; } 
            set
			{
                nombres = value;
                AreNombresValid( nombres );
                ( ( RegistrarUsuarioCommand )RegistrarUsuarioCommand ).Nombres = nombres;
			}
        }
        public string Apellidos
        {
            get { return apellidos; }
            set
            {
                apellidos = value;
                AreApellidosValid( apellidos );
                ( ( RegistrarUsuarioCommand )RegistrarUsuarioCommand ).Apellidos = apellidos;
            }
        }
        public string Nombre_Usuario
        {
            get { return nombre_usuario; }
            set
            {
                nombre_usuario = value;
                IsUsuarioValid( nombre_usuario );
                ( ( RegistrarUsuarioCommand )RegistrarUsuarioCommand ).Nombre_Usuario = nombre_usuario;
            }
        }
        public string Correo_Electronico
        {
            get { return correo_electronico; }
            set
            {
                correo_electronico = value;
                IsCorreoValid( correo_electronico );
                ( ( RegistrarUsuarioCommand )RegistrarUsuarioCommand ).Correo_Electronico = correo_electronico;
            }
        }
        public string Telefono
        {
            get { return telefono; }
            set
            {
                telefono = value;
                IsTelefonoValid( telefono );
                ( ( RegistrarUsuarioCommand )RegistrarUsuarioCommand ).Telefono = telefono;
            }
        }
        public SecureString Contrasena
        {
            get { return contrasena; }
            set
            {
                contrasena = value;
                IsContrasenaValid( ( ( RegistrarUsuarioCommand )RegistrarUsuarioCommand ).convertToUNSecureString( contrasena ) );
                ( ( RegistrarUsuarioCommand )RegistrarUsuarioCommand ).Contrasena = contrasena;
            }
        }
        public SecureString ConfirmarContrasena
        {
            get { return confirmarcontrasena; }
            set
            {
                confirmarcontrasena = value;
                DoContrasenasMatch( ( ( RegistrarUsuarioCommand )RegistrarUsuarioCommand ).convertToUNSecureString( Contrasena ),
                                    ( ( RegistrarUsuarioCommand )RegistrarUsuarioCommand ).convertToUNSecureString( confirmarcontrasena ) );
                ( ( RegistrarUsuarioCommand )RegistrarUsuarioCommand ).ConfirmarContrasena = confirmarcontrasena;
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

        public RegistrarUsuarioViewModel()
		{
            validator = new StringValidator();
            messages = new OutputMessages();
            RegistrarUsuarioCommand = new RegistrarUsuarioCommand();
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
