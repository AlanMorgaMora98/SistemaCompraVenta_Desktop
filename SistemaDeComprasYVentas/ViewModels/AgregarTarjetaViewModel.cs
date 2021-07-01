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
	public class AgregarTarjetaViewModel : ViewModelBase
	{
		private StringValidator validator;
		private OutputMessages messages;
		private TarjetaRequests requests;
		public ICommand AgregarTarjetaCommand { get; set; }
		public ICommand NavigateTarjetaCommand { get; }

		private string nombre_tarjeta_habiente;
		private string numero;
		private string fecha_vencimiento;
		private string errorText;

		public string NombreTarjetaHabiente
		{
			get { return nombre_tarjeta_habiente; }
			set
			{
				nombre_tarjeta_habiente = value;
				IsNombreValid(nombre_tarjeta_habiente);
				((AgregarTarjetaCommand)AgregarTarjetaCommand).NombreTarjetaHabiente = nombre_tarjeta_habiente;
			}
		}

		public string NumeroTarjeta
		{
			get { return numero; }
			set
			{
				numero = value;
				IsNumeroValid(numero);
				((AgregarTarjetaCommand)AgregarTarjetaCommand).NumeroTarjeta = numero;
			}
		}

		public string FechaVencimiento
		{
			get { return fecha_vencimiento; }
			set
			{
				fecha_vencimiento = value;
				((AgregarTarjetaCommand)AgregarTarjetaCommand).FechaVencimiento = fecha_vencimiento;
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

		public AgregarTarjetaViewModel()
		{
			validator = new StringValidator();
			messages = new OutputMessages();
			AgregarTarjetaCommand = new AgregarTarjetaCommand();

			requests = new TarjetaRequests();
			NavigateTarjetaCommand = new NavigateCommand<TarjetasViewModel>(
											NavigationServiceCreator.GetInstance().CreateTarjetasNavigationService());
		}


		private void IsNombreValid(string nombre)
		{
			ErrorText = "";
			if (!string.IsNullOrEmpty(nombre) && !validator.IsNombreHabienteValid(nombre))
			{
				SetErrorMessage(messages.HabienteNoValido());
			}
		}

		private void IsNumeroValid(string numero)
		{
			ErrorText = "";
			if (!string.IsNullOrEmpty(numero) && !validator.IsNumeroTarjetaValid(numero))
			{
				SetErrorMessage(messages.NumeroTarjetaNoValido());
			}
		}

		private void SetErrorMessage(string errorText)
		{
			ErrorText = errorText;
		}
	}
}
