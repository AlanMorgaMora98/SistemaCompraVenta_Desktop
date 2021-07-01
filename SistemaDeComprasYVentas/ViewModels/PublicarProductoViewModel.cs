using SistemaDeComprasYVentas.ApiRequests;
using SistemaDeComprasYVentas.Commands;
using SistemaDeComprasYVentas.Enumerations;
using SistemaDeComprasYVentas.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SistemaDeComprasYVentas.ViewModels
{
	public class PublicarProductoViewModel : ViewModelBase
	{
		private StringValidator validator;
		private OutputMessages messages;
		private PublicacionesRequests requests;
		public ICommand PublicarProductoCommand { get; set; }
		public ICommand NavigatePublicacionCommand { get; }
		

		private string nombre;
		private string descripcion;
		private double precio;
		private Categoria categoria;
		private List<string> categorias;
		private int cantidad_disponible;
		private string unidad_medida;
		private string imagen;
		private string errorText;
		private string seleccionCategory ;

		private Categoria regresarCategoria(string category)
        {
			Categoria categoriaSeleccionada = Categoria.mascotas;
			if (category.Equals("tecnologia"))
				categoriaSeleccionada = Categoria.tecnologia;
			if(category.Equals("cocina"))
				categoriaSeleccionada = Categoria.cocina;
			if (category.Equals("hogar"))
				categoriaSeleccionada = Categoria.hogar;
			if (category.Equals("juguetesYBebes"))
				categoriaSeleccionada = Categoria.juguetesYBebes;
			if (category.Equals("moda"))
				categoriaSeleccionada = Categoria.moda;
			if (category.Equals("deportes"))
				categoriaSeleccionada = Categoria.deportes;
			if (category.Equals("herramientas"))
				categoriaSeleccionada = Categoria.herramientas;
			if (category.Equals("industriasYOficina"))
				categoriaSeleccionada = Categoria.industriasYOficina;
			if (category.Equals("accesoriosParaVehiculos"))
				categoriaSeleccionada = Categoria.accesoriosParaVehiculos;
			if (category.Equals("saludEquipoMedico"))
				categoriaSeleccionada = Categoria.saludEquipoMedico;
			if (category.Equals("bellezaCuidadoPersonal"))
				categoriaSeleccionada = Categoria.bellezaCuidadoPersonal;
			if (category.Equals("calzado"))
				categoriaSeleccionada = Categoria.calzado;
			if (category.Equals("productosSustentables"))
				categoriaSeleccionada = Categoria.productosSustentables;
			if (category.Equals("mascotas"))
				categoriaSeleccionada = Categoria.mascotas;
				return categoriaSeleccionada;
        }

		public string seleccion { get { return seleccionCategory; } 
			set 
			{ 
				seleccionCategory = value;
				((PublicarProductoCommand)PublicarProductoCommand).categoria = regresarCategoria(seleccionCategory);
			} 
		}

		public string NombrePublicacion
		{
			get { return nombre; }
			set
			{
				nombre = value;
				IsNombreValid(nombre);
				((PublicarProductoCommand)PublicarProductoCommand).NombrePublicacion = nombre;
			}
		}

		public string Descripcion
		{
			get { return descripcion; }
			set
			{
				descripcion = value;
				IsDescripcionValid(descripcion);
				((PublicarProductoCommand)PublicarProductoCommand).Descripcion = descripcion;
			}
		}

		public double Precio
		{
			get { return precio; }
			set
			{
				precio = value;
				IsPrecioValid(precio);
				((PublicarProductoCommand)PublicarProductoCommand).Precio = precio;
			}
		}

		public int Cantidad
		{
			get { return cantidad_disponible; }
			set
			{
				cantidad_disponible = value;

				((PublicarProductoCommand)PublicarProductoCommand).Cantidad = cantidad_disponible;
			}
		}

		public string UnidadMedida
		{
			get { return unidad_medida; }
			set
			{
				unidad_medida = value;
				IsUnidadMedidaValid(unidad_medida);
				((PublicarProductoCommand)PublicarProductoCommand).UnidadMedida = unidad_medida;
			}
		}

		public string Imagen
		{
			get { return imagen; }
			set
			{
				imagen = value;
				((PublicarProductoCommand)PublicarProductoCommand).Imagen = imagen;
			}
		}

		public List<string> listaCategorias 
		{
			get { return categorias; }
			set
			{
				categorias = value;
				OnPropertyChanged(nameof(listaCategorias));
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

		public PublicarProductoViewModel()
		{
			listaCategorias = new List<string> { "tecnologia", "cocina", "hogar", "juguetesYBebes", "moda", "deportes", "herramientas", "industriasYOficina", "accesoriosParaVehiculos",
				"saludEquipoMedico", "bellezaCuidadoPersonal", "calzado", "productosSustentables", "mascotas"};

			validator = new StringValidator();
			messages = new OutputMessages();
			PublicarProductoCommand = new PublicarProductoCommand();

			requests = new PublicacionesRequests();
			NavigatePublicacionCommand = new NavigateCommand<PublicacionesViewModel>(
											NavigationServiceCreator.GetInstance().CreatePublicacionesNavigaionService());
		}

		private void IsNombreValid(string nombre)
		{
			ErrorText = "";
			if (!string.IsNullOrEmpty(nombre) && !validator.IsNombrePublicacionValid(nombre))
			{
				SetErrorMessage(messages.NombrePublicacionNoValido());
			}
		}

		private void IsDescripcionValid(string descripcion)
		{
			ErrorText = "";
			if (!string.IsNullOrEmpty(descripcion) && !validator.IsDescripcionPublicacionValid(descripcion))
			{
				SetErrorMessage(messages.DescripcionNoValida());
			}
		}
		
		private void IsPrecioValid(double precio)
		{
			ErrorText = "";
			if (!validator.IsCodigoPostalValid(descripcion))
			{
				SetErrorMessage(messages.PrecioPublicacionNoValido());
			}
		}

		private void IsUnidadMedidaValid(string cantidad)
		{
			ErrorText = "";
			if (!string.IsNullOrEmpty(cantidad) && !validator.IsCodigoPostalValid(cantidad))
			{
				SetErrorMessage(messages.CodigoPostalNoValido());
			}
		}

		private void SetErrorMessage(string errorText)
		{
			ErrorText = errorText;
		}
	}
}
