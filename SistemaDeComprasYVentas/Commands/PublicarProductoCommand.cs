using SistemaDeComprasYVentas.ApiRequests;
using SistemaDeComprasYVentas.Enumerations;
using SistemaDeComprasYVentas.Models;
using SistemaDeComprasYVentas.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComprasYVentas.Commands
{
    public class PublicarProductoCommand : CommandBase
    {
        private PublicacionesRequests requests;
		public string NombrePublicacion { get; set; }
		public string Descripcion { get; set; }
		public Categoria categoria { get; set; }
		public string Precio { get; set; }
		public string Cantidad { get; set; }
		public string UnidadMedida { get; set; }
		public string Imagen { get; set; }

		public PublicarProductoCommand()
        {
            requests = new PublicacionesRequests();
        }

		public override void Execute(object parameter)
		{
			requests.RegistrarPublicacion(LoginSession.GetInstance().ClaveUsuario, CreatePublicacion(), LoginSession.GetInstance().AccessToken).ContinueWith(Task =>
			{
				if (Task.Exception == null)
				{

				}
			});
		}

		private Publicacion CreatePublicacion()
		{
			return new Publicacion (0, NombrePublicacion, Descripcion, categoria, double.Parse( Precio ), int.Parse( Cantidad ), 0.0f, UnidadMedida, 0, Imagen);
		}
	}
}
