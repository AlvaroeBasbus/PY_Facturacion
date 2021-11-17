using FacturacionBackend.Datos.Implementacion;
using FacturacionBackend.Datos.Interfaces;
using FacturacionBackend.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionBackend.Servicios.Implementacion
{
    public class ProductoService : IProductoService
    {
        private IProductoDao dao;
        public ProductoService()
        {
            dao = new ProductoDao();
        }

        public bool ActualizarProducto(Producto oProducto)
        {
            return dao.ActualizarProducto(oProducto);
        }

        public List<Producto> ConsultarProducto()
        {
            return dao.GetProducto();
        }

        public bool EliminarProducto(int id)
        {
            return dao.EliminarProducto(id);
        }

        public bool GrabarProducto(Producto oProducto)
        {
            return dao.Guardar(oProducto);
        }
    }
}
