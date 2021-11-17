
namespace Reportes.Productos
{
    partial class Frm_Productos5
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SP_REPORTE_PRODUCTOS5BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsProductos5 = new Reportes.Productos.dsProductos5();
            this.SP_REPORTE_PRODUCTOS5TableAdapter = new Reportes.Productos.dsProductos5TableAdapters.SP_REPORTE_PRODUCTOS5TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SP_REPORTE_PRODUCTOS5BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProductos5)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "dsProductos5";
            reportDataSource2.Value = this.SP_REPORTE_PRODUCTOS5BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reportes.Productos.rptProductos5.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(910, 787);
            this.reportViewer1.TabIndex = 0;
            // 
            // SP_REPORTE_PRODUCTOS5BindingSource
            // 
            this.SP_REPORTE_PRODUCTOS5BindingSource.DataMember = "SP_REPORTE_PRODUCTOS5";
            this.SP_REPORTE_PRODUCTOS5BindingSource.DataSource = this.dsProductos5;
            // 
            // dsProductos5
            // 
            this.dsProductos5.DataSetName = "dsProductos5";
            this.dsProductos5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SP_REPORTE_PRODUCTOS5TableAdapter
            // 
            this.SP_REPORTE_PRODUCTOS5TableAdapter.ClearBeforeFill = true;
            // 
            // Frm_Productos5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(910, 787);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Frm_Productos5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Productos5";
            this.Load += new System.EventHandler(this.Frm_Productos5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SP_REPORTE_PRODUCTOS5BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProductos5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SP_REPORTE_PRODUCTOS5BindingSource;
        private dsProductos5 dsProductos5;
        private dsProductos5TableAdapters.SP_REPORTE_PRODUCTOS5TableAdapter SP_REPORTE_PRODUCTOS5TableAdapter;
    }
}