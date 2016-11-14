namespace puntoVenta
{
    partial class reporte_ventas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reporte_ventas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codigo_cliente_grid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomcligrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.venta_grid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_factura_grid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_desde_grid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_hasta_grid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto_deuda_grid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto_saldo_grid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_sucursal_grid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sucursa_grid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo_cliente_txt = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.nombre_cliente_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ck_credito = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ck_tipo_venta_todas = new System.Windows.Forms.CheckBox();
            this.ck_contado = new System.Windows.Forms.CheckBox();
            this.ck_cotizacion = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fecha_desde = new System.Windows.Forms.DateTimePicker();
            this.fecha_hasta = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ck_estado_venta_todas = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ck_deuda = new System.Windows.Forms.CheckBox();
            this.ck_saldada = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.monto_pendiente_desde_txt = new System.Windows.Forms.MaskedTextBox();
            this.monto_pendiente_hasta_txt = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.codigo_sucursal_txt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.nombre_sucursal_txt = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.monto_saldo_hasta_txt = new System.Windows.Forms.MaskedTextBox();
            this.monto_saldo_desde_txt = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.panel2.Location = new System.Drawing.Point(12, 540);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1175, 54);
            this.panel2.TabIndex = 104;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button4.BackgroundImage = global::puntoVenta.Properties.Resources.map_icon;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Location = new System.Drawing.Point(553, 0);
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
            this.button6.Location = new System.Drawing.Point(1103, 0);
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
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo_cliente_grid,
            this.nomcligrid,
            this.venta_grid,
            this.cod_factura_grid,
            this.fecha_desde_grid,
            this.fecha_hasta_grid,
            this.monto_deuda_grid,
            this.monto_saldo_grid,
            this.cod_sucursal_grid,
            this.sucursa_grid});
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(348, 35);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(839, 499);
            this.dataGridView1.TabIndex = 103;
            // 
            // codigo_cliente_grid
            // 
            this.codigo_cliente_grid.FillWeight = 40F;
            this.codigo_cliente_grid.HeaderText = "Cod.";
            this.codigo_cliente_grid.Name = "codigo_cliente_grid";
            this.codigo_cliente_grid.ReadOnly = true;
            // 
            // nomcligrid
            // 
            this.nomcligrid.HeaderText = "Cliente";
            this.nomcligrid.Name = "nomcligrid";
            this.nomcligrid.ReadOnly = true;
            // 
            // venta_grid
            // 
            this.venta_grid.HeaderText = "Venta";
            this.venta_grid.Name = "venta_grid";
            this.venta_grid.ReadOnly = true;
            // 
            // cod_factura_grid
            // 
            this.cod_factura_grid.HeaderText = "Factura";
            this.cod_factura_grid.Name = "cod_factura_grid";
            this.cod_factura_grid.ReadOnly = true;
            // 
            // fecha_desde_grid
            // 
            this.fecha_desde_grid.HeaderText = "Desde";
            this.fecha_desde_grid.Name = "fecha_desde_grid";
            this.fecha_desde_grid.ReadOnly = true;
            // 
            // fecha_hasta_grid
            // 
            this.fecha_hasta_grid.HeaderText = "Hasta";
            this.fecha_hasta_grid.Name = "fecha_hasta_grid";
            this.fecha_hasta_grid.ReadOnly = true;
            // 
            // monto_deuda_grid
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.monto_deuda_grid.DefaultCellStyle = dataGridViewCellStyle5;
            this.monto_deuda_grid.HeaderText = "Pendiente";
            this.monto_deuda_grid.Name = "monto_deuda_grid";
            this.monto_deuda_grid.ReadOnly = true;
            // 
            // monto_saldo_grid
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.monto_saldo_grid.DefaultCellStyle = dataGridViewCellStyle6;
            this.monto_saldo_grid.HeaderText = "Saldado";
            this.monto_saldo_grid.Name = "monto_saldo_grid";
            this.monto_saldo_grid.ReadOnly = true;
            // 
            // cod_sucursal_grid
            // 
            this.cod_sucursal_grid.FillWeight = 40F;
            this.cod_sucursal_grid.HeaderText = "Cod.";
            this.cod_sucursal_grid.Name = "cod_sucursal_grid";
            this.cod_sucursal_grid.ReadOnly = true;
            // 
            // sucursa_grid
            // 
            this.sucursa_grid.HeaderText = "Sucursal";
            this.sucursa_grid.Name = "sucursa_grid";
            this.sucursa_grid.ReadOnly = true;
            // 
            // codigo_cliente_txt
            // 
            this.codigo_cliente_txt.Location = new System.Drawing.Point(103, 38);
            this.codigo_cliente_txt.Name = "codigo_cliente_txt";
            this.codigo_cliente_txt.ReadOnly = true;
            this.codigo_cliente_txt.Size = new System.Drawing.Size(34, 20);
            this.codigo_cliente_txt.TabIndex = 114;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(264, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 30);
            this.button2.TabIndex = 113;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // nombre_cliente_txt
            // 
            this.nombre_cliente_txt.Location = new System.Drawing.Point(142, 38);
            this.nombre_cliente_txt.Name = "nombre_cliente_txt";
            this.nombre_cliente_txt.ReadOnly = true;
            this.nombre_cliente_txt.Size = new System.Drawing.Size(116, 20);
            this.nombre_cliente_txt.TabIndex = 112;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 29);
            this.label1.TabIndex = 111;
            this.label1.Text = "Cliente";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.ck_credito);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.ck_tipo_venta_todas);
            this.panel3.Controls.Add(this.ck_contado);
            this.panel3.Controls.Add(this.ck_cotizacion);
            this.panel3.Location = new System.Drawing.Point(12, 64);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(324, 95);
            this.panel3.TabIndex = 115;
            // 
            // ck_credito
            // 
            this.ck_credito.AutoSize = true;
            this.ck_credito.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_credito.ForeColor = System.Drawing.Color.Black;
            this.ck_credito.Location = new System.Drawing.Point(157, 38);
            this.ck_credito.Name = "ck_credito";
            this.ck_credito.Size = new System.Drawing.Size(89, 28);
            this.ck_credito.TabIndex = 65;
            this.ck_credito.Text = "Credito";
            this.ck_credito.UseVisualStyleBackColor = true;
            this.ck_credito.Click += new System.EventHandler(this.ck_credito_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(113, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 29);
            this.label3.TabIndex = 50;
            this.label3.Text = "Tipo venta";
            this.label3.UseCompatibleTextRendering = true;
            // 
            // ck_tipo_venta_todas
            // 
            this.ck_tipo_venta_todas.AutoSize = true;
            this.ck_tipo_venta_todas.Checked = true;
            this.ck_tipo_venta_todas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_tipo_venta_todas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_tipo_venta_todas.ForeColor = System.Drawing.Color.Black;
            this.ck_tipo_venta_todas.Location = new System.Drawing.Point(69, 38);
            this.ck_tipo_venta_todas.Name = "ck_tipo_venta_todas";
            this.ck_tipo_venta_todas.Size = new System.Drawing.Size(82, 28);
            this.ck_tipo_venta_todas.TabIndex = 47;
            this.ck_tipo_venta_todas.Text = "Todas";
            this.ck_tipo_venta_todas.UseVisualStyleBackColor = true;
            this.ck_tipo_venta_todas.CheckedChanged += new System.EventHandler(this.reporte_ventas_Load);
            this.ck_tipo_venta_todas.Click += new System.EventHandler(this.ck_credito_Click);
            // 
            // ck_contado
            // 
            this.ck_contado.AutoSize = true;
            this.ck_contado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_contado.ForeColor = System.Drawing.Color.Black;
            this.ck_contado.Location = new System.Drawing.Point(6, 64);
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
            this.ck_cotizacion.Location = new System.Drawing.Point(198, 64);
            this.ck_cotizacion.Name = "ck_cotizacion";
            this.ck_cotizacion.Size = new System.Drawing.Size(116, 28);
            this.ck_cotizacion.TabIndex = 64;
            this.ck_cotizacion.Text = "Cotizacion";
            this.ck_cotizacion.UseVisualStyleBackColor = true;
            this.ck_cotizacion.Click += new System.EventHandler(this.ck_cotizacion_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(15, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 29);
            this.label2.TabIndex = 116;
            this.label2.Text = "Desde";
            this.label2.UseCompatibleTextRendering = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(15, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 29);
            this.label4.TabIndex = 117;
            this.label4.Text = "Hasta";
            this.label4.UseCompatibleTextRendering = true;
            // 
            // fecha_desde
            // 
            this.fecha_desde.Location = new System.Drawing.Point(85, 165);
            this.fecha_desde.Name = "fecha_desde";
            this.fecha_desde.Size = new System.Drawing.Size(200, 20);
            this.fecha_desde.TabIndex = 118;
            // 
            // fecha_hasta
            // 
            this.fecha_hasta.Location = new System.Drawing.Point(85, 207);
            this.fecha_hasta.Name = "fecha_hasta";
            this.fecha_hasta.Size = new System.Drawing.Size(200, 20);
            this.fecha_hasta.TabIndex = 119;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.ck_estado_venta_todas);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.ck_deuda);
            this.panel1.Controls.Add(this.ck_saldada);
            this.panel1.Location = new System.Drawing.Point(15, 233);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 75);
            this.panel1.TabIndex = 116;
            // 
            // ck_estado_venta_todas
            // 
            this.ck_estado_venta_todas.AutoSize = true;
            this.ck_estado_venta_todas.Checked = true;
            this.ck_estado_venta_todas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_estado_venta_todas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_estado_venta_todas.ForeColor = System.Drawing.Color.Black;
            this.ck_estado_venta_todas.Location = new System.Drawing.Point(3, 38);
            this.ck_estado_venta_todas.Name = "ck_estado_venta_todas";
            this.ck_estado_venta_todas.Size = new System.Drawing.Size(82, 28);
            this.ck_estado_venta_todas.TabIndex = 51;
            this.ck_estado_venta_todas.Text = "Todas";
            this.ck_estado_venta_todas.UseVisualStyleBackColor = true;
            this.ck_estado_venta_todas.Click += new System.EventHandler(this.ck_todas_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(97, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 29);
            this.label5.TabIndex = 50;
            this.label5.Text = "Estado venta";
            this.label5.UseCompatibleTextRendering = true;
            // 
            // ck_deuda
            // 
            this.ck_deuda.AutoSize = true;
            this.ck_deuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_deuda.ForeColor = System.Drawing.Color.Black;
            this.ck_deuda.Location = new System.Drawing.Point(232, 38);
            this.ck_deuda.Name = "ck_deuda";
            this.ck_deuda.Size = new System.Drawing.Size(85, 28);
            this.ck_deuda.TabIndex = 47;
            this.ck_deuda.Text = "Deuda";
            this.ck_deuda.UseVisualStyleBackColor = true;
            this.ck_deuda.Click += new System.EventHandler(this.ck_deuda_Click);
            // 
            // ck_saldada
            // 
            this.ck_saldada.AutoSize = true;
            this.ck_saldada.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_saldada.ForeColor = System.Drawing.Color.Black;
            this.ck_saldada.Location = new System.Drawing.Point(110, 38);
            this.ck_saldada.Name = "ck_saldada";
            this.ck_saldada.Size = new System.Drawing.Size(97, 28);
            this.ck_saldada.TabIndex = 48;
            this.ck_saldada.Text = "Saldada";
            this.ck_saldada.UseVisualStyleBackColor = true;
            this.ck_saldada.Click += new System.EventHandler(this.ck_saldada_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(12, 316);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 29);
            this.label6.TabIndex = 120;
            this.label6.Text = "Pendiente desde";
            this.label6.UseCompatibleTextRendering = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(13, 345);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 29);
            this.label7.TabIndex = 121;
            this.label7.Text = "Pendiente hasta";
            this.label7.UseCompatibleTextRendering = true;
            // 
            // monto_pendiente_desde_txt
            // 
            this.monto_pendiente_desde_txt.Location = new System.Drawing.Point(169, 322);
            this.monto_pendiente_desde_txt.Mask = "999999999999999999999";
            this.monto_pendiente_desde_txt.Name = "monto_pendiente_desde_txt";
            this.monto_pendiente_desde_txt.Size = new System.Drawing.Size(133, 20);
            this.monto_pendiente_desde_txt.TabIndex = 122;
            // 
            // monto_pendiente_hasta_txt
            // 
            this.monto_pendiente_hasta_txt.Location = new System.Drawing.Point(169, 348);
            this.monto_pendiente_hasta_txt.Mask = "999999999999999999999";
            this.monto_pendiente_hasta_txt.Name = "monto_pendiente_hasta_txt";
            this.monto_pendiente_hasta_txt.Size = new System.Drawing.Size(133, 20);
            this.monto_pendiente_hasta_txt.TabIndex = 123;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(13, 430);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 29);
            this.label8.TabIndex = 124;
            this.label8.Text = "Sucursal";
            this.label8.UseCompatibleTextRendering = true;
            // 
            // codigo_sucursal_txt
            // 
            this.codigo_sucursal_txt.Location = new System.Drawing.Point(103, 434);
            this.codigo_sucursal_txt.Name = "codigo_sucursal_txt";
            this.codigo_sucursal_txt.ReadOnly = true;
            this.codigo_sucursal_txt.Size = new System.Drawing.Size(34, 20);
            this.codigo_sucursal_txt.TabIndex = 127;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(267, 429);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 30);
            this.button1.TabIndex = 126;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nombre_sucursal_txt
            // 
            this.nombre_sucursal_txt.Location = new System.Drawing.Point(142, 434);
            this.nombre_sucursal_txt.Name = "nombre_sucursal_txt";
            this.nombre_sucursal_txt.ReadOnly = true;
            this.nombre_sucursal_txt.Size = new System.Drawing.Size(119, 20);
            this.nombre_sucursal_txt.TabIndex = 125;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.Location = new System.Drawing.Point(12, 476);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(71, 58);
            this.button7.TabIndex = 129;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(305, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 29);
            this.label9.TabIndex = 66;
            this.label9.Text = "X";
            this.label9.UseCompatibleTextRendering = true;
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // monto_saldo_hasta_txt
            // 
            this.monto_saldo_hasta_txt.Location = new System.Drawing.Point(169, 403);
            this.monto_saldo_hasta_txt.Mask = "999999999999999999999";
            this.monto_saldo_hasta_txt.Name = "monto_saldo_hasta_txt";
            this.monto_saldo_hasta_txt.Size = new System.Drawing.Size(133, 20);
            this.monto_saldo_hasta_txt.TabIndex = 133;
            // 
            // monto_saldo_desde_txt
            // 
            this.monto_saldo_desde_txt.Location = new System.Drawing.Point(169, 377);
            this.monto_saldo_desde_txt.Mask = "999999999999999999999";
            this.monto_saldo_desde_txt.Name = "monto_saldo_desde_txt";
            this.monto_saldo_desde_txt.Size = new System.Drawing.Size(133, 20);
            this.monto_saldo_desde_txt.TabIndex = 132;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(13, 400);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 29);
            this.label10.TabIndex = 131;
            this.label10.Text = "Saldo hasta";
            this.label10.UseCompatibleTextRendering = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(12, 371);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 29);
            this.label11.TabIndex = 130;
            this.label11.Text = "Saldo desde";
            this.label11.UseCompatibleTextRendering = true;
            // 
            // reporte_ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1199, 606);
            this.Controls.Add(this.monto_saldo_hasta_txt);
            this.Controls.Add(this.monto_saldo_desde_txt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.codigo_sucursal_txt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nombre_sucursal_txt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.monto_pendiente_hasta_txt);
            this.Controls.Add(this.monto_pendiente_desde_txt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.fecha_hasta);
            this.Controls.Add(this.fecha_desde);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.codigo_cliente_txt);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.nombre_cliente_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "reporte_ventas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte ventas";
            this.Load += new System.EventHandler(this.reporte_ventas_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox codigo_cliente_txt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox nombre_cliente_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ck_tipo_venta_todas;
        private System.Windows.Forms.CheckBox ck_contado;
        private System.Windows.Forms.CheckBox ck_cotizacion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker fecha_desde;
        private System.Windows.Forms.DateTimePicker fecha_hasta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox ck_deuda;
        private System.Windows.Forms.CheckBox ck_saldada;
        private System.Windows.Forms.CheckBox ck_estado_venta_todas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox monto_pendiente_desde_txt;
        private System.Windows.Forms.MaskedTextBox monto_pendiente_hasta_txt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox codigo_sucursal_txt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox nombre_sucursal_txt;
        private System.Windows.Forms.CheckBox ck_credito;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_cliente_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomcligrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn venta_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_factura_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_desde_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_hasta_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto_deuda_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto_saldo_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_sucursal_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn sucursa_grid;
        private System.Windows.Forms.MaskedTextBox monto_saldo_hasta_txt;
        private System.Windows.Forms.MaskedTextBox monto_saldo_desde_txt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}