namespace puntoVenta
{
    partial class banco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(banco));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.telefono_txt = new System.Windows.Forms.MaskedTextBox();
            this.tipo_telefono_combo_txt = new System.Windows.Forms.ComboBox();
            this.ck_activo = new System.Windows.Forms.CheckBox();
            this.identificacion_txt = new System.Windows.Forms.TextBox();
            this.button11 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button12 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_banco_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.codigo_banco_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(660, 290);
            this.tabControl1.TabIndex = 99;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.telefono_txt);
            this.tabPage1.Controls.Add(this.tipo_telefono_combo_txt);
            this.tabPage1.Controls.Add(this.ck_activo);
            this.tabPage1.Controls.Add(this.identificacion_txt);
            this.tabPage1.Controls.Add(this.button11);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.button12);
            this.tabPage1.Controls.Add(this.dataGridView2);
            this.tabPage1.Controls.Add(this.nombre_banco_txt);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.codigo_banco_txt);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button8);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(652, 264);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // telefono_txt
            // 
            this.telefono_txt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.telefono_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telefono_txt.Location = new System.Drawing.Point(344, 22);
            this.telefono_txt.Mask = "9999999999";
            this.telefono_txt.Name = "telefono_txt";
            this.telefono_txt.Size = new System.Drawing.Size(98, 26);
            this.telefono_txt.TabIndex = 108;
            // 
            // tipo_telefono_combo_txt
            // 
            this.tipo_telefono_combo_txt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tipo_telefono_combo_txt.FormattingEnabled = true;
            this.tipo_telefono_combo_txt.Items.AddRange(new object[] {
            "CEL",
            "TEL"});
            this.tipo_telefono_combo_txt.Location = new System.Drawing.Point(455, 27);
            this.tipo_telefono_combo_txt.Name = "tipo_telefono_combo_txt";
            this.tipo_telefono_combo_txt.Size = new System.Drawing.Size(61, 21);
            this.tipo_telefono_combo_txt.TabIndex = 109;
            // 
            // ck_activo
            // 
            this.ck_activo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ck_activo.AutoSize = true;
            this.ck_activo.Checked = true;
            this.ck_activo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_activo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_activo.ForeColor = System.Drawing.Color.Black;
            this.ck_activo.Location = new System.Drawing.Point(120, 162);
            this.ck_activo.Name = "ck_activo";
            this.ck_activo.Size = new System.Drawing.Size(80, 28);
            this.ck_activo.TabIndex = 13;
            this.ck_activo.Text = "Activo";
            this.ck_activo.UseVisualStyleBackColor = true;
            // 
            // identificacion_txt
            // 
            this.identificacion_txt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.identificacion_txt.Location = new System.Drawing.Point(120, 116);
            this.identificacion_txt.MaxLength = 11;
            this.identificacion_txt.Name = "identificacion_txt";
            this.identificacion_txt.Size = new System.Drawing.Size(175, 20);
            this.identificacion_txt.TabIndex = 8;
            // 
            // button11
            // 
            this.button11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button11.BackgroundImage = global::puntoVenta.Properties.Resources.red_x_cross_wrong_not_clip_art_f;
            this.button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button11.Location = new System.Drawing.Point(578, 13);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(53, 39);
            this.button11.TabIndex = 107;
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(10, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Identificacion";
            // 
            // button12
            // 
            this.button12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button12.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button12.BackgroundImage")));
            this.button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button12.Location = new System.Drawing.Point(522, 14);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(49, 38);
            this.button12.TabIndex = 106;
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.telefono,
            this.tipo_telefono});
            this.dataGridView2.Location = new System.Drawing.Point(344, 53);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(287, 205);
            this.dataGridView2.TabIndex = 105;
            // 
            // telefono
            // 
            this.telefono.HeaderText = "Telefono";
            this.telefono.Name = "telefono";
            this.telefono.ReadOnly = true;
            // 
            // tipo_telefono
            // 
            this.tipo_telefono.HeaderText = "Tipo";
            this.tipo_telefono.Name = "tipo_telefono";
            this.tipo_telefono.ReadOnly = true;
            // 
            // nombre_banco_txt
            // 
            this.nombre_banco_txt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nombre_banco_txt.Location = new System.Drawing.Point(120, 69);
            this.nombre_banco_txt.MaxLength = 50;
            this.nombre_banco_txt.Name = "nombre_banco_txt";
            this.nombre_banco_txt.Size = new System.Drawing.Size(175, 20);
            this.nombre_banco_txt.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre";
            // 
            // codigo_banco_txt
            // 
            this.codigo_banco_txt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.codigo_banco_txt.Location = new System.Drawing.Point(120, 30);
            this.codigo_banco_txt.Name = "codigo_banco_txt";
            this.codigo_banco_txt.ReadOnly = true;
            this.codigo_banco_txt.Size = new System.Drawing.Size(135, 20);
            this.codigo_banco_txt.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Codigo";
            // 
            // button8
            // 
            this.button8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button8.BackgroundImage = global::puntoVenta.Properties.Resources.find_icon;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.Location = new System.Drawing.Point(261, 24);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(34, 30);
            this.button8.TabIndex = 62;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(12, 319);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(654, 55);
            this.panel2.TabIndex = 100;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button3.BackgroundImage = global::puntoVenta.Properties.Resources.map_icon;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(293, 0);
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
            this.button1.BackgroundImage = global::puntoVenta.Properties.Resources.save_file_disk_open_searsh_loading_clipboard_15131;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(582, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 55);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // banco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(682, 386);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "banco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Banco";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox identificacion_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nombre_banco_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox codigo_banco_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.CheckBox ck_activo;
        private System.Windows.Forms.ComboBox tipo_telefono_combo_txt;
        private System.Windows.Forms.MaskedTextBox telefono_txt;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_telefono;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}