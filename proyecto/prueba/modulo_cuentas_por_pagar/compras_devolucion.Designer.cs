namespace puntoVenta
{
    partial class compras_devolucion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(compras_devolucion));
            this.nombre_suplidor_txt = new System.Windows.Forms.TextBox();
            this.pais_btn = new System.Windows.Forms.Button();
            this.codigo_suplidor_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codigo_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo_unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.devolver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.cantidad_devolver_txt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Cantidad_grid_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ck_devueltas = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // nombre_suplidor_txt
            // 
            this.nombre_suplidor_txt.Location = new System.Drawing.Point(12, 44);
            this.nombre_suplidor_txt.Name = "nombre_suplidor_txt";
            this.nombre_suplidor_txt.ReadOnly = true;
            this.nombre_suplidor_txt.Size = new System.Drawing.Size(219, 20);
            this.nombre_suplidor_txt.TabIndex = 36;
            // 
            // pais_btn
            // 
            this.pais_btn.BackgroundImage = global::puntoVenta.Properties.Resources.find_icon;
            this.pais_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pais_btn.Location = new System.Drawing.Point(195, 12);
            this.pais_btn.Name = "pais_btn";
            this.pais_btn.Size = new System.Drawing.Size(36, 28);
            this.pais_btn.TabIndex = 35;
            this.pais_btn.UseVisualStyleBackColor = true;
            this.pais_btn.Click += new System.EventHandler(this.pais_btn_Click);
            // 
            // codigo_suplidor_txt
            // 
            this.codigo_suplidor_txt.Location = new System.Drawing.Point(89, 18);
            this.codigo_suplidor_txt.Name = "codigo_suplidor_txt";
            this.codigo_suplidor_txt.ReadOnly = true;
            this.codigo_suplidor_txt.Size = new System.Drawing.Size(100, 20);
            this.codigo_suplidor_txt.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 29);
            this.label1.TabIndex = 33;
            this.label1.Text = "Suplidor";
            this.label1.UseCompatibleTextRendering = true;
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
            this.codigo_producto,
            this.nombre_producto,
            this.codigo_unidad,
            this.nombre_unidad,
            this.costo,
            this.cantidad,
            this.importe,
            this.devolver});
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(12, 294);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(923, 277);
            this.dataGridView1.TabIndex = 50;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // codigo_producto
            // 
            this.codigo_producto.FillWeight = 33.13289F;
            this.codigo_producto.HeaderText = "Codigo";
            this.codigo_producto.Name = "codigo_producto";
            this.codigo_producto.ReadOnly = true;
            // 
            // nombre_producto
            // 
            this.nombre_producto.FillWeight = 66.26578F;
            this.nombre_producto.HeaderText = "Nombre";
            this.nombre_producto.Name = "nombre_producto";
            this.nombre_producto.ReadOnly = true;
            // 
            // codigo_unidad
            // 
            this.codigo_unidad.FillWeight = 66F;
            this.codigo_unidad.HeaderText = "Cod. unidad";
            this.codigo_unidad.Name = "codigo_unidad";
            this.codigo_unidad.ReadOnly = true;
            // 
            // nombre_unidad
            // 
            this.nombre_unidad.FillWeight = 66.26578F;
            this.nombre_unidad.HeaderText = "Unidad";
            this.nombre_unidad.Name = "nombre_unidad";
            this.nombre_unidad.ReadOnly = true;
            // 
            // costo
            // 
            this.costo.FillWeight = 33.13289F;
            this.costo.HeaderText = "Costo";
            this.costo.Name = "costo";
            this.costo.ReadOnly = true;
            // 
            // cantidad
            // 
            this.cantidad.FillWeight = 33.13289F;
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            // 
            // importe
            // 
            this.importe.FillWeight = 33.13289F;
            this.importe.HeaderText = "Importe";
            this.importe.Name = "importe";
            this.importe.ReadOnly = true;
            // 
            // devolver
            // 
            this.devolver.FillWeight = 50F;
            this.devolver.HeaderText = "Devuelta";
            this.devolver.Name = "devolver";
            this.devolver.ReadOnly = true;
            this.devolver.Resizable = System.Windows.Forms.DataGridViewTriState.False;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.GridColor = System.Drawing.Color.White;
            this.dataGridView2.Location = new System.Drawing.Point(12, 106);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(923, 146);
            this.dataGridView2.TabIndex = 84;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_compras_CellContentClick);
            this.dataGridView2.Click += new System.EventHandler(this.dataGridView2_compras_Click);
            // 
            // cantidad_devolver_txt
            // 
            this.cantidad_devolver_txt.Location = new System.Drawing.Point(739, 272);
            this.cantidad_devolver_txt.Name = "cantidad_devolver_txt";
            this.cantidad_devolver_txt.Size = new System.Drawing.Size(86, 20);
            this.cantidad_devolver_txt.TabIndex = 88;
            this.cantidad_devolver_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cantidad_devolver_txt_KeyUp);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(655, 269);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 25);
            this.label12.TabIndex = 87;
            this.label12.Text = "Devuelta";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button5.BackgroundImage = global::puntoVenta.Properties.Resources.lg_red_green_OK_not_OK_Icons;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Location = new System.Drawing.Point(827, 258);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(54, 36);
            this.button5.TabIndex = 85;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button4.BackgroundImage = global::puntoVenta.Properties.Resources.red_x_cross_wrong_not_clip_art_f;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Location = new System.Drawing.Point(881, 258);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(54, 36);
            this.button4.TabIndex = 86;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(12, 577);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(923, 55);
            this.panel2.TabIndex = 89;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button3.BackgroundImage = global::puntoVenta.Properties.Resources.map_icon;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(419, 0);
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
            this.button1.Location = new System.Drawing.Point(851, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 55);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Cantidad_grid_txt
            // 
            this.Cantidad_grid_txt.Location = new System.Drawing.Point(549, 272);
            this.Cantidad_grid_txt.Name = "Cantidad_grid_txt";
            this.Cantidad_grid_txt.ReadOnly = true;
            this.Cantidad_grid_txt.Size = new System.Drawing.Size(100, 20);
            this.Cantidad_grid_txt.TabIndex = 90;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(10, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 29);
            this.label3.TabIndex = 91;
            this.label3.Text = "Compras";
            this.label3.UseCompatibleTextRendering = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(224, 29);
            this.label4.TabIndex = 92;
            this.label4.Text = "Productos de la compra";
            this.label4.UseCompatibleTextRendering = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(454, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 25);
            this.label2.TabIndex = 93;
            this.label2.Text = "Cantidad";
            // 
            // ck_devueltas
            // 
            this.ck_devueltas.AutoSize = true;
            this.ck_devueltas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_devueltas.ForeColor = System.Drawing.Color.Black;
            this.ck_devueltas.Location = new System.Drawing.Point(758, 72);
            this.ck_devueltas.Name = "ck_devueltas";
            this.ck_devueltas.Size = new System.Drawing.Size(177, 28);
            this.ck_devueltas.TabIndex = 94;
            this.ck_devueltas.Text = "Ver devoluciones";
            this.ck_devueltas.UseVisualStyleBackColor = true;
            this.ck_devueltas.CheckedChanged += new System.EventHandler(this.ck_devueltas_CheckedChanged);
            this.ck_devueltas.Click += new System.EventHandler(this.ck_devueltas_Click);
            // 
            // compras_devolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(947, 644);
            this.Controls.Add(this.ck_devueltas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Cantidad_grid_txt);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cantidad_devolver_txt);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.nombre_suplidor_txt);
            this.Controls.Add(this.pais_btn);
            this.Controls.Add(this.codigo_suplidor_txt);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "compras_devolucion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compras Devolucion";
            this.Load += new System.EventHandler(this.compras_devolucion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nombre_suplidor_txt;
        private System.Windows.Forms.Button pais_btn;
        private System.Windows.Forms.TextBox codigo_suplidor_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn devolver;
        private System.Windows.Forms.TextBox cantidad_devolver_txt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Cantidad_grid_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ck_devueltas;
    }
}