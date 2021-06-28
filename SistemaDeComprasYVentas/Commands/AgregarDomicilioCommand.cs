using SistemaDeComprasYVentas.ApiRequests;
using SistemaDeComprasYVentas.Models;
using SistemaDeComprasYVentas.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.Commands
{
    public class AgregarDomicilioCommand : CommandBase
	{
		private DomicilioRequests request; 
		public string CodigoPostal { get; set; }
		public string Estado { get; set; }
		public string Municipio { get; set; }
		public string Colonia { get; set; }
		public string Direccion { get; set; }
		public int NumInterno { get; set; }
		public int NumExterno { get; set; }
		public string Descripcion { get; set; }

		public AgregarDomicilioCommand()
		{
			request = new DomicilioRequests();
		}

		public override void Execute(object parameter)
		{
			request.RegistrarDomicilio(LoginSession.GetInstance().ClaveUsuario, LoginSession.GetInstance().AccessToken, CreateDomicilio()).ContinueWith(Task =>
			{
				if (Task.Exception == null)
				{
					Domicilio response = Task.Result;
				}
			});
		}

		private Domicilio CreateDomicilio()
		{
			return new Domicilio(0, LoginSession.GetInstance().ClaveUsuario, Direccion, Colonia, Municipio, CodigoPostal, Estado,
								NumInterno, NumExterno, Descripcion);
		}
	}
}
