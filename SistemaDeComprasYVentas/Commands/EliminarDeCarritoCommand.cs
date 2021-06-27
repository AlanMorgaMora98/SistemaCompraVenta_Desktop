using SistemaDeComprasYVentas.ApiRequests;
using SistemaDeComprasYVentas.Session;
using SistemaDeComprasYVentas.Stores;
using SistemaDeComprasYVentas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.Commands
{
	public class EliminarDeCarritoCommand : CommandBase
	{
		private PublicacionesRequests requests;
		private CarritoComprasViewModel carritoViewModel;

		public EliminarDeCarritoCommand( ref CarritoComprasViewModel carritoViewModelIn )
		{
			requests = new PublicacionesRequests();
			carritoViewModel = carritoViewModelIn;
		}

		public override void Execute( object parameter )
		{
			requests.EliminarDeCarrito( LoginSession.GetInstance().ClaveUsuario,
										SelectionContainerStore.GetInstance().PublicacionSeleccionadaCarrito.clave_publicacion,
										LoginSession.GetInstance().AccessToken ).ContinueWith( Task => 
				{
					if( Task.Exception == null )
					{
						carritoViewModel.PublicacionesCarrito = SelectionContainerStore.GetInstance().EliminarPublicacionDeListaCarrito();
					}
				} );
		}
	}
}
