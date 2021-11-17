﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionBackend.Servicios
{
   public class Parametro
    {

        public Parametro()
        {

        }

        public string Nombre { get; set; }
        public object Valor { get; set; }

        public int id { get; set; }
   

        public Parametro(string nombre, object valor)
        {
            Nombre = nombre;
            Valor = valor;
        }
    }
}
