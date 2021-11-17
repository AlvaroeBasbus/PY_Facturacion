using System;
using System.Collections.Generic;
using System.Text;

namespace FacturacionBackend
{
    public class DetalleFactura
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }

        public DetalleFactura()
        {
            Producto = new Producto();
            Cantidad = 0;
        }
        public double CalcularSubTotal()
        {
            return Math.Round(Producto.Precio * Cantidad,2);
        }
    }
}
