using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeComprasYVentas.Models;
using SistemaDeComprasYVentas.Enumerations;

namespace SistemaDeComprasYVentas.ViewModels
{
	public class BuscarPublicacionesViewModel : ViewModelBase
	{
		public List< Publicacion > PublicacionesTotales { get; set; }
		public List< Publicacion > PublicacionesFiltradas { get; set; }
		public List< Categoria > CriteriosFiltracion { get; set; }
	}
}
