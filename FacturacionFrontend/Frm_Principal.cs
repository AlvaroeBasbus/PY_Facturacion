using Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacturacionFrontend
{
    public partial class Frm_Principal : Form
    {
        public string Nombre { get; set; }
        
        public Frm_Principal()
        {
            InitializeComponent();
            

        }

        private void crearFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Factura frmNuevo = new Frm_Factura();
            frmNuevo.ShowDialog();
        }

        private void consultarFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ConsultaFactura frmNuevo = new frm_ConsultaFactura();
            frmNuevo.ShowDialog();
        }

 

        private void consultarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_clienteConsulta frmNuevo = new frm_clienteConsulta();
            frmNuevo.ShowDialog();
        }



        private void consultarProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_productoConsulta frmNuevo = new frm_productoConsulta();
            frmNuevo.ShowDialog();
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Acerca frmAcerca = new Frm_Acerca();
            frmAcerca.ShowDialog();
        }

        private void iniciarSecionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea Salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                
                this.Dispose();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Frm_Principal_Load(object sender, EventArgs e)
        {
            lblUser.Text = Nombre;
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_productoConsulta frmNuevo = new frm_productoConsulta();
            frmNuevo.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_clienteConsulta frmCliente = new frm_clienteConsulta();
            frmCliente.ShowDialog();
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Inicio frmReporte = new Frm_Inicio();
            frmReporte.ShowDialog();
        }
    }
}
