using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using puntoVentaWin;

namespace puntoVentaWin.pruebas
{
    public partial class ventana_mapa : FormBase
    {
        public ventana_mapa()
        {
            InitializeComponent();
        }

        private void ventana_mapa_Load(object sender, EventArgs e)
        {
            //http://www.independent-software.com/gmap-net-tutorial-maps-markers-and-polygons/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //con que click se arrastrara
            gMapControl1.DragButton= MouseButtons.Left;
            //permitira arrastrar
            gMapControl1.CanDragMap = true;
            //que tipo de mapa usara
            gMapControl1.MapProvider=GMapProviders.GoogleMap;
            //cargar latitud,longitud
            gMapControl1.Position = new PointLatLng(double.Parse(latitud.Text), double.Parse(longitud.Text));
            //zomm con que iniciara
            gMapControl1.Zoom = 10;
            //zoom minimo
            gMapControl1.MinZoom = 0;
            //zoom maximo
            gMapControl1.MaxZoom = 20;
            //auto scroll
            gMapControl1.AutoScroll = true;


        }
    }
}
