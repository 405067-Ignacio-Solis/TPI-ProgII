using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Entidades
{
    public class Funcion
    {
        public int NroFuncion { get; set; }
        public DateTime Fecha { get; set; }

        public Funcion()
        {
            NroFuncion = 0;
            Fecha = DateTime.Now;
        }

        public Funcion(int nroFuncion, DateTime fecha)
        {
            NroFuncion = nroFuncion;
            Fecha = fecha;
        }

        public override string ToString()
        {
            return NroFuncion.ToString() + ' ' + Fecha;
        }
    }
}
