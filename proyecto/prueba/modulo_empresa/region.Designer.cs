﻿namespace puntoVenta
{
    partial class region
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(region));
            this.ck_estado = new System.Windows.Forms.CheckBox();
            this.nombre_region_nueva_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.codigo_region_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.region_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.codigo_pais_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nombre_pais_txt = new System.Windows.Forms.TextBox();
            this.pais_btn = new System.Windows.Forms.Button();
            this.nombre_region_txt = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ck_estado
            // 
            this.ck_estado.AutoSize = true;
            this.ck_estado.Checked = true;
            this.ck_estado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_estado.ForeColor = System.Drawing.Color.Black;
            this.ck_estado.Location = new System.Drawing.Point(376, 187);
            this.ck_estado.Name = "ck_estado";
            this.ck_estado.Size = new System.Drawing.Size(80, 28);
            this.ck_estado.TabIndex = 50;
            this.ck_estado.Text = "Activo";
            this.ck_estado.UseVisualStyleBackColor = true;
            // 
            // nombre_region_nueva_txt
            // 
            this.nombre_region_nueva_txt.Location = new System.Drawing.Point(455, 147);
            this.nombre_region_nueva_txt.Name = "nombre_region_nueva_txt";
            this.nombre_region_nueva_txt.Size = new System.Drawing.Size(164, 20);
            this.nombre_region_nueva_txt.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(376, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 29);
            this.label3.TabIndex = 48;
            this.label3.Text = "Region";
            this.label3.UseCompatibleTextRendering = true;
            // 
            // codigo_region_txt
            // 
            this.codigo_region_txt.Location = new System.Drawing.Point(455, 89);
            this.codigo_region_txt.Name = "codigo_region_txt";
            this.codigo_region_txt.ReadOnly = true;
            this.codigo_region_txt.Size = new System.Drawing.Size(77, 20);
            this.codigo_region_txt.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(376, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 29);
            this.label2.TabIndex = 46;
            this.label2.Text = "Codigo";
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 53);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(340, 196);
            this.dataGridView1.TabIndex = 45;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // region_txt
            // 
            this.region_txt.Location = new System.Drawing.Point(88, 30);
            this.region_txt.Name = "region_txt";
            this.region_txt.Size = new System.Drawing.Size(261, 20);
            this.region_txt.TabIndex = 44;
            this.region_txt.TextChanged += new System.EventHandler(this.pais_txt_TextChanged);
            this.region_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.region_txt_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(11, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 29);
            this.label1.TabIndex = 43;
            this.label1.Text = "Region";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(13, 259);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(604, 55);
            this.panel2.TabIndex = 42;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button3.BackgroundImage = global::puntoVenta.Properties.Resources.map_icon;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(268, 0);
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
            this.button1.Location = new System.Drawing.Point(532, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 55);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::puntoVenta.Properties.Resources.save_file_disk_open_searsh_loading_clipboard_1513;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Location = new System.Drawing.Point(455, 187);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(77, 50);
            this.button5.TabIndex = 62;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // codigo_pais_txt
            // 
            this.codigo_pais_txt.Location = new System.Drawing.Point(455, 35);
            this.codigo_pais_txt.Name = "codigo_pais_txt";
            this.codigo_pais_txt.ReadOnly = true;
            this.codigo_pais_txt.Size = new System.Drawing.Size(77, 20);
            this.codigo_pais_txt.TabIndex = 64;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(376, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 29);
            this.label4.TabIndex = 63;
            this.label4.Text = "Pais";
            this.label4.UseCompatibleTextRendering = true;
            // 
            // nombre_pais_txt
            // 
            this.nombre_pais_txt.Location = new System.Drawing.Point(455, 58);
            this.nombre_pais_txt.Name = "nombre_pais_txt";
            this.nombre_pais_txt.ReadOnly = true;
            this.nombre_pais_txt.Size = new System.Drawing.Size(162, 20);
            this.nombre_pais_txt.TabIndex = 65;
            // 
            // pais_btn
            // 
            this.pais_btn.BackgroundImage = global::puntoVenta.Properties.Resources.find_icon;
            this.pais_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pais_btn.Location = new System.Drawing.Point(545, 26);
            this.pais_btn.Name = "pais_btn";
            this.pais_btn.Size = new System.Drawing.Size(41, 29);
            this.pais_btn.TabIndex = 66;
            this.pais_btn.UseVisualStyleBackColor = true;
            this.pais_btn.Click += new System.EventHandler(this.pais_btn_Click);
            // 
            // nombre_region_txt
            // 
            this.nombre_region_txt.Location = new System.Drawing.Point(456, 112);
            this.nombre_region_txt.Name = "nombre_region_txt";
            this.nombre_region_txt.ReadOnly = true;
            this.nombre_region_txt.Size = new System.Drawing.Size(161, 20);
            this.nombre_region_txt.TabIndex = 67;
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::puntoVenta.Properties.Resources.find_icon;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Location = new System.Drawing.Point(545, 80);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(41, 29);
            this.button4.TabIndex = 68;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // region
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(629, 326);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.nombre_region_txt);
            this.Controls.Add(this.pais_btn);
            this.Controls.Add(this.nombre_pais_txt);
            this.Controls.Add(this.codigo_pais_txt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.ck_estado);
            this.Controls.Add(this.nombre_region_nueva_txt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.codigo_region_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.region_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "region";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Region";
            this.Load += new System.EventHandler(this.region_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ck_estado;
        private System.Windows.Forms.TextBox nombre_region_nueva_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox codigo_region_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox region_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox codigo_pais_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nombre_pais_txt;
        private System.Windows.Forms.Button pais_btn;
        private System.Windows.Forms.TextBox nombre_region_txt;
        private System.Windows.Forms.Button button4;
    }
}