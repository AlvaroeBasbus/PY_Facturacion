using FacturacionBackend;
using FacturacionBackend.Servicios;
using FacturacionBackend.Servicios.Implementacion;
using FacturacionBackend.Servicios.Servicios;
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
    public partial class frm_ConsultaFactura : Form
    {
        IService servicios;
        int id;
        public frm_ConsultaFactura()
        {
            InitializeComponent();
            servicios = new FacturaService();
        }

        private void frm_ConsultaFactura_Load(object sender, EventArgs e)
        {
            CargarComboCliente();
            cboCliente.Text = "";
        }

        private void CargarComboCliente()
        {
            DataTable clientes = servicios.TraerCliente();
            cboCliente.DataSource = clientes;
            cboCliente.DisplayMember = clientes.Columns[1].ColumnName;
            cboCliente.ValueMember = clientes.Columns[0].ColumnName;
        }

        private void gbFiltros_Enter(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea Salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            List<Parametro> filtros = new List<Parametro>();
            //Parametro fecha_desde = new Parametro();
            //fecha_desde.Nombre = "@fecha_desde";
            //fecha_desde.Valor = dtpDesde.Value;
            //filtros.Add(fecha_desde);
            filtros.Add(new Parametro("@fecha_desde", dtpDesde.Value.ToString("yyyy/MM/dd")));
            filtros.Add(new Parametro("@fecha_hasta", dtpHasta.Value.ToString("yyyy/MM/dd")));

            if (!String.IsNullOrEmpty(cboCliente.Text))
            {
            Parametro id = new Parametro();
            id.Nombre = "@cliente";
            id.Valor = Convert.ToInt32(cboCliente.SelectedValue.ToString());
            filtros.Add(id);
            }
    




            string baja = "N";
            if (chkBaja.Checked)
                baja = "S";
            filtros.Add(new Parametro("@baja", baja));




            List<Factura> lst = servicios.ConsultarFacturas(filtros);

            dgvResultados.Rows.Clear();
            foreach (Factura oFactura in lst)
            {
                dgvResultados.Rows.Add(new object[]{
                                         "",
                                        oFactura.FacturaNro,
                                        oFactura.Fecha.ToString("dd/MM/yyyy"),
                                        oFactura.NombreCliente,
                                        oFactura.DescripcionMetodo,
                                        oFactura.Total,
                                        oFactura.GetFechaBajaFormato()
                 }); ;
            }
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvResultados.CurrentRow; // fila actual o seleccionada
            if (row != null)
            {
                int factura = Int32.Parse(row.Cells["NroFactura"].Value.ToString());
                if (MessageBox.Show("Seguro que desea eliminar la factura seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool respuesta = servicios.RegistrarBajaFactura(factura);

                    if (respuesta)
                    {
                        MessageBox.Show("Factura eliminada!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.btnConsultar_Click(null, null);
                    }
                    else
                        MessageBox.Show("Error al intentar borrar la Factura!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvResultados.CurrentCell.ColumnIndex == 7)
            {
                //Form1 form = new Form1();
                //form.ShowDialog();
                //Frm_Facturar repFacturas = new Frm_Facturar();
                //repFacturas.idFactura = Int32.Parse(dgvResultados.CurrentRow.Cells[1].Value.ToString());
                //repFacturas.ShowDialog();

            }
        }
    }
}
