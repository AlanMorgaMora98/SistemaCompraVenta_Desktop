using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.Commands
{
	public class LoginCommand : CommandBase
	{
		private 
		public string Usuario { get; set; }
		public SecureString Contrasena { get; set; }

		public override void Execute( object parameter )
		{

		}
	}
}
