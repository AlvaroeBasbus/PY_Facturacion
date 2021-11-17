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
    public partial class Frm_Productos0 : Form
    {
        public Frm_Productos0()
        {
            InitializeComponent();
        }

        private void Frm_Productos0_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsProductos0.SP_REPORTE_PRODUCTOS0' Puede moverla o quitarla según sea necesario.
            this.SP_REPORTE_PRODUCTOS0TableAdapter.Fill(this.dsProductos0.SP_REPORTE_PRODUCTOS0);

            this.reportViewer1.RefreshReport();
        }
    }
}
