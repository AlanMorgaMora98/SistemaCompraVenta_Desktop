using SistemaDeComprasYVentas.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.Stores
{
	public class SelectionContainerStore
	{
		private static SelectionContainerStore selectionContainerStore;
		public ObservableCollection< Publicacion > PublicacionesCarrito { get; set; }
		public Publicacion PublicacionSeleccionadaBusqueda { get; set; }
		public Publicacion PublicacionSeleccionadaCarrito { get; set; }
		public Publicacion PublicacionSeleccionadaFavorito { get; set; }

		private SelectionContainerStore()
		{
			PublicacionesCarrito = null;
			PublicacionSeleccionadaBusqueda = null;
			PublicacionSeleccionadaCarrito = null;
			PublicacionSeleccionadaFavorito = null;
		}

		public static SelectionContainerStore GetInstance()
		{
			if( selectionContainerStore == null )
			{
				selectionContainerStore = new SelectionContainerStore();
			}
			return selectionContainerStore;
		}
	}
}
