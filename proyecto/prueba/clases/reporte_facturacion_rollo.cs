using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace puntoVenta.clases
{
    public class reporte_facturacion_rollo
    {

       
        private string reporte;
        private List<Microsoft.Reporting.WinForms.ReportDataSource> listaReportDataSource;

        public reporte_facturacion_rollo(string reporte, List<Microsoft.Reporting.WinForms.ReportDataSource> listaReportDataSource)
        {
            // TODO: Complete member initialization
            this.reporte = reporte;
            this.listaReportDataSource = listaReportDataSource;
        }
        public string producto { get; set; }
        public float cantidad { get; set; }
        public string unidad { get; set; }
        public float itbis { get; set; }
        public float subTotal { set; get; }
        public string total { get; set; }

    }
}
