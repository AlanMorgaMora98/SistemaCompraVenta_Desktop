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
		public Publicacion Publicacion { get; set; }

		private SelectionContainerStore()
		{
			Publicacion = null;
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
