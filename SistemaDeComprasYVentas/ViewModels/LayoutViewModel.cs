using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.ViewModels
{
	public class LayoutViewModel : ViewModelBase
	{
		public NavigationBarViewModel NavigationBarViewModel { get; }
		public ViewModelBase ContentViewModel;

		public LayoutViewModel( NavigationBarViewModel navigationBarViewModel, ViewModelBase contentViewModel )
		{
			NavigationBarViewModel = navigationBarViewModel;
			ContentViewModel = contentViewModel;
		}
	}
}
