using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SistemaDeComprasYVentas.Commands;
using SistemaDeComprasYVentas.Stores;

namespace SistemaDeComprasYVentas.ViewModels
{
	public class VisualizarPublicacionCompradorViewModel : ViewModelBase
	{
		public ICommand AgregarACarritoCommand { get; }
		public ICommand AgregarAFavoritoCommand { get; }
		private string nombre;
		private string categoria;
		private string precio;
		private string cantidad;
		private string descripcion;
		public string Nombre 
		{
			get { return nombre; } 
			set
			{
				nombre = value;
				OnPropertyChanged( nameof( Nombre ) );
			}
		}
		public string Categoria
		{
			get { return categoria; }
			set
			{
				categoria = value;
				OnPropertyChanged( nameof( Categoria ) );
			}
		}
		public string Precio
		{
			get { return precio; }
			set
			{
				precio = value;
				OnPropertyChanged( nameof( Precio ) );
			}
		}
		public string Cantidad
		{
			get { return cantidad; }
			set
			{
				cantidad = value;
				OnPropertyChanged( nameof( Cantidad ) );
			}
		}
		public string Descripcion
		{
			get { return descripcion; }
			set
			{
				descripcion = value;
				OnPropertyChanged( nameof( Descripcion ) );
			}
		}


		public VisualizarPublicacionCompradorViewModel()
		{
			AgregarACarritoCommand = new AgregarACarritoCommand();
			AgregarAFavoritoCommand = new AgregarAFavoritosCommand();
			Nombre = SelectionContainerStore.GetInstance().PublicacionBusqueda.nombre;
			Categoria = SelectionContainerStore.GetInstance().PublicacionBusqueda.categoria.ToString();
			Precio = string.Format( "{0:N2}", SelectionContainerStore.GetInstance().PublicacionBusqueda.precio );
			Cantidad = SelectionContainerStore.GetInstance().PublicacionBusqueda.cantidad_disponible.ToString();
			Descripcion = SelectionContainerStore.GetInstance().PublicacionBusqueda.descripcion;
		}
	}
}
