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
    class ProductoDao : IProductoDao
    {
        SqlConnection conexion = new SqlConnection(@"Data Source=DESKTOP-0JK85V6;Initial Catalog=db_facturacion;Integrated Security=True");

        public bool ActualizarProducto(Producto oProducto)
        {
            SqlTransaction transaccion = null;

            bool flag = true;
            try
            {
                conexion.Open();

                transaccion = conexion.BeginTransaction();

                SqlCommand cmdMaestro = new SqlCommand("SP_ACTUALIZAR_PRODUCTO", conexion, transaccion);
                cmdMaestro.CommandType = CommandType.StoredProcedure;
                cmdMaestro.Parameters.AddWithValue("@id", oProducto.IdProducto);
                cmdMaestro.Parameters.AddWithValue("@descripcion", oProducto.Nombre);
                cmdMaestro.Parameters.AddWithValue("@precio", oProducto.Precio);
                cmdMaestro.Parameters.AddWithValue("@stock", oProducto.Stock);
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

        public bool EliminarProducto(int id)
        {
            SqlTransaction t = null;
            int affected = 0;
            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();
                SqlCommand cmd = new SqlCommand("SP_ELIMINAR_PRODUCTO", conexion, t);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_producto", id);
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

        public List<Producto> GetProducto()
        {
            List<Producto> productos = new List<Producto>();
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_CONSULTAR_PRODUCTOS", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            conexion.Close();

            foreach (DataRow row in tabla.Rows)
            {
                Producto oProducto = new Producto();
                oProducto.IdProducto = Convert.ToInt32(row["id_producto"].ToString());
                oProducto.Nombre = row["descripcion"].ToString();
                oProducto.Precio = Convert.ToDouble(row["precio"].ToString());
                oProducto.Stock = Convert.ToInt32(row["stock"].ToString());
                productos.Add(oProducto);
            }
            return productos;
        }

        public bool Guardar(Producto oProducto)
        {
            SqlTransaction transaccion = null;

            bool flag = true;
            try
            {
                conexion.Open();
                
                transaccion = conexion.BeginTransaction();

                SqlCommand cmdMaestro = new SqlCommand("SP_INSERTAR_PRODUCTO", conexion, transaccion);
                cmdMaestro.CommandType = CommandType.StoredProcedure;
                cmdMaestro.Parameters.AddWithValue("@descripcion", oProducto.Nombre);
                cmdMaestro.Parameters.AddWithValue("@precio", oProducto.Precio);
                cmdMaestro.Parameters.AddWithValue("@stock", oProducto.Stock);
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
    }
    }

