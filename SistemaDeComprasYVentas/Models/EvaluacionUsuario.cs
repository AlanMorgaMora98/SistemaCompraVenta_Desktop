using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.Models
{
	public class EvaluacionUsuario
	{
		public int discriminante_evaluacion { get; set; }
		public int clave_usuario { get; set; }
		public int clave_evaluador_de_usuario { get; set; }
		public string evaluacion { get; set; }
		public int calificacion { get; set; }

		public EvaluacionUsuario()
		{
			discriminante_evaluacion = -1;
			clave_usuario = -1;
			clave_evaluador_de_usuario = -1;
			evaluacion = "";
			calificacion = -1;
		}

		public EvaluacionUsuario( EvaluacionUsuario original )
		{
			discriminante_evaluacion = original.discriminante_evaluacion;
			clave_usuario = original.clave_usuario;
			clave_evaluador_de_usuario = original.clave_evaluador_de_usuario;
			evaluacion = original.evaluacion;
			calificacion = original.calificacion;
		}

		public EvaluacionUsuario( int discriminanteIn, int claveUsuarioIn, int claveEvaluadorIn, 
								  string evaluacionIn, int calificacionIn )
		{
			discriminante_evaluacion = discriminanteIn;
			clave_usuario = claveUsuarioIn;
			clave_evaluador_de_usuario = claveEvaluadorIn;
			evaluacion = evaluacionIn;
			calificacion = calificacionIn;
		}
	}
}