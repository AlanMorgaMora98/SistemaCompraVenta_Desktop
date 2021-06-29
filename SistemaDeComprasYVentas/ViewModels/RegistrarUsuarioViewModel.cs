using SistemaDeComprasYVentas.Commands;
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
                ( ( RegistrarUsuarioCommand )RegistrarUsuarioCommand ).Nombres = nombres;
			}
        }
        public string Apellidos
        {
            get { return apellidos; }
            set
            {
                apellidos = value;
                ( ( RegistrarUsuarioCommand )RegistrarUsuarioCommand ).Apellidos = apellidos;
            }
        }
        public string Nombre_Usuario
        {
            get { return nombre_usuario; }
            set
            {
                nombre_usuario = value;
                ( ( RegistrarUsuarioCommand )RegistrarUsuarioCommand ).Nombre_Usuario = nombre_usuario;
            }
        }
        public string Correo_Electronico
        {
            get { return correo_electronico; }
            set
            {
                correo_electronico = value;
                ( ( RegistrarUsuarioCommand )RegistrarUsuarioCommand ).Correo_Electronico = correo_electronico;
            }
        }
        public string Telefono
        {
            get { return telefono; }
            set
            {
                telefono = value;
                ( ( RegistrarUsuarioCommand )RegistrarUsuarioCommand ).Telefono = telefono;
            }
        }
        public SecureString Contrasena
        {
            get { return contrasena; }
            set
            {
                contrasena = value;
                ( ( RegistrarUsuarioCommand )RegistrarUsuarioCommand ).Contrasena = contrasena;
            }
        }
        public SecureString ConfirmarContrasena
        {
            get { return confirmarcontrasena; }
            set
            {
                confirmarcontrasena = value;
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
            RegistrarUsuarioCommand = new RegistrarUsuarioCommand();
		}
    }
}
