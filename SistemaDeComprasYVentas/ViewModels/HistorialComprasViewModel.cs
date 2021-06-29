using SistemaDeComprasYVentas.ApiRequests;
using SistemaDeComprasYVentas.Models;
using SistemaDeComprasYVentas.Session;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.ViewModels
{
	public class HistorialComprasViewModel : ViewModelBase
	{
		private TransaccionRequests requests;
		private ObservableCollection< Transaccion > transaccionesUsuario;
		public ObservableCollection< Transaccion > TransaccionesUsuario
		{
			get { return transaccionesUsuario; }
			set
			{
				transaccionesUsuario = value;
				OnPropertyChanged( nameof( TransaccionesUsuario ) );
			}
		}

		public HistorialComprasViewModel()
		{
			requests = new TransaccionRequests();
			RecuperarTransacciones();
		}

		private void RecuperarTransacciones()
		{
			requests.RecuperarTransaccionesUsuario( LoginSession.GetInstance().ClaveUsuario,
													LoginSession.GetInstance().AccessToken ).ContinueWith( Task =>
				{
					if( Task.Exception == null ) 
					{
						TransaccionesUsuario = Task.Result;
					}
				} );
		}
	}
}
