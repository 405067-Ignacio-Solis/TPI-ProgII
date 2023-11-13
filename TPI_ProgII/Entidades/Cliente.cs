using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Entidades
{
    public class Cliente
    {
        public string Nombre { get; set; }
        public string Apellido { get; set;}
        public tipoDocumento Documento { get; set; }

        public Cliente()
        {
            Nombre = string.Empty;
            Apellido = string.Empty;
            Documento = 0;
        }

        public Cliente(string nombre, string apellido, tipoDocumento documento)
        {
            Nombre = nombre;
            Apellido = apellido;
            Documento = documento;
        }

        public enum tipoDocumento 
        {
            Dni = 1,
            Pasaporte = 2,
            CedulaIdentidad = 3,
            LicenciaConducir = 4,
            TarjetaIdentificacion = 5,
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
