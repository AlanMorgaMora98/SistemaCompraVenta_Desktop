using SistemaDeComprasYVentas.ApiRequests;
using SistemaDeComprasYVentas.Models;
using SistemaDeComprasYVentas.Session;
using SistemaDeComprasYVentas.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.ViewModels
{
	public class EvaluarUsuarioViewModel : ViewModelBase
	{
		private EvaluacionRequests requests; 
		private string evaluacion;
		private string calificacionSeleccionada;
		private string errorText;

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
			get { return calificacionSeleccionada; }
			set
			{
				calificacionSeleccionada = value;

			}
		}

		public string ErrorText
		{
			get { return errorText; }
			set
			{
				errorText = value;
				OnPropertyChanged( nameof( ErrorText ) );
			}
		}

		public EvaluarUsuarioViewModel()
		{
			requests = new EvaluacionRequests();
			CalificacionValues = new List< string > { "1", "2", "3", "4", "5" };
		}

		public void MandarEvaluacion()
		{
			requests.AgregarEvaluacion( CreateEvaluacion(),LoginSession.GetInstance().AccessToken ).ContinueWith( Task => 
			{
				if( Task.Exception == null )
				{

				}
			} );
		}

		private EvaluacionUsuario CreateEvaluacion()
		{
			return new EvaluacionUsuario( 0, SelectionContainerStore.GetInstance().TransaccionSeleccionadaHistorial.clave_vendedor,
										  LoginSession.GetInstance().ClaveUsuario, Evaluacion, int.Parse( CalificacionSeleccionada ), 
										  SelectionContainerStore.GetInstance().TransaccionSeleccionadaHistorial.clave_transaccion );
		}
	}
}
