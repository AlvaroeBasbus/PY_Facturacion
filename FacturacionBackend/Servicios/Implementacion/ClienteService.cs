using FacturacionBackend.Datos.Implementacion;
using FacturacionBackend.Datos.Interfaces;
using FacturacionBackend.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionBackend.Servicios.Implementacion
{
   public  class ClienteService : IClienteService
    {
        private IClienteDao dao;

        public ClienteService()
        {
            dao = new ClienteDao();
        }
        public bool ActualizarCliente(Clientes oCliente)
        {
            return dao.ActualizarCliente(oCliente);
        }

        public List<Clientes> ConsultarCliente()
        {
            return dao.ConsultarCliente();
        }

        public bool EliminarCliente(int id)
        {
            return dao.EliminarCliente(id);
        }

        public bool GrabarCliente(Clientes oCliente)
        {
            return dao.GrabarCliente(oCliente);
        }

        public DataTable TraerCondicion()
        {
            return dao.TraerCondicion();
        }
    }
}
