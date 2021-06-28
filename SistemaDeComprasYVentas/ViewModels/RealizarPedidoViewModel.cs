using SistemaDeComprasYVentas.ApiRequests;
using SistemaDeComprasYVentas.Commands;
using SistemaDeComprasYVentas.Models;
using SistemaDeComprasYVentas.Session;
using SistemaDeComprasYVentas.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SistemaDeComprasYVentas.ViewModels
{
	public class RealizarPedidoViewModel : ViewModelBase
	{
		private DomicilioRequests domicilioRequests;
		private TarjetaRequests tarjetaRequests;
		public ICommand RealizarPedidoCommand { get; }
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

		public Domicilio DomicilioSeleccionado 
		{
			get { return ( ( RealizarPedidoCommand )RealizarPedidoCommand ).DomicilioSeleccionado; }
			set
			{
				( ( RealizarPedidoCommand )RealizarPedidoCommand ).DomicilioSeleccionado = value;
			}
		}

		public Tarjeta TarjetaSeleccionada
		{
			get { return ( ( RealizarPedidoCommand )RealizarPedidoCommand ).TarjetaSeleccionada; }
			set
			{
				( ( RealizarPedidoCommand )RealizarPedidoCommand ).TarjetaSeleccionada = value;
			}
		}

		public RealizarPedidoViewModel()
		{
			domicilioRequests = new DomicilioRequests();
			tarjetaRequests = new TarjetaRequests();
			RealizarPedidoCommand = new RealizarPedidoCommand();
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
