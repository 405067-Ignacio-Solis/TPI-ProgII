using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Entidades
{
    public class DetalleTicket
    {
        public Cliente Cliente { get; set; }
        public int Precio_Unitario { get; set; }

        public DetalleTicket(Cliente cliente, int pre_unit)
        {
            Cliente = cliente;
            Precio_Unitario = pre_unit;
        }

        //calcular sub total (?
    }
}
