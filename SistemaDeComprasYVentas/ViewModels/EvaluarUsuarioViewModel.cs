using SistemaDeComprasYVentas.ApiRequests;
using SistemaDeComprasYVentas.Commands;
using SistemaDeComprasYVentas.Models;
using SistemaDeComprasYVentas.Session;
using SistemaDeComprasYVentas.Stores;
using SistemaDeComprasYVentas.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SistemaDeComprasYVentas.ViewModels
{
	public class EvaluarUsuarioViewModel : ViewModelBase
	{
		private EvaluacionRequests requests;
		private StringValidator validator;
		private OutputMessages messages;
		private ICommand NavigateToHistorialComprasCommand { get; }
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
				IsEvaluacionValid( evaluacion );
				OnPropertyChanged( nameof( Evaluacion ) );
			}
		}

		public string CalificacionSeleccionada
		{
			get { return calificacionSeleccionada; }
			set
			{
				calificacionSeleccionada = value;
				IsCalificacionValid( calificacionSeleccionada );
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
			validator = new StringValidator();
			messages = new OutputMessages();
			NavigateToHistorialComprasCommand = new NavigateCommand< HistorialComprasViewModel >( 
												NavigationServiceCreator.GetInstance().CreateHistorialComprasNavigationService() );
			CalificacionValues = new List< string > { "1", "2", "3", "4", "5" };
			IsCalificacionValid( calificacionSeleccionada );
		}

		public void MandarEvaluacion()
		{
			if( validator.IsEvaluacionValid( Evaluacion ) && !string.IsNullOrEmpty( CalificacionSeleccionada ) )
			{
				requests.AgregarEvaluacion( CreateEvaluacion(), LoginSession.GetInstance().AccessToken).ContinueWith( Task =>
				  {
					  if( Task.Exception == null )
					  {
			
					  }
				  } );
			}
		}

		private EvaluacionUsuario CreateEvaluacion()
		{
			return new EvaluacionUsuario( 0, SelectionContainerStore.GetInstance().TransaccionSeleccionadaHistorial.clave_vendedor,
										  LoginSession.GetInstance().ClaveUsuario, Evaluacion, int.Parse( CalificacionSeleccionada ), 
										  SelectionContainerStore.GetInstance().TransaccionSeleccionadaHistorial.clave_transaccion );
		}

		private void IsEvaluacionValid( string evaluacion )
		{
			ErrorText = "";
			if( !string.IsNullOrEmpty( evaluacion ) && !validator.IsEvaluacionValid( evaluacion ) )
			{
				SetErrorMessage( messages.EvaluacionNoEsValida() );
			}
		}

		private void IsCalificacionValid( string calificacion )
		{
			ErrorText = "";
			if( string.IsNullOrEmpty( calificacion ) )
			{
				SetErrorMessage( messages.CalificacionNoEsValida() );
			}
		}

		public void SetErrorMessage( string errorMessage )
		{
			ErrorText = errorMessage;
		}
	}
}
