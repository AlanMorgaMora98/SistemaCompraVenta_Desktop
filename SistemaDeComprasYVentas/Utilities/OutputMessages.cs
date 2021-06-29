using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.Utilities
{
	public class OutputMessages
	{
		public string UsuarioInvalidMessage() { return "El usuario no es valido."; }

		public string ContrasenaInvalidMessage() { return "La contraseña no es válida."; }

		public string NombresInvalidosMessage() { return "Los nombres introducidos no son válidos."; }

		public string ApellidosInvalidosMessage() { return "Los apellidos introducidos no son válidos."; }

		public string CorreoInvalidoMessage() { return "El correo introducido no son válido."; }

		public string TelefonoInvalidoMessage() { return "El telefono introducido no son válidos."; }

		public string ContrasenasNoCoincidenMessage() { return "Las contraseñas introducidos no coinciden."; }
	}
}
