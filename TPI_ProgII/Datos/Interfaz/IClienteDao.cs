using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Back.Entidades;

namespace Back.Datos.Interfaz
{
    public interface IClienteDao
    {
        public bool ActualizarCliente(Ticket oTicket);
        public bool BorrarCliente(int numero);
        public bool CrearCliente(Ticket oTicket);
    }
}
