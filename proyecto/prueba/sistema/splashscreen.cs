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
namespace puntoVenta
{
    public partial class splashscreen : Form
    {
        public splashscreen()
        {
            InitializeComponent();
        }

        private void splashscreen_Load(object sender, EventArgs e)
        {
            
        }
        int cont = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (cont == 6)//si dura x segundos
            //{
            //    timer1.Stop();
            //    timer1.Enabled = false;
            //    this.Hide();
            //    principal p = new principal();
            //    p.ShowDialog();
            //}
            //else
            //{
            //    cont++;
            //}
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
