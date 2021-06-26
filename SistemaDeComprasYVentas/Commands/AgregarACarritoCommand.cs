using SistemaDeComprasYVentas.ApiRequests;
using SistemaDeComprasYVentas.Models;
using SistemaDeComprasYVentas.Session;
using SistemaDeComprasYVentas.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.Commands
{
	public class AgregarACarritoCommand : CommandBase
	{
		private PublicacionesRequests requests;

		public AgregarACarritoCommand()
		{
			requests = new PublicacionesRequests();
		}

		public override void Execute( object parameter )
		{
			requests.AgregarACarrito( new CarritoFavoritoData( LoginSession.GetInstance().ClaveUsuario,
									  SelectionContainerStore.GetInstance().PublicacionSeleccionadaBusqueda.clave_publicacion ),
									  LoginSession.GetInstance().AccessToken ).ContinueWith( Task =>
			 {
				 if( Task.Exception == null )
				 {

				 }
			 } );
		}
	}
}
