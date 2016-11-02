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
    public partial class busqueda_empleado : Form
    {
        public busqueda_empleado()
        {
            InitializeComponent();
        }
        public delegate void pasar(string dato);
        public event pasar pasado;
        public bool mantenimiento = false;
        public string codigo_sucursal = "";
        internal singleton s { get; set; }
        private void busqueda_empleado_Load(object sender, EventArgs e)
        {
            cargar_empleado();
            nombre_txt.Focus();
        }
        public void cargar_empleado()
        {
            try
            {
                if (mantenimiento == false)
                {
                    string sql = "select e.codigo,t.nombre,p.apellido,p.fecha_nacimiento,se.descripcion as situacion,(select nombre from tercero tt join sucursal suc on tt.codigo=suc.codigo where suc.codigo=e.cod_sucursal) as sucursal from tercero t join persona p on t.codigo=p.codigo join empleado e on e.codigo=p.codigo join situacion_empleado se on se.codigo=e.cod_situacion join sucursal su on e.cod_sucursal=su.codigo where e.estado='1'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    string sql = "select e.codigo,t.nombre,p.apellido,p.fecha_nacimiento,se.descripcion as situacion,(select nombre from tercero tt join sucursal suc on tt.codigo=suc.codigo where suc.codigo=e.cod_sucursal) as sucursal from tercero t join persona p on t.codigo=p.codigo join empleado e on e.codigo=p.codigo join situacion_empleado se on se.codigo=e.cod_situacion join sucursal su on e.cod_sucursal=su.codigo";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                if(codigo_sucursal.ToString()!="" && mantenimiento == false)
                {
                    string sql = "select e.codigo,t.nombre,p.apellido,p.fecha_nacimiento,se.descripcion as situacion,(select nombre from tercero tt join sucursal suc on tt.codigo=suc.codigo where suc.codigo=e.cod_sucursal) as sucursal from tercero t join persona p on t.codigo=p.codigo join empleado e on e.codigo=p.codigo join situacion_empleado se on se.codigo=e.cod_situacion join sucursal su on e.cod_sucursal=su.codigo where e.estado='1' and e.cod_sucural='"+codigo_sucursal.ToString()+"'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                if (codigo_sucursal.ToString() != "" && mantenimiento == true)
                {
                    string sql = "select e.codigo,t.nombre,p.apellido,p.fecha_nacimiento,se.descripcion as situacion,(select nombre from tercero tt join sucursal suc on tt.codigo=suc.codigo where suc.codigo=e.cod_sucursal) as sucursal from tercero t join persona p on t.codigo=p.codigo join empleado e on e.codigo=p.codigo join situacion_empleado se on se.codigo=e.cod_situacion join sucursal su on e.cod_sucursal=su.codigo where e.cod_sucural='" + codigo_sucursal.ToString() + "'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando empleados");
            }
        }

        private void nombre_txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (mantenimiento == false)
                {
                    string sql = "select e.codigo,t.nombre,p.apellido,p.fecha_nacimiento,se.descripcion as situacion,(select nombre from tercero tt join sucursal suc on tt.codigo=suc.codigo where suc.codigo=e.cod_sucursal) as sucursal from tercero t join persona p on t.codigo=p.codigo join empleado e on e.codigo=p.codigo join situacion_empleado se on se.codigo=e.cod_situacion join sucursal su on e.cod_sucursal=su.codigo where e.estado='1' and t.nombre like '%"+nombre_txt.Text.Trim()+"%' or p.apellido like '%"+nombre_txt.Text.Trim()+"%'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    string sql = "select e.codigo,t.nombre,p.apellido,p.fecha_nacimiento,se.descripcion as situacion,(select nombre from tercero tt join sucursal suc on tt.codigo=suc.codigo where suc.codigo=e.cod_sucursal) as sucursal from tercero t join persona p on t.codigo=p.codigo join empleado e on e.codigo=p.codigo join situacion_empleado se on se.codigo=e.cod_situacion join sucursal su on e.cod_sucursal=su.codigo where  t.nombre like '%" + nombre_txt.Text.Trim() + "%' or p.apellido like '%" + nombre_txt.Text.Trim() + "%'";
                    DataSet ds = Utilidades.ejecutarcomando(sql);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando empleados por nombre");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = "";
                //MessageBox.Show(codigo_emp = dataGridView1.CurrentRow.Cells[0].Value.ToString());
                codigo = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                pasado(codigo.ToString());
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error pasando variable hacia atras");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            empleado em = new empleado();
            em.ShowDialog();
        }
    }
}
