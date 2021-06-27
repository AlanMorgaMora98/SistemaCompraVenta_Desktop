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
		private DomicilioRequests requests;
		private List< Domicilio > domiciliosUsuario;
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

		public RealizarPedidoViewModel()
		{
			requests = new DomicilioRequests();
			ProductosTotales = SelectionContainerStore.GetInstance().PublicacionesCarrito.Count.ToString();
			Subtotal = CalculateSubtotal();
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
			requests.RecuperarDomiciliosUsuario( LoginSession.GetInstance().ClaveUsuario, 
											     LoginSession.GetInstance().AccessToken ).ContinueWith( Task => 
			{
				if( Task.Exception == null )
				{
					DomiciliosUsuario = Task.Result;
				}
			} );
		}
	}
}
