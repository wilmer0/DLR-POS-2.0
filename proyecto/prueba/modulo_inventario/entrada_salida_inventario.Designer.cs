namespace puntoVenta
{
    partial class entrada_salida_inventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(entrada_salida_inventario));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.codigo_unidad_txt = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.codigo_producto_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.existencia_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nombre_producto_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cantidad_txt = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ck_producto_activo = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.concepto_txt = new System.Windows.Forms.TextBox();
            this.nombre_almacen_txt = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.codigo_almacen_txt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.nombre_sucursal_txt = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.codigo_sucursal_txt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.unidad_combo_txt = new System.Windows.Forms.ComboBox();
            this.button8 = new System.Windows.Forms.Button();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.existencia_grid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.nombre,
            this.cod_unidad,
            this.unidad,
            this.existencia_grid,
            this.cantidad,
            this.mov});
            this.dataGridView1.Location = new System.Drawing.Point(12, 134);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(958, 253);
            this.dataGridView1.TabIndex = 78;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(12, 546);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(958, 62);
            this.panel2.TabIndex = 80;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button3.BackgroundImage = global::puntoVenta.Properties.Resources.map_icon;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(445, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(71, 62);
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
            this.button2.Size = new System.Drawing.Size(71, 62);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::puntoVenta.Properties.Resources.save_file_disk_open_searsh_loading_clipboard_15131;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(886, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 62);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // codigo_unidad_txt
            // 
            this.codigo_unidad_txt.Location = new System.Drawing.Point(387, 111);
            this.codigo_unidad_txt.Name = "codigo_unidad_txt";
            this.codigo_unidad_txt.ReadOnly = true;
            this.codigo_unidad_txt.Size = new System.Drawing.Size(38, 20);
            this.codigo_unidad_txt.TabIndex = 106;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label14.Location = new System.Drawing.Point(325, 110);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label14.Size = new System.Drawing.Size(60, 20);
            this.label14.TabIndex = 105;
            this.label14.Text = "Unidad";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // codigo_producto_txt
            // 
            this.codigo_producto_txt.Location = new System.Drawing.Point(84, 111);
            this.codigo_producto_txt.Name = "codigo_producto_txt";
            this.codigo_producto_txt.ReadOnly = true;
            this.codigo_producto_txt.Size = new System.Drawing.Size(36, 20);
            this.codigo_producto_txt.TabIndex = 108;
            this.codigo_producto_txt.TextChanged += new System.EventHandler(this.codigo_producto_txt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.Location = new System.Drawing.Point(8, 110);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 107;
            this.label1.Text = "Producto";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // existencia_txt
            // 
            this.existencia_txt.Location = new System.Drawing.Point(654, 111);
            this.existencia_txt.Name = "existencia_txt";
            this.existencia_txt.ReadOnly = true;
            this.existencia_txt.Size = new System.Drawing.Size(100, 20);
            this.existencia_txt.TabIndex = 110;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label2.Location = new System.Drawing.Point(567, 110);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 109;
            this.label2.Text = "Existencia";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // nombre_producto_txt
            // 
            this.nombre_producto_txt.Location = new System.Drawing.Point(126, 111);
            this.nombre_producto_txt.Name = "nombre_producto_txt";
            this.nombre_producto_txt.ReadOnly = true;
            this.nombre_producto_txt.Size = new System.Drawing.Size(119, 20);
            this.nombre_producto_txt.TabIndex = 111;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label3.Location = new System.Drawing.Point(781, 110);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 113;
            this.label3.Text = "Cantidad";
            // 
            // cantidad_txt
            // 
            this.cantidad_txt.Location = new System.Drawing.Point(860, 111);
            this.cantidad_txt.Name = "cantidad_txt";
            this.cantidad_txt.Size = new System.Drawing.Size(104, 20);
            this.cantidad_txt.TabIndex = 114;
            this.cantidad_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cantidad_txt_KeyUp);
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.BackgroundImage = global::puntoVenta.Properties.Resources.Ok;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Location = new System.Drawing.Point(898, 393);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(70, 47);
            this.button4.TabIndex = 115;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button5.BackgroundImage = global::puntoVenta.Properties.Resources.cancel;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Location = new System.Drawing.Point(816, 393);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(70, 47);
            this.button5.TabIndex = 116;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label4.Location = new System.Drawing.Point(818, 439);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(67, 25);
            this.label4.TabIndex = 117;
            this.label4.Text = "Salida";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label5.Location = new System.Drawing.Point(892, 439);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(80, 25);
            this.label5.TabIndex = 118;
            this.label5.Text = "Entrada";
            // 
            // ck_producto_activo
            // 
            this.ck_producto_activo.AutoSize = true;
            this.ck_producto_activo.Checked = true;
            this.ck_producto_activo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_producto_activo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_producto_activo.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.ck_producto_activo.Location = new System.Drawing.Point(12, 393);
            this.ck_producto_activo.Name = "ck_producto_activo";
            this.ck_producto_activo.Size = new System.Drawing.Size(167, 28);
            this.ck_producto_activo.TabIndex = 119;
            this.ck_producto_activo.Text = "Productos activo";
            this.ck_producto_activo.UseVisualStyleBackColor = true;
            this.ck_producto_activo.CheckedChanged += new System.EventHandler(this.ck_producto_activo_CheckedChanged);
            this.ck_producto_activo.Click += new System.EventHandler(this.ck_producto_activo_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label6.Location = new System.Drawing.Point(10, 439);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(97, 25);
            this.label6.TabIndex = 120;
            this.label6.Text = "Concepto";
            // 
            // concepto_txt
            // 
            this.concepto_txt.Location = new System.Drawing.Point(15, 466);
            this.concepto_txt.MaxLength = 200;
            this.concepto_txt.Multiline = true;
            this.concepto_txt.Name = "concepto_txt";
            this.concepto_txt.Size = new System.Drawing.Size(954, 74);
            this.concepto_txt.TabIndex = 121;
            // 
            // nombre_almacen_txt
            // 
            this.nombre_almacen_txt.Location = new System.Drawing.Point(191, 69);
            this.nombre_almacen_txt.Name = "nombre_almacen_txt";
            this.nombre_almacen_txt.ReadOnly = true;
            this.nombre_almacen_txt.Size = new System.Drawing.Size(125, 20);
            this.nombre_almacen_txt.TabIndex = 129;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.Location = new System.Drawing.Point(148, 64);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(34, 30);
            this.button7.TabIndex = 128;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // codigo_almacen_txt
            // 
            this.codigo_almacen_txt.Location = new System.Drawing.Point(96, 71);
            this.codigo_almacen_txt.Name = "codigo_almacen_txt";
            this.codigo_almacen_txt.ReadOnly = true;
            this.codigo_almacen_txt.Size = new System.Drawing.Size(46, 20);
            this.codigo_almacen_txt.TabIndex = 127;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label7.Location = new System.Drawing.Point(10, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 25);
            this.label7.TabIndex = 126;
            this.label7.Text = "Almacen";
            // 
            // nombre_sucursal_txt
            // 
            this.nombre_sucursal_txt.Location = new System.Drawing.Point(191, 30);
            this.nombre_sucursal_txt.Name = "nombre_sucursal_txt";
            this.nombre_sucursal_txt.ReadOnly = true;
            this.nombre_sucursal_txt.Size = new System.Drawing.Size(125, 20);
            this.nombre_sucursal_txt.TabIndex = 125;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Location = new System.Drawing.Point(148, 25);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(34, 30);
            this.button6.TabIndex = 124;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // codigo_sucursal_txt
            // 
            this.codigo_sucursal_txt.Location = new System.Drawing.Point(96, 32);
            this.codigo_sucursal_txt.Name = "codigo_sucursal_txt";
            this.codigo_sucursal_txt.ReadOnly = true;
            this.codigo_sucursal_txt.Size = new System.Drawing.Size(46, 20);
            this.codigo_sucursal_txt.TabIndex = 123;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label8.Location = new System.Drawing.Point(10, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 25);
            this.label8.TabIndex = 122;
            this.label8.Text = "Sucursal";
            // 
            // unidad_combo_txt
            // 
            this.unidad_combo_txt.FormattingEnabled = true;
            this.unidad_combo_txt.Location = new System.Drawing.Point(431, 111);
            this.unidad_combo_txt.Name = "unidad_combo_txt";
            this.unidad_combo_txt.Size = new System.Drawing.Size(121, 21);
            this.unidad_combo_txt.TabIndex = 130;
            this.unidad_combo_txt.TextChanged += new System.EventHandler(this.unidad_combo_txt_TextChanged);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button8.BackgroundImage")));
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.Location = new System.Drawing.Point(251, 102);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(34, 30);
            this.button8.TabIndex = 131;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // codigo
            // 
            this.codigo.FillWeight = 30F;
            this.codigo.HeaderText = "Codigo";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // cod_unidad
            // 
            this.cod_unidad.FillWeight = 30F;
            this.cod_unidad.HeaderText = "Codigo";
            this.cod_unidad.Name = "cod_unidad";
            this.cod_unidad.ReadOnly = true;
            this.cod_unidad.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // unidad
            // 
            this.unidad.HeaderText = "Unidad";
            this.unidad.Name = "unidad";
            this.unidad.ReadOnly = true;
            this.unidad.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // existencia_grid
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.existencia_grid.DefaultCellStyle = dataGridViewCellStyle3;
            this.existencia_grid.FillWeight = 40F;
            this.existencia_grid.HeaderText = "Existencia";
            this.existencia_grid.Name = "existencia_grid";
            this.existencia_grid.ReadOnly = true;
            // 
            // cantidad
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle4.NullValue = "0";
            this.cantidad.DefaultCellStyle = dataGridViewCellStyle4;
            this.cantidad.FillWeight = 30F;
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // mov
            // 
            this.mov.FillWeight = 20F;
            this.mov.HeaderText = "Mov";
            this.mov.Name = "mov";
            this.mov.ReadOnly = true;
            // 
            // entrada_salida_inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(982, 616);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.unidad_combo_txt);
            this.Controls.Add(this.nombre_almacen_txt);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.codigo_almacen_txt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nombre_sucursal_txt);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.codigo_sucursal_txt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.concepto_txt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ck_producto_activo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.cantidad_txt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nombre_producto_txt);
            this.Controls.Add(this.existencia_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.codigo_producto_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.codigo_unidad_txt);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "entrada_salida_inventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entrada Salida Inventario";
            this.Load += new System.EventHandler(this.entrada_salida_inventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox codigo_unidad_txt;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox codigo_producto_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox existencia_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nombre_producto_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cantidad_txt;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox ck_producto_activo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox concepto_txt;
        private System.Windows.Forms.TextBox nombre_almacen_txt;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox codigo_almacen_txt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox nombre_sucursal_txt;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox codigo_sucursal_txt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox unidad_combo_txt;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn existencia_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn mov;
    }
}