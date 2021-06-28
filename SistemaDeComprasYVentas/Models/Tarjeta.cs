using SistemaDeComprasYVentas.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.Models
{
	public class Tarjeta
	{
		public int discriminante_tarjeta { get; set; }
		public int clave_usuario { get; set; }
		public string nombre_tarjeta_habiente { get; set; }
		public string numero { get; set; }
		public string fecha_vencimiento { get; set; }
		public TipoTarjeta tipo_tarjeta { get; set; }

		public Tarjeta()
		{
			discriminante_tarjeta = -1;
			clave_usuario = -1;
			nombre_tarjeta_habiente = "";
			numero = "";
			fecha_vencimiento = "";
			tipo_tarjeta = TipoTarjeta.debito;
		}

		public Tarjeta( Tarjeta original )
		{
			discriminante_tarjeta = original.discriminante_tarjeta;
			clave_usuario = original.clave_usuario;
			nombre_tarjeta_habiente = original.nombre_tarjeta_habiente;
			numero = original.numero;
			fecha_vencimiento = original.fecha_vencimiento;
			tipo_tarjeta = original.tipo_tarjeta;
		}

		public Tarjeta( int discriminanteIn, int claveUsuarioIn, string nombreIn, string numeroIn, 
						string fechaIn, TipoTarjeta tipoIn )
		{
			discriminante_tarjeta = discriminanteIn;
			clave_usuario = claveUsuarioIn;
			nombre_tarjeta_habiente = nombreIn;
			numero = numeroIn;
			fecha_vencimiento = fechaIn;
			tipo_tarjeta = tipoIn;
		}
	}
}
