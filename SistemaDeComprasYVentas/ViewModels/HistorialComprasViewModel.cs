using SistemaDeComprasYVentas.ApiRequests;
using SistemaDeComprasYVentas.Commands;
using SistemaDeComprasYVentas.Models;
using SistemaDeComprasYVentas.Session;
using SistemaDeComprasYVentas.Stores;
using SistemaDeComprasYVentas.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SistemaDeComprasYVentas.ViewModels
{
	public class HistorialComprasViewModel : ViewModelBase
	{
		private TransaccionRequests requests;
		private ICommand NavigateVisualizarTransaccion { get; set; }
		private ObservableCollection< Transaccion > transaccionesUsuario;
		public ObservableCollection< Transaccion > TransaccionesUsuario
		{
			get { return transaccionesUsuario; }
			set
			{
				transaccionesUsuario = value;
				OnPropertyChanged( nameof( TransaccionesUsuario ) );
			}
		}
		public Transaccion TransaccionSeleccionada
		{
			set
			{
				SelectionContainerStore.GetInstance().TransaccionSeleccionadaHistorial = value;
				NavigateVisualizarTransaccion = new NavigateCommand< VisualizarTransaccionCompradorViewModel >(
												NavigationServiceCreator.GetInstance().CreateVisualizarTransaccionNavigationService() );
				NavigateVisualizarTransaccion.Execute( this );
			}
		}
		public Transaccion ItemSeleccionado
		{
			set
			{
				SelectionContainerStore.GetInstance().TransaccionSeleccionadaHistorial = value;
				NavigateVisualizarTransaccion = new NavigateCommand< VisualizarTransaccionCompradorViewModel >( 
												NavigationServiceCreator.GetInstance().CreateVisualizarTransaccionNavigationService() );
				NavigateVisualizarTransaccion.Execute( this );
			}
		}


		public HistorialComprasViewModel()
		{
			requests = new TransaccionRequests();
			RecuperarTransacciones();
		}

		private void RecuperarTransacciones()
		{
			requests.RecuperarTransaccionesUsuario( LoginSession.GetInstance().ClaveUsuario,
													LoginSession.GetInstance().AccessToken ).ContinueWith( Task =>
				{
					if( Task.Exception == null ) 
					{
						TransaccionesUsuario = Task.Result;
					}
				} );
		}
	}
}
