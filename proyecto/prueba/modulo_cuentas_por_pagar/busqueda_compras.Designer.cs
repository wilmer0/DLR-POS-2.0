namespace puntoVenta
{
    partial class busqueda_compras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(busqueda_compras));
            this.dataGridView1_suplidores = new System.Windows.Forms.DataGridView();
            this.codigo_supli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_supli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.identificacion_supli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.nombre_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView2_compras = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num_fac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ncf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rnc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_compra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_inicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_limite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView3_detalle_compras = new System.Windows.Forms.DataGridView();
            this.cod_pro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_uni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.canti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_suplidores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2_compras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3_detalle_compras)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1_suplidores
            // 
            this.dataGridView1_suplidores.AllowUserToAddRows = false;
            this.dataGridView1_suplidores.AllowUserToDeleteRows = false;
            this.dataGridView1_suplidores.AllowUserToResizeColumns = false;
            this.dataGridView1_suplidores.AllowUserToResizeRows = false;
            this.dataGridView1_suplidores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1_suplidores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1_suplidores.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1_suplidores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1_suplidores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1_suplidores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo_supli,
            this.nombre_supli,
            this.identificacion_supli});
            this.dataGridView1_suplidores.GridColor = System.Drawing.Color.White;
            this.dataGridView1_suplidores.Location = new System.Drawing.Point(12, 52);
            this.dataGridView1_suplidores.MultiSelect = false;
            this.dataGridView1_suplidores.Name = "dataGridView1_suplidores";
            this.dataGridView1_suplidores.ReadOnly = true;
            this.dataGridView1_suplidores.RowHeadersVisible = false;
            this.dataGridView1_suplidores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1_suplidores.Size = new System.Drawing.Size(557, 173);
            this.dataGridView1_suplidores.TabIndex = 50;
            this.dataGridView1_suplidores.SelectionChanged += new System.EventHandler(this.dataGridView1_suplidores_SelectionChanged);
            this.dataGridView1_suplidores.Click += new System.EventHandler(this.dataGridView1_suplidores_Click);
            // 
            // codigo_supli
            // 
            this.codigo_supli.FillWeight = 80F;
            this.codigo_supli.HeaderText = "Cod. suplidor";
            this.codigo_supli.Name = "codigo_supli";
            this.codigo_supli.ReadOnly = true;
            // 
            // nombre_supli
            // 
            this.nombre_supli.HeaderText = "Nombre";
            this.nombre_supli.Name = "nombre_supli";
            this.nombre_supli.ReadOnly = true;
            // 
            // identificacion_supli
            // 
            this.identificacion_supli.HeaderText = "Identificacion";
            this.identificacion_supli.Name = "identificacion_supli";
            this.identificacion_supli.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 29);
            this.label2.TabIndex = 80;
            this.label2.Text = "Suplidor";
            this.label2.UseCompatibleTextRendering = true;
            // 
            // nombre_txt
            // 
            this.nombre_txt.Location = new System.Drawing.Point(98, 25);
            this.nombre_txt.Name = "nombre_txt";
            this.nombre_txt.Size = new System.Drawing.Size(187, 20);
            this.nombre_txt.TabIndex = 81;
            this.nombre_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nombre_txt_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 29);
            this.label1.TabIndex = 82;
            this.label1.Text = "Compras";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // dataGridView2_compras
            // 
            this.dataGridView2_compras.AllowUserToAddRows = false;
            this.dataGridView2_compras.AllowUserToDeleteRows = false;
            this.dataGridView2_compras.AllowUserToResizeColumns = false;
            this.dataGridView2_compras.AllowUserToResizeRows = false;
            this.dataGridView2_compras.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2_compras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2_compras.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2_compras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2_compras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2_compras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.num_fac,
            this.ncf,
            this.rnc,
            this.tipo_compra,
            this.fecha_inicial,
            this.fecha_limite});
            this.dataGridView2_compras.GridColor = System.Drawing.Color.White;
            this.dataGridView2_compras.Location = new System.Drawing.Point(12, 272);
            this.dataGridView2_compras.MultiSelect = false;
            this.dataGridView2_compras.Name = "dataGridView2_compras";
            this.dataGridView2_compras.ReadOnly = true;
            this.dataGridView2_compras.RowHeadersVisible = false;
            this.dataGridView2_compras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2_compras.Size = new System.Drawing.Size(557, 173);
            this.dataGridView2_compras.TabIndex = 83;
            this.dataGridView2_compras.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_compras_CellContentClick);
            this.dataGridView2_compras.Click += new System.EventHandler(this.dataGridView2_compras_Click);
            // 
            // codigo
            // 
            this.codigo.FillWeight = 70F;
            this.codigo.HeaderText = "Cod. factura";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // num_fac
            // 
            this.num_fac.FillWeight = 70F;
            this.num_fac.HeaderText = "Num factura";
            this.num_fac.Name = "num_fac";
            this.num_fac.ReadOnly = true;
            // 
            // ncf
            // 
            this.ncf.FillWeight = 110F;
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
            // tipo_compra
            // 
            this.tipo_compra.FillWeight = 80F;
            this.tipo_compra.HeaderText = "Tipo compra";
            this.tipo_compra.Name = "tipo_compra";
            this.tipo_compra.ReadOnly = true;
            // 
            // fecha_inicial
            // 
            this.fecha_inicial.HeaderText = "Fecha hecha";
            this.fecha_inicial.Name = "fecha_inicial";
            this.fecha_inicial.ReadOnly = true;
            // 
            // fecha_limite
            // 
            this.fecha_limite.HeaderText = "Fecha limite";
            this.fecha_limite.Name = "fecha_limite";
            this.fecha_limite.ReadOnly = true;
            // 
            // dataGridView3_detalle_compras
            // 
            this.dataGridView3_detalle_compras.AllowUserToAddRows = false;
            this.dataGridView3_detalle_compras.AllowUserToDeleteRows = false;
            this.dataGridView3_detalle_compras.AllowUserToResizeColumns = false;
            this.dataGridView3_detalle_compras.AllowUserToResizeRows = false;
            this.dataGridView3_detalle_compras.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3_detalle_compras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3_detalle_compras.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView3_detalle_compras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView3_detalle_compras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3_detalle_compras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod_pro,
            this.prod,
            this.cod_uni,
            this.unidad,
            this.costo,
            this.canti});
            this.dataGridView3_detalle_compras.GridColor = System.Drawing.Color.White;
            this.dataGridView3_detalle_compras.Location = new System.Drawing.Point(575, 52);
            this.dataGridView3_detalle_compras.MultiSelect = false;
            this.dataGridView3_detalle_compras.Name = "dataGridView3_detalle_compras";
            this.dataGridView3_detalle_compras.ReadOnly = true;
            this.dataGridView3_detalle_compras.RowHeadersVisible = false;
            this.dataGridView3_detalle_compras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView3_detalle_compras.Size = new System.Drawing.Size(595, 393);
            this.dataGridView3_detalle_compras.TabIndex = 85;
            // 
            // cod_pro
            // 
            this.cod_pro.FillWeight = 80F;
            this.cod_pro.HeaderText = "Cod. producto";
            this.cod_pro.Name = "cod_pro";
            this.cod_pro.ReadOnly = true;
            // 
            // prod
            // 
            this.prod.HeaderText = "Producto";
            this.prod.Name = "prod";
            this.prod.ReadOnly = true;
            // 
            // cod_uni
            // 
            this.cod_uni.FillWeight = 80F;
            this.cod_uni.HeaderText = "Cod. unidad";
            this.cod_uni.Name = "cod_uni";
            this.cod_uni.ReadOnly = true;
            // 
            // unidad
            // 
            this.unidad.HeaderText = "Unidad";
            this.unidad.Name = "unidad";
            this.unidad.ReadOnly = true;
            // 
            // costo
            // 
            this.costo.HeaderText = "Costo";
            this.costo.Name = "costo";
            this.costo.ReadOnly = true;
            // 
            // canti
            // 
            this.canti.HeaderText = "Cantidad";
            this.canti.Name = "canti";
            this.canti.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(575, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 29);
            this.label3.TabIndex = 84;
            this.label3.Text = "Detalles compra";
            this.label3.UseCompatibleTextRendering = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Location = new System.Drawing.Point(12, 451);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1158, 54);
            this.panel2.TabIndex = 94;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button3.BackgroundImage = global::puntoVenta.Properties.Resources.map_icon;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(545, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(71, 54);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button6
            // 
            this.button6.BackgroundImage = global::puntoVenta.Properties.Resources.edit_not_validated1;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Dock = System.Windows.Forms.DockStyle.Left;
            this.button6.Location = new System.Drawing.Point(0, 0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(71, 54);
            this.button6.TabIndex = 1;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.Dock = System.Windows.Forms.DockStyle.Right;
            this.button7.Location = new System.Drawing.Point(1086, 0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(72, 54);
            this.button7.TabIndex = 0;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.White;
            this.button9.BackgroundImage = global::puntoVenta.Properties.Resources.cancel1;
            this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button9.Location = new System.Drawing.Point(1110, 9);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(60, 43);
            this.button9.TabIndex = 95;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(1046, 27);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 25);
            this.label14.TabIndex = 96;
            this.label14.Text = "Anular";
            this.label14.UseCompatibleTextRendering = true;
            // 
            // busqueda_compras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1182, 513);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView3_detalle_compras);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView2_compras);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nombre_txt);
            this.Controls.Add(this.dataGridView1_suplidores);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "busqueda_compras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busqueda compras";
            this.Load += new System.EventHandler(this.busqueda_compras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_suplidores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2_compras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3_detalle_compras)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1_suplidores;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nombre_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView2_compras;
        private System.Windows.Forms.DataGridView dataGridView3_detalle_compras;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_pro;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_uni;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn canti;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn num_fac;
        private System.Windows.Forms.DataGridViewTextBoxColumn ncf;
        private System.Windows.Forms.DataGridViewTextBoxColumn rnc;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_compra;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_inicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_limite;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_supli;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_supli;
        private System.Windows.Forms.DataGridViewTextBoxColumn identificacion_supli;
    }
}