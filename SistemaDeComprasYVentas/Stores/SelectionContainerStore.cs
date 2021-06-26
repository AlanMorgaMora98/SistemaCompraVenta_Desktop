using SistemaDeComprasYVentas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.Stores
{
	public class SelectionContainerStore
	{
		private static SelectionContainerStore selectionContainerStore;
		public Publicacion PublicacionBusqueda { get; set; }
		public Publicacion PublicacionCarrito { get; set; }
		public Publicacion PublicacionFavorito { get; set; }

		private SelectionContainerStore()
		{
			PublicacionBusqueda = null;
			PublicacionCarrito = null;
			PublicacionFavorito = null;
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
