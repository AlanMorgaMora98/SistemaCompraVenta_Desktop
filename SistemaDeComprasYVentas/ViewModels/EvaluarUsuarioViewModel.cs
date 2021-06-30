using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.ViewModels
{
	public class EvaluarUsuarioViewModel : ViewModelBase
	{
		public List< string > CalificacionValues { get; set; }

		public EvaluarUsuarioViewModel()
		{
			CalificacionValues = new List< string > { "1", "2", "3", "4", "5" };
		}
	}
}
