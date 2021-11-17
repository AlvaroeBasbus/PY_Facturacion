
using System;
using System.Collections.Generic;
using System.Text;

namespace Reportes.Dominio
{
    public class Factura
    {
        public int FacturaNro { get; set; }
        public DateTime Fecha { get; set; }

        public int Cliente { get; set; }
        public string NombreCliente { get; set; }

        public string DescripcionMetodo { get; set; }
        public DateTime FechaBaja { get; set; }

        public int MetodoPago { get; set; }
        public double Total { get; set; }

        // public List<DetalleFactura> Detalles { get; }

        public Factura()
        {

        }
        //public Factura()
        //{
        //    //generar la relación 1 a muchos
        //    Detalles = new List<DetalleFactura>();
        //}


        //public void AgregarDetalle(DetalleFactura detalle)
        //{
        //    Detalles.Add(detalle);
        //}


        //public void QuitarDetalle(int nro)
        //{
        //    Detalles.RemoveAt(nro);
        //}

        //public double CalcularTotal()
        //{
        //    double total = 0;
        //    foreach (DetalleFactura item in Detalles)
        //    {
        //        total += item.CalcularSubTotal();
        //    }
        //    return Math.Round(total,2);

        //}
        public string GetFechaBajaFormato()
        {
            string aux = FechaBaja.ToString("dd/MM/yyyy");
            return aux.Equals("01/01/0001") ? "" : aux;
        }



    }
}

