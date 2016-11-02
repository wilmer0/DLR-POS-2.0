namespace puntoVenta
{
    partial class busqueda_unidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(busqueda_unidad));
            this.label1 = new System.Windows.Forms.Label();
            this.codigo_unidad_txt = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nombre_unidad_txt = new System.Windows.Forms.TextBox();
            this.ck_activo = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.unidad_txt = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.abreviacion_txt = new System.Windows.Forms.TextBox();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_grid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abre_grid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado_grid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 74;
            this.label1.Text = "Codigo";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // codigo_unidad_txt
            // 
            this.codigo_unidad_txt.Location = new System.Drawing.Point(101, 14);
            this.codigo_unidad_txt.Name = "codigo_unidad_txt";
            this.codigo_unidad_txt.ReadOnly = true;
            this.codigo_unidad_txt.Size = new System.Drawing.Size(86, 20);
            this.codigo_unidad_txt.TabIndex = 75;
            this.codigo_unidad_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.codigo_unidad_txt_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(12, 368);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(436, 56);
            this.panel2.TabIndex = 77;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button3.BackgroundImage = global::puntoVenta.Properties.Resources.map_icon;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(190, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(71, 56);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::puntoVenta.Properties.Resources.edit_not_validated1;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 56);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(364, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 56);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 24);
            this.label2.TabIndex = 78;
            this.label2.Text = "Nombre";
            this.label2.UseCompatibleTextRendering = true;
            // 
            // nombre_unidad_txt
            // 
            this.nombre_unidad_txt.Location = new System.Drawing.Point(101, 40);
            this.nombre_unidad_txt.Name = "nombre_unidad_txt";
            this.nombre_unidad_txt.Size = new System.Drawing.Size(139, 20);
            this.nombre_unidad_txt.TabIndex = 79;
            // 
            // ck_activo
            // 
            this.ck_activo.AutoSize = true;
            this.ck_activo.Checked = true;
            this.ck_activo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_activo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_activo.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.ck_activo.Location = new System.Drawing.Point(98, 66);
            this.ck_activo.Name = "ck_activo";
            this.ck_activo.Size = new System.Drawing.Size(80, 28);
            this.ck_activo.TabIndex = 80;
            this.ck_activo.Text = "Activo";
            this.ck_activo.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::puntoVenta.Properties.Resources.save_file_disk_open_searsh_loading_clipboard_1513;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Location = new System.Drawing.Point(246, 30);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(55, 42);
            this.button4.TabIndex = 81;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.nombre_grid,
            this.abre_grid,
            this.estado_grid});
            this.dataGridView1.Location = new System.Drawing.Point(12, 196);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(436, 166);
            this.dataGridView1.TabIndex = 82;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label3.Location = new System.Drawing.Point(12, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 29);
            this.label3.TabIndex = 83;
            this.label3.Text = "Nombre";
            this.label3.UseCompatibleTextRendering = true;
            // 
            // unidad_txt
            // 
            this.unidad_txt.Location = new System.Drawing.Point(98, 170);
            this.unidad_txt.Name = "unidad_txt";
            this.unidad_txt.Size = new System.Drawing.Size(220, 20);
            this.unidad_txt.TabIndex = 84;
            this.unidad_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.unidad_txt_KeyUp);
            // 
            // button7
            // 
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.Location = new System.Drawing.Point(307, 30);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(49, 42);
            this.button7.TabIndex = 85;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label4.Location = new System.Drawing.Point(12, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 24);
            this.label4.TabIndex = 86;
            this.label4.Text = "Abrev.";
            this.label4.UseCompatibleTextRendering = true;
            // 
            // abreviacion_txt
            // 
            this.abreviacion_txt.Location = new System.Drawing.Point(101, 101);
            this.abreviacion_txt.MaxLength = 5;
            this.abreviacion_txt.Name = "abreviacion_txt";
            this.abreviacion_txt.Size = new System.Drawing.Size(139, 20);
            this.abreviacion_txt.TabIndex = 87;
            // 
            // codigo
            // 
            this.codigo.FillWeight = 30F;
            this.codigo.HeaderText = "Codigo";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // nombre_grid
            // 
            this.nombre_grid.FillWeight = 110F;
            this.nombre_grid.HeaderText = "Nombre";
            this.nombre_grid.Name = "nombre_grid";
            this.nombre_grid.ReadOnly = true;
            // 
            // abre_grid
            // 
            this.abre_grid.FillWeight = 30F;
            this.abre_grid.HeaderText = "Abrev";
            this.abre_grid.Name = "abre_grid";
            this.abre_grid.ReadOnly = true;
            // 
            // estado_grid
            // 
            this.estado_grid.FillWeight = 30F;
            this.estado_grid.HeaderText = "Estado";
            this.estado_grid.Name = "estado_grid";
            this.estado_grid.ReadOnly = true;
            // 
            // busqueda_unidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(460, 436);
            this.Controls.Add(this.abreviacion_txt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.unidad_txt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.ck_activo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nombre_unidad_txt);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.codigo_unidad_txt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "busqueda_unidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busqueda unidad";
            this.Load += new System.EventHandler(this.busqueda_unidad_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox codigo_unidad_txt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nombre_unidad_txt;
        private System.Windows.Forms.CheckBox ck_activo;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox unidad_txt;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox abreviacion_txt;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn abre_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado_grid;
    }
}