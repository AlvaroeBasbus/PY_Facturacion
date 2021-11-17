using Reportes.Datos.Implementacion;
using Reportes.Datos.Interfaces;
using Reportes.Dominio;
using Reportes.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reportes.Servicios.Implementacion
{
  public  class FacturaService : IService
    {
        private IFacturaDao facturaDao;

        public FacturaService()
        {
            facturaDao = new FacturaDao();
        }

        List<Factura> IService.TraerFacturas()
        {
            return facturaDao.TraerFacturas();
        }
    }
}
