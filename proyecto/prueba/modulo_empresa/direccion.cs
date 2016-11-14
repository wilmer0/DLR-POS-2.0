using puntoVenta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace puntoVenta
{
    public partial class direccion : Form
    {
    private Panel panel2;
    private Button button3;
    private Button button2;
    private Label label1;
    private TextBox codigo_pais_txt;
    private Button pais_btn;
    private TextBox codigo_region_txt;
    private Label label2;
    private TextBox codigo_provincia_txt;
    private Label label3;
    private TextBox codigo_sector_txt;
    private Label label4;
    private TextBox detalle_txt;
    private Label label5;
    private Button region_btn;
    private Button provincia_btn;
    private Button sector_btn;
    private TextBox pais_nombre;
    private TextBox provincia_nombre;
    private TextBox region_nombre;
    private TextBox sector_nombre;
    private CheckBox ck_activo;
    private DataGridViewTextBoxColumn codigo;
    private DataGridView dataGridView1;
    private Button button1; public direccion() { InitializeComponent(); }

private void InitializeComponent()
{
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(direccion));
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.codigo_pais_txt = new System.Windows.Forms.TextBox();
            this.codigo_region_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.codigo_provincia_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.codigo_sector_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.detalle_txt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pais_nombre = new System.Windows.Forms.TextBox();
            this.provincia_nombre = new System.Windows.Forms.TextBox();
            this.region_nombre = new System.Windows.Forms.TextBox();
            this.sector_nombre = new System.Windows.Forms.TextBox();
            this.sector_btn = new System.Windows.Forms.Button();
            this.provincia_btn = new System.Windows.Forms.Button();
            this.region_btn = new System.Windows.Forms.Button();
            this.pais_btn = new System.Windows.Forms.Button();
            this.ck_activo = new System.Windows.Forms.CheckBox();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(12, 488);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(623, 54);
            this.panel2.TabIndex = 26;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button3.BackgroundImage = global::puntoVenta.Properties.Resources.map_icon;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(277, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(71, 54);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::puntoVenta.Properties.Resources.edit_not_validated1;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Dock = System.Windows.Forms.DockStyle.Left;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 54);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::puntoVenta.Properties.Resources.save_file_disk_open_searsh_loading_clipboard_1513;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(551, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 54);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(37, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 29);
            this.label1.TabIndex = 27;
            this.label1.Text = "Pais";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // codigo_pais_txt
            // 
            this.codigo_pais_txt.Location = new System.Drawing.Point(149, 48);
            this.codigo_pais_txt.Name = "codigo_pais_txt";
            this.codigo_pais_txt.ReadOnly = true;
            this.codigo_pais_txt.Size = new System.Drawing.Size(100, 20);
            this.codigo_pais_txt.TabIndex = 28;
            this.codigo_pais_txt.TextChanged += new System.EventHandler(this.codigo_pais_txt_TextChanged);
            this.codigo_pais_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.codigo_pais_txt_KeyUp);
            // 
            // codigo_region_txt
            // 
            this.codigo_region_txt.Location = new System.Drawing.Point(426, 44);
            this.codigo_region_txt.Name = "codigo_region_txt";
            this.codigo_region_txt.ReadOnly = true;
            this.codigo_region_txt.Size = new System.Drawing.Size(100, 20);
            this.codigo_region_txt.TabIndex = 31;
            this.codigo_region_txt.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(340, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 29);
            this.label2.TabIndex = 30;
            this.label2.Text = "Region";
            this.label2.UseCompatibleTextRendering = true;
            // 
            // codigo_provincia_txt
            // 
            this.codigo_provincia_txt.Location = new System.Drawing.Point(150, 135);
            this.codigo_provincia_txt.Name = "codigo_provincia_txt";
            this.codigo_provincia_txt.ReadOnly = true;
            this.codigo_provincia_txt.Size = new System.Drawing.Size(100, 20);
            this.codigo_provincia_txt.TabIndex = 34;
            this.codigo_provincia_txt.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(37, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 29);
            this.label3.TabIndex = 33;
            this.label3.Text = "Provincia";
            this.label3.UseCompatibleTextRendering = true;
            // 
            // codigo_sector_txt
            // 
            this.codigo_sector_txt.Location = new System.Drawing.Point(426, 134);
            this.codigo_sector_txt.Name = "codigo_sector_txt";
            this.codigo_sector_txt.ReadOnly = true;
            this.codigo_sector_txt.Size = new System.Drawing.Size(100, 20);
            this.codigo_sector_txt.TabIndex = 37;
            this.codigo_sector_txt.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(340, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 29);
            this.label4.TabIndex = 36;
            this.label4.Text = "Sector";
            this.label4.UseCompatibleTextRendering = true;
            // 
            // detalle_txt
            // 
            this.detalle_txt.Location = new System.Drawing.Point(12, 238);
            this.detalle_txt.Multiline = true;
            this.detalle_txt.Name = "detalle_txt";
            this.detalle_txt.Size = new System.Drawing.Size(623, 185);
            this.detalle_txt.TabIndex = 39;
            this.detalle_txt.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(12, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 29);
            this.label5.TabIndex = 40;
            this.label5.Text = "Detalle";
            this.label5.UseCompatibleTextRendering = true;
            // 
            // pais_nombre
            // 
            this.pais_nombre.Location = new System.Drawing.Point(149, 72);
            this.pais_nombre.Name = "pais_nombre";
            this.pais_nombre.ReadOnly = true;
            this.pais_nombre.Size = new System.Drawing.Size(141, 20);
            this.pais_nombre.TabIndex = 44;
            // 
            // provincia_nombre
            // 
            this.provincia_nombre.Location = new System.Drawing.Point(149, 158);
            this.provincia_nombre.Name = "provincia_nombre";
            this.provincia_nombre.ReadOnly = true;
            this.provincia_nombre.Size = new System.Drawing.Size(141, 20);
            this.provincia_nombre.TabIndex = 45;
            // 
            // region_nombre
            // 
            this.region_nombre.Location = new System.Drawing.Point(426, 66);
            this.region_nombre.Name = "region_nombre";
            this.region_nombre.ReadOnly = true;
            this.region_nombre.Size = new System.Drawing.Size(141, 20);
            this.region_nombre.TabIndex = 46;
            // 
            // sector_nombre
            // 
            this.sector_nombre.Location = new System.Drawing.Point(426, 158);
            this.sector_nombre.Name = "sector_nombre";
            this.sector_nombre.ReadOnly = true;
            this.sector_nombre.Size = new System.Drawing.Size(141, 20);
            this.sector_nombre.TabIndex = 47;
            // 
            // sector_btn
            // 
            this.sector_btn.BackgroundImage = global::puntoVenta.Properties.Resources.find_icon;
            this.sector_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sector_btn.Location = new System.Drawing.Point(533, 124);
            this.sector_btn.Name = "sector_btn";
            this.sector_btn.Size = new System.Drawing.Size(34, 30);
            this.sector_btn.TabIndex = 43;
            this.sector_btn.UseVisualStyleBackColor = true;
            this.sector_btn.Click += new System.EventHandler(this.sector_btn_Click);
            // 
            // provincia_btn
            // 
            this.provincia_btn.BackgroundImage = global::puntoVenta.Properties.Resources.find_icon;
            this.provincia_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.provincia_btn.Location = new System.Drawing.Point(256, 125);
            this.provincia_btn.Name = "provincia_btn";
            this.provincia_btn.Size = new System.Drawing.Size(34, 30);
            this.provincia_btn.TabIndex = 42;
            this.provincia_btn.UseVisualStyleBackColor = true;
            this.provincia_btn.Click += new System.EventHandler(this.provincia_btn_Click);
            // 
            // region_btn
            // 
            this.region_btn.BackgroundImage = global::puntoVenta.Properties.Resources.find_icon;
            this.region_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.region_btn.Location = new System.Drawing.Point(533, 34);
            this.region_btn.Name = "region_btn";
            this.region_btn.Size = new System.Drawing.Size(34, 30);
            this.region_btn.TabIndex = 41;
            this.region_btn.UseVisualStyleBackColor = true;
            this.region_btn.Click += new System.EventHandler(this.region_btn_Click);
            // 
            // pais_btn
            // 
            this.pais_btn.BackgroundImage = global::puntoVenta.Properties.Resources.find_icon;
            this.pais_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pais_btn.Location = new System.Drawing.Point(256, 38);
            this.pais_btn.Name = "pais_btn";
            this.pais_btn.Size = new System.Drawing.Size(34, 30);
            this.pais_btn.TabIndex = 29;
            this.pais_btn.UseVisualStyleBackColor = true;
            this.pais_btn.Click += new System.EventHandler(this.button4_Click);
            // 
            // ck_activo
            // 
            this.ck_activo.AutoSize = true;
            this.ck_activo.Checked = true;
            this.ck_activo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_activo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_activo.ForeColor = System.Drawing.Color.Black;
            this.ck_activo.Location = new System.Drawing.Point(426, 192);
            this.ck_activo.Name = "ck_activo";
            this.ck_activo.Size = new System.Drawing.Size(80, 28);
            this.ck_activo.TabIndex = 53;
            this.ck_activo.Text = "Activo";
            this.ck_activo.UseVisualStyleBackColor = true;
            // 
            // codigo
            // 
            this.codigo.FillWeight = 29.61083F;
            this.codigo.HeaderText = "Codigo";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo});
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(12, 429);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(126, 53);
            this.dataGridView1.TabIndex = 50;
            // 
            // direccion
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(647, 544);
            this.Controls.Add(this.ck_activo);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.sector_nombre);
            this.Controls.Add(this.region_nombre);
            this.Controls.Add(this.provincia_nombre);
            this.Controls.Add(this.pais_nombre);
            this.Controls.Add(this.sector_btn);
            this.Controls.Add(this.provincia_btn);
            this.Controls.Add(this.region_btn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.detalle_txt);
            this.Controls.Add(this.codigo_sector_txt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.codigo_provincia_txt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.codigo_region_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pais_btn);
            this.Controls.Add(this.codigo_pais_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "direccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Direccion";
            this.Load += new System.EventHandler(this.direccion_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

}
        public delegate void pasar(string dato);
        public event pasar pasado;
        public string codigo_direccion_global ="";
        private void direccion_Load(object sender, EventArgs e)
        {
            pais_btn.Focus();
            if(codigo_direccion_global!="")
            {
                cargar_datos();
            }
        }
        public void cargar_datos()
        {
            try
            {
                string sql = "select dir.codigo as codigo_direccion,p.codigo,r.codigo,pro.codigo,sec.codigo,dir.detalle,dir.estado from pais p join region r  on p.codigo=r.cod_pais join provincia pro  on pro.cod_region=r.codigo join sector sec  on sec.cod_provincia=pro.codigo join direccion dir on dir.cod_sector=sec.codigo where dir.codigo='"+codigo_direccion_global.ToString()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);

                //agregando el codigo de la direccion al datagrid para que cuando lo cargue tambien cargue la direccion
                dataGridView1.Rows.Add(ds.Tables[0].Rows[0][0].ToString());
                
                codigo_pais_txt.Text = ds.Tables[0].Rows[0][1].ToString();
                cargar_nombre_pais();

                codigo_region_txt.Text = ds.Tables[0].Rows[0][2].ToString();
                cargar_nombre_region();

                codigo_provincia_txt.Text = ds.Tables[0].Rows[0][3].ToString();
                cargar_nombre_provincia();

                codigo_sector_txt.Text=ds.Tables[0].Rows[0][4].ToString();
                cargar_nombre_sector();

                detalle_txt.Text = ds.Tables[0].Rows[0][5].ToString();

                if (ds.Tables[0].Rows[0][6].ToString() == "True")
                    ck_activo.Checked = true;
                else
                    ck_activo.Checked = false;

            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando la direccion");
            }
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                pais p = new pais();
                p.pasado += new pais.pasar(ejecutar_pais);
                p.ShowDialog();
                codigo_region_txt.Clear();
                region_nombre.Clear();
                codigo_provincia_txt.Clear();
                provincia_nombre.Clear();
                codigo_sector_txt.Clear();
                sector_nombre.Clear();
                detalle_txt.Clear();
                
                ck_activo.Checked = false;
            }
            catch(Exception)
            {

            }
        }
        public void ejecutar_pais(string dato)
        {
            codigo_pais_txt.Text = dato.ToString();
            codigo_pais_txt.ReadOnly = true;
        }
        public void ejecutar_region(string dato)
        {
            codigo_region_txt.Text = dato.ToString();
            codigo_region_txt.ReadOnly = true;
        }
        public void ejecutar_provincia(string dato)
        {
            codigo_provincia_txt.Text = dato.ToString();
            codigo_provincia_txt.ReadOnly = true;
        }
        public void ejecutar_sector(string dato)
        {
            codigo_sector_txt.Text = dato.ToString();
            codigo_sector_txt.ReadOnly = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void codigo_pais_txt_TextChanged(object sender, EventArgs e)
        {
            cargar_nombre_pais();
        }
        public void cargar_nombre_pais()
        {
            try
            {
                string sql = "select nombre from pais where codigo='" + codigo_pais_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                pais_nombre.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error sacando el nombre del pais");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Desea salir?","Saliendo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(dr==DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea limpiar?", "Limpiando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    codigo_pais_txt.Clear();
                    pais_nombre.Clear();
                    codigo_region_txt.Clear();
                    region_nombre.Clear();
                    provincia_nombre.Clear();
                    codigo_provincia_txt.Clear();
                    codigo_sector_txt.Clear();
                    sector_nombre.Clear();
                    ck_activo.Checked = true;
                    detalle_txt.Clear();

                    dataGridView1.Rows.Clear();
                  

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error borrando los datos");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                guardar_direccion();
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

        private void region_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (codigo_pais_txt.Text.Trim() != "")
                {

                    region r = new region();
                    r.pasado += new region.pasar(ejecutar_region);
                    r.cod_pais = codigo_pais_txt.Text.Trim();
                    r.ShowDialog();
                    cargar_nombre_region();
                    codigo_provincia_txt.Clear();
                    provincia_nombre.Clear();
                    codigo_sector_txt.Clear();
                    sector_nombre.Clear();
                    detalle_txt.Clear();
                    
                    ck_activo.Checked = false;
                }
                else
                {
                    MessageBox.Show("Falta que seleccione el pais");
                }
            }
            catch(Exception)
            {

            }
        }
        public void cargar_nombre_region()
        {
            try
            {
                string sql = "select nombre from region where codigo='"+codigo_region_txt.Text.Trim()+"'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                region_nombre.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Error cargando nombre de la region");
            }
        }
        private void provincia_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (codigo_region_txt.Text.Trim() != "")
                {
                    provincia p = new provincia();
                    p.pasado += new provincia.pasar(ejecutar_provincia);
                    p.cod_region = codigo_region_txt.Text.Trim();
                    p.ShowDialog();
                    cargar_nombre_provincia();

                    codigo_sector_txt.Clear();
                    sector_nombre.Clear();
                    detalle_txt.Clear();
                    
                    ck_activo.Checked = false;
                }
                else
                {
                    MessageBox.Show("Falta que seleccione la region");
                }
            }
            catch (Exception)
            {

            }
        }
        public void cargar_nombre_provincia()
        {
            try
            {
                string sql = "select nombre from provincia where codigo='" + codigo_provincia_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                provincia_nombre.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando nombre de la provincia");
            }
        }
        private void sector_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (codigo_provincia_txt.Text.Trim() != "")
                {
                    sector s = new sector();
                    s.pasado += new sector.pasar(ejecutar_sector);
                    s.cod_provincia = codigo_provincia_txt.Text.Trim();
                    s.ShowDialog();
                    cargar_nombre_sector();

                    detalle_txt.Clear();
                    
                    ck_activo.Checked = false;
                }
                else
                {
                    MessageBox.Show("Falta que seleccione la provincia");
                }
            }
            catch(Exception)
            {

            }
        }
        public void cargar_nombre_sector()
        {
            try
            {
                string sql = "select nombre from sector where codigo='" + codigo_region_txt.Text.Trim() + "'";
                DataSet ds = Utilidades.ejecutarcomando(sql);
                sector_nombre.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error cargando nombre del sector");
            }
        }

        private void codigo_pais_txt_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
        }
        public void guardar_direccion()
        {
            try
            {
                //create proc insert_direccion @codigo_sector int,@detalle varchar(1000),@estado bit
                if (detalle_txt.Text.Trim() != "")
                {
                    string cod_direccion_temp = "";
                    int estado = 0;
                    if (ck_activo.Checked == true)
                        estado = 1;
                    if (dataGridView1.Rows.Count == 0)
                    {
                        //agregar una nueva direccion
                        string sql = "exec insert_direccion '" + codigo_sector_txt.Text.Trim() + "','" + detalle_txt.Text.Trim() + "','" + estado.ToString() + "','0'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        cod_direccion_temp = ds.Tables[0].Rows[0][0].ToString();
                        dataGridView1.Rows.Clear();
                        dataGridView1.Rows.Add(cod_direccion_temp.ToString());
                    }
                    else
                    {
                        //modificar una direccion
                        string codigo_direccion_parametro = dataGridView1.Rows[0].Cells[0].Value.ToString();
                        string sql = "exec insert_direccion '" + codigo_sector_txt.Text.Trim() + "','" + detalle_txt.Text.Trim() + "','" + estado.ToString() + "','" + codigo_direccion_parametro.ToString() + "'";
                        DataSet ds = Utilidades.ejecutarcomando(sql);
                        //cod_direccion_temp = ds.Tables[0].Rows[0][0].ToString();
                        //dataGridView1.Rows.Clear();
                        //dataGridView1.Rows.Add(cod_direccion_temp.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("El detalle de la direccion no puede estar en blanco");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error agregando el codigo de la direccion");
            }
        }
    }
}