namespace puntoVenta
{
    partial class comprobante_serie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(comprobante_serie));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.codigo_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nombre_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ck_activo = new System.Windows.Forms.CheckBox();
            this.serie_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(12, 172);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(483, 141);
            this.dataGridView1.TabIndex = 55;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Location = new System.Drawing.Point(12, 328);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(483, 54);
            this.panel2.TabIndex = 96;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button1.BackgroundImage = global::puntoVenta.Properties.Resources.map_icon;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(213, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 54);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.button7.BackgroundImage = global::puntoVenta.Properties.Resources.save_file_disk_open_searsh_loading_clipboard_15131;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.Dock = System.Windows.Forms.DockStyle.Right;
            this.button7.Location = new System.Drawing.Point(411, 0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(72, 54);
            this.button7.TabIndex = 0;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // codigo_txt
            // 
            this.codigo_txt.Location = new System.Drawing.Point(161, 27);
            this.codigo_txt.Name = "codigo_txt";
            this.codigo_txt.ReadOnly = true;
            this.codigo_txt.Size = new System.Drawing.Size(57, 20);
            this.codigo_txt.TabIndex = 104;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(82, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 29);
            this.label4.TabIndex = 103;
            this.label4.Text = "Codigo";
            this.label4.UseCompatibleTextRendering = true;
            // 
            // nombre_txt
            // 
            this.nombre_txt.Location = new System.Drawing.Point(161, 95);
            this.nombre_txt.MaxLength = 50;
            this.nombre_txt.Name = "nombre_txt";
            this.nombre_txt.Size = new System.Drawing.Size(204, 20);
            this.nombre_txt.TabIndex = 106;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(82, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 29);
            this.label1.TabIndex = 105;
            this.label1.Text = "Nombre";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // ck_activo
            // 
            this.ck_activo.AutoSize = true;
            this.ck_activo.Checked = true;
            this.ck_activo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_activo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_activo.ForeColor = System.Drawing.Color.Black;
            this.ck_activo.Location = new System.Drawing.Point(161, 124);
            this.ck_activo.Name = "ck_activo";
            this.ck_activo.Size = new System.Drawing.Size(80, 28);
            this.ck_activo.TabIndex = 107;
            this.ck_activo.Text = "Activo";
            this.ck_activo.UseVisualStyleBackColor = true;
            // 
            // serie_txt
            // 
            this.serie_txt.Location = new System.Drawing.Point(161, 61);
            this.serie_txt.MaxLength = 1;
            this.serie_txt.Name = "serie_txt";
            this.serie_txt.Size = new System.Drawing.Size(120, 20);
            this.serie_txt.TabIndex = 109;
            this.serie_txt.TextChanged += new System.EventHandler(this.serie_txt_TextChanged);
            this.serie_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.serie_txt_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(82, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 29);
            this.label2.TabIndex = 108;
            this.label2.Text = "Serie";
            this.label2.UseCompatibleTextRendering = true;
            // 
            // comprobante_serie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(507, 394);
            this.Controls.Add(this.serie_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ck_activo);
            this.Controls.Add(this.nombre_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.codigo_txt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "comprobante_serie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comprobante Serie";
            this.Load += new System.EventHandler(this.comprobante_serie_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox codigo_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nombre_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ck_activo;
        private System.Windows.Forms.TextBox serie_txt;
        private System.Windows.Forms.Label label2;
    }
}