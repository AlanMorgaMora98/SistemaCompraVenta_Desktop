using SistemaDeComprasYVentas.ApiRequests;
using SistemaDeComprasYVentas.Commands;
using SistemaDeComprasYVentas.Models;
using SistemaDeComprasYVentas.Session;
using SistemaDeComprasYVentas.Stores;
using SistemaDeComprasYVentas.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SistemaDeComprasYVentas.ViewModels
{
	public class RealizarPedidoViewModel : ViewModelBase
	{
		private OutputMessages messages;
		private DomicilioRequests domicilioRequests;
		private TarjetaRequests tarjetaRequests;
		public ICommand RealizarPedidoCommand { get; }
		private ObservableCollection< Domicilio > domiciliosUsuario;
		private ObservableCollection< Tarjeta > tarjetasUsuario;
		private string productosTotales;
		private string subtotal;
		private string errorText;

		public string ErrorText
		{
			get { return errorText; }
			set
			{
				errorText = value;
				OnPropertyChanged( nameof( ErrorText ) );
			}
		}

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

		public ObservableCollection< Domicilio > DomiciliosUsuario
		{
			get { return domiciliosUsuario; }
			set
			{
				domiciliosUsuario = value;
				OnPropertyChanged( nameof( DomiciliosUsuario ) );
			}
		}

		public ObservableCollection< Tarjeta > TarjetasUsuario
		{
			get { return tarjetasUsuario; }
			set
			{
				tarjetasUsuario = value;
				OnPropertyChanged( nameof( TarjetasUsuario ) );
			}
		}

		public Domicilio DomicilioSeleccionado 
		{
			get { return ( ( RealizarPedidoCommand )RealizarPedidoCommand ).DomicilioSeleccionado; }
			set
			{
				( ( RealizarPedidoCommand )RealizarPedidoCommand ).DomicilioSeleccionado = value;
			}
		}

		public Tarjeta TarjetaSeleccionada
		{
			get { return ( ( RealizarPedidoCommand )RealizarPedidoCommand ).TarjetaSeleccionada; }
			set
			{
				( ( RealizarPedidoCommand )RealizarPedidoCommand ).TarjetaSeleccionada = value;
			}
		}

		public RealizarPedidoViewModel()
		{
			messages = new OutputMessages();
			domicilioRequests = new DomicilioRequests();
			tarjetaRequests = new TarjetaRequests();
			RealizarPedidoCommand = new RealizarPedidoCommand();
			ProductosTotales = SelectionContainerStore.GetInstance().PublicacionesCarrito.Count.ToString();
			Subtotal = CalculateSubtotal();
			RecuperarDomiliosUsuario();
			RecuperarTarjetasUsuario();
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

		private void RecuperarDomiliosUsuario()
		{
			domicilioRequests.RecuperarDomiciliosUsuario( LoginSession.GetInstance().ClaveUsuario, 
																LoginSession.GetInstance().AccessToken ).ContinueWith( Task => 
			{
				if( Task.Exception == null )
				{
					DomiciliosUsuario = Task.Result;
					CheckIfUserHasDomicilios();
				}
			} );
		}

		private void RecuperarTarjetasUsuario()
		{
			tarjetaRequests.RecuperarTarjetasUsuario( LoginSession.GetInstance().ClaveUsuario,
													  LoginSession.GetInstance().AccessToken ).ContinueWith( Task =>
				{
				 if( Task.Exception == null )
				 {
					 TarjetasUsuario = Task.Result;
					 CheckIfUserHasTarjetas();
				 }
				} );
		}

		private void CheckIfUserHasDomicilios()
		{
			if( DomiciliosUsuario.Count == 0 )
			{
				ErrorText = messages.UsuarioNoTieneDomicilios();
			}
		}
		private void CheckIfUserHasTarjetas()
		{
			if( TarjetasUsuario.Count == 0 )
			{
				ErrorText = messages.UsuarioNoTieneTarjetas();
			}
		}

		private void setErrorText( string errorMessage )
		{
			ErrorText = errorMessage;
		}
	}
}
