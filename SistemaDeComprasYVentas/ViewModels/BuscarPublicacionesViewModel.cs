using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeComprasYVentas.Models;
using SistemaDeComprasYVentas.Enumerations;
using SistemaDeComprasYVentas.ApiRequests;
using SistemaDeComprasYVentas.AsyncViewModels;
using System.Collections.ObjectModel;

namespace SistemaDeComprasYVentas.ViewModels
{
	public class BuscarPublicacionesViewModel : ViewModelBase
	{
		private readonly BuscarPublicacionesAsyncViewModel _asyncViewModel;
		private List< Publicacion > publicacionesTotales;
		private ObservableCollection< Publicacion > publicacionesFiltradas;
		private bool tecnologiaChecked;
		private bool cocinaChecked;
		private bool juguetesYBebesChecked;
		private bool modaChecked;
		private bool deportesChecked;
		private bool herramientasChecked;
		private bool industriaYOficinaChecked;
		private bool accesoriosVehiculoChecked;
		private bool saludEquipoMedicoChecked;
		private bool bellezaCuidadoPersonalChecked;
		private bool calzadoChecked;
		private bool productosSustentablesChecked;
		private bool mascotasChecked;
		public List< Categoria > criteriosFiltracion;
		public string cadenaBusqueda;

		public List< Publicacion > PublicacionesTotales 
		{
			get { return publicacionesTotales; } 
			set
			{
				publicacionesTotales = value;
				FilterPublicaciones();
			}
		}

		public ObservableCollection< Publicacion > PublicacionesFiltradas 
		{
			get { return publicacionesFiltradas; } 
			set
			{
				publicacionesFiltradas = value;
				OnPropertyChanged( nameof( PublicacionesFiltradas ) );
			}
		}

		public List< Categoria > CriteriosFiltracion 
		{
			get { return criteriosFiltracion; } 
			set
			{
				criteriosFiltracion = value;
				FilterPublicaciones();
			}
		}

		public string CadenaBusqueda
		{
			get { return cadenaBusqueda; }
			set 
			{ 
				cadenaBusqueda = value;
				FilterPublicaciones();
			}
		}

		public bool TecnologiaChecked
		{
			get { return tecnologiaChecked; }
			set
			{
				tecnologiaChecked = value;
				if( tecnologiaChecked )
				{
					AddFilterCriteria( Categoria.tecnologia );
				}
				else
				{
					RemoveFilterCriteria( Categoria.tecnologia );
				}
			}
		}

		public bool CocinaChecked
		{
			get { return cocinaChecked; }
			set
			{
				cocinaChecked = value;
				if( cocinaChecked )
				{
					AddFilterCriteria( Categoria.cocina );
				}
				else
				{
					RemoveFilterCriteria( Categoria.cocina );
				}
			}
		}

		public bool JuguetesYBebesChecked
		{
			get { return juguetesYBebesChecked; }
			set
			{
				juguetesYBebesChecked = value;
				if( juguetesYBebesChecked )
				{
					AddFilterCriteria( Categoria.juguetesYBebes );
				}
				else
				{
					RemoveFilterCriteria( Categoria.juguetesYBebes );
				}
			}
		}

		public bool ModaChecked
		{
			get { return modaChecked; }
			set
			{
				modaChecked = value;
				if( modaChecked )
				{
					AddFilterCriteria( Categoria.moda );
				}
				else
				{
					RemoveFilterCriteria( Categoria.moda );
				}
			}
		}

		public bool DeportesChecked
		{
			get { return deportesChecked; }
			set
			{
				deportesChecked = value;
				if( deportesChecked )
				{
					AddFilterCriteria( Categoria.deportes );
				}
				else
				{
					RemoveFilterCriteria( Categoria.deportes );
				}
			}
		}

		public bool HerramientasChecked
		{
			get { return herramientasChecked; }
			set
			{
				herramientasChecked = value;
				if( herramientasChecked )
				{
					AddFilterCriteria( Categoria.herramientas );
				}
				else
				{
					RemoveFilterCriteria( Categoria.herramientas );
				}
			}
		}

		public bool IndustriaYOficinasChecked
		{
			get { return industriaYOficinaChecked; }
			set
			{
				industriaYOficinaChecked = value;
				if( industriaYOficinaChecked )
				{
					AddFilterCriteria( Categoria.industriasYOficina );
				}
				else
				{
					RemoveFilterCriteria( Categoria.industriasYOficina );
				}
			}
		}

		public bool AccesoriosVehiculoChecked
		{
			get { return accesoriosVehiculoChecked; }
			set
			{
				accesoriosVehiculoChecked = value;
				if( accesoriosVehiculoChecked )
				{
					AddFilterCriteria( Categoria.accesoriosParaVehiculos );
				}
				else
				{
					RemoveFilterCriteria( Categoria.accesoriosParaVehiculos );
				}
			}
		}

		public bool SaludEquipoMedicoChecked
		{
			get { return saludEquipoMedicoChecked; }
			set
			{
				saludEquipoMedicoChecked = value;
				if( saludEquipoMedicoChecked )
				{
					AddFilterCriteria( Categoria.saludEquipoMedico );
				}
				else
				{
					RemoveFilterCriteria( Categoria.saludEquipoMedico );
				}
			}
		}

