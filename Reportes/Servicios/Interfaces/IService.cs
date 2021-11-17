using Reportes.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reportes.Servicios.Interfaces
{
   public interface IService
    {

        List<Factura> TraerFacturas();
    }
}
