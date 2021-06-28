using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.Models
{
	public class Domicilio
	{
		public int discriminante_domicilio { get; set; }
		public int clave_usuario { get; set; }
		public string calle { get; set; }
		public string colonia { get; set; }
		public string municipio { get; set; }
		public string codigo_postal { get; set; }
		public string estado { get; set; }
		public int numero_interno { get; set; }
		public int numero_externo { get; set; }
		public string descripcion { get; set; }

		public string callecompleta
		{
			get { return $"{ calle } { numero_externo } { colonia }, { municipio }, { estado }"; }
		}

		public Domicilio()
		{
			discriminante_domicilio = -1;
			clave_usuario = -1;
			calle = "";
			colonia = "";
			municipio = "";
			codigo_postal = "";
			estado = "";
			numero_interno = -1;
			numero_externo = -1;
			descripcion = "";
		}

		public Domicilio( Domicilio original )
		{
			discriminante_domicilio = original.discriminante_domicilio;
			clave_usuario = original.clave_usuario;
			calle = original.calle;
			colonia = original.colonia;
			municipio = original.municipio;
			codigo_postal = original.codigo_postal;
			estado = original.estado;
			numero_interno = original.numero_interno;
			numero_externo = original.numero_externo;
			descripcion = original.descripcion;
		}

		public Domicilio( int discriminanteIn, int claveUsuarioIn, string calleIn, string coloniaIn, 
						  string municipioIn, string codigoIn, string estadoIn, int numInternoIn, int numExternoIn,
						  string descripcionIn )
		{
			discriminante_domicilio = discriminanteIn;
			clave_usuario = claveUsuarioIn;
			calle = calleIn;
			colonia = coloniaIn;
			municipio = municipioIn;
			codigo_postal = codigoIn;
			estado = estadoIn;
			numero_interno = numInternoIn;
			numero_externo = numExternoIn;
			descripcion = descripcionIn;
		}
	}
}