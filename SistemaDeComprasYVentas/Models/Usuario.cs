
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeComprasYVentas.Enumerations;

namespace SistemaDeComprasYVentas.Models
{
	class Usuario
	{
        public int Clave_Usuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Contrasena { get; set; }
        public string Correo_Electronico { get; set; }
        public string Telefono { get; set; }
        public TipoUsuario Tipo_Usuario { get; set; }
        public float Calificacion { get; set; }

        public Usuario()
        {
            Clave_Usuario = 0;
            Nombres = "";
            Apellidos = "";
            Correo_Electronico = "";
            Telefono = "";
            Nombre_Usuario = "";
            Contrasena = "";
            Calificacion = 0.0f;
            Tipo_Usuario = TipoUsuario.comprador;
        }

        public Usuario( Usuario original )
        {
            Clave_Usuario = original.Clave_Usuario;
            Nombres = original.Nombres;
            Apellidos = original.Apellidos;
            Correo_Electronico = original.Correo_Electronico;
            Telefono = original.Telefono;
            Nombre_Usuario = original.Nombre_Usuario;
            Contrasena = original.Contrasena;
            Calificacion = original.Calificacion;
            Tipo_Usuario = original.Tipo_Usuario;
        }

        public Usuario( int claveUsuarioIn, string NombresIn, string ApellidosIn, string correoIn, string TelefonoIn,
                        string usuarioIn, string ContrasenaIn, float CalificacionIn, TipoUsuario tipoIn )
        {
            Clave_Usuario = claveUsuarioIn;
            Nombres = NombresIn;
            Apellidos = ApellidosIn;
            Correo_Electronico = correoIn;
            Telefono = TelefonoIn;
            Nombre_Usuario = usuarioIn;
            Contrasena = ContrasenaIn;
            Calificacion = CalificacionIn;
            Tipo_Usuario = tipoIn;
        }
    }
}
