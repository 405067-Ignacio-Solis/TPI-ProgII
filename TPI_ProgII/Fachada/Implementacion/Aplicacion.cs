using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Back.Datos.Implementacion;
using Back.Datos.Interfaz;
using Back.Entidades;
using Back.Fachada.Interfaz;

namespace Back.Fachada.Implementacion
{
    public class Aplicacion : IAplicacion
    {
        private ITicketDao dao;
        public Aplicacion()
        {
            dao = new TicketDao();
        }
        public List<Cliente> GetClientes()
        {
            return dao.ObtenerClientes();
        }

        public List<Funcion> GetFunciones()
        {
            return dao.ObtenerFunciones();
        }

        public bool SaveTicket(Ticket oTicket)
        {
            return dao.CrearTicket(oTicket);
        }


    }
}
