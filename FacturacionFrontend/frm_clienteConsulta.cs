using FacturacionBackend.Servicios.Implementacion;
using FacturacionBackend.Servicios.Interfaces;
using FacturacionBackend.Servicios;
using FacturacionFrontend.Cliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using FacturacionBackend;

namespace FacturacionFrontend
{
    public partial class frm_clienteConsulta : Form
    {
        IClienteService servicios;
        int getId = 0;
        public frm_clienteConsulta()
        {
            InitializeComponent();
            servicios = new ClienteService();
            btnActualizar.Enabled = false;
            CargarComboCondicion();
        }

        private async void frm_clienteConsulta_LoadAsync(object sender, EventArgs e)
        {
            await cargarDatosAsync();
        }

        private async
  Task
cargarDatosAsync()
        {
            List<Clientes> clientes = null;
            string url = "https://localhost:44347/api/Cliente/consultar";
            var resultado = await ClienteSingleton.GetInstancia().GetAsync(url);

            clientes = JsonConvert.DeserializeObject<List<Clientes>>(resultado);

            for (int i = 0; i < clientes.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();

                row.CreateCells(dgvClientes);
                row.Cells[0].Value = clientes[i].idCliente;
                row.Cells[1].Value = clientes[i].Nombre;
                row.Cells[2].Value = clientes[i].Apellido;
                row.Cells[3].Value = clientes[i].DNI;
                row.Cells[4].Value = clientes[i].Telefono;
                row.Cells[5].Value = clientes[i].Domicilio;
                row.Cells[6].Value = clientes[i].Correo;
                row.Cells[7].Value = clientes[i].Condicion;
              


                dgvClientes.Rows.Add(row);
            }
        }

        private async void dataGridView1_CellContentClickAsync(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.CurrentCell.ColumnIndex == 8) // modificar
            {

                btnActualizar.Enabled = true;
                btnGuardar.Enabled = false;
                txtNombre.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
                txtApellido.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
                txtDni.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString();
                txtTelefono.Text = dgvClientes.CurrentRow.Cells[4].Value.ToString();
                txtDireccion.Text = dgvClientes.CurrentRow.Cells[5].Value.ToString();
                txtDireccion.Text = dgvClientes.CurrentRow.Cells[5].Value.ToString();
                txtCorreo.Text = dgvClientes.CurrentRow.Cells[6].Value.ToString();
                cboIva.Text = dgvClientes.CurrentRow.Cells[7].Value.ToString();
                getId = Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value);
            }
            if (dgvClientes.CurrentCell.ColumnIndex == 9) // eliminar
            {
                DialogResult result = MessageBox.Show("Desea ELiminar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    getId = Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value);
                    servicios.EliminarCliente(getId);
                    dgvClientes.Rows.Clear();
                    await cargarDatosAsync();
                    getId = 0;
                    MessageBox.Show("Cliente Eliminado Con Exito", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }


            }
        }


        private void CargarComboCondicion()
        {
            DataTable tiposCondicion = servicios.TraerCondicion();
            cboIva.DataSource = tiposCondicion;
            cboIva.DisplayMember = tiposCondicion.Columns[1].ColumnName;
            cboIva.ValueMember = tiposCondicion.Columns[0].ColumnName;
        }


