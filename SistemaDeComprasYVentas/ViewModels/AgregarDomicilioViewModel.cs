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
		private StringValidator validator;
		private OutputMessages messages;
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
		private string errorText;

		public string CodigoPostal
		{
			get { return codigo_postal; }
			set
			{
				codigo_postal = value;
				IsCodigoValid( codigo_postal );
				((AgregarDomicilioCommand)AgregarDomicilioCommand).CodigoPostal = codigo_postal;
			}
		}

		public string Estado
		{
			get { return estado; }
			set
			{
				estado = value;
				IsEstadoValid( estado );
				((AgregarDomicilioCommand)AgregarDomicilioCommand).Estado = estado;
			}
		}

		public string Municipio
		{
			get { return municipio; }
			set
			{
				municipio = value;
				IsMunicipioValid( municipio );
				((AgregarDomicilioCommand)AgregarDomicilioCommand).Municipio = municipio;
			}
		}

		public string Colonia
		{
			get { return colonia; }
			set
			{
				colonia = value;
				IsColoniaValid( colonia );
				((AgregarDomicilioCommand)AgregarDomicilioCommand).Colonia = colonia;
			}
		}

		public string Direccion
		{
			get { return direccion; }
			set
			{
				direccion = value;
				IsDireccionValid( direccion );
				((AgregarDomicilioCommand)AgregarDomicilioCommand).Direccion = direccion;
			}
		}

		public int NumInterno
		{
			get { return numero_interno; }
			set
			{
				numero_interno = value;
				IsNumInternoValid( numero_interno );
				((AgregarDomicilioCommand)AgregarDomicilioCommand).NumInterno = numero_interno;
			}
		}

		public int NumExterno
		{
			get { return numero_externo; }
			set
			{
				numero_externo = value;
				IsNumExternoValid( numero_externo );
				((AgregarDomicilioCommand)AgregarDomicilioCommand).NumExterno = numero_externo;
			}
		}

		public string Descripcion
		{
			get { return descripcion; }
			set
			{
				descripcion = value;
				IsDescripcionValid( descripcion );
				((AgregarDomicilioCommand)AgregarDomicilioCommand).Descripcion = descripcion;
			}
		}

		public string ErrorText
		{
			get { return errorText; }
			set
			{
				errorText = value;
				OnPropertyChanged(nameof(ErrorText));
			}
		}

		public AgregarDomicilioViewModel()
		{
			validator = new StringValidator();
			messages = new OutputMessages();
			AgregarDomicilioCommand = new AgregarDomicilioCommand();

			requests = new DomicilioRequests();
			NavigateDomicilioCommand = new NavigateCommand<DomiciliosViewModel>(
											NavigationServiceCreator.GetInstance().CreateDomicilioNavigationService());
		}

		private void IsCodigoValid(string codigo)
		{
			ErrorText = "";
			if (!string.IsNullOrEmpty(codigo) && !validator.IsCodigoPostalValid(codigo))
			{
				SetErrorMessage(messages.CodigoPostalNoValido());
			}
		}

		private void IsEstadoValid(string estado)
		{
			ErrorText = "";
			if (!string.IsNullOrEmpty(estado) && !validator.IsEstadoValid(estado))
			{
				SetErrorMessage(messages.EstadoNoValido());
			}
		}

		private void IsMunicipioValid(string municipio)
		{
			ErrorText = "";
			if (!string.IsNullOrEmpty(municipio) && !validator.IsMunicipioValid(municipio))
			{
				SetErrorMessage(messages.MunicipioNoValido());
			}
		}

		
		private void IsColoniaValid(string colonia)
		{
			ErrorText = "";
			if (!string.IsNullOrEmpty(colonia) && !validator.IsColoniaValid(colonia))
			{
				SetErrorMessage(messages.ColoniaNoValida());
			}
		}

		private void IsDireccionValid(string direccion)
		{
			ErrorText = "";
			if (!string.IsNullOrEmpty(direccion) && !validator.IsColoniaValid(direccion))
			{
				SetErrorMessage(messages.DireccionNoValida());
			}
		}

		private void IsNumInternoValid(int interno)
		{
			ErrorText = "";
			if (!validator.IsNumeroInternoValid(interno))
			{
				SetErrorMessage(messages.NumIntNoValido());
			}
		}

		private void IsNumExternoValid(int externo)
		{
			ErrorText = "";
			if (!validator.IsNumeroExternoValid(externo))
			{
				SetErrorMessage(messages.NumExtNoValido());
			}
		}

		private void IsDescripcionValid(string descripcion)
		{
			ErrorText = "";
			if (!string.IsNullOrEmpty(descripcion) && !validator.IsDescripcionValid(descripcion))
			{
				SetErrorMessage(messages.DescripcionNoValida());
			}
		}

		private void SetErrorMessage(string errorText)
		{
			ErrorText = errorText;
		}

	}
}
