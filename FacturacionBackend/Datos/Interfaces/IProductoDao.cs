using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionBackend.Datos.Interfaces
{
    public interface IProductoDao
    {
        List<Producto> GetProducto();

        bool Guardar(Producto oProducto);

        bool ActualizarProducto(Producto oProducto);
        bool EliminarProducto(int id);


    }
}