        private void bntCancelar_Click(object sender, EventArgs e)
        {
            inicio();
        }
        private void inicio()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDni.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";
            cboIva.SelectedIndex = -1;
            btnActualizar.Enabled = false;
            btnGuardar.Enabled = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea Salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private async void btnGuardar_ClickAsync(object sender, EventArgs e)
        {

            if (txtNombre.Text == String.Empty.Trim())
            {
                MessageBox.Show("Debe Ingresar el nombre", "Sin Nombre", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Focus();
                return;
            }
            if (txtApellido.Text == String.Empty.Trim())
            {
                MessageBox.Show("Debe Ingresar el apellido", "Sin apellido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtApellido.Focus();
                return;
            }
            if (txtDni.Text == String.Empty.Trim())
            {
                MessageBox.Show("Debe Ingresar el DNI", "Sin DNI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDni.Focus();
                return;
            }
            if (txtTelefono.Text == String.Empty.Trim())
            {
                MessageBox.Show("Debe Ingresar el Telefono", "Sin Telefono", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTelefono.Focus();
                return;
            }
            if (txtCorreo.Text == String.Empty.Trim())
            {
                MessageBox.Show("Debe Ingresar el correo", "Sin correo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCorreo.Focus();
                return;
            }
            if (txtDireccion.Text == String.Empty.Trim())
            {
                MessageBox.Show("Debe Ingresar la Direccion", "Sin Direccion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDireccion.Focus();
                return;
            }

            if (ExisteClienteEnGrilla(Convert.ToInt32(txtDni.Text)))
            {
                MessageBox.Show("Cliente ya existe!!!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {

                Clientes oCliente = new Clientes();
                oCliente.Nombre = txtNombre.Text;
                oCliente.Apellido = txtApellido.Text;
                oCliente.DNI = Convert.ToInt32(txtDni.Text);
                oCliente.Domicilio = txtDireccion.Text;
                oCliente.Telefono = (int)Convert.ToInt64(txtTelefono.Text);
                oCliente.Condicion = cboIva.Text;
                oCliente.Correo = txtCorreo.Text;          
                servicios.GrabarCliente(oCliente);
                dgvClientes.Rows.Clear();
                await cargarDatosAsync();
                inicio();
            }
        }

        private bool ExisteClienteEnGrilla(int text)
        {
            foreach (DataGridViewRow fila in dgvClientes.Rows)
            {
                if (fila.Cells["Documento"].Value != null)
                {
                    if (fila.Cells["Documento"].Value.Equals(text))
                        return true;
                }

            }
            return false;
        }

        private async void btnActualizar_ClickAsync(object sender, EventArgs e)
        {
            if (txtNombre.Text == String.Empty.Trim())
            {
                MessageBox.Show("Debe Ingresar el nombre", "Sin Nombre", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Focus();
                return;
            }
            if (txtApellido.Text == String.Empty.Trim())
            {
                MessageBox.Show("Debe Ingresar el apellido", "Sin apellido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtApellido.Focus();
                return;
            }
            if (txtDni.Text == String.Empty.Trim())
            {
                MessageBox.Show("Debe Ingresar el DNI", "Sin DNI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDni.Focus();
                return;
            }
            if (txtTelefono.Text == String.Empty.Trim())
            {
                MessageBox.Show("Debe Ingresar el Telefono", "Sin Telefono", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTelefono.Focus();
                return;
            }
            if (txtCorreo.Text == String.Empty.Trim())
            {
                MessageBox.Show("Debe Ingresar el correo", "Sin correo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCorreo.Focus();
                return;
            }
            if (txtDireccion.Text == String.Empty.Trim())
            {
                MessageBox.Show("Debe Ingresar la Direccion", "Sin Direccion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDireccion.Focus();
                return;
            }


            Clientes oCliente = new Clientes();
            oCliente.Nombre = txtNombre.Text;
            oCliente.Apellido = txtApellido.Text;
            oCliente.DNI = Convert.ToInt32(txtDni.Text);
            oCliente.Domicilio = txtDireccion.Text;
            oCliente.Telefono = (int)Convert.ToInt64(txtTelefono.Text);
            oCliente.Condicion = cboIva.Text;
            oCliente.Correo = txtCorreo.Text;
            oCliente.idCliente = getId;

            bool flag = servicios.ActualizarCliente(oCliente);
            if (flag)
            {
                MessageBox.Show("Cliente Actualizado con éxito!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvClientes.Rows.Clear();


                await cargarDatosAsync();
                inicio();

            }
            else
            {
                MessageBox.Show("No se pudo actualizar el cliente", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboIva_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Cliente_Enter(object sender, EventArgs e)
        {

        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
       
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


    }
}
