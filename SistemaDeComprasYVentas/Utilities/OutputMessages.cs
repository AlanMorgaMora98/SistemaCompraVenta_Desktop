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

		public string CodigoPostalNoValido() { return "El Codigo Postal no es válida."; }

		public string EstadoNoValido() { return "El Estado no es válido."; }

		public string MunicipioNoValido() { return "El Municipio no es válido."; }

		public string ColoniaNoValida() { return "La Colonia no es válida."; }

		public string DireccionNoValida() { return "La Direccion no es válida."; }

		public string NumExtNoValido() { return "El numero externo no es válido."; }

		public string NumIntNoValido() { return "El numero interno no es válido."; }

		public string DescripcionNoValida() { return "La descripcion no es válida."; }

		public string HabienteNoValido() { return "El nombre no es válido."; }

		public string NumeroTarjetaNoValido() { return "El numero de la tarjeta no es válido."; }

		public string FechaVencimientoNoValida() { return "La fecha no es válida."; }

		public string NombrePublicacionNoValido() { return "El nombre no es válido."; }

		public string PrecioPublicacionNoValido() { return "El precio no es válido."; }

		public string UsuarioNoTieneDomicilios() { return "Favor de registrar por lo menos un domicilio."; }

		public string UsuarioNoTieneTarjetas() { return "Favor de registrar por lo menos una tarjeta."; }

		public string ProductoAgregadoACarrito() { return "¡Producto agregado a carrito!"; }

		public string ProductoAgregadoAFavoritos() { return "¡Producto agregado a Favoritos!"; }

		public string MensajeConfirmarEliminarCuenta() { return "¿Estas seguro que deseas eliminar tu cuenta?"; }

		public string ConfirmTitle() { return "Confirmar Eliminacion"; }

		public string SinConexionTitle() { return "Error de Conexion"; }

		public string NoHayConexionAlServido() { return "No hay conexión al servidor. Por favor inténtelo más tarde"; }

		public string RegistrarUsuarioError() { return "Ocurrio un error o ya existe ese usuario."; }

		public string ErrorTitle() { return "Error"; }
	}
}
