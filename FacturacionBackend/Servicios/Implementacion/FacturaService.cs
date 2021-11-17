using FacturacionBackend.Datos.Implementacion;
using FacturacionBackend.Datos.Interfaces;
using FacturacionBackend.Servicios.Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionBackend.Servicios.Implementacion
{
    public class FacturaService : IService
    {
        private IFacturaDao facturaDao;
        public FacturaService()
        {
            facturaDao = new FacturaDao();
        }

        public List<Factura> ConsultarFacturas(List<Parametro> filtros)
        {
            return facturaDao.TraerConFiltros(filtros);
        }

        public List<Producto> GetProductos()
        {
            return facturaDao.GetProductos();
        }

        public bool GuardarFactura(Factura oFactura)
        {
            return facturaDao.GuardarFactura(oFactura);
        }

        public bool Login(string User, string Password)
        {
            return facturaDao.Login(User, Password);
        }

        public double obtenerPrecio(int id)
        {
            return facturaDao.obtenerPrecio(id);
        }

        public bool RegistrarBajaFactura(int factura)
        {
            return facturaDao.Eliminar(factura);
        }

        public DataTable TraerCliente()
        {
            return facturaDao.TraerCliente();
        }

        public DataTable TraerMetodo()
        {
            return facturaDao.TraerMetodo();
        }

        public DataTable TraerProductos()
        {
            return facturaDao.TraerProductos();
        }
    }
}
