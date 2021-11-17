
namespace Reportes.Facturas
{
    partial class Frm_Facturacion
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
            this.SP_REPORTE_FACTURASBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsFacturacion = new Reportes.Facturas.dsFacturacion();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SP_REPORTE_FACTURASTableAdapter = new Reportes.Facturas.dsFacturacionTableAdapters.SP_REPORTE_FACTURASTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SP_REPORTE_FACTURASBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFacturacion)).BeginInit();
            this.SuspendLayout();
            // 
            // SP_REPORTE_FACTURASBindingSource
            // 
            this.SP_REPORTE_FACTURASBindingSource.DataMember = "SP_REPORTE_FACTURAS";
            this.SP_REPORTE_FACTURASBindingSource.DataSource = this.dsFacturacion;
            // 
            // dsFacturacion
            // 
            this.dsFacturacion.DataSetName = "dsFacturacion";
            this.dsFacturacion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsFacturacion";
            reportDataSource1.Value = this.SP_REPORTE_FACTURASBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reportes.Facturas.rptFacturacion.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(952, 914);
            this.reportViewer1.TabIndex = 0;
            // 
            // SP_REPORTE_FACTURASTableAdapter
            // 
            this.SP_REPORTE_FACTURASTableAdapter.ClearBeforeFill = true;
            // 
            // Frm_Facturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 914);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Facturacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Facturacion";
            this.Load += new System.EventHandler(this.Frm_Facturacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SP_REPORTE_FACTURASBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsFacturacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SP_REPORTE_FACTURASBindingSource;
        private dsFacturacion dsFacturacion;
        private dsFacturacionTableAdapters.SP_REPORTE_FACTURASTableAdapter SP_REPORTE_FACTURASTableAdapter;
    }
}