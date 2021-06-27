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
	public class CarritoComprasViewModel : ViewModelBase
	{
		private PublicacionesRequests requests;
		public ICommand NavigateRealizarPedidoCommand { get; }

		public ObservableCollection< Publicacion > PublicacionesCarrito
		{
			get { return SelectionContainerStore.GetInstance().PublicacionesCarrito; }
			set
			{
				SelectionContainerStore.GetInstance().PublicacionesCarrito = value;
				OnPropertyChanged( nameof( PublicacionesCarrito ) );
			}
		}

		public Publicacion ItemSeleccionado
		{
			set
			{
				SelectionContainerStore.GetInstance().PublicacionSeleccionadaCarrito = value;
			}
		}

		public CarritoComprasViewModel()
		{
			requests = new PublicacionesRequests();
			NavigateRealizarPedidoCommand = new NavigateCommand< RealizarPedidoViewModel >( 
											NavigationServiceCreator.GetInstance().CreateRealizarPedidoNavigationService() );
			RecuperarPublicacionesCarrito();
		}

		private void RecuperarPublicacionesCarrito()
		{
			requests.RecuperarPublicacionesCarrito( LoginSession.GetInstance().ClaveUsuario, 
													LoginSession.GetInstance().AccessToken ).ContinueWith( Task => 
			{
				if( Task.Exception == null )
				{
					PublicacionesCarrito = Task.Result;
				}
			} );
		}

		public void EliminarPublicacionDeCarrito()
		{
			requests.EliminarDeCarrito( LoginSession.GetInstance().ClaveUsuario,
										SelectionContainerStore.GetInstance().PublicacionSeleccionadaCarrito.clave_publicacion,
										LoginSession.GetInstance().AccessToken ).ContinueWith( Task =>
				{
					if( Task.Exception == null )
					{
						System.Windows.Application.Current.Dispatcher.Invoke( delegate
						{
							SelectionContainerStore.GetInstance().EliminarPublicacionDeListaCarrito();
							RecuperarPublicacionesCarrito();
						} );
					}
				} );
		}
	}
}
