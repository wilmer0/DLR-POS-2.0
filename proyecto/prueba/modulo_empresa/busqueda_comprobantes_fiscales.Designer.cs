namespace puntoVenta
{
    partial class busqueda_comprobantes_fiscales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(busqueda_comprobantes_fiscales));
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empresa_tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serie_secuencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caja_nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_comprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comprobante_secuencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_empresa_txt = new System.Windows.Forms.TextBox();
            this.codigo_empresa_txt = new System.Windows.Forms.TextBox();
            this.button16 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.nombre_sucursal_txt = new System.Windows.Forms.TextBox();
            this.codigo_sucursal_txt = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
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
            this.panel2.Location = new System.Drawing.Point(12, 354);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(894, 55);
            this.panel2.TabIndex = 70;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button3.BackgroundImage = global::puntoVenta.Properties.Resources.map_icon;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(405, 0);
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
            this.button1.Location = new System.Drawing.Point(822, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 55);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
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
            this.empresa_tipo,
            this.serie_secuencia,
            this.caja_nombre,
            this.tipo_comprobante,
            this.comprobante_secuencia,
            this.desde,
            this.hasta,
            this.actual});
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(12, 154);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(894, 194);
            this.dataGridView1.TabIndex = 71;
            // 
            // codigo
            // 
            this.codigo.FillWeight = 50F;
            this.codigo.HeaderText = "Codigo";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // empresa_tipo
            // 
            this.empresa_tipo.HeaderText = "Empresa";
            this.empresa_tipo.Name = "empresa_tipo";
            this.empresa_tipo.ReadOnly = true;
            // 
            // serie_secuencia
            // 
            this.serie_secuencia.FillWeight = 40F;
            this.serie_secuencia.HeaderText = "Serie";
            this.serie_secuencia.Name = "serie_secuencia";
            this.serie_secuencia.ReadOnly = true;
            // 
            // caja_nombre
            // 
            this.caja_nombre.HeaderText = "Caja";
            this.caja_nombre.Name = "caja_nombre";
            this.caja_nombre.ReadOnly = true;
            // 
            // tipo_comprobante
            // 
            this.tipo_comprobante.HeaderText = "Tipo comprobante";
            this.tipo_comprobante.Name = "tipo_comprobante";
            this.tipo_comprobante.ReadOnly = true;
            // 
            // comprobante_secuencia
            // 
            this.comprobante_secuencia.FillWeight = 70F;
            this.comprobante_secuencia.HeaderText = "Secuencia comprobante";
            this.comprobante_secuencia.Name = "comprobante_secuencia";
            this.comprobante_secuencia.ReadOnly = true;
            // 
            // desde
            // 
            this.desde.HeaderText = "Desde";
            this.desde.Name = "desde";
            this.desde.ReadOnly = true;
            // 
            // hasta
            // 
            this.hasta.HeaderText = "Hasta";
            this.hasta.Name = "hasta";
            this.hasta.ReadOnly = true;
            // 
            // actual
            // 
            this.actual.HeaderText = "Usado";
            this.actual.Name = "actual";
            this.actual.ReadOnly = true;
            // 
            // nombre_empresa_txt
            // 
            this.nombre_empresa_txt.Location = new System.Drawing.Point(15, 51);
            this.nombre_empresa_txt.Name = "nombre_empresa_txt";
            this.nombre_empresa_txt.ReadOnly = true;
            this.nombre_empresa_txt.Size = new System.Drawing.Size(241, 20);
            this.nombre_empresa_txt.TabIndex = 90;
            // 
            // codigo_empresa_txt
            // 
            this.codigo_empresa_txt.Location = new System.Drawing.Point(97, 30);
            this.codigo_empresa_txt.Name = "codigo_empresa_txt";
            this.codigo_empresa_txt.ReadOnly = true;
            this.codigo_empresa_txt.Size = new System.Drawing.Size(106, 20);
            this.codigo_empresa_txt.TabIndex = 89;
            // 
            // button16
            // 
            this.button16.BackgroundImage = global::puntoVenta.Properties.Resources.find_icon;
            this.button16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button16.Location = new System.Drawing.Point(207, 12);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(49, 38);
            this.button16.TabIndex = 88;
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(10, 26);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(90, 25);
            this.label16.TabIndex = 87;
            this.label16.Text = "Empresa";
            // 
            // nombre_sucursal_txt
            // 
            this.nombre_sucursal_txt.Location = new System.Drawing.Point(16, 123);
            this.nombre_sucursal_txt.Name = "nombre_sucursal_txt";
            this.nombre_sucursal_txt.ReadOnly = true;
            this.nombre_sucursal_txt.Size = new System.Drawing.Size(241, 20);
            this.nombre_sucursal_txt.TabIndex = 86;
            // 
            // codigo_sucursal_txt
            // 
            this.codigo_sucursal_txt.Location = new System.Drawing.Point(98, 102);
            this.codigo_sucursal_txt.Name = "codigo_sucursal_txt";
            this.codigo_sucursal_txt.ReadOnly = true;
            this.codigo_sucursal_txt.Size = new System.Drawing.Size(106, 20);
            this.codigo_sucursal_txt.TabIndex = 85;
            // 
            // button6
            // 
            this.button6.BackgroundImage = global::puntoVenta.Properties.Resources.find_icon;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Location = new System.Drawing.Point(208, 84);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(49, 38);
            this.button6.TabIndex = 84;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(11, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 25);
            this.label12.TabIndex = 83;
            this.label12.Text = "Sucursal";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackgroundImage = global::puntoVenta.Properties.Resources.red_x_cross_wrong_not_clip_art_f;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Location = new System.Drawing.Point(847, 113);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(59, 39);
            this.button4.TabIndex = 91;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // busqueda_comprobantes_fiscales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(914, 421);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.nombre_empresa_txt);
            this.Controls.Add(this.codigo_empresa_txt);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.nombre_sucursal_txt);
            this.Controls.Add(this.codigo_sucursal_txt);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "busqueda_comprobantes_fiscales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busqueda Comprobantes Fiscales";
            this.Load += new System.EventHandler(this.busqueda_comprobantes_fiscales_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox nombre_empresa_txt;
        private System.Windows.Forms.TextBox codigo_empresa_txt;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox nombre_sucursal_txt;
        private System.Windows.Forms.TextBox codigo_sucursal_txt;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn empresa_tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn serie_secuencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn caja_nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_comprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn comprobante_secuencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn desde;
        private System.Windows.Forms.DataGridViewTextBoxColumn hasta;
        private System.Windows.Forms.DataGridViewTextBoxColumn actual;
        private System.Windows.Forms.Button button4;
    }
}