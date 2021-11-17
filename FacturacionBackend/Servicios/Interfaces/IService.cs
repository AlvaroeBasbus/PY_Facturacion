using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionBackend.Servicios.Servicios
{
   public interface IService
    {
        bool Login(string User, string Password);

        DataTable TraerCliente();

        DataTable TraerMetodo();
        DataTable TraerProductos();

        double obtenerPrecio(int id);
        List<Producto> GetProductos();
        bool GuardarFactura(Factura oFactura);

        List<Factura> ConsultarFacturas(List<Parametro> filtros);

        bool RegistrarBajaFactura(int factura);
    }
}
