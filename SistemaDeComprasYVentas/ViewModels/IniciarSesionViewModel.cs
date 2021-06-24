using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.ViewModels
{
	public class IniciarSesionViewModel : ViewModelBase
	{
		public string Usuario { get; set; }
		public SecureString Contrasena { private get; set; }
	}
}
