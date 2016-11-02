namespace puntoVenta
{
    partial class host
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(host));
            this.usuario_lbl = new System.Windows.Forms.Label();
            this.ip_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.usuario_base_datos_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.clave_dba_txt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.base_de_datos_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fecha_vencimiento = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // usuario_lbl
            // 
            this.usuario_lbl.AutoSize = true;
            this.usuario_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuario_lbl.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.usuario_lbl.Location = new System.Drawing.Point(12, 28);
            this.usuario_lbl.Name = "usuario_lbl";
            this.usuario_lbl.Size = new System.Drawing.Size(96, 20);
            this.usuario_lbl.TabIndex = 13;
            this.usuario_lbl.Text = "IP SERVER";
            // 
            // ip_txt
            // 
            this.ip_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ip_txt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ip_txt.Location = new System.Drawing.Point(142, 28);
            this.ip_txt.MaxLength = 20;
            this.ip_txt.Name = "ip_txt";
            this.ip_txt.Size = new System.Drawing.Size(160, 26);
            this.ip_txt.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.Location = new System.Drawing.Point(14, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "USER DBA";
            // 
            // usuario_base_datos_txt
            // 
            this.usuario_base_datos_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuario_base_datos_txt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.usuario_base_datos_txt.Location = new System.Drawing.Point(142, 115);
            this.usuario_base_datos_txt.MaxLength = 20;
            this.usuario_base_datos_txt.Name = "usuario_base_datos_txt";
            this.usuario_base_datos_txt.Size = new System.Drawing.Size(160, 26);
            this.usuario_base_datos_txt.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label2.Location = new System.Drawing.Point(16, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "PASSWORD";
            // 
            // clave_dba_txt
            // 
            this.clave_dba_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clave_dba_txt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.clave_dba_txt.Location = new System.Drawing.Point(142, 160);
            this.clave_dba_txt.MaxLength = 20;
            this.clave_dba_txt.Name = "clave_dba_txt";
            this.clave_dba_txt.PasswordChar = '*';
            this.clave_dba_txt.Size = new System.Drawing.Size(160, 26);
            this.clave_dba_txt.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(253, 432);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 49);
            this.button1.TabIndex = 18;
            this.button1.Text = "PUNCH ME";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label3.Location = new System.Drawing.Point(14, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "DBA";
            // 
            // base_de_datos_txt
            // 
            this.base_de_datos_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.base_de_datos_txt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.base_de_datos_txt.Location = new System.Drawing.Point(142, 71);
            this.base_de_datos_txt.MaxLength = 20;
            this.base_de_datos_txt.Name = "base_de_datos_txt";
            this.base_de_datos_txt.Size = new System.Drawing.Size(160, 26);
            this.base_de_datos_txt.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label4.Location = new System.Drawing.Point(6, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Fec. venc";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.fecha_vencimiento);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 215);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(349, 211);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones";
            // 
            // fecha_vencimiento
            // 
            this.fecha_vencimiento.Location = new System.Drawing.Point(130, 30);
            this.fecha_vencimiento.Name = "fecha_vencimiento";
            this.fecha_vencimiento.Size = new System.Drawing.Size(177, 20);
            this.fecha_vencimiento.TabIndex = 22;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(282, 180);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 25);
            this.button2.TabIndex = 23;
            this.button2.Text = "update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // host
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(373, 493);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.base_de_datos_txt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.clave_dba_txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usuario_base_datos_txt);
            this.Controls.Add(this.usuario_lbl);
            this.Controls.Add(this.ip_txt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "host";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.host_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usuario_lbl;
        private System.Windows.Forms.TextBox ip_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox usuario_base_datos_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox clave_dba_txt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox base_de_datos_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker fecha_vencimiento;
        private System.Windows.Forms.Button button2;
    }
}