using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SistemaDeComprasYVentas.Utilities;
using SistemaDeComprasYVentas.Commands;
using SistemaDeComprasYVentas.Session;
using SistemaDeComprasYVentas.ApiRequests;

namespace SistemaDeComprasYVentas.ViewModels
{
	public class PerfilViewModel : ViewModelBase
	{
		private UsuarioRequests requests;
		private string nombres;
		private string apellidos;
		private string correo;
		private string usuario;
		private string telefono;
		private string calificacion;

		public ICommand EliminarCuentaCommand { get; }
		public ICommand NavigateModificarDatosCommand { get; }
		public string Nombres 
		{
			get { return nombres; } 
			set
			{
				nombres = value;
				OnPropertyChanged( nameof( Nombres ) );
			}
		}
		public string Apellidos
		{
			get { return apellidos; }
			set
			{
				apellidos = value;
				OnPropertyChanged( nameof( Apellidos ) );
			}
		}
		public string Correo
		{
			get { return correo; }
			set
			{
				correo = value;
				OnPropertyChanged( nameof( Correo ) );
			}
		}
		public string Usuario
		{
			get { return usuario; }
			set
			{
				usuario = value;
				OnPropertyChanged( nameof( Usuario ) );
			}
		}
		public string Telefono
		{
			get { return telefono; }
			set
			{
				telefono = value;
				OnPropertyChanged( nameof( Telefono ) );
			}
		}
		public string Calificacion
		{
			get { return calificacion; }
			set
			{
				calificacion = value;
				OnPropertyChanged( nameof( Calificacion ) );
			}
		}

		public PerfilViewModel()
		{
			requests = new UsuarioRequests();
			EliminarCuentaCommand = new EliminarCuentaCommand();
			NavigateModificarDatosCommand = new NavigateCommand< ModificarDatosPersonalesViewModel >(
											NavigationServiceCreator.GetInstance().CreateModificarDatosNavigationService() );
			GetUserFields();
		}

		private void GetUserFields()
		{
			if( LoginSession.GetInstance().Usuario != null )
			{
				SetUserFields();
			}
			else
			{
				requests.GetUsuarioInformation( LoginSession.GetInstance().ClaveUsuario, LoginSession.GetInstance().AccessToken ).ContinueWith( Task => 
				{
					if( Task.Exception == null )
					{
						LoginSession.GetInstance().Usuario = Task.Result;
						SetUserFields();
					}
				} );
			}
		}

		private void SetUserFields()
		{
			Nombres = LoginSession.GetInstance().Usuario.nombres;
			Apellidos = LoginSession.GetInstance().Usuario.apellidos;
			Correo = LoginSession.GetInstance().Usuario.correo_electronico;
			Usuario = LoginSession.GetInstance().Usuario.nombre_usuario;
			Telefono = LoginSession.GetInstance().Usuario.telefono;
			Calificacion = string.Format( "{0:N2}", LoginSession.GetInstance().Usuario.calificacion );
		}
	}
}
