namespace puntoVenta
{
    partial class cambiar_clave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cambiar_clave));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.clave_confirmar_txt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.clave_nueva_txt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.clave_actual_txt = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Location = new System.Drawing.Point(12, 195);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 56);
            this.panel1.TabIndex = 103;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button4.BackgroundImage = global::puntoVenta.Properties.Resources.map_icon;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Location = new System.Drawing.Point(190, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(71, 56);
            this.button4.TabIndex = 2;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::puntoVenta.Properties.Resources.edit_not_validated1;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Location = new System.Drawing.Point(0, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(71, 56);
            this.button5.TabIndex = 1;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.BackgroundImage = global::puntoVenta.Properties.Resources.save_file_disk_open_searsh_loading_clipboard_1513;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Location = new System.Drawing.Point(370, 0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(72, 56);
            this.button6.TabIndex = 0;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(125, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 45);
            this.label1.TabIndex = 111;
            this.label1.Text = "Cambiar clave";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(75, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 29);
            this.label4.TabIndex = 110;
            this.label4.Text = "Confirmar";
            this.label4.UseCompatibleTextRendering = true;
            // 
            // clave_confirmar_txt
            // 
            this.clave_confirmar_txt.Location = new System.Drawing.Point(202, 154);
            this.clave_confirmar_txt.MaxLength = 30;
            this.clave_confirmar_txt.Name = "clave_confirmar_txt";
            this.clave_confirmar_txt.PasswordChar = '*';
            this.clave_confirmar_txt.Size = new System.Drawing.Size(178, 20);
            this.clave_confirmar_txt.TabIndex = 109;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(75, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 29);
            this.label5.TabIndex = 108;
            this.label5.Text = "Clave nueva";
            this.label5.UseCompatibleTextRendering = true;
            // 
            // clave_nueva_txt
            // 
            this.clave_nueva_txt.Location = new System.Drawing.Point(202, 113);
            this.clave_nueva_txt.MaxLength = 30;
            this.clave_nueva_txt.Name = "clave_nueva_txt";
            this.clave_nueva_txt.PasswordChar = '*';
            this.clave_nueva_txt.Size = new System.Drawing.Size(178, 20);
            this.clave_nueva_txt.TabIndex = 107;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label6.Location = new System.Drawing.Point(75, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 29);
            this.label6.TabIndex = 106;
            this.label6.Text = "Clave actual";
            this.label6.UseCompatibleTextRendering = true;
            // 
            // clave_actual_txt
            // 
            this.clave_actual_txt.Location = new System.Drawing.Point(202, 70);
            this.clave_actual_txt.MaxLength = 30;
            this.clave_actual_txt.Name = "clave_actual_txt";
            this.clave_actual_txt.PasswordChar = '*';
            this.clave_actual_txt.Size = new System.Drawing.Size(178, 20);
            this.clave_actual_txt.TabIndex = 105;
            // 
            // cambiar_clave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(466, 263);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.clave_confirmar_txt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.clave_nueva_txt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.clave_actual_txt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "cambiar_clave";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambiar clave";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox clave_confirmar_txt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox clave_nueva_txt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox clave_actual_txt;
    }
}