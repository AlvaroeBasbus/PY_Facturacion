using Reportes.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reportes.Datos.Interfaces
{
    public interface IFacturaDao
    {
        List<Factura> TraerFacturas();
    }
}
