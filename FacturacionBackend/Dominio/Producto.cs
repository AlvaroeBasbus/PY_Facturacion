using System;
using System.Collections.Generic;
using System.Text;

namespace FacturacionBackend
{
    public class Producto : Object
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        public int SelectedValue { get; }
        public string V { get; }

        public Producto()
        {

        }

        public Producto(int selectedValue, string v)
        {
            SelectedValue = selectedValue;
            V = v;
        }

        public override string ToString()
        {

            return IdProducto.ToString() + "-" + Nombre;

        }
    }
}
