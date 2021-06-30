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

		public string CorreoInvalidoMessage() { return "El correo introducido no es válido."; }

		public string TelefonoInvalidoMessage() { return "El telefono introducido no es válidos."; }

		public string ContrasenasNoCoincidenMessage() { return "Las contraseñas introducidas no coinciden."; }

		public string EvaluacionNoEsValida() { return "La evaluación no es válida."; }

		public string CalificacionNoEsValida() { return "La calificación no es válida."; }
	}
}
