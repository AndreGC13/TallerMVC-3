using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador_prototipoumg;

namespace CapaVista_prototipoumg26.Reportes
{
    public partial class FrmReporteEmpleado : Form
    {
        private ModeloEmpleado ControladorEmpleado = new ModeloEmpleado();
        public FrmReporteEmpleado()
        {
            InitializeComponent();
        }

        private void FrmReporteEmpleado_Load(object sender, EventArgs e)
        {
            ReportDataSource reportDataSource1 = new ReportDataSource("DataSet1", ControladorEmpleado.GetAll());
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaVista_prototipoumg26.Reportes.ReporteEmpleado.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.RefreshReport();
        }
    }
}
