using FacturacionBackend.Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionBackend.Datos.Interfaces
{
    interface IFacturaDao
    {

        bool Login(string User, string Password);
        DataTable TraerCliente();

        DataTable TraerProductos();

        List<Factura> TraerConFiltros(List<Parametro> filtros);
        DataTable TraerMetodo();
        List<Producto> GetProductos();
        double obtenerPrecio(int id);

        bool GuardarFactura(Factura oFactura);

        bool Eliminar(int nro);
    }
}
