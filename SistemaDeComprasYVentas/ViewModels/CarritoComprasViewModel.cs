using SistemaDeComprasYVentas.ApiRequests;
using SistemaDeComprasYVentas.Models;
using SistemaDeComprasYVentas.Session;
using SistemaDeComprasYVentas.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.ViewModels
{
	public class CarritoComprasViewModel : ViewModelBase
	{
		private PublicacionesRequests requests;
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
			RecuperarPublicacionesCarrito();
		}

		private void RecuperarPublicacionesCarrito()
		{
			requests.RecuperarPublicacionesCarrito( LoginSession.GetInstance().ClaveUsuario, 
													LoginSession.GetInstance().AccessToken).ContinueWith( Task => 
			{
				if( Task.Exception == null )
				{
					PublicacionesCarrito = Task.Result;
				}
			} );
		}
	}
}
