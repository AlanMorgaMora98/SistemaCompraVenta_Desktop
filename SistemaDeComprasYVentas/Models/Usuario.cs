
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.Models
{
	class Usuario
	{
        private int claveUsuario;
        private string nombres;
        private string apellidos;
        private string correoElectronico;
        private string nombreUsuario;
        private string contrasena;
        private TipoUsuario tipoUsuario;
        private string telefono;
        private float calificacion;

        public Usuario()
        {
            claveUsuario = 0;
            nombres = "";
            apellidos = "";
            correoElectronico = "";
            telefono = "";
            nombreUsuario = "";
            contrasena = "";
            calificacion = 0.0f;
            tipoUsuario = null;
        }

        public Usuario( Usuario original )
        {
            claveUsuario = original.claveUsuario;
            nombres = original.nombres;
            apellidos = original.apellidos;
            correoElectronico = original.correoElectronico;
            telefono = original.telefono;
            nombreUsuario = original.nombreUsuario;
            contrasena = original.contrasena;
            calificacion = original.calificacion;
            tipoUsuario = original.tipoUsuario;
        }

        public Usuario( int claveUsuarioIn, string nombresIn, string apellidosIn, string correoIn, string telefonoIn,
                        string usuarioIn, string contrasenaIn, float calificacionIn, TipoUsuario tipoIn )
        {
            claveUsuario = claveUsuarioIn;
            nombres = nombresIn;
            apellidos = apellidosIn;
            correoElectronico = correoIn;
            telefono = telefonoIn;
            nombreUsuario = usuarioIn;
            contrasena = contrasenaIn;
            calificacion = calificacionIn;
            tipoUsuario = tipoIn;
        }
    }
}
