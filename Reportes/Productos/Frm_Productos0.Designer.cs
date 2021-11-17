
namespace Reportes.Productos
{
    partial class Frm_Productos0
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
            this.dsProductos0 = new Reportes.Productos.dsProductos0();
            this.SP_REPORTE_PRODUCTOS0BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SP_REPORTE_PRODUCTOS0TableAdapter = new Reportes.Productos.dsProductos0TableAdapters.SP_REPORTE_PRODUCTOS0TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsProductos0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_REPORTE_PRODUCTOS0BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsProductos0";
            reportDataSource1.Value = this.SP_REPORTE_PRODUCTOS0BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reportes.Productos.rptProductos0.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(929, 834);
            this.reportViewer1.TabIndex = 0;
            // 
            // dsProductos0
            // 
            this.dsProductos0.DataSetName = "dsProductos0";
            this.dsProductos0.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SP_REPORTE_PRODUCTOS0BindingSource
            // 
            this.SP_REPORTE_PRODUCTOS0BindingSource.DataMember = "SP_REPORTE_PRODUCTOS0";
            this.SP_REPORTE_PRODUCTOS0BindingSource.DataSource = this.dsProductos0;
            // 
            // SP_REPORTE_PRODUCTOS0TableAdapter
            // 
            this.SP_REPORTE_PRODUCTOS0TableAdapter.ClearBeforeFill = true;
            // 
            // Frm_Productos0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 834);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Frm_Productos0";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Productos0";
            this.Load += new System.EventHandler(this.Frm_Productos0_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsProductos0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_REPORTE_PRODUCTOS0BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SP_REPORTE_PRODUCTOS0BindingSource;
        private dsProductos0 dsProductos0;
        private dsProductos0TableAdapters.SP_REPORTE_PRODUCTOS0TableAdapter SP_REPORTE_PRODUCTOS0TableAdapter;
    }
}