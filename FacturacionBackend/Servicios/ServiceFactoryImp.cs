using FacturacionBackend.Servicios.Implementacion;
using FacturacionBackend.Servicios.Interfaces;
using FacturacionBackend.Servicios.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionBackend.Servicios
{
    public class ServiceFactoryImp : AbstractServiceFactory
    {
        public override IService CrearCarreraService()
        {
            return new FacturaService();
        }
        public override IProductoService CrearProductoService()
        {
            return new ProductoService();
        }
        public override IClienteService CrearClienteService()
        {
            return new ClienteService();
        }
    }
}
