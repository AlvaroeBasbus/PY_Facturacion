using FacturacionBackend;
using FacturacionBackend.Servicios.Implementacion;
using FacturacionBackend.Servicios.Servicios;
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
    public partial class Frm_Factura : Form
    {
        
        IService servicios;
        Factura oFactura;
        double Total;
        Clientes cliente;
        int metodo;
        public Frm_Factura()
        {
            InitializeComponent();
            servicios = new FacturaService();
            oFactura = new Factura();

        }

        private void Frm_Factura_Load(object sender, EventArgs e)
        {
            CargarComboCliente();
            CargarComboProductos();
            CargarComboMetodo();
        }
        private void CargarComboCliente()
        {
            DataTable clientes = servicios.TraerCliente();
            cboClientes.DataSource = clientes;
            cboClientes.DisplayMember = clientes.Columns[1].ColumnName;
            cboClientes.ValueMember = clientes.Columns[0].ColumnName;
        }

        private void CargarComboMetodo()
        {
            DataTable metodo = servicios.TraerMetodo();
            cboMetodo.DataSource = metodo;
            cboMetodo.DisplayMember = metodo.Columns[1].ColumnName;
            cboMetodo.ValueMember = metodo.Columns[0].ColumnName;
        }
        public void CargarComboProductos()
        {
            List<Producto> lst = servicios.GetProductos();


            cboProductos.DataSource = lst;
            cboProductos.DisplayMember = "Nombre";
            cboProductos.ValueMember = "IdProducto";

            
        }

        private void dgvDetFactura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvDetFactura.CurrentCell.ColumnIndex == 5)
            {
                oFactura.QuitarDetalle(dgvDetFactura.CurrentRow.Index);
                dgvDetFactura.Rows.Remove(dgvDetFactura.CurrentRow);
                CalcularTotales();
            }

        }
    

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Now.Date;
            dateTimePicker1.MaxDate = DateTime.Now.Date;
        }

        private void cboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ExisteProductoEnGrilla(cboProductos.Text))
            {
                MessageBox.Show("Producto ya agregado como detalle", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
          

            DetalleFactura detalle = new DetalleFactura();

            Producto oProducto = (Producto)cboProductos.SelectedItem;
            if (oProducto.Stock< (int)numCantidad.Value)
            {
                int stock = oProducto.Stock;
                    MessageBox.Show("Producto sin stock, stock disponible: " + stock.ToString(), "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            detalle.Producto = oProducto;
            detalle.Cantidad = (int)numCantidad.Value;
            metodo= Convert.ToInt32(cboMetodo.SelectedValue.ToString());
            

            cliente = new Clientes();
            cliente.idCliente = Convert.ToInt32(cboClientes.SelectedValue.ToString());

            oFactura.AgregarDetalle(detalle);

            dgvDetFactura.Rows.Add(new object[] { "", oProducto.Nombre, detalle.Cantidad, oProducto.Precio, detalle.CalcularSubTotal() }); ;

            CalcularTotales();
        }
        public void CalcularTotales()
        {
            Total = oFactura.CalcularTotal();
            lblPrecioTotal.Text =  Total.ToString();

            //pasar total al objeto
            oFactura.Total = Total;
        }

        private bool ExisteProductoEnGrilla(object text)
        {
            foreach (DataGridViewRow fila in dgvDetFactura.Rows)
            {
                if (fila.Cells["descripcion"].Value.Equals(text))
                    return true;
            }
            return false;
        }

        private void label2_Click(object sender, EventArgs e)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelar();
        }
        private void cancelar()
        {
            dgvDetFactura.Rows.Clear();
            lblPrecioTotal.Text = "";


        }

        private void numCantidad_ValueChanged(object sender, EventArgs e)
        {
            numCantidad.Minimum = 1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dgvDetFactura.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos un producto como detalle", "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboProductos.Focus();
                return;
            }

            
           

            oFactura.Cliente = cliente.idCliente;
            oFactura.MetodoPago = metodo;
            //oFactura.Fecha= Convert.ToDateTime(dateTimePicker1.Text);
            oFactura.Total = Total;
            

            if (servicios.GuardarFactura(oFactura))
            {
                MessageBox.Show("Factura guardada con éxito!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvDetFactura.Rows.Clear();
                numCantidad.Value = 1;
                cboMetodo.SelectedIndex = 0;
                cboProductos.SelectedIndex = 0;
                cboClientes.SelectedIndex = 0;
                lblPrecioTotal.Text = "";
                oFactura.Total = 0;
                CargarComboProductos();
            }
            else
            {
                MessageBox.Show("Error al intentar grabar el presupuesto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }

