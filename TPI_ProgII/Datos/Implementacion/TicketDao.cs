using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Back.Datos.Interfaz;
using Back.Entidades;

namespace Back.Datos.Implementacion
{
    public class TicketDao : ITicketDao
    {
        public bool ActualizarTicket(Ticket oTicket)
        {
            throw new NotImplementedException();
        }

        public bool BorrarTicket(int numero)
        {
            throw new NotImplementedException();
        }

        public bool CrearTicket(Ticket oTicket)
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

        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> lClientes = new List<Cliente>();
            DataTable tabla = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_CLIENTES"); //esta hecho el sp?
            //mapear un registro de la tabla a un objeto del modelo de dominio
            foreach (DataRow fila in tabla.Rows)
            {

            }
            return lClientes;
        }

        public List<Funcion> ObtenerFunciones()
        {
            List<Funcion> lFunciones = new List<Funcion>();
            DataTable tabla = HelperDao.ObtenerInstancia().Consultar("SP_CONSULTAR_FUNCIONES"); //esta hecho el sp?
            //mapear un registro de la tabla a un objeto del modelo de dominio
            foreach (DataRow fila in tabla.Rows)
            {

            }
            return lFunciones;
        }

        public int ObtenerProximoTicket()
        {
            return HelperDao.ObtenerInstancia().ConsultarEscalar("SP_PROXIMO_TICKET (esta hecho?)", "@next");
        }

        public Ticket ObtenerTicketPorNro(int numero)
        {
            //hace falta? para que era?
            throw new NotImplementedException();
        }

        public List<Ticket> ObtenerTicketsPorFiltros(List<Parametro> lFiltros)
        {
            //hace falta? para que era?
            throw new NotImplementedException();
        }
    }
}
