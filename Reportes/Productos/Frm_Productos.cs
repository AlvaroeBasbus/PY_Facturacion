using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reportes.Productos
{
    public partial class Frm_Productos : Form
    {
        public Frm_Productos()
        {
            InitializeComponent();
        }

        private void Frm_Productos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsProductos.SP_REPORTE_PRODUCTOS' Puede moverla o quitarla según sea necesario.
            this.SP_REPORTE_PRODUCTOSTableAdapter.Fill(this.dsProductos.SP_REPORTE_PRODUCTOS);

            this.reportViewer1.RefreshReport();
        }
    }
}
