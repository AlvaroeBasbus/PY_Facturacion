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
    public partial class Frm_Productos5 : Form
    {
        public Frm_Productos5()
        {
            InitializeComponent();
        }

        private void Frm_Productos5_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsProductos5.SP_REPORTE_PRODUCTOS5' Puede moverla o quitarla según sea necesario.
            this.SP_REPORTE_PRODUCTOS5TableAdapter.Fill(this.dsProductos5.SP_REPORTE_PRODUCTOS5);

            this.reportViewer1.RefreshReport();
        }
    }
}
