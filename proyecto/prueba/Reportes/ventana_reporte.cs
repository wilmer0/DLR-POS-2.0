using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using puntoVenta;
using Microsoft.Reporting.WebForms;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Drawing.Design;
using System.IO;
using System.Net.Mail;
using System.Net;



namespace puntoVenta.Reportes
{
    public partial class ventana_reporte : Form
    {

        //variables
        public string codigo_factura {get;set;}


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
       
    }
}
