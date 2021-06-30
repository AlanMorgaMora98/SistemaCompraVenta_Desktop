using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.ViewModels
{
	public class EvaluarUsuarioViewModel : ViewModelBase
	{
		private string evaluacion;
		private string calificacionSeleccionada;

		public List< string > CalificacionValues { get; set; }
		public string Evaluacion
		{
			get { return evaluacion; }
			set 
			{
				evaluacion = value;
			}
		}

		public string CalificacionSeleccionada
		{
			set
			{
				calificacionSeleccionada = value;

			}
		}

		public EvaluarUsuarioViewModel()
		{
			CalificacionValues = new List< string > { "1", "2", "3", "4", "5" };
		}
	}
}
