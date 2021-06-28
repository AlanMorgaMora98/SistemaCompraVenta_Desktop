using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.Models
{
	public class Transaccion
	{
		public int clave_transaccion { get; set; }
		public int clave_vendedor { get; set; }
		public string direccion_comprador { get; set; }
		public string numero_tarjeta { get; set; }
		public string fecha_venta { get; set; }
		public double total { get; set; }
		public bool usuario_evaluado { get; set; }

		public Transaccion()
		{
			clave_transaccion = -1;
			clave_vendedor = -1;
			direccion_comprador = "";
			numero_tarjeta = "";
			fecha_venta = "";
			total = 0.0;
			usuario_evaluado = false;
		}

		public Transaccion( Transaccion original )
		{
			clave_transaccion = original.clave_transaccion;
			clave_vendedor = original.clave_vendedor;
			direccion_comprador = original.direccion_comprador;
			numero_tarjeta = original.numero_tarjeta;
			fecha_venta = original.fecha_venta;
			total = original.total;
			usuario_evaluado = original.usuario_evaluado;
		}

		public Transaccion( int claveTransaccionIn, int claveVendedorIn, string direccionIn, 
							string numeroIn, string fechaIn, double totalIn, bool usuarioIn )
		{
			clave_transaccion = claveTransaccionIn;
			clave_vendedor = claveVendedorIn;
			direccion_comprador = direccionIn;
			numero_tarjeta = numeroIn;
			fecha_venta = fechaIn;
			total = totalIn;
			usuario_evaluado = usuarioIn;
		}
	}
}
