namespace puntoVenta
{
    partial class cargo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cargo));
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.nombre_cargo_txt = new System.Windows.Forms.TextBox();
            this.ck_estado = new System.Windows.Forms.CheckBox();
            this.codigo_cargo_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(12, 302);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(361, 55);
            this.panel2.TabIndex = 25;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button3.BackgroundImage = global::puntoVenta.Properties.Resources.map_icon;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(146, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(71, 55);
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
            this.button2.Size = new System.Drawing.Size(71, 55);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(289, 0);
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
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 133);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(362, 163);
            this.dataGridView1.TabIndex = 26;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label7.Location = new System.Drawing.Point(20, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 29);
            this.label7.TabIndex = 29;
            this.label7.Text = "Cargo";
            this.label7.UseCompatibleTextRendering = true;
            // 
            // nombre_cargo_txt
            // 
            this.nombre_cargo_txt.Location = new System.Drawing.Point(89, 62);
            this.nombre_cargo_txt.Name = "nombre_cargo_txt";
            this.nombre_cargo_txt.Size = new System.Drawing.Size(176, 20);
            this.nombre_cargo_txt.TabIndex = 30;
            // 
            // ck_estado
            // 
            this.ck_estado.AutoSize = true;
            this.ck_estado.Checked = true;
            this.ck_estado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_estado.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.ck_estado.Location = new System.Drawing.Point(89, 94);
            this.ck_estado.Name = "ck_estado";
            this.ck_estado.Size = new System.Drawing.Size(80, 28);
            this.ck_estado.TabIndex = 31;
            this.ck_estado.Text = "Activo";
            this.ck_estado.UseVisualStyleBackColor = true;
            // 
            // codigo_cargo_txt
            // 
            this.codigo_cargo_txt.Location = new System.Drawing.Point(89, 24);
            this.codigo_cargo_txt.Name = "codigo_cargo_txt";
            this.codigo_cargo_txt.ReadOnly = true;
            this.codigo_cargo_txt.Size = new System.Drawing.Size(132, 20);
            this.codigo_cargo_txt.TabIndex = 33;
            this.codigo_cargo_txt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 29);
            this.label1.TabIndex = 32;
            this.label1.Text = "Codigo";
            this.label1.UseCompatibleTextRendering = true;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::puntoVenta.Properties.Resources.save_file_disk_open_searsh_loading_clipboard_1513;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Location = new System.Drawing.Point(210, 88);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(55, 42);
            this.button4.TabIndex = 34;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button7
            // 
            this.button7.BackgroundImage = global::puntoVenta.Properties.Resources.find_icon;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.Location = new System.Drawing.Point(226, 18);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(39, 35);
            this.button7.TabIndex = 81;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // cargo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(386, 369);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.codigo_cargo_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ck_estado);
            this.Controls.Add(this.nombre_cargo_txt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "cargo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargos";
            this.Load += new System.EventHandler(this.cargo_Load);
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox nombre_cargo_txt;
        private System.Windows.Forms.CheckBox ck_estado;
        private System.Windows.Forms.TextBox codigo_cargo_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button7;
    }
}