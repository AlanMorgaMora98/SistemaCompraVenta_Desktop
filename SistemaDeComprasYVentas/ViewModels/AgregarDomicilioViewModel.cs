using SistemaDeComprasYVentas.ApiRequests;
using SistemaDeComprasYVentas.Commands;
using SistemaDeComprasYVentas.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SistemaDeComprasYVentas.ViewModels
{
	public class AgregarDomicilioViewModel : ViewModelBase
	{
		private DomicilioRequests requests;
		public ICommand AgregarDomicilioCommand { get; set; }
		public ICommand NavigateDomicilioCommand { get; }
		public ICommand CancelarDomicilioCommand { get; }

		private string codigo_postal;
		private string estado;
		private string municipio;
		private string colonia;
		private string direccion;
		private int numero_interno;
		private int numero_externo;
		private string descripcion;

		public string CodigoPostal
		{
			get { return codigo_postal; }
			set
			{
				codigo_postal = value;
				((AgregarDomicilioCommand)AgregarDomicilioCommand).CodigoPostal = codigo_postal;
			}
		}

		public string Estado
		{
			get { return estado; }
			set
			{
				estado = value;
				((AgregarDomicilioCommand)AgregarDomicilioCommand).Estado = estado;
			}
		}

		public string Municipio
		{
			get { return municipio; }
			set
			{
				municipio = value;
				((AgregarDomicilioCommand)AgregarDomicilioCommand).Municipio = municipio;
			}
		}

		public string Colonia
		{
			get { return colonia; }
			set
			{
				colonia = value;
				((AgregarDomicilioCommand)AgregarDomicilioCommand).Colonia = colonia;
			}
		}

		public string Direccion
		{
			get { return direccion; }
			set
			{
				direccion = value;
				((AgregarDomicilioCommand)AgregarDomicilioCommand).Direccion = direccion;
			}
		}

		public int NumInterno
		{
			get { return numero_interno; }
			set
			{
				numero_interno = value;
				((AgregarDomicilioCommand)AgregarDomicilioCommand).NumInterno = numero_interno;
			}
		}

		public int NumExterno
		{
			get { return numero_externo; }
			set
			{
				numero_externo = value;
				((AgregarDomicilioCommand)AgregarDomicilioCommand).NumExterno = numero_externo;
			}
		}

		public string Descripcion
		{
			get { return descripcion; }
			set
			{
				descripcion = value;
				((AgregarDomicilioCommand)AgregarDomicilioCommand).Descripcion = descripcion;
			}
		}

		public AgregarDomicilioViewModel()
		{
			AgregarDomicilioCommand = new AgregarDomicilioCommand();

			requests = new DomicilioRequests();
			NavigateDomicilioCommand = new NavigateCommand<DomiciliosViewModel>(
											NavigationServiceCreator.GetInstance().CreateDomicilioNavigationService());
		}
	}
}
