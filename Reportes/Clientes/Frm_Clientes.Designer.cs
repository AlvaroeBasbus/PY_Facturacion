
namespace Reportes.Clientes
{
    partial class Frm_Clientes
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SP_REPORTE_CLIENTESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsClientes = new Reportes.Clientes.dsClientes();
            this.SP_REPORTE_CLIENTESTableAdapter = new Reportes.Clientes.dsClientesTableAdapters.SP_REPORTE_CLIENTESTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SP_REPORTE_CLIENTESBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsClientes";
            reportDataSource1.Value = this.SP_REPORTE_CLIENTESBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reportes.Clientes.rptClientes.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(947, 881);
            this.reportViewer1.TabIndex = 0;
            // 
            // SP_REPORTE_CLIENTESBindingSource
            // 
            this.SP_REPORTE_CLIENTESBindingSource.DataMember = "SP_REPORTE_CLIENTES";
            this.SP_REPORTE_CLIENTESBindingSource.DataSource = this.dsClientes;
            // 
            // dsClientes
            // 
            this.dsClientes.DataSetName = "dsClientes";
            this.dsClientes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SP_REPORTE_CLIENTESTableAdapter
            // 
            this.SP_REPORTE_CLIENTESTableAdapter.ClearBeforeFill = true;
            // 
            // Frm_Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 881);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Clientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Clientes";
            this.Load += new System.EventHandler(this.Frm_Clientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SP_REPORTE_CLIENTESBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SP_REPORTE_CLIENTESBindingSource;
        private dsClientes dsClientes;
        private dsClientesTableAdapters.SP_REPORTE_CLIENTESTableAdapter SP_REPORTE_CLIENTESTableAdapter;
    }
}