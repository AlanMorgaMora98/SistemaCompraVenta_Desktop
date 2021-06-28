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
	public class RealizarPedidoCommand : CommandBase
	{
		private TransaccionRequests requests;
		public Domicilio DomicilioSeleccionado { get; set; }
		public Tarjeta TarjetaSeleccionada { get; set; }

		public RealizarPedidoCommand()
		{
			requests = new TransaccionRequests();
			DomicilioSeleccionado = null;
			TarjetaSeleccionada = null;
		}

		public override void Execute( object parameter )
		{
			if( DomicilioSeleccionado != null && TarjetaSeleccionada != null )
			{
				foreach( Publicacion publicacion in SelectionContainerStore.GetInstance().PublicacionesCarrito )
				{
					RecuperarClaveUsuario( publicacion );
				}
			}
		}

		private void RecuperarClaveUsuario( Publicacion publicacion )
		{
			requests.RecuperarClaveUsuario( publicacion.clave_publicacion, LoginSession.GetInstance().AccessToken ).ContinueWith( Task => 
			{
				if( Task.Exception == null )
				{
					UsuarioPublicacion usuarioPublicacion = Task.Result;
					RealizarPedido( usuarioPublicacion.clave_usuario_usuario, publicacion );
				}
			} );
		}

		private void RealizarPedido( int claveVendedor, Publicacion publicacion )
		{
			requests.AgregarTransaccion( LoginSession.GetInstance().ClaveUsuario, CreateTransaccion( claveVendedor, publicacion ), 
										 LoginSession.GetInstance().AccessToken ).ContinueWith( Task => 
			{
				if( Task.Exception == null )
				{ }
			} );
		}

		private Transaccion CreateTransaccion( int claveVendedor, Publicacion publicacion )
		{
			return new Transaccion( 0, claveVendedor, DomicilioSeleccionado.callecompleta, 
									TarjetaSeleccionada.numero, DateTime.Today.ToString(), publicacion.precio, false );
		}
	}
}
