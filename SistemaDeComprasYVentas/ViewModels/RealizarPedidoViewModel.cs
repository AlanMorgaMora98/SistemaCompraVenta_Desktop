using SistemaDeComprasYVentas.Models;
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

		public RealizarPedidoViewModel()
		{
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
	}
}
