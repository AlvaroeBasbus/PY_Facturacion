using System;
using System.Collections.Generic;
using System.Text;

namespace FacturacionBackend
{
   public class Clientes
    {
        public int idCliente { get; set; }
        public int DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public string Domicilio { get; set; }

        public string Condicion { get; set; }
        

        public Clientes()
        {

        }


    }
}
