namespace puntoVenta
{
    partial class cuenta_por_pagar_suplidores
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cuenta_por_pagar_suplidores));
            this.panel3 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nombre_suplidor_txt = new System.Windows.Forms.TextBox();
            this.codigo_suplidor_txt = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.detalle_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ck_registro_hasta = new System.Windows.Forms.CheckBox();
            this.ck_registro_desde = new System.Windows.Forms.CheckBox();
            this.fecha_hasta_txt = new System.Windows.Forms.DateTimePicker();
            this.ck_aplicar_todo = new System.Windows.Forms.CheckBox();
            this.fecha_desde_txt = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.nombre_cajero_txt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.codigo_cajero_txt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.montoDescuentoText = new System.Windows.Forms.TextBox();
            this.descuentoPorCientoText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MontoAbonoText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tipoPagoText = new System.Windows.Forms.ComboBox();
            this.MontoTotalPendienteText = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.MontoTotalAbonarText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.codigo_compra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supligrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ncf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rnc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo_tipo_compra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_inicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_limite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empleadogrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto_pendiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abonogrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descugrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.button6);
            this.panel3.Controls.Add(this.button7);
            this.panel3.Controls.Add(this.button8);
            this.panel3.Location = new System.Drawing.Point(12, 532);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(961, 55);
            this.panel3.TabIndex = 80;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button6.BackgroundImage = global::puntoVenta.Properties.Resources.map_icon;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Location = new System.Drawing.Point(451, 0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(71, 55);
            this.button6.TabIndex = 2;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.BackgroundImage = global::puntoVenta.Properties.Resources.edit_not_validated1;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.Location = new System.Drawing.Point(0, 0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(74, 55);
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
            this.button8.Location = new System.Drawing.Point(889, 0);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(72, 55);
            this.button8.TabIndex = 0;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
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
            this.codigo_compra,
            this.supligrid,
            this.ncf,
            this.rnc,
            this.codigo_tipo_compra,
            this.fecha_inicial,
            this.fecha_limite,
            this.empleadogrid,
            this.monto_pendiente,
            this.abonogrid,
            this.descugrid});
            this.dataGridView1.Location = new System.Drawing.Point(15, 208);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(958, 214);
            this.dataGridView1.TabIndex = 75;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // nombre_suplidor_txt
            // 
            this.nombre_suplidor_txt.Location = new System.Drawing.Point(13, 108);
            this.nombre_suplidor_txt.Name = "nombre_suplidor_txt";
            this.nombre_suplidor_txt.ReadOnly = true;
            this.nombre_suplidor_txt.Size = new System.Drawing.Size(178, 20);
            this.nombre_suplidor_txt.TabIndex = 71;
            // 
            // codigo_suplidor_txt
            // 
            this.codigo_suplidor_txt.Location = new System.Drawing.Point(93, 85);
            this.codigo_suplidor_txt.Name = "codigo_suplidor_txt";
            this.codigo_suplidor_txt.ReadOnly = true;
            this.codigo_suplidor_txt.Size = new System.Drawing.Size(58, 20);
            this.codigo_suplidor_txt.TabIndex = 69;
            this.codigo_suplidor_txt.TextChanged += new System.EventHandler(this.codigo_suplidor_txt_TextChanged);
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::puntoVenta.Properties.Resources.find_icon;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Location = new System.Drawing.Point(157, 76);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(34, 30);
            this.button4.TabIndex = 70;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // detalle_txt
            // 
            this.detalle_txt.Location = new System.Drawing.Point(12, 465);
            this.detalle_txt.MaxLength = 100;
            this.detalle_txt.Multiline = true;
            this.detalle_txt.Name = "detalle_txt";
            this.detalle_txt.Size = new System.Drawing.Size(961, 61);
            this.detalle_txt.TabIndex = 81;
            this.detalle_txt.Text = "PAGO DE FACTURA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 437);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 25);
            this.label4.TabIndex = 83;
            this.label4.Text = "concepto";
            // 
            // fecha
            // 
            this.fecha.Enabled = false;
            this.fecha.Location = new System.Drawing.Point(783, 12);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(200, 20);
            this.fecha.TabIndex = 90;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.ck_registro_hasta);
            this.groupBox1.Controls.Add(this.ck_registro_desde);
            this.groupBox1.Controls.Add(this.fecha_hasta_txt);
            this.groupBox1.Controls.Add(this.ck_aplicar_todo);
            this.groupBox1.Controls.Add(this.fecha_desde_txt);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.nombre_cajero_txt);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.nombre_suplidor_txt);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.codigo_suplidor_txt);
            this.groupBox1.Controls.Add(this.codigo_cajero_txt);
            this.groupBox1.Location = new System.Drawing.Point(12, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(971, 132);
            this.groupBox1.TabIndex = 105;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(200, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 20);
            this.label6.TabIndex = 105;
            this.label6.Text = "X";
            // 
            // ck_registro_hasta
            // 
            this.ck_registro_hasta.AutoSize = true;
            this.ck_registro_hasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_registro_hasta.ForeColor = System.Drawing.Color.Black;
            this.ck_registro_hasta.Location = new System.Drawing.Point(461, 17);
            this.ck_registro_hasta.Name = "ck_registro_hasta";
            this.ck_registro_hasta.Size = new System.Drawing.Size(68, 24);
            this.ck_registro_hasta.TabIndex = 122;
            this.ck_registro_hasta.Text = "hasta";
            this.ck_registro_hasta.UseVisualStyleBackColor = true;
            // 
            // ck_registro_desde
            // 
            this.ck_registro_desde.AutoSize = true;
            this.ck_registro_desde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_registro_desde.ForeColor = System.Drawing.Color.Black;
            this.ck_registro_desde.Location = new System.Drawing.Point(240, 17);
            this.ck_registro_desde.Name = "ck_registro_desde";
            this.ck_registro_desde.Size = new System.Drawing.Size(72, 24);
            this.ck_registro_desde.TabIndex = 119;
            this.ck_registro_desde.Text = "desde";
            this.ck_registro_desde.UseVisualStyleBackColor = true;
            // 
            // fecha_hasta_txt
            // 
            this.fecha_hasta_txt.Enabled = false;
            this.fecha_hasta_txt.Location = new System.Drawing.Point(458, 41);
            this.fecha_hasta_txt.Name = "fecha_hasta_txt";
            this.fecha_hasta_txt.Size = new System.Drawing.Size(212, 20);
            this.fecha_hasta_txt.TabIndex = 121;
            // 
            // ck_aplicar_todo
            // 
            this.ck_aplicar_todo.AutoSize = true;
            this.ck_aplicar_todo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_aplicar_todo.ForeColor = System.Drawing.Color.Black;
            this.ck_aplicar_todo.Location = new System.Drawing.Point(240, 81);
            this.ck_aplicar_todo.Name = "ck_aplicar_todo";
            this.ck_aplicar_todo.Size = new System.Drawing.Size(209, 28);
            this.ck_aplicar_todo.TabIndex = 85;
            this.ck_aplicar_todo.Text = "Saldo por antiguedad";
            this.ck_aplicar_todo.UseVisualStyleBackColor = true;
            this.ck_aplicar_todo.Visible = false;
            // 
            // fecha_desde_txt
            // 
            this.fecha_desde_txt.Enabled = false;
            this.fecha_desde_txt.Location = new System.Drawing.Point(240, 41);
            this.fecha_desde_txt.Name = "fecha_desde_txt";
            this.fecha_desde_txt.Size = new System.Drawing.Size(212, 20);
            this.fecha_desde_txt.TabIndex = 120;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(7, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 25);
            this.label7.TabIndex = 2;
            this.label7.Text = "suplidor";
            // 
            // nombre_cajero_txt
            // 
            this.nombre_cajero_txt.Location = new System.Drawing.Point(11, 45);
            this.nombre_cajero_txt.Name = "nombre_cajero_txt";
            this.nombre_cajero_txt.ReadOnly = true;
            this.nombre_cajero_txt.Size = new System.Drawing.Size(180, 20);
            this.nombre_cajero_txt.TabIndex = 102;
            this.nombre_cajero_txt.Text = " ";
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
            // button5
            // 
            this.button5.BackgroundImage = global::puntoVenta.Properties.Resources.find_icon;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Location = new System.Drawing.Point(157, 13);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(34, 30);
            this.button5.TabIndex = 101;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // codigo_cajero_txt
            // 
            this.codigo_cajero_txt.Location = new System.Drawing.Point(93, 23);
            this.codigo_cajero_txt.Name = "codigo_cajero_txt";
            this.codigo_cajero_txt.ReadOnly = true;
            this.codigo_cajero_txt.Size = new System.Drawing.Size(58, 20);
            this.codigo_cajero_txt.TabIndex = 100;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(855, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 20);
            this.label8.TabIndex = 122;
            this.label8.Text = "Aplicar(F2)";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // montoDescuentoText
            // 
            this.montoDescuentoText.Location = new System.Drawing.Point(694, 186);
            this.montoDescuentoText.Name = "montoDescuentoText";
            this.montoDescuentoText.Size = new System.Drawing.Size(130, 20);
            this.montoDescuentoText.TabIndex = 121;
            this.montoDescuentoText.Text = "0";
            this.montoDescuentoText.TextChanged += new System.EventHandler(this.montoDescuentoText_TextChanged);
            // 
            // descuentoPorCientoText
            // 
            this.descuentoPorCientoText.Location = new System.Drawing.Point(646, 186);
            this.descuentoPorCientoText.MaxLength = 5;
            this.descuentoPorCientoText.Name = "descuentoPorCientoText";
            this.descuentoPorCientoText.Size = new System.Drawing.Size(41, 20);
            this.descuentoPorCientoText.TabIndex = 120;
            this.descuentoPorCientoText.Text = "0.00";
            this.descuentoPorCientoText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.descuentoPorCientoText_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(535, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 119;
            this.label1.Text = "Descuento %";
            // 
            // MontoAbonoText
            // 
            this.MontoAbonoText.Location = new System.Drawing.Point(368, 186);
            this.MontoAbonoText.Name = "MontoAbonoText";
            this.MontoAbonoText.Size = new System.Drawing.Size(157, 20);
            this.MontoAbonoText.TabIndex = 118;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(259, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 20);
            this.label5.TabIndex = 117;
            this.label5.Text = "Monto abono";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(11, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 116;
            this.label2.Text = "Metodo pago";
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
            this.tipoPagoText.Location = new System.Drawing.Point(120, 184);
            this.tipoPagoText.Name = "tipoPagoText";
            this.tipoPagoText.Size = new System.Drawing.Size(121, 21);
            this.tipoPagoText.TabIndex = 115;
            this.tipoPagoText.ValueMember = "0";
            // 
            // MontoTotalPendienteText
            // 
            this.MontoTotalPendienteText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MontoTotalPendienteText.Location = new System.Drawing.Point(513, 433);
            this.MontoTotalPendienteText.Name = "MontoTotalPendienteText";
            this.MontoTotalPendienteText.ReadOnly = true;
            this.MontoTotalPendienteText.Size = new System.Drawing.Size(169, 26);
            this.MontoTotalPendienteText.TabIndex = 124;
            this.MontoTotalPendienteText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(407, 433);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(100, 29);
            this.label19.TabIndex = 123;
            this.label19.Text = "Pendiente";
            this.label19.UseCompatibleTextRendering = true;
            // 
            // MontoTotalAbonarText
            // 
            this.MontoTotalAbonarText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MontoTotalAbonarText.Location = new System.Drawing.Point(779, 433);
            this.MontoTotalAbonarText.Name = "MontoTotalAbonarText";
            this.MontoTotalAbonarText.ReadOnly = true;
            this.MontoTotalAbonarText.Size = new System.Drawing.Size(194, 26);
            this.MontoTotalAbonarText.TabIndex = 126;
            this.MontoTotalAbonarText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(702, 432);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 29);
            this.label3.TabIndex = 125;
            this.label3.Text = "Abonar";
            this.label3.UseCompatibleTextRendering = true;
            // 
            // codigo_compra
            // 
            this.codigo_compra.FillWeight = 40F;
            this.codigo_compra.HeaderText = "Id";
            this.codigo_compra.Name = "codigo_compra";
            this.codigo_compra.ReadOnly = true;
            // 
            // supligrid
            // 
            this.supligrid.FillWeight = 120F;
            this.supligrid.HeaderText = "Suplidor";
            this.supligrid.Name = "supligrid";
            this.supligrid.ReadOnly = true;
            // 
            // ncf
            // 
            this.ncf.HeaderText = "NCF";
            this.ncf.Name = "ncf";
            this.ncf.ReadOnly = true;
            // 
            // rnc
            // 
            this.rnc.FillWeight = 70F;
            this.rnc.HeaderText = "RNC";
            this.rnc.Name = "rnc";
            this.rnc.ReadOnly = true;
            // 
            // codigo_tipo_compra
            // 
            this.codigo_tipo_compra.FillWeight = 50F;
            this.codigo_tipo_compra.HeaderText = "Compra";
            this.codigo_tipo_compra.Name = "codigo_tipo_compra";
            this.codigo_tipo_compra.ReadOnly = true;
            // 
            // fecha_inicial
            // 
            this.fecha_inicial.FillWeight = 80F;
            this.fecha_inicial.HeaderText = "Fecha";
            this.fecha_inicial.Name = "fecha_inicial";
            this.fecha_inicial.ReadOnly = true;
            // 
            // fecha_limite
            // 
            this.fecha_limite.HeaderText = "Fecha Limite";
            this.fecha_limite.Name = "fecha_limite";
            this.fecha_limite.ReadOnly = true;
            // 
            // empleadogrid
            // 
            this.empleadogrid.HeaderText = "Empleado";
            this.empleadogrid.Name = "empleadogrid";
            this.empleadogrid.ReadOnly = true;
            // 
            // monto_pendiente
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.monto_pendiente.DefaultCellStyle = dataGridViewCellStyle1;
            this.monto_pendiente.HeaderText = "Pendiente";
            this.monto_pendiente.Name = "monto_pendiente";
            this.monto_pendiente.ReadOnly = true;
            // 
            // abonogrid
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.abonogrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.abonogrid.HeaderText = "Abono";
            this.abonogrid.Name = "abonogrid";
            this.abonogrid.ReadOnly = true;
            // 
            // descugrid
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.descugrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.descugrid.HeaderText = "Descuento";
            this.descugrid.Name = "descugrid";
            this.descugrid.ReadOnly = true;
            // 
            // cuenta_por_pagar_suplidores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(995, 599);
            this.Controls.Add(this.MontoTotalAbonarText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MontoTotalPendienteText);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.montoDescuentoText);
            this.Controls.Add(this.descuentoPorCientoText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MontoAbonoText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tipoPagoText);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.detalle_txt);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "cuenta_por_pagar_suplidores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuenta por pagar suplidores";
            this.Load += new System.EventHandler(this.cuenta_por_pagar_suplidores_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox nombre_suplidor_txt;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox codigo_suplidor_txt;
        private System.Windows.Forms.TextBox detalle_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker fecha;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ck_registro_hasta;
        private System.Windows.Forms.CheckBox ck_registro_desde;
        private System.Windows.Forms.DateTimePicker fecha_hasta_txt;
        private System.Windows.Forms.CheckBox ck_aplicar_todo;
        private System.Windows.Forms.DateTimePicker fecha_desde_txt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox nombre_cajero_txt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox codigo_cajero_txt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox montoDescuentoText;
        private System.Windows.Forms.TextBox descuentoPorCientoText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MontoAbonoText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox tipoPagoText;
        private System.Windows.Forms.TextBox MontoTotalPendienteText;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox MontoTotalAbonarText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_compra;
        private System.Windows.Forms.DataGridViewTextBoxColumn supligrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ncf;
        private System.Windows.Forms.DataGridViewTextBoxColumn rnc;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_tipo_compra;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_inicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_limite;
        private System.Windows.Forms.DataGridViewTextBoxColumn empleadogrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto_pendiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn abonogrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn descugrid;
    }
}