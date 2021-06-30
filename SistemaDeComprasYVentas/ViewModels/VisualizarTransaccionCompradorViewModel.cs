using SistemaDeComprasYVentas.Commands;
using SistemaDeComprasYVentas.Stores;
using SistemaDeComprasYVentas.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SistemaDeComprasYVentas.ViewModels
{
	public class VisualizarTransaccionCompradorViewModel : ViewModelBase
	{
		public ICommand NavigateEvaluarUsuario { get; }
		private string claveTransaccion;
		private string claveVendedor;
		private string direccionComprador;
		private string fechaVenta;
		private string total;
		public string ClaveTransaccion
		{
			get { return claveTransaccion; }
			set 
			{
				claveTransaccion = value;
				OnPropertyChanged( nameof( ClaveTransaccion ) );
			}
		}
		public string ClaveVendedor
		{
			get { return claveVendedor; }
			set
			{
				claveVendedor = value;
				OnPropertyChanged( nameof( ClaveVendedor ) );
			}
		}
		public string DireccionComprador
		{
			get { return direccionComprador; }
			set
			{
				direccionComprador = value;
				OnPropertyChanged( nameof( DireccionComprador ) );
			}
		}
		public string FechaVenta
		{
			get { return fechaVenta; }
			set
			{
				fechaVenta = value;
				OnPropertyChanged( nameof( FechaVenta ) );
			}
		}
		public string Total
		{
			get { return total; }
			set
			{
				total = value;
				OnPropertyChanged( nameof( Total ) );
			}
		}
		public bool UsuarioNoEstaEvaluado { get; set; }

		public VisualizarTransaccionCompradorViewModel()
		{
			NavigateEvaluarUsuario = new NavigateCommand< EvaluarUsuarioViewModel >( 
										 NavigationServiceCreator.GetInstance().CreateEvaluarUsuarioNavigationService() );
			UsuarioNoEstaEvaluado = !SelectionContainerStore.GetInstance().TransaccionSeleccionadaHistorial.usuario_evaluado;

			ClaveTransaccion = SelectionContainerStore.GetInstance().TransaccionSeleccionadaHistorial.clave_transaccion.ToString();
			ClaveVendedor = SelectionContainerStore.GetInstance().TransaccionSeleccionadaHistorial.clave_vendedor.ToString();
			DireccionComprador = SelectionContainerStore.GetInstance().TransaccionSeleccionadaHistorial.direccion_comprador;
			FechaVenta = SelectionContainerStore.GetInstance().TransaccionSeleccionadaHistorial.fecha_venta;
			total = SelectionContainerStore.GetInstance().TransaccionSeleccionadaHistorial.total.ToString();
		}
	}
}
