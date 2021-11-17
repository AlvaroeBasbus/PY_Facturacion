using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reportes.Clientes
{
    public partial class Frm_Clientes : Form
    {
        public Frm_Clientes()
        {
            InitializeComponent();
        }

        private void Frm_Clientes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsClientes.SP_REPORTE_CLIENTES' Puede moverla o quitarla según sea necesario.
            this.SP_REPORTE_CLIENTESTableAdapter.Fill(this.dsClientes.SP_REPORTE_CLIENTES);

            this.reportViewer1.RefreshReport();
        }
    }
}
