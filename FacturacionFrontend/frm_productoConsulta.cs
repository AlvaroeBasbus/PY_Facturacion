using FacturacionBackend;
using FacturacionBackend.Servicios;
using FacturacionBackend.Servicios.Implementacion;
using FacturacionBackend.Servicios.Interfaces;
using FacturacionBackend.Servicios.Servicios;
using FacturacionFrontend.Cliente;
using Newtonsoft.Json;
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
    public partial class frm_productoConsulta : Form
    {
        IProductoService servicios;

        int getId=0;
        public frm_productoConsulta()
        {
            InitializeComponent();
            servicios = new ProductoService();
            btnActualizar.Enabled = false;
            
        }

        private async void Frm_productoConsulta_LoadAsync(object sender, EventArgs e)
        {
            await cargarDatosAsync();
            ControlStock();

        }

        private void ControlStock()
        {
            foreach (DataGridViewRow row in dtvProductos.Rows)
            {
                int valor = 5;
                if (Convert.ToInt32(row.Cells["Stock"].Value) <= valor)
                {
                    string producto = row.Cells["Producto"].Value.ToString();
                    MessageBox.Show("Debe reponer el producto: " +producto , "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    row.DefaultCellStyle.BackColor = Color.AntiqueWhite;


                }
            }
        }
        private void ControlStock2()
        {
            foreach (DataGridViewRow row in dtvProductos.Rows)
            {
                int valor = 5;
                if (Convert.ToInt32(row.Cells["Stock"].Value) <= valor)
                {
                      row.DefaultCellStyle.BackColor = Color.AntiqueWhite;


                }
            }
        }

        private async 
        Task
cargarDatosAsync()
        {
            List<Producto> productos = null;
            string url = "https://localhost:44347/api/Producto/consultar";
            var resultado = await ClienteSingleton.GetInstancia().GetAsync(url);

            productos = JsonConvert.DeserializeObject<List<Producto>>(resultado);

            for (int i = 0; i < productos.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();

                row.CreateCells(dtvProductos);
                row.Cells[0].Value = productos[i].IdProducto;
                row.Cells[1].Value = productos[i].Nombre;
                row.Cells[2].Value = productos[i].Stock;
                row.Cells[3].Value = productos[i].Precio;
                dtvProductos.Rows.Add(row);
            }
        }

        private async void dataGridView1_CellContentClickAsync(object sender, DataGridViewCellEventArgs e)
        {
            if (dtvProductos.CurrentCell.ColumnIndex == 4) // modificar
            {
              
                btnActualizar.Enabled = true;
                btnGuardar.Enabled = false;
                txtProducto.Text = dtvProductos.CurrentRow.Cells[1].Value.ToString();
                txtPrecio.Text = dtvProductos.CurrentRow.Cells[3].Value.ToString();
                numericUpDown1.Value = Convert.ToInt32(dtvProductos.CurrentRow.Cells[2].Value);
                getId = Convert.ToInt32(dtvProductos.CurrentRow.Cells[0].Value);
            }
            if (dtvProductos.CurrentCell.ColumnIndex == 5) // eliminar
            {
                DialogResult result = MessageBox.Show("Desea ELiminar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
               
                    getId = Convert.ToInt32(dtvProductos.CurrentRow.Cells[0].Value);
                    servicios.EliminarProducto(getId);
                    dtvProductos.Rows.Clear();
                    await cargarDatosAsync();
                    ControlStock();
                    inicio();
                }




            }


          
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            inicio();
        }

        private void inicio()
        {
            txtPrecio.Text = "";
            txtProducto.Text = "";
            numericUpDown1.Value = 1;
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
            if (txtProducto.Text == String.Empty.Trim())
            {
                MessageBox.Show("Debe Ingresar el producto", "Sin producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProducto.Focus();
                return;
            }
            if (txtPrecio.Text == String.Empty.Trim())
            {
                MessageBox.Show("Debe Ingresar el precio", "Sin precio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPrecio.Focus();
                return;
            }
            if (ExisteProductoEnGrilla(txtProducto.Text))
            {
                MessageBox.Show("Producto ya existente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                

                Producto oProducto = new Producto();
                oProducto.Nombre = txtProducto.Text;
                oProducto.Precio = Convert.ToDouble(txtPrecio.Text);

                oProducto.Stock = (int)numericUpDown1.Value;
                // dtvProductos.Rows.Add(new object[] { "", oProducto.Nombre, oProducto.Stock, oProducto.Precio }); ;
                servicios.GrabarProducto(oProducto);
                dtvProductos.Rows.Clear();


                await cargarDatosAsync();
                inicio();
                ControlStock2();
            }


            
            
        }

        private bool ExisteProductoEnGrilla(string text)
        {
            foreach (DataGridViewRow fila in dtvProductos.Rows)
            {
                if (fila.Cells["producto"].Value != null)
                {
                    if (fila.Cells["producto"].Value.Equals(text))
                    return true;
                }
                
            }
            return false;
        }

        private async void btnActualizar_ClickAsync(object sender, EventArgs e)
        {

            if (txtProducto.Text == String.Empty.Trim())
            {
                MessageBox.Show("Debe Ingresar el producto", "Sin producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProducto.Focus();
                return;
            }
            if (txtPrecio.Text == String.Empty.Trim())
            {
                MessageBox.Show("Debe Ingresar el precio", "Sin precio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPrecio.Focus();
                return;
            }

            Producto oProducto = new Producto();
            oProducto.Nombre = txtProducto.Text;
            oProducto.Stock = Convert.ToInt32(numericUpDown1.Value);
            oProducto.Precio = Convert.ToDouble(txtPrecio.Text);
            oProducto.IdProducto = getId;

           

            //DataGridViewRow row = new DataGridViewRow();

            //row.Cells[0].Value =/* Convert.ToInt32*/(oProducto.IdProducto);
            //row.Cells[1].Value = oProducto.Nombre;
            //row.Cells[2].Value = Convert.ToInt32(oProducto.S
            //Convert.ToDouble(oProducto.Precio);


            bool flag = servicios.ActualizarProducto(oProducto);
            if (flag)
            {
                 MessageBox.Show("Producto Actualizado con éxito!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtvProductos.Rows.Clear();


                await cargarDatosAsync();
                inicio();
                ControlStock2();

            }
            else
            {
                MessageBox.Show("No se pudo actualizar el producto", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            



        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = 1;
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
 
            
        }
    }


}
