using Reportes.Dominio;
using Reportes.Datos.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Reportes.Datos.Implementacion
{
    class FacturaDao : IFacturaDao
    {
        SqlConnection conexion = new SqlConnection(@"Data Source=DESKTOP-0JK85V6;Initial Catalog=db_facturacion;Integrated Security=True");
      
        List<Factura> IFacturaDao.TraerFacturas()
        {
            List<Factura> lst = new List<Factura>();
            DataTable table = new DataTable();

            try
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("SP_CONSULTAR_FACTURASR", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                // cmd.Parameters.AddWithValue(p.Nombre, p.Valor);

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
    }
}
