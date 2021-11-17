using FacturacionBackend.Servicios;
using FacturacionBackend.Servicios.Servicios;
using FacturacionFrontend.Cliente;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace FacturacionFrontend
{
    public partial class Frm_Login : Form
    {

        private IService servicio;
        Frm_Principal principal;
        
        public Frm_Login()
        {
            InitializeComponent();
            principal = new Frm_Principal();

            
        }

                private async void btnEntrar_ClickAsync(object sender, EventArgs e)
               {
            
            List<Parametro> lst = new List<Parametro>();

            if (!String.IsNullOrEmpty(txtUsuarios.Text) && !String.IsNullOrEmpty(txtContrasena.Text))
            {
                lst.Add(new Parametro("user", txtUsuarios.Text));
                lst.Add(new Parametro("pass", txtContrasena.Text));
                principal.Nombre = txtUsuarios.Text;
            }
            else
            {
                MessageBox.Show("Ingrese un usuario y una contraseña", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            string obj = JsonConvert.SerializeObject(lst);
            string url = "https://localhost:44347/api/Login/login";

            var resultado = await ClienteSingleton.GetInstancia().PostAsync(url, obj);
            var res = JsonConvert.DeserializeObject(resultado);

            if (Convert.ToBoolean(res))
            {

                DialogResult result = MessageBox.Show("Acceso correcto", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    //Dispose();
                    //Frm_Principal principal = new Frm_Principal();
                    principal.ShowDialog();
                    this.btnSalir_Click("",  e);


                }
            }
            else
            {
                MessageBox.Show("Acceso incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea Salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {

        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {
            txtContrasena.UseSystemPasswordChar = true;
        }
    }
}

