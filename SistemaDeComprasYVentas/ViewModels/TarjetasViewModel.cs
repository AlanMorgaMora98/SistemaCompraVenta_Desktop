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
	public class TarjetasViewModel : ViewModelBase
	{
		private TarjetaRequests requests;
		public ICommand NavigateAgregarTarjetaCommand { get; }


		public ObservableCollection<Tarjeta> Tarjetas
		{
			get { return SelectionContainerStore.GetInstance().TarjetasUsuario; }
			set
			{
				SelectionContainerStore.GetInstance().TarjetasUsuario = value;
				OnPropertyChanged(nameof( Tarjetas ));
			}
		}

		public Tarjeta ItemSeleccionado
		{
			set
			{
				SelectionContainerStore.GetInstance().TarjetaSeleccionadaUsuario = value;
			}
		}

		public bool TarjetaSeleccionada
		{
			get
			{
				return SelectionContainerStore.GetInstance().TarjetaSeleccionadaUsuario != null;
			}
		}

		public TarjetasViewModel()
		{
			requests = new TarjetaRequests();
			NavigateAgregarTarjetaCommand = new NavigateCommand<AgregarTarjetaViewModel>(
											NavigationServiceCreator.GetInstance().CreateAgregarTarjetaNavigationService() );
			SelectionContainerStore.GetInstance().TarjetaSeleccionadaUsuario = null;
			RecuperarTarjetasDeUsuario();
		}

		private void RecuperarTarjetasDeUsuario()
		{
			requests.RecuperarTarjetasUsuario( LoginSession.GetInstance().ClaveUsuario,
											   LoginSession.GetInstance().AccessToken).ContinueWith( Task =>
			{
				if( Task.Exception == null )
				{
					Tarjetas = Task.Result;
				}
			} );
		}

		public void EliminarTarjetaDeUsuario()
		{
			if( SelectionContainerStore.GetInstance().TarjetaSeleccionadaUsuario != null )
			{
				requests.EliminarTarjeta( LoginSession.GetInstance().ClaveUsuario,
										  SelectionContainerStore.GetInstance().TarjetaSeleccionadaUsuario.discriminante_tarjeta,
										  LoginSession.GetInstance().AccessToken).ContinueWith( Task =>
				  {
					  if( Task.Exception == null )
					  {
						  System.Windows.Application.Current.Dispatcher.Invoke( delegate
						  {
							  SelectionContainerStore.GetInstance().EliminarTarjetaDeUsuario();
							  SelectionContainerStore.GetInstance().TarjetaSeleccionadaUsuario = null;
							  RecuperarTarjetasDeUsuario();
						  } );
					  }
				  } );
			}
		}
	}
}
