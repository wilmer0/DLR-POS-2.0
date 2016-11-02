namespace puntoVenta
{
    partial class reporte_cliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reporte_cliente));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codigo_grid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_grid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.identificacion_grid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_categoria_grid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categora_grid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_subcate_grid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subcategoria_grid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.limite_credito_grid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crdito_abiertogrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ck_clientes_Activos = new System.Windows.Forms.CheckBox();
            this.ck_tecnica_rfm = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.limite_credito_hasta_txt = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.limite_credito_desde_txt = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ck_registro_hasta = new System.Windows.Forms.CheckBox();
            this.ck_registro_desde = new System.Windows.Forms.CheckBox();
            this.registro_hasta_txt = new System.Windows.Forms.DateTimePicker();
            this.registro_desde_txt = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.nombre_sucursal_txt = new System.Windows.Forms.TextBox();
            this.codigo_sucursal_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Location = new System.Drawing.Point(13, 607);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(856, 54);
            this.panel2.TabIndex = 102;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button4.BackgroundImage = global::puntoVenta.Properties.Resources.map_icon;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(394, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(71, 54);
            this.button4.TabIndex = 2;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::puntoVenta.Properties.Resources.edit_not_validated1;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Dock = System.Windows.Forms.DockStyle.Left;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(0, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(71, 54);
            this.button5.TabIndex = 1;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Dock = System.Windows.Forms.DockStyle.Right;
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(784, 0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(72, 54);
            this.button6.TabIndex = 0;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo_grid,
            this.nombre_grid,
            this.identificacion_grid,
            this.cod_categoria_grid,
            this.categora_grid,
            this.cod_subcate_grid,
            this.subcategoria_grid,
            this.limite_credito_grid,
            this.crdito_abiertogrid});
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(12, 225);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(857, 376);
            this.dataGridView1.TabIndex = 101;
            // 
            // codigo_grid
            // 
            this.codigo_grid.FillWeight = 40F;
            this.codigo_grid.HeaderText = "cod";
            this.codigo_grid.Name = "codigo_grid";
            this.codigo_grid.ReadOnly = true;
            // 
            // nombre_grid
            // 
            this.nombre_grid.HeaderText = "nombre";
            this.nombre_grid.Name = "nombre_grid";
            this.nombre_grid.ReadOnly = true;
            // 
            // identificacion_grid
            // 
            this.identificacion_grid.HeaderText = "identificacion";
            this.identificacion_grid.Name = "identificacion_grid";
            this.identificacion_grid.ReadOnly = true;
            // 
            // cod_categoria_grid
            // 
            this.cod_categoria_grid.FillWeight = 40F;
            this.cod_categoria_grid.HeaderText = "cod";
            this.cod_categoria_grid.Name = "cod_categoria_grid";
            this.cod_categoria_grid.ReadOnly = true;
            // 
            // categora_grid
            // 
            this.categora_grid.HeaderText = "categoria";
            this.categora_grid.Name = "categora_grid";
            this.categora_grid.ReadOnly = true;
            // 
            // cod_subcate_grid
            // 
            this.cod_subcate_grid.FillWeight = 40F;
            this.cod_subcate_grid.HeaderText = "cod";
            this.cod_subcate_grid.Name = "cod_subcate_grid";
            this.cod_subcate_grid.ReadOnly = true;
            // 
            // subcategoria_grid
            // 
            this.subcategoria_grid.HeaderText = "sub-categoria";
            this.subcategoria_grid.Name = "subcategoria_grid";
            this.subcategoria_grid.ReadOnly = true;
            // 
            // limite_credito_grid
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.limite_credito_grid.DefaultCellStyle = dataGridViewCellStyle4;
            this.limite_credito_grid.HeaderText = "limite credito";
            this.limite_credito_grid.Name = "limite_credito_grid";
            this.limite_credito_grid.ReadOnly = true;
            // 
            // crdito_abiertogrid
            // 
            this.crdito_abiertogrid.HeaderText = "credito abierto";
            this.crdito_abiertogrid.Name = "crdito_abiertogrid";
            this.crdito_abiertogrid.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(856, 207);
            this.groupBox1.TabIndex = 103;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(784, 152);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 49);
            this.button2.TabIndex = 112;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ck_clientes_Activos);
            this.groupBox5.Controls.Add(this.ck_tecnica_rfm);
            this.groupBox5.Location = new System.Drawing.Point(242, 9);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(230, 192);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            // 
            // ck_clientes_Activos
            // 
            this.ck_clientes_Activos.AutoSize = true;
            this.ck_clientes_Activos.Checked = true;
            this.ck_clientes_Activos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_clientes_Activos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_clientes_Activos.ForeColor = System.Drawing.Color.Black;
            this.ck_clientes_Activos.Location = new System.Drawing.Point(6, 43);
            this.ck_clientes_Activos.Name = "ck_clientes_Activos";
            this.ck_clientes_Activos.Size = new System.Drawing.Size(155, 28);
            this.ck_clientes_Activos.TabIndex = 52;
            this.ck_clientes_Activos.Text = "clientes activos";
            this.ck_clientes_Activos.UseVisualStyleBackColor = true;
            // 
            // ck_tecnica_rfm
            // 
            this.ck_tecnica_rfm.AutoSize = true;
            this.ck_tecnica_rfm.Checked = true;
            this.ck_tecnica_rfm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_tecnica_rfm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_tecnica_rfm.ForeColor = System.Drawing.Color.Black;
            this.ck_tecnica_rfm.Location = new System.Drawing.Point(6, 12);
            this.ck_tecnica_rfm.Name = "ck_tecnica_rfm";
            this.ck_tecnica_rfm.Size = new System.Drawing.Size(176, 28);
            this.ck_tecnica_rfm.TabIndex = 51;
            this.ck_tecnica_rfm.Text = "usar tecnica RFM";
            this.ck_tecnica_rfm.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.limite_credito_hasta_txt);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.limite_credito_desde_txt);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(478, 9);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(230, 77);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Limite de credito";
            // 
            // limite_credito_hasta_txt
            // 
            this.limite_credito_hasta_txt.Location = new System.Drawing.Point(142, 43);
            this.limite_credito_hasta_txt.Mask = "9999999999";
            this.limite_credito_hasta_txt.Name = "limite_credito_hasta_txt";
            this.limite_credito_hasta_txt.Size = new System.Drawing.Size(78, 20);
            this.limite_credito_hasta_txt.TabIndex = 119;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(142, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 24);
            this.label4.TabIndex = 117;
            this.label4.Text = "hasta";
            this.label4.UseCompatibleTextRendering = true;
            // 
            // limite_credito_desde_txt
            // 
            this.limite_credito_desde_txt.Location = new System.Drawing.Point(5, 46);
            this.limite_credito_desde_txt.Mask = "9999999999";
            this.limite_credito_desde_txt.Name = "limite_credito_desde_txt";
            this.limite_credito_desde_txt.Size = new System.Drawing.Size(78, 20);
            this.limite_credito_desde_txt.TabIndex = 118;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(5, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 24);
            this.label5.TabIndex = 116;
            this.label5.Text = "desde";
            this.label5.UseCompatibleTextRendering = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ck_registro_hasta);
            this.groupBox3.Controls.Add(this.ck_registro_desde);
            this.groupBox3.Controls.Add(this.registro_hasta_txt);
            this.groupBox3.Controls.Add(this.registro_desde_txt);
            this.groupBox3.Location = new System.Drawing.Point(6, 94);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(230, 107);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Registro cliente";
            // 
            // ck_registro_hasta
            // 
            this.ck_registro_hasta.AutoSize = true;
            this.ck_registro_hasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_registro_hasta.ForeColor = System.Drawing.Color.Black;
            this.ck_registro_hasta.Location = new System.Drawing.Point(9, 58);
            this.ck_registro_hasta.Name = "ck_registro_hasta";
            this.ck_registro_hasta.Size = new System.Drawing.Size(68, 24);
            this.ck_registro_hasta.TabIndex = 118;
            this.ck_registro_hasta.Text = "hasta";
            this.ck_registro_hasta.UseVisualStyleBackColor = true;
            this.ck_registro_hasta.Click += new System.EventHandler(this.ck_registro_hasta_Click);
            // 
            // ck_registro_desde
            // 
            this.ck_registro_desde.AutoSize = true;
            this.ck_registro_desde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_registro_desde.ForeColor = System.Drawing.Color.Black;
            this.ck_registro_desde.Location = new System.Drawing.Point(9, 15);
            this.ck_registro_desde.Name = "ck_registro_desde";
            this.ck_registro_desde.Size = new System.Drawing.Size(72, 24);
            this.ck_registro_desde.TabIndex = 53;
            this.ck_registro_desde.Text = "desde";
            this.ck_registro_desde.UseVisualStyleBackColor = true;
            this.ck_registro_desde.CheckedChanged += new System.EventHandler(this.ck_registro_desde_CheckedChanged);
            this.ck_registro_desde.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // registro_hasta_txt
            // 
            this.registro_hasta_txt.Enabled = false;
            this.registro_hasta_txt.Location = new System.Drawing.Point(6, 82);
            this.registro_hasta_txt.Name = "registro_hasta_txt";
            this.registro_hasta_txt.Size = new System.Drawing.Size(212, 20);
            this.registro_hasta_txt.TabIndex = 117;
            // 
            // registro_desde_txt
            // 
            this.registro_desde_txt.Enabled = false;
            this.registro_desde_txt.Location = new System.Drawing.Point(9, 39);
            this.registro_desde_txt.Name = "registro_desde_txt";
            this.registro_desde_txt.Size = new System.Drawing.Size(212, 20);
            this.registro_desde_txt.TabIndex = 116;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.nombre_sucursal_txt);
            this.groupBox2.Controls.Add(this.codigo_sucursal_txt);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(6, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 79);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sucursal";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(204, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(17, 24);
            this.label19.TabIndex = 111;
            this.label19.Text = "X";
            this.label19.UseCompatibleTextRendering = true;
            this.label19.Click += new System.EventHandler(this.label19_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(164, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 30);
            this.button1.TabIndex = 66;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nombre_sucursal_txt
            // 
            this.nombre_sucursal_txt.Location = new System.Drawing.Point(9, 43);
            this.nombre_sucursal_txt.Name = "nombre_sucursal_txt";
            this.nombre_sucursal_txt.ReadOnly = true;
            this.nombre_sucursal_txt.Size = new System.Drawing.Size(189, 20);
            this.nombre_sucursal_txt.TabIndex = 65;
            // 
            // codigo_sucursal_txt
            // 
            this.codigo_sucursal_txt.Location = new System.Drawing.Point(79, 16);
            this.codigo_sucursal_txt.Name = "codigo_sucursal_txt";
            this.codigo_sucursal_txt.ReadOnly = true;
            this.codigo_sucursal_txt.Size = new System.Drawing.Size(56, 20);
            this.codigo_sucursal_txt.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 24);
            this.label1.TabIndex = 63;
            this.label1.Text = "sucursal";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // reporte_cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(886, 671);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "reporte_cliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte cliente";
            this.Load += new System.EventHandler(this.reporte_cliente_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.TextBox nombre_sucursal_txt;
        private System.Windows.Forms.TextBox codigo_sucursal_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.MaskedTextBox limite_credito_hasta_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox limite_credito_desde_txt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox ck_clientes_Activos;
        private System.Windows.Forms.CheckBox ck_tecnica_rfm;
        private System.Windows.Forms.CheckBox ck_registro_hasta;
        private System.Windows.Forms.CheckBox ck_registro_desde;
        private System.Windows.Forms.DateTimePicker registro_hasta_txt;
        private System.Windows.Forms.DateTimePicker registro_desde_txt;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn identificacion_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_categoria_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn categora_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_subcate_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn subcategoria_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn limite_credito_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn crdito_abiertogrid;
    }
}