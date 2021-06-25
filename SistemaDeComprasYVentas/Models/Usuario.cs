
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeComprasYVentas.Enumerations;

namespace SistemaDeComprasYVentas.Models
{
	public class Usuario
	{
        public int clave_usuario { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string nombre_usuario { get; set; }
        public string contrasena { get; set; }
        public string correo_electronico { get; set; }
        public string telefono { get; set; }
        public TipoUsuario tipo_usuario { get; set; }
        public float calificacion { get; set; }

        public Usuario()
        {
            clave_usuario = 0;
            nombres = "";
            apellidos = "";
            correo_electronico = "";
            telefono = "";
            nombre_usuario = "";
            contrasena = "";
            calificacion = 0.0f;
            tipo_usuario = TipoUsuario.comprador;
        }

        public Usuario( Usuario original )
        {
            clave_usuario = original.clave_usuario;
            nombres = original.nombres;
            apellidos = original.apellidos;
            correo_electronico = original.correo_electronico;
            telefono = original.telefono;
            nombre_usuario = original.nombre_usuario;
            contrasena = original.contrasena;
            calificacion = original.calificacion;
            tipo_usuario = original.tipo_usuario;
        }

        public Usuario( int claveUsuarioIn, string NombresIn, string ApellidosIn, string correoIn, string TelefonoIn,
                        string usuarioIn, string ContrasenaIn, float CalificacionIn, TipoUsuario tipoIn )
        {
            clave_usuario = claveUsuarioIn;
            nombres = NombresIn;
            apellidos = ApellidosIn;
            correo_electronico = correoIn;
            telefono = TelefonoIn;
            nombre_usuario = usuarioIn;
            contrasena = ContrasenaIn;
            calificacion = CalificacionIn;
            tipo_usuario = tipoIn;
        }
    }
}
