using Reportes.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reportes.Dominio;
using Reportes.Servicios.Implementacion;
using Reportes.Facturas;
using Reportes.Clientes;
using Reportes.Productos;

namespace Reportes
{
    public partial class Frm_Inicio : Form
    {
        IService servicios;
        public Frm_Inicio()
        {
            InitializeComponent();
            
            servicios = new FacturaService();

        }

        private void cargarData()
        {
            List<Factura> lst = servicios.TraerFacturas();

            dgvFac.Rows.Clear();
            foreach (Factura oFactura in lst)
            {
                dgvFac.Rows.Add(new object[]{
                                        oFactura.FacturaNro,
                                        oFactura.Fecha.ToString("dd/MM/yyyy"),
                                        oFactura.NombreCliente,
                                        oFactura.DescripcionMetodo,
                                        oFactura.Total,
                                        oFactura.GetFechaBajaFormato()
                 }); ;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFac.CurrentCell.ColumnIndex == 6)
            {

                Frm_Facturacion repFacturas = new Frm_Facturacion();
                repFacturas.idFactura = Int32.Parse(dgvFac.CurrentRow.Cells[0].Value.ToString());
                repFacturas.ShowDialog();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea Salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void Frm_Inicio_Load(object sender, EventArgs e)
        {
            cargarData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Clientes frmClientes = new Frm_Clientes();
            frmClientes.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frm_Productos frmProductos = new Frm_Productos();
            frmProductos.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Frm_Productos5 frmProductos5 = new Frm_Productos5();
            frmProductos5.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Frm_Productos0 frmProductos0 = new Frm_Productos0();
            frmProductos0.ShowDialog();
        }
    }
}
