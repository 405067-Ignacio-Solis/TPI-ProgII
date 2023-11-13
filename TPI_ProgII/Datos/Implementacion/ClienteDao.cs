using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Back.Entidades;
using Back.Datos.Interfaz;

namespace Back.Datos.Implementacion
{
    public class ClienteDao : IClienteDao
    {
        public bool ActualizarCliente(Ticket oTicket)
        {
            throw new NotImplementedException();
        }

        public bool BorrarCliente(int numero)
        {
            throw new NotImplementedException();
        }

        public bool CrearCliente(Ticket oTicket)
        {
            bool resultado = true;
            SqlConnection conexion = HelperDao.ObtenerInstancia().ObtenerConexion();
            SqlTransaction t = null;
            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.Transaction = t;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_INSERTAR_MAESTRO (esta hecho?)";
                //parametros a hacer
                SqlParameter parametro = new SqlParameter();
                parametro.ParameterName = "@ticket_nro";
                parametro.SqlDbType = SqlDbType.Int;
                parametro.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parametro);

                comando.ExecuteNonQuery();

                int ticketNro = (int)parametro.Value;
                int detalleNro = 1;
                SqlCommand cmdDetalle;

                foreach (DetalleTicket dp in oTicket.Detalle)
                {
                    cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLE (esta hecho?)", conexion, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    //parametros a hacer
                    cmdDetalle.ExecuteNonQuery();
                    detalleNro++;
                }
                t.Commit();
            }
            catch
            {
                if (t != null)
                    t.Rollback();
                resultado = false;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            return resultado;
        }
    }
}
