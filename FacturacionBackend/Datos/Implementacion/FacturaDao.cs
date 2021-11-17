using FacturacionBackend.Datos.Interfaces;
using FacturacionBackend.Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionBackend.Datos.Implementacion
{
    class FacturaDao : IFacturaDao
    {
        SqlConnection conexion = new SqlConnection(@"Data Source=DESKTOP-0JK85V6;Initial Catalog=db_facturacion;Integrated Security=True");

        public bool Login(string User, string Password)
        {
            bool b = false;
            try
            {
                SqlCommand cmd = new SqlCommand();
                conexion.Open();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_LOGIN";



                cmd.Parameters.AddWithValue("@USUARIO", User);
                cmd.Parameters.AddWithValue("@CONTRASENA", Password);

                SqlParameter param = new SqlParameter("@USUARIOS", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                if ((int)param.Value == 1) b = true;
            }
            catch (SqlException ex)
            {
                b = false;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open) conexion.Close();
            }
            return b;
        }

        public DataTable TraerCliente()
        {
            conexion.Open();

            DataTable tabla = new DataTable();
            SqlCommand cmd3 = new SqlCommand("SP_TRAER_CLIENTES", conexion);
            cmd3.CommandType = CommandType.StoredProcedure;
            tabla.Load(cmd3.ExecuteReader());
            conexion.Close();
            return tabla;
        }
        public DataTable TraerProductos()
        {
            conexion.Open();

            DataTable tabla = new DataTable();
            SqlCommand cmd3 = new SqlCommand("SP_TRAER_PRODUCTOS", conexion);
            cmd3.CommandType = CommandType.StoredProcedure;
            tabla.Load(cmd3.ExecuteReader());
            conexion.Close();
            return tabla;
        }

        public List<Producto> GetProductos()
        {
            List<Producto> lst = new List<Producto>();
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand("SP_CONSULTAR_PRODUCTOS", conexion);

            cmd2.CommandType = CommandType.StoredProcedure;

            DataTable table = new DataTable();
            table.Load(cmd2.ExecuteReader());

            conexion.Close();

            foreach (DataRow row in table.Rows)
            {
                Producto oProducto = new Producto();
                oProducto.IdProducto = Convert.ToInt32(row["id_producto"].ToString());
                oProducto.Nombre = row["descripcion"].ToString();
                oProducto.Precio = Convert.ToDouble(row["precio"].ToString());
                oProducto.Stock = Convert.ToInt32(row["stock"].ToString());


                lst.Add(oProducto);
            }

            return lst;
        }

        public double obtenerPrecio(int id)
        {
            double precio;
            conexion.Open();

            DataTable tabla = new DataTable();
            SqlCommand cmd3 = new SqlCommand("SP_OBTENER_PRECIO", conexion);
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.Parameters.AddWithValue("@id", id);
            tabla.Load(cmd3.ExecuteReader());

            precio = Convert.ToDouble(tabla.Rows[0]["precio"].ToString());

            //precio = Convert.ToDouble(cmd3.ExecuteReader());
            conexion.Close();
            //precio = Convert.ToDouble(tabla.Rows[0].ToString());
            return precio;
            
        }
        public bool GuardarFactura(Factura oFactura)
        {

            SqlTransaction transaccion = null;

            bool flag = true;
            try
            {
                conexion.Open();
                transaccion = conexion.BeginTransaction();

                SqlCommand cmdMaestro = new SqlCommand("SP_INSERTAR_FACTURA", conexion, transaccion);
                cmdMaestro.CommandType = CommandType.StoredProcedure;
                cmdMaestro.Parameters.AddWithValue("@cliente", oFactura.Cliente);
               // cmdMaestro.Parameters.AddWithValue("@fecha", oFactura.Fecha);
                cmdMaestro.Parameters.AddWithValue("@total", oFactura.Total);
                cmdMaestro.Parameters.AddWithValue("@metodo", oFactura.MetodoPago);


                SqlParameter param = new SqlParameter();
                param.ParameterName = "@nro_factura";
                param.SqlDbType = SqlDbType.Int;

                param.Direction = ParameterDirection.Output;
                cmdMaestro.Parameters.Add(param);
                cmdMaestro.ExecuteNonQuery();

                int nroFactura = (int)param.Value;
                //int nroDetalle = 0;

                foreach (DetalleFactura det in oFactura.Detalles)
                {
                    SqlCommand cmd = new SqlCommand("SP_INSERTAR_DETALLE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Transaction = transaccion;
                    cmd.Parameters.AddWithValue("@id_producto", det.Producto.IdProducto);
                    cmd.Parameters.AddWithValue("@cantidad ", det.Cantidad);
                    cmd.Parameters.AddWithValue("@precio ", det.CalcularSubTotal());
                    cmd.Parameters.AddWithValue("@NRO_FACTURA", nroFactura);
                    //cmd.Parameters.AddWithValue("@detalle", ++nroDetalle);
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand("SP_ACTUALIZAR_STOCK", conexion);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Transaction = transaccion;
                    cmd2.Parameters.AddWithValue("@id_producto", det.Producto.IdProducto);
                    cmd2.Parameters.AddWithValue("@cantidad ", det.Cantidad);
                    cmd2.ExecuteNonQuery();
                }

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

        public DataTable TraerMetodo()
        {
            conexion.Open();

            DataTable tabla = new DataTable();
            SqlCommand cmd3 = new SqlCommand("SP_TRAER_METODOS", conexion);
            cmd3.CommandType = CommandType.StoredProcedure;
            tabla.Load(cmd3.ExecuteReader());
            conexion.Close();
            return tabla;
        }



        public List<Factura> TraerConFiltros(List<Parametro> filtros)
        {
            List<Factura> lst = new List<Factura>();
            DataTable table = new DataTable();

            try
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("SP_CONSULTAR_FACTURAS", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (Parametro p in filtros)
                {
                    cmd.Parameters.AddWithValue(p.Nombre, p.Valor);
                }

                table.Load(cmd.ExecuteReader());
                //mappear los registros como objetos del dominio:

                foreach (DataRow row in table.Rows)
                {
                    //Por cada registro creamos un objeto del dominio
                    Factura oFactura = new Factura();
                    oFactura.NombreCliente = row["cliente"].ToString();
                    oFactura.Fecha = Convert.ToDateTime(row["fecha"].ToString());
                    oFactura.FacturaNro = Convert.ToInt32(row["factura_nro"].ToString());
                    oFactura.Total = Convert.ToDouble(row["total"].ToString());
                    oFactura.DescripcionMetodo = row["metodo_pago"].ToString();
                    //validar que fecha_baja no es null:
                    if (!row["fecha_baja"].Equals(DBNull.Value))
                        oFactura.FechaBaja = Convert.ToDateTime(row["fecha_baja"].ToString());

                    lst.Add(oFactura);
                }

                conexion.Close();
            }
            catch (SqlException)
            {
                lst = null;
            }
            return lst;
        }

        public bool Eliminar(int nro)
        {
             SqlTransaction t = null;
            int affected = 0;
            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();
                SqlCommand cmd = new SqlCommand("SP_REGISTRAR_BAJA_FACTURA", conexion, t);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@factura_nro", nro);
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
    }
}
