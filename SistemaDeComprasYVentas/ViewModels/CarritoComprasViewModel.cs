using SistemaDeComprasYVentas.Models;
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
		private ObservableCollection< Publicacion > publicacionesCarrito;
		public ObservableCollection< Publicacion > PublicacionesCarrito
		{
			get { return publicacionesCarrito; }
			set
			{
				publicacionesCarrito = value;
				OnPropertyChanged( nameof( PublicacionesCarrito ) );
			}
		}

		public Publicacion ItemSeleccionado
		{
			set
			{
				SelectionContainerStore.GetInstance().PublicacionCarrito = value;
			}
		}

		public CarritoComprasViewModel()
		{

		}
	}
}
