using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using puntoVenta;
using puntoVenta.clases;

namespace puntoVenta.modulo_opciones
{

    public partial class configuracion_modulos : FormBase
    {


        //objetos
        Utilidades utilidades=new Utilidades();


        //litas




        public configuracion_modulos()
        {
            InitializeComponent();
            loadVentana();
        }

        public override void loadVentana()
        {
            this.Text = utilidades.GetTituloVentana("wilmer de la rosa", "configuración módulos");
            this.tituloLabel.Text = utilidades.GetTituloVentana("wilmer de la rosa", "configuración módulos");

        }

        private void configuracion_modulos_Load(object sender, EventArgs e)
        {
            
        }
    }
}
