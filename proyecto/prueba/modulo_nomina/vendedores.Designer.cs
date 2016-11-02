namespace puntoVenta
{
    partial class vendedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(vendedores));
            this.nombre_empleado_txt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.codigo_empleado_txt = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.porciento_txt = new System.Windows.Forms.TextBox();
            this.ck_activo = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button11 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // nombre_empleado_txt
            // 
            this.nombre_empleado_txt.Location = new System.Drawing.Point(117, 52);
            this.nombre_empleado_txt.Name = "nombre_empleado_txt";
            this.nombre_empleado_txt.ReadOnly = true;
            this.nombre_empleado_txt.Size = new System.Drawing.Size(193, 20);
            this.nombre_empleado_txt.TabIndex = 116;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label7.Location = new System.Drawing.Point(15, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 29);
            this.label7.TabIndex = 115;
            this.label7.Text = "Empleado";
            this.label7.UseCompatibleTextRendering = true;
            // 
            // codigo_empleado_txt
            // 
            this.codigo_empleado_txt.Location = new System.Drawing.Point(117, 29);
            this.codigo_empleado_txt.Name = "codigo_empleado_txt";
            this.codigo_empleado_txt.ReadOnly = true;
            this.codigo_empleado_txt.Size = new System.Drawing.Size(135, 20);
            this.codigo_empleado_txt.TabIndex = 114;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Location = new System.Drawing.Point(12, 309);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(567, 54);
            this.panel2.TabIndex = 112;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button1.BackgroundImage = global::puntoVenta.Properties.Resources.map_icon;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(249, 0);
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
            this.button7.Location = new System.Drawing.Point(495, 0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(72, 54);
            this.button7.TabIndex = 0;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.Location = new System.Drawing.Point(15, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 29);
            this.label1.TabIndex = 123;
            this.label1.Text = "Porciento";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // porciento_txt
            // 
            this.porciento_txt.Location = new System.Drawing.Point(117, 93);
            this.porciento_txt.MaxLength = 4;
            this.porciento_txt.Name = "porciento_txt";
            this.porciento_txt.Size = new System.Drawing.Size(100, 20);
            this.porciento_txt.TabIndex = 124;
            this.porciento_txt.Text = "0.0";
            this.porciento_txt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.porciento_txt_KeyUp);
            // 
            // ck_activo
            // 
            this.ck_activo.AutoSize = true;
            this.ck_activo.Checked = true;
            this.ck_activo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_activo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_activo.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.ck_activo.Location = new System.Drawing.Point(117, 128);
            this.ck_activo.Name = "ck_activo";
            this.ck_activo.Size = new System.Drawing.Size(80, 28);
            this.ck_activo.TabIndex = 125;
            this.ck_activo.Text = "Activo";
            this.ck_activo.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::puntoVenta.Properties.Resources.B;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(350, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 154);
            this.panel1.TabIndex = 122;
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Transparent;
            this.button11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button11.BackgroundImage")));
            this.button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button11.Location = new System.Drawing.Point(276, 19);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(34, 30);
            this.button11.TabIndex = 113;
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // vendedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(591, 375);
            this.Controls.Add(this.ck_activo);
            this.Controls.Add(this.porciento_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.nombre_empleado_txt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.codigo_empleado_txt);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "vendedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vendedores";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox nombre_empleado_txt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox codigo_empleado_txt;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox porciento_txt;
        private System.Windows.Forms.CheckBox ck_activo;
    }
}