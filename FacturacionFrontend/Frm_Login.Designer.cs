
namespace FacturacionFrontend
{
    partial class Frm_Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button btnEntrar;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Login));
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.txtUsuarios = new System.Windows.Forms.TextBox();
            this.lblUsuarios = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            btnEntrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEntrar
            // 
            btnEntrar.BackColor = System.Drawing.Color.MintCream;
            btnEntrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnEntrar.Location = new System.Drawing.Point(54, 177);
            btnEntrar.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new System.Drawing.Size(99, 35);
            btnEntrar.TabIndex = 3;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = false;
            btnEntrar.Click += new System.EventHandler(this.btnEntrar_ClickAsync);
            // 
            // txtContrasena
            // 
            this.txtContrasena.Location = new System.Drawing.Point(165, 95);
            this.txtContrasena.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(157, 27);
            this.txtContrasena.TabIndex = 2;
            this.txtContrasena.TextChanged += new System.EventHandler(this.txtContrasena_TextChanged);
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblContraseña.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblContraseña.Location = new System.Drawing.Point(36, 97);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(124, 25);
            this.lblContraseña.TabIndex = 8;
            this.lblContraseña.Text = "Contraseña";
            // 
            // txtUsuarios
            // 
            this.txtUsuarios.BackColor = System.Drawing.SystemColors.Window;
            this.txtUsuarios.Location = new System.Drawing.Point(165, 33);
            this.txtUsuarios.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtUsuarios.Name = "txtUsuarios";
            this.txtUsuarios.Size = new System.Drawing.Size(157, 27);
            this.txtUsuarios.TabIndex = 1;
            // 
            // lblUsuarios
            // 
            this.lblUsuarios.AutoSize = true;
            this.lblUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUsuarios.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblUsuarios.Location = new System.Drawing.Point(60, 33);
            this.lblUsuarios.Name = "lblUsuarios";
            this.lblUsuarios.Size = new System.Drawing.Size(86, 25);
            this.lblUsuarios.TabIndex = 6;
            this.lblUsuarios.Text = "Usuario";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.MintCream;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSalir.Location = new System.Drawing.Point(239, 177);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(99, 35);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(384, 237);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.lblContraseña);
            this.Controls.Add(this.txtUsuarios);
            this.Controls.Add(this.lblUsuarios);
            this.Controls.Add(btnEntrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "Frm_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar Sesion";
            this.Load += new System.EventHandler(this.Frm_Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.TextBox txtUsuarios;
        private System.Windows.Forms.Label lblUsuarios;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.Button btnSalir;
    }
}