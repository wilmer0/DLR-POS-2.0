namespace puntoVenta
{
    partial class devolucion_venta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(devolucion_venta));
            this.nombre_cliente_txt = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.codigo_cliente_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.codigo_producto_gr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_producto_gr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo_unidad_gr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_unidad_gr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio_gr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad_gr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itebi_grid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto_gr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.devuelta_gr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero_factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_hecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rnc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_limite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_venta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cantidad_txt = new System.Windows.Forms.TextBox();
            this.cantidad_devolver_txt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.monto_total_factura_txt = new System.Windows.Forms.TextBox();
            this.monto_devolver_txt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ck_efectivo = new System.Windows.Forms.CheckBox();
            this.ck_nota_credito = new System.Windows.Forms.CheckBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // nombre_cliente_txt
            // 
            this.nombre_cliente_txt.Location = new System.Drawing.Point(17, 48);
            this.nombre_cliente_txt.Name = "nombre_cliente_txt";
            this.nombre_cliente_txt.ReadOnly = true;
            this.nombre_cliente_txt.Size = new System.Drawing.Size(212, 20);
            this.nombre_cliente_txt.TabIndex = 99;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(9, 615);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(816, 55);
            this.panel2.TabIndex = 105;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button3.BackgroundImage = global::puntoVenta.Properties.Resources.map_icon;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(366, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(71, 55);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button2.BackgroundImage = global::puntoVenta.Properties.Resources.edit_not_validated1;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 55);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.BackgroundImage = global::puntoVenta.Properties.Resources.save_file_disk_open_searsh_loading_clipboard_1513;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(744, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 55);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // codigo_cliente_txt
            // 
            this.codigo_cliente_txt.Location = new System.Drawing.Point(95, 26);
            this.codigo_cliente_txt.Name = "codigo_cliente_txt";
            this.codigo_cliente_txt.ReadOnly = true;
            this.codigo_cliente_txt.Size = new System.Drawing.Size(95, 20);
            this.codigo_cliente_txt.TabIndex = 96;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 25);
            this.label1.TabIndex = 95;
            this.label1.Text = "Cliente";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo_producto_gr,
            this.nombre_producto_gr,
            this.codigo_unidad_gr,
            this.nombre_unidad_gr,
            this.precio_gr,
            this.cantidad_gr,
            this.itebi_grid,
            this.monto_gr,
            this.devuelta_gr});
            this.dataGridView2.GridColor = System.Drawing.Color.White;
            this.dataGridView2.Location = new System.Drawing.Point(14, 378);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(811, 194);
            this.dataGridView2.TabIndex = 109;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.dataGridView2.Click += new System.EventHandler(this.dataGridView2_Click);
            // 
            // codigo_producto_gr
            // 
            this.codigo_producto_gr.HeaderText = "Cod producto";
            this.codigo_producto_gr.Name = "codigo_producto_gr";
            this.codigo_producto_gr.ReadOnly = true;
            // 
            // nombre_producto_gr
            // 
            this.nombre_producto_gr.HeaderText = "Producto";
            this.nombre_producto_gr.Name = "nombre_producto_gr";
            this.nombre_producto_gr.ReadOnly = true;
            // 
            // codigo_unidad_gr
            // 
            this.codigo_unidad_gr.HeaderText = "Cod unidad";
            this.codigo_unidad_gr.Name = "codigo_unidad_gr";
            this.codigo_unidad_gr.ReadOnly = true;
            // 
            // nombre_unidad_gr
            // 
            this.nombre_unidad_gr.HeaderText = "Unidad";
            this.nombre_unidad_gr.Name = "nombre_unidad_gr";
            this.nombre_unidad_gr.ReadOnly = true;
            // 
            // precio_gr
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.precio_gr.DefaultCellStyle = dataGridViewCellStyle2;
            this.precio_gr.HeaderText = "Precio";
            this.precio_gr.Name = "precio_gr";
            this.precio_gr.ReadOnly = true;
            // 
            // cantidad_gr
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.cantidad_gr.DefaultCellStyle = dataGridViewCellStyle3;
            this.cantidad_gr.HeaderText = "Cantidad";
            this.cantidad_gr.Name = "cantidad_gr";
            this.cantidad_gr.ReadOnly = true;
            // 
            // itebi_grid
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.itebi_grid.DefaultCellStyle = dataGridViewCellStyle4;
            this.itebi_grid.HeaderText = "Itbis";
            this.itebi_grid.Name = "itebi_grid";
            this.itebi_grid.ReadOnly = true;
            // 
            // monto_gr
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.monto_gr.DefaultCellStyle = dataGridViewCellStyle5;
            this.monto_gr.HeaderText = "Sub total";
            this.monto_gr.Name = "monto_gr";
            this.monto_gr.ReadOnly = true;
            // 
            // devuelta_gr
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.devuelta_gr.DefaultCellStyle = dataGridViewCellStyle6;
            this.devuelta_gr.HeaderText = "Devuelto";
            this.devuelta_gr.Name = "devuelta_gr";
            this.devuelta_gr.ReadOnly = true;
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.numero_factura,
            this.fecha_hecha,
            this.comprobante,
            this.rnc,
            this.fecha_limite,
            this.tipo_venta});
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(17, 106);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(808, 229);
            this.dataGridView1.TabIndex = 107;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // codigo
            // 
            this.codigo.FillWeight = 50F;
            this.codigo.HeaderText = "Codigo";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // numero_factura
            // 
            this.numero_factura.FillWeight = 60F;
            this.numero_factura.HeaderText = "Num. factura";
            this.numero_factura.Name = "numero_factura";
            this.numero_factura.ReadOnly = true;
            // 
            // fecha_hecha
            // 
            this.fecha_hecha.HeaderText = "Fecha";
            this.fecha_hecha.Name = "fecha_hecha";
            this.fecha_hecha.ReadOnly = true;
            // 
            // comprobante
            // 
            this.comprobante.FillWeight = 120F;
            this.comprobante.HeaderText = "Comprobante";
            this.comprobante.Name = "comprobante";
            this.comprobante.ReadOnly = true;
            // 
            // rnc
            // 
            this.rnc.FillWeight = 110F;
            this.rnc.HeaderText = "RNC";
            this.rnc.Name = "rnc";
            this.rnc.ReadOnly = true;
            // 
            // fecha_limite
            // 
            this.fecha_limite.HeaderText = "Fecha limite";
            this.fecha_limite.Name = "fecha_limite";
            this.fecha_limite.ReadOnly = true;
            // 
            // tipo_venta
            // 
            this.tipo_venta.HeaderText = "Tipo venta";
            this.tipo_venta.Name = "tipo_venta";
            this.tipo_venta.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(13, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 106;
            this.label2.Text = "Ventas";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 357);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 125;
            this.label3.Text = "Productos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(358, 357);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 140;
            this.label4.Text = "Cantidad";
            // 
            // cantidad_txt
            // 
            this.cantidad_txt.Location = new System.Drawing.Point(437, 355);
            this.cantidad_txt.Name = "cantidad_txt";
            this.cantidad_txt.ReadOnly = true;
            this.cantidad_txt.Size = new System.Drawing.Size(100, 20);
            this.cantidad_txt.TabIndex = 139;
            // 
            // cantidad_devolver_txt
            // 
            this.cantidad_devolver_txt.Location = new System.Drawing.Point(627, 355);
            this.cantidad_devolver_txt.Name = "cantidad_devolver_txt";
            this.cantidad_devolver_txt.Size = new System.Drawing.Size(86, 20);
            this.cantidad_devolver_txt.TabIndex = 138;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(549, 357);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 20);
            this.label12.TabIndex = 137;
            this.label12.Text = "Devuelta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(401, 587);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 25);
            this.label5.TabIndex = 141;
            this.label5.Text = "Total";
            // 
            // monto_total_factura_txt
            // 
            this.monto_total_factura_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monto_total_factura_txt.Location = new System.Drawing.Point(476, 591);
            this.monto_total_factura_txt.Name = "monto_total_factura_txt";
            this.monto_total_factura_txt.ReadOnly = true;
            this.monto_total_factura_txt.Size = new System.Drawing.Size(145, 21);
            this.monto_total_factura_txt.TabIndex = 142;
            this.monto_total_factura_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // monto_devolver_txt
            // 
            this.monto_devolver_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monto_devolver_txt.Location = new System.Drawing.Point(680, 591);
            this.monto_devolver_txt.Name = "monto_devolver_txt";
            this.monto_devolver_txt.ReadOnly = true;
            this.monto_devolver_txt.Size = new System.Drawing.Size(145, 21);
            this.monto_devolver_txt.TabIndex = 144;
            this.monto_devolver_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(627, 587);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 25);
            this.label6.TabIndex = 143;
            this.label6.Text = "Dev";
            // 
            // ck_efectivo
            // 
            this.ck_efectivo.AutoSize = true;
            this.ck_efectivo.Checked = true;
            this.ck_efectivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_efectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_efectivo.ForeColor = System.Drawing.Color.Black;
            this.ck_efectivo.Location = new System.Drawing.Point(585, 6);
            this.ck_efectivo.Name = "ck_efectivo";
            this.ck_efectivo.Size = new System.Drawing.Size(172, 28);
            this.ck_efectivo.TabIndex = 145;
            this.ck_efectivo.Text = "Devolver efectivo";
            this.ck_efectivo.UseVisualStyleBackColor = true;
            this.ck_efectivo.Click += new System.EventHandler(this.ck_efectivo_Click);
            // 
            // ck_nota_credito
            // 
            this.ck_nota_credito.AutoSize = true;
            this.ck_nota_credito.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_nota_credito.ForeColor = System.Drawing.Color.Black;
            this.ck_nota_credito.Location = new System.Drawing.Point(585, 42);
            this.ck_nota_credito.Name = "ck_nota_credito";
            this.ck_nota_credito.Size = new System.Drawing.Size(217, 28);
            this.ck_nota_credito.TabIndex = 146;
            this.ck_nota_credito.Text = "Aplicar nota de credito";
            this.ck_nota_credito.UseVisualStyleBackColor = true;
            this.ck_nota_credito.Visible = false;
            this.ck_nota_credito.Click += new System.EventHandler(this.ck_nota_credito_Click);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.BackgroundImage = global::puntoVenta.Properties.Resources.iconDinero2;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.Location = new System.Drawing.Point(506, 8);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(49, 38);
            this.button7.TabIndex = 147;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackgroundImage = global::puntoVenta.Properties.Resources.red_x_cross_wrong_not_clip_art_f;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Location = new System.Drawing.Point(776, 341);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(49, 36);
            this.button5.TabIndex = 136;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.BackgroundImage = global::puntoVenta.Properties.Resources.lg_red_green_OK_not_OK_Icons;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Location = new System.Drawing.Point(721, 341);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(49, 36);
            this.button6.TabIndex = 135;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::puntoVenta.Properties.Resources.find_icon;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Location = new System.Drawing.Point(196, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(33, 27);
            this.button4.TabIndex = 97;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(498, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 20);
            this.label7.TabIndex = 148;
            this.label7.Text = "Egresos";
            // 
            // devolucion_venta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(837, 680);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.ck_nota_credito);
            this.Controls.Add(this.ck_efectivo);
            this.Controls.Add(this.monto_devolver_txt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.monto_total_factura_txt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cantidad_txt);
            this.Controls.Add(this.cantidad_devolver_txt);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nombre_cliente_txt);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.codigo_cliente_txt);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "devolucion_venta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devolucion Venta";
            this.Load += new System.EventHandler(this.devolucion_venta_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nombre_cliente_txt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox codigo_cliente_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cantidad_txt;
        private System.Windows.Forms.TextBox cantidad_devolver_txt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_factura;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_hecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn comprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn rnc;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_limite;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_venta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox monto_total_factura_txt;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_producto_gr;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_producto_gr;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_unidad_gr;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_unidad_gr;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio_gr;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad_gr;
        private System.Windows.Forms.DataGridViewTextBoxColumn itebi_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto_gr;
        private System.Windows.Forms.DataGridViewTextBoxColumn devuelta_gr;
        private System.Windows.Forms.TextBox monto_devolver_txt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ck_efectivo;
        private System.Windows.Forms.CheckBox ck_nota_credito;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label7;

    }
}