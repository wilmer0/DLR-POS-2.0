namespace puntoVenta
{
    partial class busqueda_entrada_salida_inventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(busqueda_entrada_salida_inventario));
            this.panel2 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_uni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.canti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.motivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.codigo_empleado_txt = new System.Windows.Forms.TextBox();
            this.nombre_empleado_txt = new System.Windows.Forms.TextBox();
            this.button11 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.nombre_sucursal_txt = new System.Windows.Forms.TextBox();
            this.codigo_sucursal_txt = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.nombre_almacen_txt = new System.Windows.Forms.TextBox();
            this.codigo_almacen_txt = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.panel2.Location = new System.Drawing.Point(12, 481);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(837, 48);
            this.panel2.TabIndex = 61;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button4.BackgroundImage = global::puntoVenta.Properties.Resources.map_icon;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Location = new System.Drawing.Point(384, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(71, 48);
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
            this.button5.Size = new System.Drawing.Size(71, 48);
            this.button5.TabIndex = 1;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackgroundImage = global::puntoVenta.Properties.Resources.save_file_disk_open_searsh_loading_clipboard_1513;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Dock = System.Windows.Forms.DockStyle.Right;
            this.button6.Location = new System.Drawing.Point(765, 0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(72, 48);
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
            this.codigo,
            this.producto,
            this.cod_uni,
            this.unidad,
            this.canti,
            this.mov,
            this.motivo,
            this.fecha,
            this.empleado});
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(12, 111);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(837, 364);
            this.dataGridView1.TabIndex = 62;
            // 
            // codigo
            // 
            this.codigo.FillWeight = 80F;
            this.codigo.HeaderText = "Codigo";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // producto
            // 
            this.producto.HeaderText = "Producto";
            this.producto.Name = "producto";
            this.producto.ReadOnly = true;
            // 
            // cod_uni
            // 
            this.cod_uni.FillWeight = 80F;
            this.cod_uni.HeaderText = "Codigo";
            this.cod_uni.Name = "cod_uni";
            this.cod_uni.ReadOnly = true;
            // 
            // unidad
            // 
            this.unidad.HeaderText = "Unidad";
            this.unidad.Name = "unidad";
            this.unidad.ReadOnly = true;
            // 
            // canti
            // 
            this.canti.FillWeight = 70F;
            this.canti.HeaderText = "Cantidad";
            this.canti.Name = "canti";
            this.canti.ReadOnly = true;
            // 
            // mov
            // 
            this.mov.HeaderText = "Movimiento";
            this.mov.Name = "mov";
            this.mov.ReadOnly = true;
            // 
            // motivo
            // 
            this.motivo.HeaderText = "Motivo";
            this.motivo.Name = "motivo";
            this.motivo.ReadOnly = true;
            // 
            // fecha
            // 
            this.fecha.HeaderText = "Fecha";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            // 
            // empleado
            // 
            this.empleado.HeaderText = "Empleado";
            this.empleado.Name = "empleado";
            this.empleado.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(292, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 24);
            this.label1.TabIndex = 63;
            this.label1.Text = "Empleado";
            this.label1.UseCompatibleTextRendering = true;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // codigo_empleado_txt
            // 
            this.codigo_empleado_txt.Location = new System.Drawing.Point(400, 32);
            this.codigo_empleado_txt.Name = "codigo_empleado_txt";
            this.codigo_empleado_txt.ReadOnly = true;
            this.codigo_empleado_txt.Size = new System.Drawing.Size(60, 20);
            this.codigo_empleado_txt.TabIndex = 91;
            this.codigo_empleado_txt.TextChanged += new System.EventHandler(this.codigo_empleado_txt_TextChanged);
            // 
            // nombre_empleado_txt
            // 
            this.nombre_empleado_txt.Location = new System.Drawing.Point(294, 53);
            this.nombre_empleado_txt.Name = "nombre_empleado_txt";
            this.nombre_empleado_txt.ReadOnly = true;
            this.nombre_empleado_txt.Size = new System.Drawing.Size(208, 20);
            this.nombre_empleado_txt.TabIndex = 90;
            this.nombre_empleado_txt.TextChanged += new System.EventHandler(this.nombre_empleado_txt_TextChanged);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Transparent;
            this.button11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button11.BackgroundImage")));
            this.button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button11.Location = new System.Drawing.Point(468, 22);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(34, 30);
            this.button11.TabIndex = 89;
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(22, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 24);
            this.label2.TabIndex = 92;
            this.label2.Text = "Fecha inicial";
            this.label2.UseCompatibleTextRendering = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(367, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 24);
            this.label3.TabIndex = 93;
            this.label3.Text = "Fecha final";
            this.label3.UseCompatibleTextRendering = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(129, 89);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 94;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(459, 86);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 95;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(777, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 48);
            this.button1.TabIndex = 96;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(777, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 29);
            this.label4.TabIndex = 97;
            this.label4.Text = "Buscar";
            this.label4.UseCompatibleTextRendering = true;
            // 
            // nombre_sucursal_txt
            // 
            this.nombre_sucursal_txt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.nombre_sucursal_txt.Location = new System.Drawing.Point(24, 53);
            this.nombre_sucursal_txt.Name = "nombre_sucursal_txt";
            this.nombre_sucursal_txt.ReadOnly = true;
            this.nombre_sucursal_txt.Size = new System.Drawing.Size(224, 20);
            this.nombre_sucursal_txt.TabIndex = 101;
            this.nombre_sucursal_txt.TextChanged += new System.EventHandler(this.nombre_sucursal_txt_TextChanged);
            // 
            // codigo_sucursal_txt
            // 
            this.codigo_sucursal_txt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.codigo_sucursal_txt.Location = new System.Drawing.Point(97, 32);
            this.codigo_sucursal_txt.Name = "codigo_sucursal_txt";
            this.codigo_sucursal_txt.ReadOnly = true;
            this.codigo_sucursal_txt.Size = new System.Drawing.Size(106, 20);
            this.codigo_sucursal_txt.TabIndex = 100;
            this.codigo_sucursal_txt.TextChanged += new System.EventHandler(this.codigo_sucursal_txt_TextChanged);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button2.BackgroundImage = global::puntoVenta.Properties.Resources.find_icon;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(214, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 30);
            this.button2.TabIndex = 99;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(20, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 20);
            this.label12.TabIndex = 98;
            this.label12.Text = "Sucursal";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // nombre_almacen_txt
            // 
            this.nombre_almacen_txt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.nombre_almacen_txt.Location = new System.Drawing.Point(544, 53);
            this.nombre_almacen_txt.Name = "nombre_almacen_txt";
            this.nombre_almacen_txt.ReadOnly = true;
            this.nombre_almacen_txt.Size = new System.Drawing.Size(182, 20);
            this.nombre_almacen_txt.TabIndex = 105;
            this.nombre_almacen_txt.TextChanged += new System.EventHandler(this.nombre_almacen_txt_TextChanged);
            // 
            // codigo_almacen_txt
            // 
            this.codigo_almacen_txt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.codigo_almacen_txt.Location = new System.Drawing.Point(626, 32);
            this.codigo_almacen_txt.Name = "codigo_almacen_txt";
            this.codigo_almacen_txt.ReadOnly = true;
            this.codigo_almacen_txt.Size = new System.Drawing.Size(60, 20);
            this.codigo_almacen_txt.TabIndex = 104;
            this.codigo_almacen_txt.TextChanged += new System.EventHandler(this.codigo_almacen_txt_TextChanged);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button3.BackgroundImage = global::puntoVenta.Properties.Resources.find_icon;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(692, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(34, 30);
            this.button3.TabIndex = 103;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(543, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 20);
            this.label5.TabIndex = 102;
            this.label5.Text = "Almacen";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(254, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 20);
            this.label6.TabIndex = 106;
            this.label6.Text = "X";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(507, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 20);
            this.label7.TabIndex = 107;
            this.label7.Text = "X";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(732, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 20);
            this.label8.TabIndex = 108;
            this.label8.Text = "X";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // busqueda_entrada_salida_inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(861, 541);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nombre_almacen_txt);
            this.Controls.Add(this.codigo_almacen_txt);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nombre_sucursal_txt);
            this.Controls.Add(this.codigo_sucursal_txt);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.codigo_empleado_txt);
            this.Controls.Add(this.nombre_empleado_txt);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "busqueda_entrada_salida_inventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busqueda entrada y salida de inventario";
            this.Load += new System.EventHandler(this.busqueda_entrada_salida_inventario_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox codigo_empleado_txt;
        private System.Windows.Forms.TextBox nombre_empleado_txt;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nombre_sucursal_txt;
        private System.Windows.Forms.TextBox codigo_sucursal_txt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox nombre_almacen_txt;
        private System.Windows.Forms.TextBox codigo_almacen_txt;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_uni;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn canti;
        private System.Windows.Forms.DataGridViewTextBoxColumn mov;
        private System.Windows.Forms.DataGridViewTextBoxColumn motivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn empleado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}