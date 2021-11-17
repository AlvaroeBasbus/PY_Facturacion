using FacturacionBackend.Servicios.Interfaces;
using FacturacionBackend.Servicios.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionBackend.Servicios
{
   public abstract class AbstractServiceFactory
    {
        public abstract IService CrearCarreraService();
        public abstract IProductoService CrearProductoService();
        public abstract IClienteService CrearClienteService();
    }
}
