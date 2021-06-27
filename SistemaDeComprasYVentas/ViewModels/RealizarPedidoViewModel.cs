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
	public class RealizarPedidoViewModel : ViewModelBase
	{
		private DomicilioRequests domicilioRequests;
		private TarjetaRequests tarjetaRequests;
		private List< Domicilio > domiciliosUsuario;
		private List< Tarjeta > tarjetasUsuario;
		private string productosTotales;
		private string subtotal;

		public string ProductosTotales 
		{
			get { return productosTotales; }
			set
			{
				productosTotales = value;
				OnPropertyChanged( nameof( ProductosTotales ) );
			}
		}

		public string Subtotal 
		{ 
			get { return subtotal; } 
			set
			{
				subtotal = value;
				OnPropertyChanged( nameof( Subtotal ) );
			}
		}

		public List< Domicilio > DomiciliosUsuario
		{
			get { return domiciliosUsuario; }
			set
			{
				domiciliosUsuario = value;
				OnPropertyChanged( nameof( DomiciliosUsuario ) );
			}
		}

		public List< Tarjeta > TarjetasUsuario
		{
			get { return tarjetasUsuario; }
			set
			{
				tarjetasUsuario = value;
				OnPropertyChanged( nameof( TarjetasUsuario ) );
			}
		}

		public RealizarPedidoViewModel()
		{
			domicilioRequests = new DomicilioRequests();
			tarjetaRequests = new TarjetaRequests();
			ProductosTotales = SelectionContainerStore.GetInstance().PublicacionesCarrito.Count.ToString();
			Subtotal = CalculateSubtotal();
			RecuperarDomiliosUsuario();
			RecuperarTarjetasUsuario();
		}

		private string CalculateSubtotal()
		{
			double subtotal = 0.0;
			foreach( Publicacion publicacion in SelectionContainerStore.GetInstance().PublicacionesCarrito )
			{
				subtotal += publicacion.precio;
			}
			return subtotal.ToString();
		}

		private void RecuperarDomiliosUsuario()
		{
			domicilioRequests.RecuperarDomiciliosUsuario( LoginSession.GetInstance().ClaveUsuario, 
											     LoginSession.GetInstance().AccessToken ).ContinueWith( Task => 
			{
				if( Task.Exception == null )
				{
					DomiciliosUsuario = Task.Result;
				}
			} );
		}

		private void RecuperarTarjetasUsuario()
		{
			tarjetaRequests.RecuperarTarjetasUsuario( LoginSession.GetInstance().ClaveUsuario,
													   LoginSession.GetInstance().AccessToken ).ContinueWith( Task =>
				{
				 if (Task.Exception == null)
				 {
					 TarjetasUsuario = Task.Result;
				 }
				});
		}
	}
}
