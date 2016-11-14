namespace puntoVenta
{
    partial class cuenta_por_cobrar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cuenta_por_cobrar));
            this.label1 = new System.Windows.Forms.Label();
            this.codigo_cliente_txt = new System.Windows.Forms.TextBox();
            this.nombre_cliente_txt = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ncf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rnc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_de_factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_inicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_limite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pendiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abonogrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descgrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.detalle_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ck_aplicar_todo = new System.Windows.Forms.CheckBox();
            this.MontoTotalPendienteText = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.nombre_cajero_txt = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.codigo_cajero_txt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.ck_registro_hasta = new System.Windows.Forms.CheckBox();
            this.ck_registro_desde = new System.Windows.Forms.CheckBox();
            this.fecha_hasta_txt = new System.Windows.Forms.DateTimePicker();
            this.fecha_desde_txt = new System.Windows.Forms.DateTimePicker();
            this.tipoPagoText = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.MontoAbonoText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.descuentoPorCientoText = new System.Windows.Forms.TextBox();
            this.montoDescuentoText = new System.Windows.Forms.TextBox();
            this.MontoTotalAbonarText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "cliente";
            // 
            // codigo_cliente_txt
            // 
            this.codigo_cliente_txt.Location = new System.Drawing.Point(82, 85);
            this.codigo_cliente_txt.Name = "codigo_cliente_txt";
            this.codigo_cliente_txt.ReadOnly = true;
            this.codigo_cliente_txt.Size = new System.Drawing.Size(64, 20);
            this.codigo_cliente_txt.TabIndex = 3;
            // 
            // nombre_cliente_txt
            // 
            this.nombre_cliente_txt.Location = new System.Drawing.Point(11, 107);
            this.nombre_cliente_txt.Name = "nombre_cliente_txt";
            this.nombre_cliente_txt.ReadOnly = true;
            this.nombre_cliente_txt.Size = new System.Drawing.Size(175, 20);
            this.nombre_cliente_txt.TabIndex = 58;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.nombre_cliente,
            this.ncf,
            this.rnc,
            this.tipo_de_factura,
            this.fecha_inicial,
            this.fecha_limite,
            this.nombre_empleado,
            this.pendiente,
            this.abonogrid,
            this.descgrid});
            this.dataGridView1.Location = new System.Drawing.Point(18, 195);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(984, 255);
            this.dataGridView1.TabIndex = 62;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // codigo
            // 
            this.codigo.FillWeight = 60F;
            this.codigo.HeaderText = "Codigo";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // nombre_cliente
            // 
            this.nombre_cliente.FillWeight = 150F;
            this.nombre_cliente.HeaderText = "Nombre Cliente";
            this.nombre_cliente.Name = "nombre_cliente";
            this.nombre_cliente.ReadOnly = true;
            // 
            // ncf
            // 
            this.ncf.FillWeight = 170F;
            this.ncf.HeaderText = "NCF";
            this.ncf.Name = "ncf";
            this.ncf.ReadOnly = true;
            // 
            // rnc
            // 
            this.rnc.HeaderText = "RNC";
            this.rnc.Name = "rnc";
            this.rnc.ReadOnly = true;
            // 
            // tipo_de_factura
            // 
            this.tipo_de_factura.FillWeight = 80F;
            this.tipo_de_factura.HeaderText = "Factura";
            this.tipo_de_factura.Name = "tipo_de_factura";
            this.tipo_de_factura.ReadOnly = true;
            // 
            // fecha_inicial
            // 
            this.fecha_inicial.HeaderText = "Fecha Creada";
            this.fecha_inicial.Name = "fecha_inicial";
            this.fecha_inicial.ReadOnly = true;
            // 
            // fecha_limite
            // 
            this.fecha_limite.HeaderText = "Fecha Limite";
            this.fecha_limite.Name = "fecha_limite";
            this.fecha_limite.ReadOnly = true;
            // 
            // nombre_empleado
            // 
            this.nombre_empleado.HeaderText = "Empleado";
            this.nombre_empleado.Name = "nombre_empleado";
            this.nombre_empleado.ReadOnly = true;
            // 
            // pendiente
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0";
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.pendiente.DefaultCellStyle = dataGridViewCellStyle7;
            this.pendiente.HeaderText = "Pendiente";
            this.pendiente.Name = "pendiente";
            this.pendiente.ReadOnly = true;
            // 
            // abonogrid
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = "0";
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.abonogrid.DefaultCellStyle = dataGridViewCellStyle8;
            this.abonogrid.HeaderText = "Abono";
            this.abonogrid.Name = "abonogrid";
            this.abonogrid.ReadOnly = true;
            // 
            // descgrid
            // 
            this.descgrid.HeaderText = "Descuento";
            this.descgrid.Name = "descgrid";
            this.descgrid.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.button6);
            this.panel3.Controls.Add(this.button7);
            this.panel3.Controls.Add(this.button8);
            this.panel3.Location = new System.Drawing.Point(17, 555);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(985, 55);
            this.panel3.TabIndex = 67;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button6.BackgroundImage = global::puntoVenta.Properties.Resources.map_icon;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Location = new System.Drawing.Point(455, 0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(71, 55);
            this.button6.TabIndex = 2;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.button7.BackgroundImage = global::puntoVenta.Properties.Resources.edit_not_validated1;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.Location = new System.Drawing.Point(0, 0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(71, 55);
            this.button7.TabIndex = 1;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button8.BackgroundImage = global::puntoVenta.Properties.Resources.save_file_disk_open_searsh_loading_clipboard_1513;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.Location = new System.Drawing.Point(913, 0);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(72, 55);
            this.button8.TabIndex = 0;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::puntoVenta.Properties.Resources.find_icon;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Location = new System.Drawing.Point(152, 75);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(34, 30);
            this.button4.TabIndex = 57;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // detalle_txt
            // 
            this.detalle_txt.Location = new System.Drawing.Point(15, 485);
            this.detalle_txt.MaxLength = 200;
            this.detalle_txt.Multiline = true;
            this.detalle_txt.Name = "detalle_txt";
            this.detalle_txt.Size = new System.Drawing.Size(987, 62);
            this.detalle_txt.TabIndex = 69;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(10, 457);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 25);
            this.label4.TabIndex = 70;
            this.label4.Text = "Concepto";
            // 
            // ck_aplicar_todo
            // 
            this.ck_aplicar_todo.AutoSize = true;
            this.ck_aplicar_todo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_aplicar_todo.ForeColor = System.Drawing.Color.Black;
            this.ck_aplicar_todo.Location = new System.Drawing.Point(225, 81);
            this.ck_aplicar_todo.Name = "ck_aplicar_todo";
            this.ck_aplicar_todo.Size = new System.Drawing.Size(209, 28);
            this.ck_aplicar_todo.TabIndex = 85;
            this.ck_aplicar_todo.Text = "Saldo por antiguedad";
            this.ck_aplicar_todo.UseVisualStyleBackColor = true;
            this.ck_aplicar_todo.Visible = false;
            this.ck_aplicar_todo.Click += new System.EventHandler(this.ck_aplicar_todo_Click);
            // 
            // MontoTotalPendienteText
            // 
            this.MontoTotalPendienteText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MontoTotalPendienteText.Location = new System.Drawing.Point(481, 456);
            this.MontoTotalPendienteText.Name = "MontoTotalPendienteText";
            this.MontoTotalPendienteText.ReadOnly = true;
            this.MontoTotalPendienteText.Size = new System.Drawing.Size(169, 26);
            this.MontoTotalPendienteText.TabIndex = 87;
            this.MontoTotalPendienteText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(375, 456);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(100, 29);
            this.label19.TabIndex = 86;
            this.label19.Text = "Pendiente";
            this.label19.UseCompatibleTextRendering = true;
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
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // nombre_cajero_txt
            // 
            this.nombre_cajero_txt.Location = new System.Drawing.Point(9, 46);
            this.nombre_cajero_txt.Name = "nombre_cajero_txt";
            this.nombre_cajero_txt.ReadOnly = true;
            this.nombre_cajero_txt.Size = new System.Drawing.Size(175, 20);
            this.nombre_cajero_txt.TabIndex = 102;
            this.nombre_cajero_txt.Text = " ";
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::puntoVenta.Properties.Resources.find_icon;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(150, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 30);
            this.button2.TabIndex = 101;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // codigo_cajero_txt
            // 
            this.codigo_cajero_txt.Location = new System.Drawing.Point(80, 24);
            this.codigo_cajero_txt.Name = "codigo_cajero_txt";
            this.codigo_cajero_txt.ReadOnly = true;
            this.codigo_cajero_txt.Size = new System.Drawing.Size(64, 20);
            this.codigo_cajero_txt.TabIndex = 100;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(8, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 25);
            this.label10.TabIndex = 99;
            this.label10.Text = "cajero";
            // 
            // fecha
            // 
            this.fecha.Enabled = false;
            this.fecha.Location = new System.Drawing.Point(799, 7);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(200, 20);
            this.fecha.TabIndex = 103;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.ck_registro_hasta);
            this.groupBox1.Controls.Add(this.ck_registro_desde);
            this.groupBox1.Controls.Add(this.fecha_hasta_txt);
            this.groupBox1.Controls.Add(this.ck_aplicar_todo);
            this.groupBox1.Controls.Add(this.fecha_desde_txt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.codigo_cliente_txt);
            this.groupBox1.Controls.Add(this.nombre_cajero_txt);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.nombre_cliente_txt);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.codigo_cajero_txt);
            this.groupBox1.Location = new System.Drawing.Point(18, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(984, 132);
            this.groupBox1.TabIndex = 104;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(192, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 20);
            this.label3.TabIndex = 105;
            this.label3.Text = "X";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::puntoVenta.Properties.Resources.find_icon;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(912, 73);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(63, 53);
            this.button3.TabIndex = 105;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ck_registro_hasta
            // 
            this.ck_registro_hasta.AutoSize = true;
            this.ck_registro_hasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_registro_hasta.ForeColor = System.Drawing.Color.Black;
            this.ck_registro_hasta.Location = new System.Drawing.Point(446, 17);
            this.ck_registro_hasta.Name = "ck_registro_hasta";
            this.ck_registro_hasta.Size = new System.Drawing.Size(68, 24);
            this.ck_registro_hasta.TabIndex = 122;
            this.ck_registro_hasta.Text = "hasta";
            this.ck_registro_hasta.UseVisualStyleBackColor = true;
            this.ck_registro_hasta.Click += new System.EventHandler(this.ck_registro_hasta_Click);
            // 
            // ck_registro_desde
            // 
            this.ck_registro_desde.AutoSize = true;
            this.ck_registro_desde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_registro_desde.ForeColor = System.Drawing.Color.Black;
            this.ck_registro_desde.Location = new System.Drawing.Point(225, 17);
            this.ck_registro_desde.Name = "ck_registro_desde";
            this.ck_registro_desde.Size = new System.Drawing.Size(72, 24);
            this.ck_registro_desde.TabIndex = 119;
            this.ck_registro_desde.Text = "desde";
            this.ck_registro_desde.UseVisualStyleBackColor = true;
            this.ck_registro_desde.Click += new System.EventHandler(this.ck_registro_desde_Click);
            // 
            // fecha_hasta_txt
            // 
            this.fecha_hasta_txt.Enabled = false;
            this.fecha_hasta_txt.Location = new System.Drawing.Point(443, 41);
            this.fecha_hasta_txt.Name = "fecha_hasta_txt";
            this.fecha_hasta_txt.Size = new System.Drawing.Size(212, 20);
            this.fecha_hasta_txt.TabIndex = 121;
            // 
            // fecha_desde_txt
            // 
            this.fecha_desde_txt.Enabled = false;
            this.fecha_desde_txt.Location = new System.Drawing.Point(225, 41);
            this.fecha_desde_txt.Name = "fecha_desde_txt";
            this.fecha_desde_txt.Size = new System.Drawing.Size(212, 20);
            this.fecha_desde_txt.TabIndex = 120;
            // 
            // tipoPagoText
            // 
            this.tipoPagoText.DisplayMember = "0";
            this.tipoPagoText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoPagoText.FormattingEnabled = true;
            this.tipoPagoText.Items.AddRange(new object[] {
            "Efectivo",
            "Deposito",
            "Cheque",
            "Tarjeta"});
            this.tipoPagoText.Location = new System.Drawing.Point(127, 166);
            this.tipoPagoText.Name = "tipoPagoText";
            this.tipoPagoText.Size = new System.Drawing.Size(121, 21);
            this.tipoPagoText.TabIndex = 105;
            this.tipoPagoText.ValueMember = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(18, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 106;
            this.label2.Text = "Metodo pago";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(266, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 20);
            this.label5.TabIndex = 107;
            this.label5.Text = "Monto abono";
            // 
            // MontoAbonoText
            // 
            this.MontoAbonoText.Location = new System.Drawing.Point(375, 169);
            this.MontoAbonoText.Name = "MontoAbonoText";
            this.MontoAbonoText.Size = new System.Drawing.Size(157, 20);
            this.MontoAbonoText.TabIndex = 108;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(542, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 20);
            this.label6.TabIndex = 109;
            this.label6.Text = "Descuento %";
            // 
            // descuentoPorCientoText
            // 
            this.descuentoPorCientoText.Location = new System.Drawing.Point(653, 168);
            this.descuentoPorCientoText.MaxLength = 5;
            this.descuentoPorCientoText.Name = "descuentoPorCientoText";
            this.descuentoPorCientoText.Size = new System.Drawing.Size(41, 20);
            this.descuentoPorCientoText.TabIndex = 110;
            this.descuentoPorCientoText.Text = "0.00";
            this.descuentoPorCientoText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // montoDescuentoText
            // 
            this.montoDescuentoText.Location = new System.Drawing.Point(701, 168);
            this.montoDescuentoText.Name = "montoDescuentoText";
            this.montoDescuentoText.Size = new System.Drawing.Size(130, 20);
            this.montoDescuentoText.TabIndex = 111;
            this.montoDescuentoText.Text = "0";
            this.montoDescuentoText.TextChanged += new System.EventHandler(this.montoDescuentoText_TextChanged);
            // 
            // MontoTotalAbonarText
            // 
            this.MontoTotalAbonarText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MontoTotalAbonarText.Location = new System.Drawing.Point(808, 456);
            this.MontoTotalAbonarText.Name = "MontoTotalAbonarText";
            this.MontoTotalAbonarText.ReadOnly = true;
            this.MontoTotalAbonarText.Size = new System.Drawing.Size(194, 26);
            this.MontoTotalAbonarText.TabIndex = 113;
            this.MontoTotalAbonarText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(731, 455);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 29);
            this.label7.TabIndex = 112;
            this.label7.Text = "Abonar";
            this.label7.UseCompatibleTextRendering = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(862, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 20);
            this.label8.TabIndex = 114;
            this.label8.Text = "Aplicar(F2)";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // cuenta_por_cobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1014, 622);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.MontoTotalAbonarText);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.montoDescuentoText);
            this.Controls.Add(this.descuentoPorCientoText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.MontoAbonoText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tipoPagoText);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.MontoTotalPendienteText);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.detalle_txt);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "cuenta_por_cobrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuenta por cobrar";
            this.Load += new System.EventHandler(this.cuenta_por_cobrar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cuenta_por_cobrar_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox codigo_cliente_txt;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox nombre_cliente_txt;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox detalle_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ck_aplicar_todo;
        private System.Windows.Forms.TextBox MontoTotalPendienteText;
        private System.Windows.Forms.Label label19;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.TextBox nombre_cajero_txt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox codigo_cajero_txt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker fecha;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ck_registro_hasta;
        private System.Windows.Forms.CheckBox ck_registro_desde;
        private System.Windows.Forms.DateTimePicker fecha_hasta_txt;
        private System.Windows.Forms.DateTimePicker fecha_desde_txt;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox tipoPagoText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox MontoAbonoText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox descuentoPorCientoText;
        private System.Windows.Forms.TextBox montoDescuentoText;
        private System.Windows.Forms.TextBox MontoTotalAbonarText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ncf;
        private System.Windows.Forms.DataGridViewTextBoxColumn rnc;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_de_factura;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_inicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_limite;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn pendiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn abonogrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn descgrid;
        private System.Windows.Forms.Label label8;
    }
}