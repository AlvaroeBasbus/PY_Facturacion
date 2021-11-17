
namespace Reportes.Productos
{
    partial class Frm_Productos
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
            this.dsProductos = new Reportes.Productos.dsProductos();
            this.SP_REPORTE_PRODUCTOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SP_REPORTE_PRODUCTOSTableAdapter = new Reportes.Productos.dsProductosTableAdapters.SP_REPORTE_PRODUCTOSTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_REPORTE_PRODUCTOSBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsProductos";
            reportDataSource1.Value = this.SP_REPORTE_PRODUCTOSBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reportes.Productos.rptProductos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(928, 834);
            this.reportViewer1.TabIndex = 0;
            // 
            // dsProductos
            // 
            this.dsProductos.DataSetName = "dsProductos";
            this.dsProductos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SP_REPORTE_PRODUCTOSBindingSource
            // 
            this.SP_REPORTE_PRODUCTOSBindingSource.DataMember = "SP_REPORTE_PRODUCTOS";
            this.SP_REPORTE_PRODUCTOSBindingSource.DataSource = this.dsProductos;
            // 
            // SP_REPORTE_PRODUCTOSTableAdapter
            // 
            this.SP_REPORTE_PRODUCTOSTableAdapter.ClearBeforeFill = true;
            // 
            // Frm_Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 834);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Frm_Productos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Productos";
            this.Load += new System.EventHandler(this.Frm_Productos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_REPORTE_PRODUCTOSBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SP_REPORTE_PRODUCTOSBindingSource;
        private dsProductos dsProductos;
        private dsProductosTableAdapters.SP_REPORTE_PRODUCTOSTableAdapter SP_REPORTE_PRODUCTOSTableAdapter;
    }
}