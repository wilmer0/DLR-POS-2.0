namespace puntoVenta
{
    partial class grupo_usuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(grupo_usuarios));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.codigo_grupo_txt = new System.Windows.Forms.TextBox();
            this.button11 = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.ck_activo = new System.Windows.Forms.CheckBox();
            this.nombre_grupo_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.codigo_permiso_txt = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.nombre_permiso_txt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.permiso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.ck_todos = new System.Windows.Forms.CheckBox();
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
            this.panel2.Location = new System.Drawing.Point(12, 394);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(419, 48);
            this.panel2.TabIndex = 62;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button4.BackgroundImage = global::puntoVenta.Properties.Resources.map_icon;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Location = new System.Drawing.Point(175, 0);
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
            this.button6.Location = new System.Drawing.Point(347, 0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(72, 48);
            this.button6.TabIndex = 0;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // codigo_grupo_txt
            // 
            this.codigo_grupo_txt.Location = new System.Drawing.Point(103, 43);
            this.codigo_grupo_txt.Name = "codigo_grupo_txt";
            this.codigo_grupo_txt.ReadOnly = true;
            this.codigo_grupo_txt.Size = new System.Drawing.Size(129, 20);
            this.codigo_grupo_txt.TabIndex = 92;
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Transparent;
            this.button11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button11.BackgroundImage")));
            this.button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button11.Location = new System.Drawing.Point(238, 33);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(46, 34);
            this.button11.TabIndex = 90;
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label18.Location = new System.Drawing.Point(15, 37);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(73, 29);
            this.label18.TabIndex = 89;
            this.label18.Text = "Codigo";
            this.label18.UseCompatibleTextRendering = true;
            // 
            // ck_activo
            // 
            this.ck_activo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ck_activo.AutoSize = true;
            this.ck_activo.Checked = true;
            this.ck_activo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_activo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_activo.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.ck_activo.Location = new System.Drawing.Point(101, 111);
            this.ck_activo.Name = "ck_activo";
            this.ck_activo.Size = new System.Drawing.Size(80, 28);
            this.ck_activo.TabIndex = 93;
            this.ck_activo.Text = "Activo";
            this.ck_activo.UseVisualStyleBackColor = true;
            // 
            // nombre_grupo_txt
            // 
            this.nombre_grupo_txt.Location = new System.Drawing.Point(103, 85);
            this.nombre_grupo_txt.MaxLength = 50;
            this.nombre_grupo_txt.Name = "nombre_grupo_txt";
            this.nombre_grupo_txt.Size = new System.Drawing.Size(181, 20);
            this.nombre_grupo_txt.TabIndex = 94;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.Location = new System.Drawing.Point(15, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 29);
            this.label1.TabIndex = 95;
            this.label1.Text = "Nombre";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // codigo_permiso_txt
            // 
            this.codigo_permiso_txt.Location = new System.Drawing.Point(127, 179);
            this.codigo_permiso_txt.Mask = "99999";
            this.codigo_permiso_txt.Name = "codigo_permiso_txt";
            this.codigo_permiso_txt.ReadOnly = true;
            this.codigo_permiso_txt.Size = new System.Drawing.Size(125, 20);
            this.codigo_permiso_txt.TabIndex = 109;
            this.codigo_permiso_txt.ValidatingType = typeof(int);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label8.Location = new System.Drawing.Point(10, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 25);
            this.label8.TabIndex = 104;
            this.label8.Text = "Permiso";
            // 
            // button10
            // 
            this.button10.BackgroundImage = global::puntoVenta.Properties.Resources.red_x_cross_wrong_not_clip_art_f;
            this.button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button10.Location = new System.Drawing.Point(378, 187);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(53, 36);
            this.button10.TabIndex = 108;
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.BackgroundImage = global::puntoVenta.Properties.Resources.lg_red_green_OK_not_OK_Icons;
            this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button9.Location = new System.Drawing.Point(327, 187);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(50, 36);
            this.button9.TabIndex = 105;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // nombre_permiso_txt
            // 
            this.nombre_permiso_txt.Location = new System.Drawing.Point(15, 201);
            this.nombre_permiso_txt.Name = "nombre_permiso_txt";
            this.nombre_permiso_txt.ReadOnly = true;
            this.nombre_permiso_txt.Size = new System.Drawing.Size(239, 20);
            this.nombre_permiso_txt.TabIndex = 107;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::puntoVenta.Properties.Resources.find_icon;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(257, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 36);
            this.button1.TabIndex = 106;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.permiso});
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(15, 223);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(416, 161);
            this.dataGridView1.TabIndex = 103;
            // 
            // codigo
            // 
            this.codigo.FillWeight = 29.61083F;
            this.codigo.HeaderText = "Codigo";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // permiso
            // 
            this.permiso.HeaderText = "Permiso";
            this.permiso.Name = "permiso";
            this.permiso.ReadOnly = true;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::puntoVenta.Properties.Resources.save_file_disk_open_searsh_loading_clipboard_15132;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(218, 111);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 48);
            this.button2.TabIndex = 110;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ck_todos
            // 
            this.ck_todos.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ck_todos.AutoSize = true;
            this.ck_todos.Checked = true;
            this.ck_todos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_todos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_todos.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.ck_todos.Location = new System.Drawing.Point(327, 153);
            this.ck_todos.Name = "ck_todos";
            this.ck_todos.Size = new System.Drawing.Size(83, 28);
            this.ck_todos.TabIndex = 111;
            this.ck_todos.Text = "Todos";
            this.ck_todos.UseVisualStyleBackColor = true;
            this.ck_todos.CheckedChanged += new System.EventHandler(this.ck_todos_CheckedChanged);
            this.ck_todos.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // grupo_usuarios
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(443, 454);
            this.Controls.Add(this.ck_todos);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.codigo_permiso_txt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.nombre_permiso_txt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nombre_grupo_txt);
            this.Controls.Add(this.ck_activo);
            this.Controls.Add(this.codigo_grupo_txt);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "grupo_usuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grupo de usuarios";
            this.Load += new System.EventHandler(this.grupo_usuarios_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox codigo_grupo_txt;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox ck_activo;
        private System.Windows.Forms.TextBox nombre_grupo_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox codigo_permiso_txt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox nombre_permiso_txt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn permiso;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox ck_todos;
    }
}
