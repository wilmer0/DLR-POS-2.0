namespace puntoVenta
{
    partial class busqueda_factura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(busqueda_factura));
            this.numero_factura_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1_facturas = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.ck_credito = new System.Windows.Forms.CheckBox();
            this.ck_contado = new System.Windows.Forms.CheckBox();
            this.ck_cotizacion = new System.Windows.Forms.CheckBox();
            this.codigo_cli_supli_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.codigo_cajero_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dias_txt = new System.Windows.Forms.MaskedTextBox();
            this.fecha_desde = new System.Windows.Forms.DateTimePicker();
            this.fecha_hasta = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numero_comprobanteFiscal_txt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView2_detalle_factura = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridView3_movimientos_factura = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.ck_cliente = new System.Windows.Forms.CheckBox();
            this.ck_suplidor = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comprobante_combo_txt = new System.Windows.Forms.ComboBox();
            this.nombre_cajero_txt = new System.Windows.Forms.TextBox();
            this.nombre_cli_supli_txt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_facturas)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2_detalle_factura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3_movimientos_factura)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // numero_factura_txt
            // 
            this.numero_factura_txt.Location = new System.Drawing.Point(96, 66);
            this.numero_factura_txt.Name = "numero_factura_txt";
            this.numero_factura_txt.Size = new System.Drawing.Size(150, 20);
            this.numero_factura_txt.TabIndex = 31;
            this.numero_factura_txt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 25);
            this.label2.TabIndex = 30;
            this.label2.Text = "Factura";
            // 
            // dataGridView1_facturas
            // 
            this.dataGridView1_facturas.AllowUserToAddRows = false;
            this.dataGridView1_facturas.AllowUserToDeleteRows = false;
            this.dataGridView1_facturas.AllowUserToResizeColumns = false;
            this.dataGridView1_facturas.AllowUserToResizeRows = false;
            this.dataGridView1_facturas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1_facturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1_facturas.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1_facturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1_facturas.GridColor = System.Drawing.Color.White;
            this.dataGridView1_facturas.Location = new System.Drawing.Point(410, 48);
            this.dataGridView1_facturas.MultiSelect = false;
            this.dataGridView1_facturas.Name = "dataGridView1_facturas";
            this.dataGridView1_facturas.ReadOnly = true;
            this.dataGridView1_facturas.Size = new System.Drawing.Size(528, 156);
            this.dataGridView1_facturas.TabIndex = 50;
            this.dataGridView1_facturas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Location = new System.Drawing.Point(12, 582);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(926, 54);
            this.panel2.TabIndex = 61;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button4.BackgroundImage = global::puntoVenta.Properties.Resources.map_icon;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Location = new System.Drawing.Point(429, 0);
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
            this.button6.Location = new System.Drawing.Point(854, 0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(72, 54);
            this.button6.TabIndex = 0;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.ck_credito);
            this.panel3.Controls.Add(this.ck_contado);
            this.panel3.Controls.Add(this.ck_cotizacion);
            this.panel3.Location = new System.Drawing.Point(22, 204);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(327, 76);
            this.panel3.TabIndex = 70;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(113, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 29);
            this.label3.TabIndex = 50;
            this.label3.Text = "Tipo factura";
            this.label3.UseCompatibleTextRendering = true;
            // 
            // ck_credito
            // 
            this.ck_credito.AutoSize = true;
            this.ck_credito.Checked = true;
            this.ck_credito.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_credito.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_credito.ForeColor = System.Drawing.Color.Black;
            this.ck_credito.Location = new System.Drawing.Point(3, 38);
            this.ck_credito.Name = "ck_credito";
            this.ck_credito.Size = new System.Drawing.Size(89, 28);
            this.ck_credito.TabIndex = 47;
            this.ck_credito.Text = "Credito";
            this.ck_credito.UseVisualStyleBackColor = true;
            this.ck_credito.Click += new System.EventHandler(this.ck_credito_Click);
            // 
            // ck_contado
            // 
            this.ck_contado.AutoSize = true;
            this.ck_contado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_contado.ForeColor = System.Drawing.Color.Black;
            this.ck_contado.Location = new System.Drawing.Point(98, 38);
            this.ck_contado.Name = "ck_contado";
            this.ck_contado.Size = new System.Drawing.Size(100, 28);
            this.ck_contado.TabIndex = 48;
            this.ck_contado.Text = "Contado";
            this.ck_contado.UseVisualStyleBackColor = true;
            this.ck_contado.Click += new System.EventHandler(this.ck_contado_Click);
            // 
            // ck_cotizacion
            // 
            this.ck_cotizacion.AutoSize = true;
            this.ck_cotizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_cotizacion.ForeColor = System.Drawing.Color.Black;
            this.ck_cotizacion.Location = new System.Drawing.Point(204, 38);
            this.ck_cotizacion.Name = "ck_cotizacion";
            this.ck_cotizacion.Size = new System.Drawing.Size(116, 28);
            this.ck_cotizacion.TabIndex = 64;
            this.ck_cotizacion.Text = "Cotizacion";
            this.ck_cotizacion.UseVisualStyleBackColor = true;
            this.ck_cotizacion.Click += new System.EventHandler(this.ck_cotizacion_Click);
            // 
            // codigo_cli_supli_txt
            // 
            this.codigo_cli_supli_txt.Location = new System.Drawing.Point(98, 150);
            this.codigo_cli_supli_txt.Name = "codigo_cli_supli_txt";
            this.codigo_cli_supli_txt.ReadOnly = true;
            this.codigo_cli_supli_txt.Size = new System.Drawing.Size(150, 20);
            this.codigo_cli_supli_txt.TabIndex = 73;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(16, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 25);
            this.label1.TabIndex = 72;
            this.label1.Text = "Cli/Supli";
            // 
            // codigo_cajero_txt
            // 
            this.codigo_cajero_txt.Location = new System.Drawing.Point(96, 103);
            this.codigo_cajero_txt.Name = "codigo_cajero_txt";
            this.codigo_cajero_txt.ReadOnly = true;
            this.codigo_cajero_txt.Size = new System.Drawing.Size(150, 20);
            this.codigo_cajero_txt.TabIndex = 76;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(17, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 25);
            this.label4.TabIndex = 75;
            this.label4.Text = "Cajero";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(39, 332);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 25);
            this.label5.TabIndex = 78;
            this.label5.Text = "Dias";
            // 
            // dias_txt
            // 
            this.dias_txt.Location = new System.Drawing.Point(96, 338);
            this.dias_txt.Mask = "9999";
            this.dias_txt.Name = "dias_txt";
            this.dias_txt.Size = new System.Drawing.Size(33, 20);
            this.dias_txt.TabIndex = 79;
            this.dias_txt.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            // 
            // fecha_desde
            // 
            this.fecha_desde.Location = new System.Drawing.Point(96, 374);
            this.fecha_desde.Name = "fecha_desde";
            this.fecha_desde.Size = new System.Drawing.Size(200, 20);
            this.fecha_desde.TabIndex = 81;
            // 
            // fecha_hasta
            // 
            this.fecha_hasta.Location = new System.Drawing.Point(96, 407);
            this.fecha_hasta.Name = "fecha_hasta";
            this.fecha_hasta.Size = new System.Drawing.Size(200, 20);
            this.fecha_hasta.TabIndex = 82;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(20, 369);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 25);
            this.label6.TabIndex = 83;
            this.label6.Text = "Desde";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(20, 404);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 25);
            this.label7.TabIndex = 84;
            this.label7.Text = "Hasta";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // numero_comprobanteFiscal_txt
            // 
            this.numero_comprobanteFiscal_txt.Location = new System.Drawing.Point(96, 286);
            this.numero_comprobanteFiscal_txt.Name = "numero_comprobanteFiscal_txt";
            this.numero_comprobanteFiscal_txt.ReadOnly = true;
            this.numero_comprobanteFiscal_txt.Size = new System.Drawing.Size(150, 20);
            this.numero_comprobanteFiscal_txt.TabIndex = 86;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(34, 293);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 25);
            this.label8.TabIndex = 85;
            this.label8.Text = "NCF";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(405, 216);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(199, 25);
            this.label9.TabIndex = 87;
            this.label9.Text = "Componentes factura";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // dataGridView2_detalle_factura
            // 
            this.dataGridView2_detalle_factura.AllowUserToAddRows = false;
            this.dataGridView2_detalle_factura.AllowUserToDeleteRows = false;
            this.dataGridView2_detalle_factura.AllowUserToResizeColumns = false;
            this.dataGridView2_detalle_factura.AllowUserToResizeRows = false;
            this.dataGridView2_detalle_factura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2_detalle_factura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2_detalle_factura.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2_detalle_factura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2_detalle_factura.GridColor = System.Drawing.Color.White;
            this.dataGridView2_detalle_factura.Location = new System.Drawing.Point(410, 244);
            this.dataGridView2_detalle_factura.MultiSelect = false;
            this.dataGridView2_detalle_factura.Name = "dataGridView2_detalle_factura";
            this.dataGridView2_detalle_factura.ReadOnly = true;
            this.dataGridView2_detalle_factura.Size = new System.Drawing.Size(528, 147);
            this.dataGridView2_detalle_factura.TabIndex = 88;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(405, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 25);
            this.label10.TabIndex = 89;
            this.label10.Text = "Facturas";
            // 
            // dataGridView3_movimientos_factura
            // 
            this.dataGridView3_movimientos_factura.AllowUserToAddRows = false;
            this.dataGridView3_movimientos_factura.AllowUserToDeleteRows = false;
            this.dataGridView3_movimientos_factura.AllowUserToResizeColumns = false;
            this.dataGridView3_movimientos_factura.AllowUserToResizeRows = false;
            this.dataGridView3_movimientos_factura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3_movimientos_factura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3_movimientos_factura.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView3_movimientos_factura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3_movimientos_factura.GridColor = System.Drawing.Color.White;
            this.dataGridView3_movimientos_factura.Location = new System.Drawing.Point(410, 434);
            this.dataGridView3_movimientos_factura.MultiSelect = false;
            this.dataGridView3_movimientos_factura.Name = "dataGridView3_movimientos_factura";
            this.dataGridView3_movimientos_factura.ReadOnly = true;
            this.dataGridView3_movimientos_factura.Size = new System.Drawing.Size(528, 140);
            this.dataGridView3_movimientos_factura.TabIndex = 91;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(405, 406);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(186, 25);
            this.label11.TabIndex = 90;
            this.label11.Text = "Movimientos factura";
            // 
            // ck_cliente
            // 
            this.ck_cliente.AutoSize = true;
            this.ck_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_cliente.ForeColor = System.Drawing.Color.Black;
            this.ck_cliente.Location = new System.Drawing.Point(17, 32);
            this.ck_cliente.Name = "ck_cliente";
            this.ck_cliente.Size = new System.Drawing.Size(87, 28);
            this.ck_cliente.TabIndex = 65;
            this.ck_cliente.Text = "Cliente";
            this.ck_cliente.UseVisualStyleBackColor = true;
            this.ck_cliente.Click += new System.EventHandler(this.ck_cliente_Click);
            // 
            // ck_suplidor
            // 
            this.ck_suplidor.AutoSize = true;
            this.ck_suplidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_suplidor.ForeColor = System.Drawing.Color.Black;
            this.ck_suplidor.Location = new System.Drawing.Point(197, 28);
            this.ck_suplidor.Name = "ck_suplidor";
            this.ck_suplidor.Size = new System.Drawing.Size(99, 28);
            this.ck_suplidor.TabIndex = 66;
            this.ck_suplidor.Text = "Suplidor";
            this.ck_suplidor.UseVisualStyleBackColor = true;
            this.ck_suplidor.Click += new System.EventHandler(this.ck_suplidor_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Location = new System.Drawing.Point(25, 437);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(361, 140);
            this.panel1.TabIndex = 71;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Transparent;
            this.button9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button9.BackgroundImage")));
            this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button9.Location = new System.Drawing.Point(95, 3);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(84, 60);
            this.button9.TabIndex = 93;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button8.BackgroundImage")));
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.Location = new System.Drawing.Point(5, 3);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(84, 60);
            this.button8.TabIndex = 92;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.BackgroundImage = global::puntoVenta.Properties.Resources.find_icon;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.Location = new System.Drawing.Point(252, 62);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(32, 27);
            this.button7.TabIndex = 80;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::puntoVenta.Properties.Resources.find_icon;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(252, 98);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(34, 27);
            this.button3.TabIndex = 77;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::puntoVenta.Properties.Resources.find_icon;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(254, 145);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 27);
            this.button2.TabIndex = 74;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::puntoVenta.Properties.Resources.find_icon;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(302, 371);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 60);
            this.button1.TabIndex = 71;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comprobante_combo_txt
            // 
            this.comprobante_combo_txt.FormattingEnabled = true;
            this.comprobante_combo_txt.Location = new System.Drawing.Point(96, 308);
            this.comprobante_combo_txt.Name = "comprobante_combo_txt";
            this.comprobante_combo_txt.Size = new System.Drawing.Size(176, 21);
            this.comprobante_combo_txt.TabIndex = 92;
            // 
            // nombre_cajero_txt
            // 
            this.nombre_cajero_txt.Location = new System.Drawing.Point(22, 124);
            this.nombre_cajero_txt.Name = "nombre_cajero_txt";
            this.nombre_cajero_txt.ReadOnly = true;
            this.nombre_cajero_txt.Size = new System.Drawing.Size(263, 20);
            this.nombre_cajero_txt.TabIndex = 93;
            // 
            // nombre_cli_supli_txt
            // 
            this.nombre_cli_supli_txt.Location = new System.Drawing.Point(22, 172);
            this.nombre_cli_supli_txt.Name = "nombre_cli_supli_txt";
            this.nombre_cli_supli_txt.ReadOnly = true;
            this.nombre_cli_supli_txt.Size = new System.Drawing.Size(262, 20);
            this.nombre_cli_supli_txt.TabIndex = 94;
            // 
            // busqueda_factura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(950, 648);
            this.Controls.Add(this.nombre_cli_supli_txt);
            this.Controls.Add(this.nombre_cajero_txt);
            this.Controls.Add(this.comprobante_combo_txt);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ck_cliente);
            this.Controls.Add(this.ck_suplidor);
            this.Controls.Add(this.dataGridView3_movimientos_factura);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataGridView2_detalle_factura);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numero_comprobanteFiscal_txt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.fecha_hasta);
            this.Controls.Add(this.fecha_desde);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.dias_txt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.codigo_cajero_txt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.codigo_cli_supli_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1_facturas);
            this.Controls.Add(this.numero_factura_txt);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "busqueda_factura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busqueda factura";
            this.Load += new System.EventHandler(this.busqueda_factura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_facturas)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2_detalle_factura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3_movimientos_factura)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox numero_factura_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1_facturas;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ck_credito;
        private System.Windows.Forms.CheckBox ck_contado;
        private System.Windows.Forms.CheckBox ck_cotizacion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox codigo_cli_supli_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox codigo_cajero_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox dias_txt;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.DateTimePicker fecha_desde;
        private System.Windows.Forms.DateTimePicker fecha_hasta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox numero_comprobanteFiscal_txt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView2_detalle_factura;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridView3_movimientos_factura;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox ck_cliente;
        private System.Windows.Forms.CheckBox ck_suplidor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.ComboBox comprobante_combo_txt;
        private System.Windows.Forms.TextBox nombre_cajero_txt;
        private System.Windows.Forms.TextBox nombre_cli_supli_txt;
    }
}