		public bool BellezaCuidadoPersonalChecked
		{
			get { return bellezaCuidadoPersonalChecked; }
			set
			{
				bellezaCuidadoPersonalChecked = value;
				if( bellezaCuidadoPersonalChecked )
				{
					AddFilterCriteria( Categoria.bellezaCuidadoPersonal );
				}
				else
				{
					RemoveFilterCriteria( Categoria.bellezaCuidadoPersonal );
				}
			}
		}

		public bool CalzadoChecked
		{
			get { return calzadoChecked; }
			set
			{
				calzadoChecked = value;
				if( calzadoChecked )
				{
					AddFilterCriteria( Categoria.calzado );
				}
				else
				{
					RemoveFilterCriteria( Categoria.calzado );
				}
			}
		}

		public bool ProductosSustentablesChecked
		{
			get { return productosSustentablesChecked; }
			set
			{
				productosSustentablesChecked = value;
				if( productosSustentablesChecked )
				{
					AddFilterCriteria( Categoria.productosSustentables );
				}
				else
				{
					RemoveFilterCriteria( Categoria.productosSustentables );
				}
			}
		}

		public bool MascotasChecked
		{
			get { return mascotasChecked; }
			set
			{
				mascotasChecked = value;
				if( mascotasChecked )
				{
					AddFilterCriteria( Categoria.mascotas );
				}
				else
				{
					RemoveFilterCriteria( Categoria.mascotas );
				}
			}
		}

		public BuscarPublicacionesViewModel()
		{
			PublicacionesTotales = new List< Publicacion >();
			PublicacionesFiltradas = new ObservableCollection< Publicacion >();
			CriteriosFiltracion = new List< Categoria >();
			_asyncViewModel = BuscarPublicacionesAsyncViewModel.CargarPublicaciones();
		}

		public void FilterPublicaciones()
		{
			if( _asyncViewModel != null )
			{
				if( CriteriosFiltracion.Count() != 0 )
				{
					FilterPublicacionesByBusqueda( FilterPublicacionesByCriterio() );
				}
				else
				{
					FilterPublicacionesByBusqueda( GetMainListAsObservableList( _asyncViewModel.PublicacionesTotales ) );
				}
			}
		}

		private ObservableCollection< Publicacion > FilterPublicacionesByCriterio()
		{
			ObservableCollection< Publicacion > publicacionesFiltradas = new ObservableCollection< Publicacion >(); 
			for( int currentPublicacion = 0; currentPublicacion < _asyncViewModel.PublicacionesTotales.Count(); currentPublicacion++ )
			{
				bool publicacionAgregada = false;
				for( int currentCriterio = 0; currentCriterio < CriteriosFiltracion.Count(); currentCriterio++ )
				{
					if (!publicacionAgregada &&
						_asyncViewModel.PublicacionesTotales[ currentPublicacion ].Categoria == CriteriosFiltracion[ currentCriterio ] )
					{
						publicacionAgregada = true;
						publicacionesFiltradas.Add( _asyncViewModel.PublicacionesTotales[ currentPublicacion ] );
					}
				}
			}
			return publicacionesFiltradas;
		}

		private void FilterPublicacionesByBusqueda( ObservableCollection< Publicacion > publicacionesEntrada )
		{
			ObservableCollection< Publicacion > publicacionesFiltradasBusqueda = new ObservableCollection< Publicacion >();
			if( !CadenaBusqueda.Equals( "" ) )
			{
				for( int currentPublicacion = 0; currentPublicacion < publicacionesEntrada.Count(); currentPublicacion++ )
				{
					bool publicacionAgregada = false;
					if( !publicacionAgregada &&
						publicacionesEntrada[ currentPublicacion ].Nombre.Contains( CadenaBusqueda ) )
					{
						publicacionAgregada = true;
						publicacionesFiltradasBusqueda.Add( publicacionesEntrada[ currentPublicacion ] );
					}
				}
				PublicacionesFiltradas = publicacionesFiltradasBusqueda;
			}
			else
			{
				PublicacionesFiltradas = publicacionesEntrada;
			}
		}

		private ObservableCollection< Publicacion > GetMainListAsObservableList( List< Publicacion > listaEntrada )
		{
			ObservableCollection< Publicacion > listaObservable = new ObservableCollection< Publicacion >();
			foreach( Publicacion publicacion in listaEntrada )
			{
				listaObservable.Add( publicacion );
			}
			return listaObservable;
		}

		private void AddFilterCriteria( Categoria categoriaIn )
		{
			CriteriosFiltracion = GetNewAddedCriteriaList( CriteriosFiltracion, categoriaIn );
		}

		private void RemoveFilterCriteria( Categoria categoriaOut )
		{
			CriteriosFiltracion = GetNewRemovedCriteriaList( CriteriosFiltracion, categoriaOut );
		}

		private List< Categoria > GetNewAddedCriteriaList( List< Categoria > currentList, Categoria newValue )
		{
			List< Categoria > nuevaLista = currentList;
			nuevaLista.Add( newValue );
			return nuevaLista;
		}

		private List< Categoria > GetNewRemovedCriteriaList( List< Categoria > currentList, Categoria newValue )
		{
			List< Categoria > nuevaLista = currentList;
			nuevaLista.Remove( newValue );
			return nuevaLista;
		}
	}
}
