using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reportes.Facturas
{
    public partial class Frm_Facturacion : Form
    {
        public Frm_Facturacion()
        {
            InitializeComponent();
        }

        public int idFactura { get; set; }
        
        private void Frm_Facturacion_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsFacturacion.SP_REPORTE_FACTURAS' Puede moverla o quitarla según sea necesario.
            this.SP_REPORTE_FACTURASTableAdapter.Fill(this.dsFacturacion.SP_REPORTE_FACTURAS, idFactura);

            this.reportViewer1.RefreshReport();
        }
    }
}
