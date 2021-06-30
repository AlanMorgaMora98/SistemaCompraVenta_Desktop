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
		private ObservableCollection< Publicacion > publicacionesCarrito;
		private ObservableCollection< Publicacion > publicacionesFavoritos;
		private ObservableCollection< Domicilio > domiciliosUsuario;
		private ObservableCollection< Publicacion > publicacionesUsuario;

		public ObservableCollection< Publicacion > PublicacionesCarrito 
		{
			get { return publicacionesCarrito; } 
			set
			{
				publicacionesCarrito = value;
			}
		}
		public ObservableCollection<Publicacion> PublicacionesFavoritos
		{
			get { return publicacionesFavoritos; }
			set
			{
				publicacionesFavoritos = value;
			}
		}
		public ObservableCollection<Domicilio> DomiciliosUsuario
		{
			get { return domiciliosUsuario; }
			set
			{
				domiciliosUsuario = value;
			}
		}
		public ObservableCollection<Publicacion> PublicacionesUsuario
		{
			get { return publicacionesUsuario; }
			set
			{
				publicacionesUsuario = value;
			}
		}
		public Publicacion PublicacionSeleccionadaBusqueda { get; set; }
		public Publicacion PublicacionSeleccionadaCarrito { get; set; }
		public Publicacion PublicacionSeleccionadaFavorito { get; set; }
		public Domicilio DomicilioSeleccionado { get; set; }
		public Publicacion PublicacionSeleccionadaUsuario { get; set; }
		public Transaccion TransaccionSeleccionadaHistorial { get; set; }

		private SelectionContainerStore()
		{
			publicacionesCarrito = null;
			PublicacionSeleccionadaBusqueda = null;
			PublicacionSeleccionadaCarrito = null;
			PublicacionSeleccionadaFavorito = null;
			DomicilioSeleccionado = null;
			PublicacionSeleccionadaUsuario = null;
		}

		public static SelectionContainerStore GetInstance()
		{
			if( selectionContainerStore == null )
			{
				selectionContainerStore = new SelectionContainerStore();
			}
			return selectionContainerStore;
		}

		public void EliminarPublicacionDeListaCarrito()
		{
			publicacionesCarrito.Remove( PublicacionSeleccionadaCarrito );
		}

		public void EliminarPublicacionDeListaFavoritos()
		{
			publicacionesFavoritos.Remove( PublicacionSeleccionadaFavorito );
		}

		public void EliminarDomicilioDeUsuario()
		{
			domiciliosUsuario.Remove(DomicilioSeleccionado);
		}

		public void EliminarPublicacionDeUsuario()
		{
			publicacionesUsuario.Remove(PublicacionSeleccionadaUsuario);
		}
	}
}
