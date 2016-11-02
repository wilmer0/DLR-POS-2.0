namespace puntoVenta
{
    partial class caja_egresos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(caja_egresos));
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.nombre_cajero_txt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.codigo_cajero_txt = new System.Windows.Forms.TextBox();
            this.detalles_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nombre_concepto_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.codigo_concepto_txt = new System.Windows.Forms.TextBox();
            this.ck_afecta_cuadre = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.monto_egreso_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Location = new System.Drawing.Point(12, 369);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(577, 54);
            this.panel2.TabIndex = 113;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button1.BackgroundImage = global::puntoVenta.Properties.Resources.map_icon;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(254, 0);
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
            this.button7.Location = new System.Drawing.Point(505, 0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(72, 54);
            this.button7.TabIndex = 0;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // nombre_cajero_txt
            // 
            this.nombre_cajero_txt.Location = new System.Drawing.Point(94, 56);
            this.nombre_cajero_txt.Name = "nombre_cajero_txt";
            this.nombre_cajero_txt.ReadOnly = true;
            this.nombre_cajero_txt.Size = new System.Drawing.Size(175, 20);
            this.nombre_cajero_txt.TabIndex = 120;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(12, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 24);
            this.label7.TabIndex = 119;
            this.label7.Text = "Cajero";
            this.label7.UseCompatibleTextRendering = true;
            // 
            // codigo_cajero_txt
            // 
            this.codigo_cajero_txt.Location = new System.Drawing.Point(94, 33);
            this.codigo_cajero_txt.Name = "codigo_cajero_txt";
            this.codigo_cajero_txt.ReadOnly = true;
            this.codigo_cajero_txt.Size = new System.Drawing.Size(135, 20);
            this.codigo_cajero_txt.TabIndex = 118;
            // 
            // detalles_txt
            // 
            this.detalles_txt.Location = new System.Drawing.Point(12, 236);
            this.detalles_txt.MaxLength = 500;
            this.detalles_txt.Multiline = true;
            this.detalles_txt.Name = "detalles_txt";
            this.detalles_txt.Size = new System.Drawing.Size(577, 123);
            this.detalles_txt.TabIndex = 121;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 24);
            this.label1.TabIndex = 122;
            this.label1.Text = "Detalles";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // nombre_concepto_txt
            // 
            this.nombre_concepto_txt.Location = new System.Drawing.Point(94, 115);
            this.nombre_concepto_txt.Name = "nombre_concepto_txt";
            this.nombre_concepto_txt.ReadOnly = true;
            this.nombre_concepto_txt.Size = new System.Drawing.Size(175, 20);
            this.nombre_concepto_txt.TabIndex = 126;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 24);
            this.label2.TabIndex = 125;
            this.label2.Text = "Concepto";
            this.label2.UseCompatibleTextRendering = true;
            // 
            // codigo_concepto_txt
            // 
            this.codigo_concepto_txt.Location = new System.Drawing.Point(94, 92);
            this.codigo_concepto_txt.Name = "codigo_concepto_txt";
            this.codigo_concepto_txt.ReadOnly = true;
            this.codigo_concepto_txt.Size = new System.Drawing.Size(135, 20);
            this.codigo_concepto_txt.TabIndex = 124;
            // 
            // ck_afecta_cuadre
            // 
            this.ck_afecta_cuadre.AutoSize = true;
            this.ck_afecta_cuadre.Checked = true;
            this.ck_afecta_cuadre.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_afecta_cuadre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_afecta_cuadre.ForeColor = System.Drawing.Color.Black;
            this.ck_afecta_cuadre.Location = new System.Drawing.Point(94, 141);
            this.ck_afecta_cuadre.Name = "ck_afecta_cuadre";
            this.ck_afecta_cuadre.Size = new System.Drawing.Size(231, 28);
            this.ck_afecta_cuadre.TabIndex = 127;
            this.ck_afecta_cuadre.Text = "Afecta el cuadre de caja";
            this.ck_afecta_cuadre.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(235, 82);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 30);
            this.button2.TabIndex = 123;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Transparent;
            this.button11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button11.BackgroundImage")));
            this.button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button11.Location = new System.Drawing.Point(235, 23);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(34, 30);
            this.button11.TabIndex = 117;
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // fecha
            // 
            this.fecha.Enabled = false;
            this.fecha.Location = new System.Drawing.Point(389, 12);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(200, 20);
            this.fecha.TabIndex = 128;
            // 
            // monto_egreso_txt
            // 
            this.monto_egreso_txt.Location = new System.Drawing.Point(94, 176);
            this.monto_egreso_txt.Name = "monto_egreso_txt";
            this.monto_egreso_txt.Size = new System.Drawing.Size(100, 20);
            this.monto_egreso_txt.TabIndex = 129;
            this.monto_egreso_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.monto_egreso_txt_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 24);
            this.label3.TabIndex = 130;
            this.label3.Text = "Monto";
            this.label3.UseCompatibleTextRendering = true;
            // 
            // caja_egresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(601, 435);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.monto_egreso_txt);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.ck_afecta_cuadre);
            this.Controls.Add(this.nombre_concepto_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.codigo_concepto_txt);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.detalles_txt);
            this.Controls.Add(this.nombre_cajero_txt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.codigo_cajero_txt);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "caja_egresos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Egresos de caja";
            this.Load += new System.EventHandler(this.caja_egresos_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox nombre_cajero_txt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox codigo_cajero_txt;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.TextBox detalles_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nombre_concepto_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox codigo_concepto_txt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox ck_afecta_cuadre;
        private System.Windows.Forms.DateTimePicker fecha;
        private System.Windows.Forms.TextBox monto_egreso_txt;
        private System.Windows.Forms.Label label3;
    }
}