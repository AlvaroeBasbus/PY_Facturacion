using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionBackend.Servicios.Interfaces
{
   public interface IClienteService
    {
        List<Clientes> ConsultarCliente();

        bool GrabarCliente(Clientes oCliente);

        bool EliminarCliente(int id);

        bool ActualizarCliente(Clientes oCliente);

        DataTable TraerCondicion();
    }
}
