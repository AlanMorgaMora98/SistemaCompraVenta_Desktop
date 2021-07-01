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
    public class AgregarTarjetaCommand : CommandBase
    {
        private TarjetaRequests request;
        public string NombreTarjetaHabiente { get; set; }
        public string NumeroTarjeta { get; set; }
        public string FechaVencimiento { get; set; }

        public AgregarTarjetaCommand()
        {
            request = new TarjetaRequests();
        }


        public override void Execute(object parameter)
        {
            request.RegistrarTarjeta(LoginSession.GetInstance().ClaveUsuario, LoginSession.GetInstance().AccessToken, CreateTarjeta()).ContinueWith(Task =>
            {
                if (Task.Exception == null)
                {
                    Tarjeta response = Task.Result;
                }
            });
        }
        
        private Tarjeta CreateTarjeta()
        {
            return new Tarjeta(0, LoginSession.GetInstance().ClaveUsuario, NombreTarjetaHabiente, NumeroTarjeta, FechaVencimiento, Enumerations.TipoTarjeta.debito);
        }
    }
}
