using FacturacionBackend.Datos.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionBackend.Datos.Implementacion
{
    class ClienteDao : IClienteDao
    {
        SqlConnection conexion = new SqlConnection(@"Data Source=DESKTOP-0JK85V6;Initial Catalog=db_facturacion;Integrated Security=True");

        public bool ActualizarCliente(Clientes oCliente)
        {
            SqlTransaction transaccion = null;

            bool flag = true;
            try
            {
                conexion.Open();

                transaccion = conexion.BeginTransaction();

                SqlCommand cmdMaestro = new SqlCommand("SP_ACTUALIZAR_CLIENTE", conexion, transaccion);
                cmdMaestro.CommandType = CommandType.StoredProcedure;
                cmdMaestro.Parameters.AddWithValue("@id", oCliente.idCliente);
                cmdMaestro.Parameters.AddWithValue("@nombre", oCliente.Nombre);
                cmdMaestro.Parameters.AddWithValue("@apellido", oCliente.Apellido);
                cmdMaestro.Parameters.AddWithValue("@domicilio", oCliente.Domicilio);
                cmdMaestro.Parameters.AddWithValue("@documento", oCliente.DNI);
                cmdMaestro.Parameters.AddWithValue("@condicion", oCliente.Condicion);
                cmdMaestro.Parameters.AddWithValue("@correo", oCliente.Correo);
                cmdMaestro.Parameters.AddWithValue("@telefono", oCliente.Telefono);
                cmdMaestro.ExecuteNonQuery();
                transaccion.Commit();

            }
            catch
            {
                transaccion.Rollback();
                flag = false;

            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();

            }

            return flag;
        }

        public List<Clientes> ConsultarCliente()
        {

            List<Clientes> clientes = new List<Clientes>();
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_CONSULTAR_CLIENTES", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            conexion.Close();

            foreach (DataRow row in tabla.Rows)
            {
                Clientes oCliente = new Clientes();
                oCliente.idCliente = Convert.ToInt32(row["id_cliente"].ToString());
                oCliente.Nombre = row["nombre"].ToString();
                oCliente.Apellido = row["apellido"].ToString();
                oCliente.DNI = Convert.ToInt32(row["documento"].ToString());
                oCliente.Correo = row["correo"].ToString();
                oCliente.Telefono = Convert.ToInt32(row["telefono"].ToString());
                oCliente.Domicilio = row["domicilio"].ToString();
                oCliente.Condicion = row["condicion"].ToString();
                clientes.Add(oCliente);
            }
            return clientes;
            
        }


        public bool EliminarCliente(int id)
        {
            SqlTransaction t = null;
            int affected = 0;
            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();
                SqlCommand cmd = new SqlCommand("SP_ELIMINAR_CLIENTE", conexion, t);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                affected = cmd.ExecuteNonQuery();
                t.Commit();

            }
            catch (SqlException)
            {
                t.Rollback();
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }

            return affected == 1;
        }

        public bool GrabarCliente(Clientes oCliente)
        {
            SqlTransaction transaccion = null;

            bool flag = true;
            try
            {
                conexion.Open();

                transaccion = conexion.BeginTransaction();

                SqlCommand cmdMaestro = new SqlCommand("SP_INSERTAR_CLIENTE", conexion, transaccion);
                cmdMaestro.CommandType = CommandType.StoredProcedure;
                cmdMaestro.Parameters.AddWithValue("@nombre", oCliente.Nombre);
                cmdMaestro.Parameters.AddWithValue("@apellido", oCliente.Apellido);
                cmdMaestro.Parameters.AddWithValue("@domicilio", oCliente.Domicilio);
                cmdMaestro.Parameters.AddWithValue("@documento", oCliente.DNI);
                cmdMaestro.Parameters.AddWithValue("@correo", oCliente.Correo);
                cmdMaestro.Parameters.AddWithValue("@telefono", oCliente.Telefono);
                cmdMaestro.Parameters.AddWithValue("@condicion", oCliente.Condicion);
                cmdMaestro.ExecuteNonQuery();
                transaccion.Commit();

            }
            catch
            {
                transaccion.Rollback();
                flag = false;

            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();

            }

            return flag;

        }

        public DataTable TraerCondicion()
        {

            conexion.Open();

            
            DataTable tabla = new DataTable();
            SqlCommand cmd3 = new SqlCommand("SP_CONSULTAR_CONDICION_IVA", conexion);
            cmd3.CommandType = CommandType.StoredProcedure;
            tabla.Load(cmd3.ExecuteReader());
            conexion.Close();
            return tabla;
        }
    }
    }

