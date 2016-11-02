using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using puntoVenta;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Drawing.Design;
using System.IO;
using System.Net.Mail;
using System.Net;
using Microsoft.Reporting.WinForms;
using ReportDataSource = Microsoft.Reporting.WebForms.ReportDataSource;
using ReportParameter = Microsoft.Reporting.WebForms.ReportParameter;
using  puntoVenta.clases;

namespace puntoVenta.Reportes
{
    public partial class ventana_reporte : Form
    {

        //variables
        public string codigo_factura {get;set;}
        public  Utilidades utilidades = new Utilidades();
        private Microsoft.Reporting.WinForms.ReportViewer Reporte;

        public ventana_reporte()
        {
            InitializeComponent();
        }
        singleton s { get; set; }

        private void ventana_reporte_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load_1(object sender, EventArgs e)
        {

        }
        public ventana_reporte(String reporte, List<ReportDataSource> lista, string usuario, List<ReportParameter> ListaReportParameter, Boolean IncluirEmpresa, Boolean IncluirUsuario, Boolean IncluirFechaActual, Boolean ExportarExel = false)
        {
            InitializeComponent();
            ExportarExel = ExportarExel;
            List<string> listaempresa = new List<string>();
            if (IncluirEmpresa)
            {
                listaempresa.Add(usuario);
                ReportDataSource empresaDataSource = new ReportDataSource("empresa", listaempresa);
                lista.Add(empresaDataSource);
            }
            if (IncluirUsuario)
            {
                List<string> listausuario = new List<string>();
                listausuario.Add(usuario);
                ReportDataSource usuarioDataSource = new ReportDataSource("usuario", listausuario);
                lista.Add(usuarioDataSource);
            }
            if (IncluirFechaActual)
            {
                if (ListaReportParameter == null)
                {
                    ListaReportParameter = new List<ReportParameter>();
                }
                ReportParameter parameter = new ReportParameter("fecha", Utilidades.getFormaFechaNormal(DateTime.Now));
                ListaReportParameter.Add(parameter);
                GetLoad(reporte, lista, ListaReportParameter);
            }
            GetLoad(reporte, lista, ListaReportParameter);
        }

        private void GetLoad(String reporte, List<ReportDataSource> lista, List<ReportParameter> ListaReportParameter)
        {
            Reporte.LocalReport.ReportEmbeddedResource = reporte;
            lista.ForEach(x =>
            {
                //Reporte.LocalReport.DataSources.Add(x);
            });
            if (ListaReportParameter != null)
            {
                //Reporte.LocalReport.SetParameters(ListaReportParameter);
            }
        }
        private void visor_reporte_Load(object sender, EventArgs e)
        {
            Reporte.SetDisplayMode(DisplayMode.PrintLayout);
            this.Reporte.RefreshReport();
        }
        
    }

}
