using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeComprasYVentas.ViewModels;

namespace SistemaDeComprasYVentas.Services
{
	public interface INavigationService< TViewModel >
		where TViewModel : ViewModelBase
	{
		void Navigate();
	}
}
