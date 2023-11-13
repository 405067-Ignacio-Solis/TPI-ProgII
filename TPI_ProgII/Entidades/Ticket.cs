using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Back.Datos.Interfaz;

namespace Back.Entidades
{
    public class Ticket
    {
        public int NroTicket { get; set; }
        public int NroCliente { get; set; }
        public DateTime Fecha { get; set; }
        public List<DetalleTicket> Detalle { get; set; }

        public Ticket()
        {
            Detalle = new List<DetalleTicket>();
        }

        public void AgregarDetalle(DetalleTicket detalle)
        {
            Detalle.Add(detalle);
        }

        public void QuitarDetalle(int posicion)
        {
            Detalle.RemoveAt(posicion);
        }

        //metodos para calcular sub total y total (?
    }
}
