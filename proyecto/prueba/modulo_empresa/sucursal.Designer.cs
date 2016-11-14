namespace puntoVenta
{
    partial class sucursal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sucursal));
            this.codigo_sucursal_txt = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.sucursal_nombre_txt = new System.Windows.Forms.TextBox();
            this.ck_activo = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.codigo_direccion_txt = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.codigo_empresa_txt = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.nombre_empresa_txt = new System.Windows.Forms.TextBox();
            this.tipo_telefono_combo_txt = new System.Windows.Forms.ComboBox();
            this.telefono_txt = new System.Windows.Forms.MaskedTextBox();
            this.button12 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secuencia_txt = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // codigo_sucursal_txt
            // 
            this.codigo_sucursal_txt.Location = new System.Drawing.Point(129, 107);
            this.codigo_sucursal_txt.Name = "codigo_sucursal_txt";
            this.codigo_sucursal_txt.ReadOnly = true;
            this.codigo_sucursal_txt.Size = new System.Drawing.Size(101, 20);
            this.codigo_sucursal_txt.TabIndex = 8;
            this.codigo_sucursal_txt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(12, 315);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(581, 54);
            this.panel2.TabIndex = 31;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button3.BackgroundImage = global::puntoVenta.Properties.Resources.map_icon;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(256, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(71, 54);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::puntoVenta.Properties.Resources.edit_not_validated1;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Dock = System.Windows.Forms.DockStyle.Left;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 54);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::puntoVenta.Properties.Resources.save_file_disk_open_searsh_loading_clipboard_15131;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(509, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 54);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(36, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 29);
            this.label2.TabIndex = 32;
            this.label2.Text = "Sucursal";
            this.label2.UseCompatibleTextRendering = true;
            // 
            // sucursal_nombre_txt
            // 
            this.sucursal_nombre_txt.Location = new System.Drawing.Point(129, 134);
            this.sucursal_nombre_txt.MaxLength = 50;
            this.sucursal_nombre_txt.Name = "sucursal_nombre_txt";
            this.sucursal_nombre_txt.Size = new System.Drawing.Size(147, 20);
            this.sucursal_nombre_txt.TabIndex = 33;
            this.sucursal_nombre_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sucursal_nombre_txt_KeyDown);
            // 
            // ck_activo
            // 
            this.ck_activo.AutoSize = true;
            this.ck_activo.Checked = true;
            this.ck_activo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_activo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_activo.ForeColor = System.Drawing.Color.Black;
            this.ck_activo.Location = new System.Drawing.Point(43, 258);
            this.ck_activo.Name = "ck_activo";
            this.ck_activo.Size = new System.Drawing.Size(80, 28);
            this.ck_activo.TabIndex = 34;
            this.ck_activo.Text = "Activo";
            this.ck_activo.UseVisualStyleBackColor = true;
            this.ck_activo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ck_activo_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(30, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 29);
            this.label4.TabIndex = 39;
            this.label4.Text = "Dirección";
            this.label4.UseCompatibleTextRendering = true;
            // 
            // codigo_direccion_txt
            // 
            this.codigo_direccion_txt.Location = new System.Drawing.Point(129, 224);
            this.codigo_direccion_txt.Name = "codigo_direccion_txt";
            this.codigo_direccion_txt.ReadOnly = true;
            this.codigo_direccion_txt.Size = new System.Drawing.Size(101, 20);
            this.codigo_direccion_txt.TabIndex = 40;
            // 
            // button6
            // 
            this.button6.BackgroundImage = global::puntoVenta.Properties.Resources.find_icon;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Location = new System.Drawing.Point(236, 97);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(40, 32);
            this.button6.TabIndex = 42;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::puntoVenta.Properties.Resources.find_icon;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Location = new System.Drawing.Point(236, 218);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(40, 29);
            this.button5.TabIndex = 41;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.BackgroundImage = global::puntoVenta.Properties.Resources.red_x_cross_wrong_not_clip_art_f;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.Location = new System.Drawing.Point(540, 18);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(53, 39);
            this.button7.TabIndex = 60;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(20, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 29);
            this.label5.TabIndex = 61;
            this.label5.Text = "Secuencia";
            this.label5.UseCompatibleTextRendering = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(33, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 29);
            this.label6.TabIndex = 65;
            this.label6.Text = "Empresa";
            this.label6.UseCompatibleTextRendering = true;
            // 
            // codigo_empresa_txt
            // 
            this.codigo_empresa_txt.Location = new System.Drawing.Point(129, 39);
            this.codigo_empresa_txt.MaxLength = 50;
            this.codigo_empresa_txt.Name = "codigo_empresa_txt";
            this.codigo_empresa_txt.ReadOnly = true;
            this.codigo_empresa_txt.Size = new System.Drawing.Size(101, 20);
            this.codigo_empresa_txt.TabIndex = 66;
            // 
            // button8
            // 
            this.button8.BackgroundImage = global::puntoVenta.Properties.Resources.find_icon;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.Location = new System.Drawing.Point(236, 29);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(40, 32);
            this.button8.TabIndex = 67;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // nombre_empresa_txt
            // 
            this.nombre_empresa_txt.Location = new System.Drawing.Point(129, 64);
            this.nombre_empresa_txt.MaxLength = 50;
            this.nombre_empresa_txt.Name = "nombre_empresa_txt";
            this.nombre_empresa_txt.ReadOnly = true;
            this.nombre_empresa_txt.Size = new System.Drawing.Size(147, 20);
            this.nombre_empresa_txt.TabIndex = 68;
            // 
            // tipo_telefono_combo_txt
            // 
            this.tipo_telefono_combo_txt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipo_telefono_combo_txt.FormattingEnabled = true;
            this.tipo_telefono_combo_txt.Items.AddRange(new object[] {
            "TEL",
            "CEL"});
            this.tipo_telefono_combo_txt.Location = new System.Drawing.Point(420, 34);
            this.tipo_telefono_combo_txt.Name = "tipo_telefono_combo_txt";
            this.tipo_telefono_combo_txt.Size = new System.Drawing.Size(61, 21);
            this.tipo_telefono_combo_txt.TabIndex = 102;
            this.tipo_telefono_combo_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tipo_telefono_combo_txt_KeyUp);
            // 
            // telefono_txt
            // 
            this.telefono_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telefono_txt.Location = new System.Drawing.Point(319, 31);
            this.telefono_txt.Mask = "9999999999";
            this.telefono_txt.Name = "telefono_txt";
            this.telefono_txt.Size = new System.Drawing.Size(98, 26);
            this.telefono_txt.TabIndex = 101;
            // 
            // button12
            // 
            this.button12.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button12.BackgroundImage")));
            this.button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button12.Location = new System.Drawing.Point(485, 19);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(49, 38);
            this.button12.TabIndex = 99;
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
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
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.telefono,
            this.tipo_telefono});
            this.dataGridView1.Location = new System.Drawing.Point(319, 59);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(274, 230);
            this.dataGridView1.TabIndex = 98;
            // 
            // telefono
            // 
            this.telefono.HeaderText = "telefono";
            this.telefono.Name = "telefono";
            this.telefono.ReadOnly = true;
            // 
            // tipo_telefono
            // 
            this.tipo_telefono.HeaderText = "Tipo";
            this.tipo_telefono.Name = "tipo_telefono";
            this.tipo_telefono.ReadOnly = true;
            // 
            // secuencia_txt
            // 
            this.secuencia_txt.Location = new System.Drawing.Point(129, 183);
            this.secuencia_txt.MaxLength = 3;
            this.secuencia_txt.Name = "secuencia_txt";
            this.secuencia_txt.Size = new System.Drawing.Size(147, 20);
            this.secuencia_txt.TabIndex = 103;
            this.secuencia_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.secuencia_txt_KeyUp);
            // 
            // sucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(605, 381);
            this.Controls.Add(this.secuencia_txt);
            this.Controls.Add(this.tipo_telefono_combo_txt);
            this.Controls.Add(this.telefono_txt);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.nombre_empresa_txt);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.codigo_empresa_txt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.codigo_direccion_txt);
            this.Controls.Add(this.ck_activo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sucursal_nombre_txt);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.codigo_sucursal_txt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "sucursal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sucursal";
            this.Load += new System.EventHandler(this.sucursal_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox codigo_sucursal_txt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sucursal_nombre_txt;
        private System.Windows.Forms.CheckBox ck_activo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox codigo_direccion_txt;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox codigo_empresa_txt;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox nombre_empresa_txt;
        private System.Windows.Forms.ComboBox tipo_telefono_combo_txt;
        private System.Windows.Forms.MaskedTextBox telefono_txt;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_telefono;
        private System.Windows.Forms.TextBox secuencia_txt;
    }
}