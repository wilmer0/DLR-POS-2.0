namespace puntoVenta
{
    partial class cliente_estado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cliente_estado));
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codigo_factura_gr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num_factura_gr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ncf_gr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_factura_gr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rnc_gr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_gr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sucursal_gr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe_gr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pendiente_grid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_cliente_txt = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.codigo_cliente_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.total_saldadas_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.total_factura_pendiente_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
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
            this.panel2.Location = new System.Drawing.Point(12, 581);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(979, 55);
            this.panel2.TabIndex = 106;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button3.BackgroundImage = global::puntoVenta.Properties.Resources.map_icon;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(447, 0);
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
            this.button1.Location = new System.Drawing.Point(907, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 55);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(10, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 25);
            this.label3.TabIndex = 142;
            this.label3.Text = "Cliente";
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
            this.codigo_factura_gr,
            this.num_factura_gr,
            this.ncf_gr,
            this.tipo_factura_gr,
            this.rnc_gr,
            this.fecha_gr,
            this.sucursal_gr,
            this.importe_gr,
            this.pendiente_grid});
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(15, 110);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(974, 439);
            this.dataGridView1.TabIndex = 141;
            // 
            // codigo_factura_gr
            // 
            this.codigo_factura_gr.FillWeight = 70F;
            this.codigo_factura_gr.HeaderText = "Cod. factura";
            this.codigo_factura_gr.Name = "codigo_factura_gr";
            this.codigo_factura_gr.ReadOnly = true;
            // 
            // num_factura_gr
            // 
            this.num_factura_gr.HeaderText = "Num. factura";
            this.num_factura_gr.Name = "num_factura_gr";
            this.num_factura_gr.ReadOnly = true;
            // 
            // ncf_gr
            // 
            this.ncf_gr.FillWeight = 150F;
            this.ncf_gr.HeaderText = "NCF";
            this.ncf_gr.Name = "ncf_gr";
            this.ncf_gr.ReadOnly = true;
            // 
            // tipo_factura_gr
            // 
            this.tipo_factura_gr.FillWeight = 60F;
            this.tipo_factura_gr.HeaderText = "Tipo";
            this.tipo_factura_gr.Name = "tipo_factura_gr";
            this.tipo_factura_gr.ReadOnly = true;
            // 
            // rnc_gr
            // 
            this.rnc_gr.FillWeight = 130F;
            this.rnc_gr.HeaderText = "RNC";
            this.rnc_gr.Name = "rnc_gr";
            this.rnc_gr.ReadOnly = true;
            // 
            // fecha_gr
            // 
            this.fecha_gr.HeaderText = "Fecha";
            this.fecha_gr.Name = "fecha_gr";
            this.fecha_gr.ReadOnly = true;
            // 
            // sucursal_gr
            // 
            this.sucursal_gr.HeaderText = "Sucursal";
            this.sucursal_gr.Name = "sucursal_gr";
            this.sucursal_gr.ReadOnly = true;
            // 
            // importe_gr
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.importe_gr.DefaultCellStyle = dataGridViewCellStyle2;
            this.importe_gr.HeaderText = "Saldado";
            this.importe_gr.Name = "importe_gr";
            this.importe_gr.ReadOnly = true;
            // 
            // pendiente_grid
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Orange;
            this.pendiente_grid.DefaultCellStyle = dataGridViewCellStyle3;
            this.pendiente_grid.HeaderText = "Pendiente";
            this.pendiente_grid.Name = "pendiente_grid";
            this.pendiente_grid.ReadOnly = true;
            // 
            // nombre_cliente_txt
            // 
            this.nombre_cliente_txt.Location = new System.Drawing.Point(15, 52);
            this.nombre_cliente_txt.Name = "nombre_cliente_txt";
            this.nombre_cliente_txt.ReadOnly = true;
            this.nombre_cliente_txt.Size = new System.Drawing.Size(216, 20);
            this.nombre_cliente_txt.TabIndex = 147;
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::puntoVenta.Properties.Resources.find_icon;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Location = new System.Drawing.Point(198, 24);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(33, 27);
            this.button4.TabIndex = 146;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // codigo_cliente_txt
            // 
            this.codigo_cliente_txt.Location = new System.Drawing.Point(97, 29);
            this.codigo_cliente_txt.Name = "codigo_cliente_txt";
            this.codigo_cliente_txt.ReadOnly = true;
            this.codigo_cliente_txt.Size = new System.Drawing.Size(95, 20);
            this.codigo_cliente_txt.TabIndex = 145;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 25);
            this.label1.TabIndex = 148;
            this.label1.Text = "Facturas saldadas";
            // 
            // total_saldadas_txt
            // 
            this.total_saldadas_txt.Location = new System.Drawing.Point(605, 556);
            this.total_saldadas_txt.Name = "total_saldadas_txt";
            this.total_saldadas_txt.ReadOnly = true;
            this.total_saldadas_txt.Size = new System.Drawing.Size(140, 20);
            this.total_saldadas_txt.TabIndex = 150;
            this.total_saldadas_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(514, 552);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 25);
            this.label2.TabIndex = 149;
            this.label2.Text = "Saldado";
            // 
            // total_factura_pendiente_txt
            // 
            this.total_factura_pendiente_txt.Location = new System.Drawing.Point(849, 555);
            this.total_factura_pendiente_txt.Name = "total_factura_pendiente_txt";
            this.total_factura_pendiente_txt.ReadOnly = true;
            this.total_factura_pendiente_txt.Size = new System.Drawing.Size(140, 20);
            this.total_factura_pendiente_txt.TabIndex = 154;
            this.total_factura_pendiente_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(752, 551);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 25);
            this.label4.TabIndex = 153;
            this.label4.Text = "Pendiente";
            // 
            // cliente_estado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1003, 648);
            this.Controls.Add(this.total_factura_pendiente_txt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.total_saldadas_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nombre_cliente_txt);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.codigo_cliente_txt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "cliente_estado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estado del cliente";
            this.Load += new System.EventHandler(this.form_padre_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.TextBox nombre_cliente_txt;
        public System.Windows.Forms.Button button4;
        public System.Windows.Forms.TextBox codigo_cliente_txt;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox total_saldadas_txt;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox total_factura_pendiente_txt;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_factura_gr;
        private System.Windows.Forms.DataGridViewTextBoxColumn num_factura_gr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ncf_gr;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_factura_gr;
        private System.Windows.Forms.DataGridViewTextBoxColumn rnc_gr;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_gr;
        private System.Windows.Forms.DataGridViewTextBoxColumn sucursal_gr;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe_gr;
        private System.Windows.Forms.DataGridViewTextBoxColumn pendiente_grid;
    }
}