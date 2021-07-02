using SistemaDeComprasYVentas.ApiRequests;
using SistemaDeComprasYVentas.Models;
using SistemaDeComprasYVentas.Session;
using SistemaDeComprasYVentas.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SistemaDeComprasYVentas.ViewModels
{
	public class HistorialVentasViewModel : ViewModelBase
	{
		private TransaccionRequests requests;
		private int ventasTotales;
		private ObservableCollection<Transaccion> transaccionesUsuario;

		public int VentasTotales
		{
			get { return ventasTotales; }
			set
			{
				ventasTotales = value;
				OnPropertyChanged( nameof( VentasTotales ) );
			}
		}

		public ObservableCollection<Transaccion> TransaccionesUsuario
		{
			get { return transaccionesUsuario; }
			set
			{
				transaccionesUsuario = value;
				OnPropertyChanged( nameof( TransaccionesUsuario ) );
			}
		}


		public HistorialVentasViewModel()
		{
			requests = new TransaccionRequests();
			RecuperarTransaccionesVendedor();
		}

		private void RecuperarTransaccionesVendedor()
		{
			requests.RecuperarTransaccionesUsuario( LoginSession.GetInstance().ClaveUsuario,
													LoginSession.GetInstance().AccessToken ).ContinueWith(Task =>
				{
					if( Task.Exception == null )
					{
						TransaccionesUsuario = Task.Result;
						VentasTotales = TransaccionesUsuario.Count;
					}
				});
		}
	}
}
