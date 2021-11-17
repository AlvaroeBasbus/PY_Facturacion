using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionBackend.Servicios.Interfaces
{
    public interface IProductoService
    {
        List<Producto> ConsultarProducto();

        bool GrabarProducto(Producto oProducto);

        bool EliminarProducto(int id);

        bool ActualizarProducto(Producto oProducto);



    }
}
