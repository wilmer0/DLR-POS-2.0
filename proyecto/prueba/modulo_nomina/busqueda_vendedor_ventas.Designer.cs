namespace puntoVenta
{
    partial class busqueda_vendedor_pedidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(busqueda_vendedor_pedidos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.nombre_vendedor_txt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.codigo_vendedor_txt = new System.Windows.Forms.TextBox();
            this.button11 = new System.Windows.Forms.Button();
            this.fecha_inicial = new System.Windows.Forms.DateTimePicker();
            this.fecha_final = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nombre_cliente_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.codigo_cliente_txt = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.numer_factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tarj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.che = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo_empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_gri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.panel3.Location = new System.Drawing.Point(12, 560);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(981, 55);
            this.panel3.TabIndex = 95;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button6.BackgroundImage = global::puntoVenta.Properties.Resources.map_icon;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Location = new System.Drawing.Point(461, 0);
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
            this.button8.Location = new System.Drawing.Point(909, 0);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(72, 55);
            this.button8.TabIndex = 0;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // nombre_vendedor_txt
            // 
            this.nombre_vendedor_txt.Location = new System.Drawing.Point(98, 44);
            this.nombre_vendedor_txt.Name = "nombre_vendedor_txt";
            this.nombre_vendedor_txt.ReadOnly = true;
            this.nombre_vendedor_txt.Size = new System.Drawing.Size(170, 20);
            this.nombre_vendedor_txt.TabIndex = 120;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label7.Location = new System.Drawing.Point(15, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 24);
            this.label7.TabIndex = 119;
            this.label7.Text = "Vendedor";
            this.label7.UseCompatibleTextRendering = true;
            // 
            // codigo_vendedor_txt
            // 
            this.codigo_vendedor_txt.Location = new System.Drawing.Point(98, 21);
            this.codigo_vendedor_txt.Name = "codigo_vendedor_txt";
            this.codigo_vendedor_txt.ReadOnly = true;
            this.codigo_vendedor_txt.Size = new System.Drawing.Size(130, 20);
            this.codigo_vendedor_txt.TabIndex = 118;
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Transparent;
            this.button11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button11.BackgroundImage")));
            this.button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button11.Location = new System.Drawing.Point(234, 12);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(34, 30);
            this.button11.TabIndex = 117;
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // fecha_inicial
            // 
            this.fecha_inicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fecha_inicial.Location = new System.Drawing.Point(98, 71);
            this.fecha_inicial.Name = "fecha_inicial";
            this.fecha_inicial.Size = new System.Drawing.Size(170, 18);
            this.fecha_inicial.TabIndex = 121;
            // 
            // fecha_final
            // 
            this.fecha_final.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fecha_final.Location = new System.Drawing.Point(98, 97);
            this.fecha_final.Name = "fecha_final";
            this.fecha_final.Size = new System.Drawing.Size(170, 18);
            this.fecha_final.TabIndex = 122;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.Location = new System.Drawing.Point(15, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 24);
            this.label1.TabIndex = 123;
            this.label1.Text = "Desde";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label2.Location = new System.Drawing.Point(15, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 24);
            this.label2.TabIndex = 124;
            this.label2.Text = "Hasta";
            this.label2.UseCompatibleTextRendering = true;
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
            this.numer_factura,
            this.monto,
            this.tarj,
            this.che,
            this.trans,
            this.codigo_empleado,
            this.nombre_empleado,
            this.fecha_gri});
            this.dataGridView1.Location = new System.Drawing.Point(12, 213);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(981, 341);
            this.dataGridView1.TabIndex = 125;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(937, 142);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 45);
            this.button1.TabIndex = 126;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label3.Location = new System.Drawing.Point(938, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 24);
            this.label3.TabIndex = 127;
            this.label3.Text = "Buscar";
            this.label3.UseCompatibleTextRendering = true;
            // 
            // nombre_cliente_txt
            // 
            this.nombre_cliente_txt.Location = new System.Drawing.Point(98, 156);
            this.nombre_cliente_txt.Name = "nombre_cliente_txt";
            this.nombre_cliente_txt.ReadOnly = true;
            this.nombre_cliente_txt.Size = new System.Drawing.Size(170, 20);
            this.nombre_cliente_txt.TabIndex = 131;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label4.Location = new System.Drawing.Point(15, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 24);
            this.label4.TabIndex = 130;
            this.label4.Text = "Cliente";
            this.label4.UseCompatibleTextRendering = true;
            // 
            // codigo_cliente_txt
            // 
            this.codigo_cliente_txt.Location = new System.Drawing.Point(98, 133);
            this.codigo_cliente_txt.Name = "codigo_cliente_txt";
            this.codigo_cliente_txt.ReadOnly = true;
            this.codigo_cliente_txt.Size = new System.Drawing.Size(130, 20);
            this.codigo_cliente_txt.TabIndex = 129;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(234, 124);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 30);
            this.button2.TabIndex = 128;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // numer_factura
            // 
            this.numer_factura.FillWeight = 70F;
            this.numer_factura.HeaderText = "Factura";
            this.numer_factura.Name = "numer_factura";
            this.numer_factura.ReadOnly = true;
            // 
            // monto
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle1.Format = "###,###,###,###.#0";
            dataGridViewCellStyle1.NullValue = "0";
            this.monto.DefaultCellStyle = dataGridViewCellStyle1;
            this.monto.HeaderText = "Efectivo";
            this.monto.Name = "monto";
            this.monto.ReadOnly = true;
            // 
            // tarj
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle2.Format = "###,###,###,###.#0";
            dataGridViewCellStyle2.NullValue = "0";
            this.tarj.DefaultCellStyle = dataGridViewCellStyle2;
            this.tarj.HeaderText = "Tarjeta";
            this.tarj.Name = "tarj";
            this.tarj.ReadOnly = true;
            // 
            // che
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle3.Format = "###,###,###,###.#0";
            dataGridViewCellStyle3.NullValue = "0";
            this.che.DefaultCellStyle = dataGridViewCellStyle3;
            this.che.HeaderText = "Cheque";
            this.che.Name = "che";
            this.che.ReadOnly = true;
            // 
            // trans
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.trans.DefaultCellStyle = dataGridViewCellStyle4;
            this.trans.HeaderText = "Transferencia";
            this.trans.Name = "trans";
            this.trans.ReadOnly = true;
            // 
            // codigo_empleado
            // 
            this.codigo_empleado.FillWeight = 60F;
            this.codigo_empleado.HeaderText = "cod. vendedor";
            this.codigo_empleado.Name = "codigo_empleado";
            this.codigo_empleado.ReadOnly = true;
            // 
            // nombre_empleado
            // 
            this.nombre_empleado.HeaderText = "Vendedor";
            this.nombre_empleado.Name = "nombre_empleado";
            this.nombre_empleado.ReadOnly = true;
            // 
            // fecha_gri
            // 
            this.fecha_gri.FillWeight = 70F;
            this.fecha_gri.HeaderText = "Fecha";
            this.fecha_gri.Name = "fecha_gri";
            this.fecha_gri.ReadOnly = true;
            // 
            // busqueda_vendedor_pedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1005, 627);
            this.Controls.Add(this.nombre_cliente_txt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.codigo_cliente_txt);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fecha_final);
            this.Controls.Add(this.fecha_inicial);
            this.Controls.Add(this.nombre_vendedor_txt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.codigo_vendedor_txt);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "busqueda_vendedor_pedidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pedidos de vendedores";
            this.Load += new System.EventHandler(this.busqueda_vendedor_pedidos_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox nombre_vendedor_txt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox codigo_vendedor_txt;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.DateTimePicker fecha_inicial;
        private System.Windows.Forms.DateTimePicker fecha_final;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nombre_cliente_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox codigo_cliente_txt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn numer_factura;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn tarj;
        private System.Windows.Forms.DataGridViewTextBoxColumn che;
        private System.Windows.Forms.DataGridViewTextBoxColumn trans;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_gri;
    }
}