﻿namespace puntoVenta
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.usuarioText = new System.Windows.Forms.TextBox();
            this.labelClave = new System.Windows.Forms.Label();
            this.claveText = new System.Windows.Forms.TextBox();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.labelInicioSesion = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.espanolRadioButton = new System.Windows.Forms.RadioButton();
            this.inglesRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.SalirPanel = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // usuarioText
            // 
            this.usuarioText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuarioText.ForeColor = System.Drawing.SystemColors.WindowText;
            this.usuarioText.Location = new System.Drawing.Point(127, 28);
            this.usuarioText.MaxLength = 20;
            this.usuarioText.Name = "usuarioText";
            this.usuarioText.Size = new System.Drawing.Size(225, 26);
            this.usuarioText.TabIndex = 1;
            this.usuarioText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.usuarioText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.usuario_KeyDown);
            this.usuarioText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.usuario_KeyUp);
            // 
            // labelClave
            // 
            this.labelClave.AutoSize = true;
            this.labelClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClave.ForeColor = System.Drawing.Color.Black;
            this.labelClave.Location = new System.Drawing.Point(12, 69);
            this.labelClave.Name = "labelClave";
            this.labelClave.Size = new System.Drawing.Size(109, 25);
            this.labelClave.TabIndex = 2;
            this.labelClave.Text = "contraseña";
            // 
            // claveText
            // 
            this.claveText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.claveText.Location = new System.Drawing.Point(127, 70);
            this.claveText.MaxLength = 20;
            this.claveText.Name = "claveText";
            this.claveText.PasswordChar = '*';
            this.claveText.Size = new System.Drawing.Size(225, 26);
            this.claveText.TabIndex = 3;
            this.claveText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clave_KeyDown);
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsuario.ForeColor = System.Drawing.Color.Black;
            this.labelUsuario.Location = new System.Drawing.Point(45, 27);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(76, 25);
            this.labelUsuario.TabIndex = 11;
            this.labelUsuario.Text = "usuario";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.ForestGreen;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.Location = new System.Drawing.Point(298, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 32);
            this.button3.TabIndex = 16;
            this.button3.Text = "HOST";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // labelInicioSesion
            // 
            this.labelInicioSesion.AutoSize = true;
            this.labelInicioSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInicioSesion.ForeColor = System.Drawing.Color.Black;
            this.labelInicioSesion.Location = new System.Drawing.Point(125, 81);
            this.labelInicioSesion.Name = "labelInicioSesion";
            this.labelInicioSesion.Size = new System.Drawing.Size(201, 31);
            this.labelInicioSesion.TabIndex = 19;
            this.labelInicioSesion.Text = "Inicio de sesión";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.labelInicioSesion);
            this.panel2.Location = new System.Drawing.Point(0, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(431, 307);
            this.panel2.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.labelUsuario);
            this.groupBox2.Controls.Add(this.labelClave);
            this.groupBox2.Controls.Add(this.usuarioText);
            this.groupBox2.Controls.Add(this.claveText);
            this.groupBox2.Location = new System.Drawing.Point(12, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(407, 110);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.espanolRadioButton);
            this.groupBox1.Controls.Add(this.inglesRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 237);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 58);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // espanolRadioButton
            // 
            this.espanolRadioButton.AutoSize = true;
            this.espanolRadioButton.Checked = true;
            this.espanolRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.espanolRadioButton.Location = new System.Drawing.Point(6, 19);
            this.espanolRadioButton.Name = "espanolRadioButton";
            this.espanolRadioButton.Size = new System.Drawing.Size(76, 21);
            this.espanolRadioButton.TabIndex = 21;
            this.espanolRadioButton.TabStop = true;
            this.espanolRadioButton.Text = "español";
            this.espanolRadioButton.UseVisualStyleBackColor = true;
            this.espanolRadioButton.Click += new System.EventHandler(this.espanolRadioButton_Click);
            // 
            // inglesRadioButton
            // 
            this.inglesRadioButton.AutoSize = true;
            this.inglesRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inglesRadioButton.Location = new System.Drawing.Point(330, 19);
            this.inglesRadioButton.Name = "inglesRadioButton";
            this.inglesRadioButton.Size = new System.Drawing.Size(71, 21);
            this.inglesRadioButton.TabIndex = 22;
            this.inglesRadioButton.Text = "english";
            this.inglesRadioButton.UseVisualStyleBackColor = true;
            this.inglesRadioButton.Click += new System.EventHandler(this.espanolRadioButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(93, 85);
            this.panel1.TabIndex = 7;
            // 
            // LoginPanel
            // 
            this.LoginPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LoginPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LoginPanel.BackgroundImage")));
            this.LoginPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LoginPanel.Location = new System.Drawing.Point(357, 315);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(62, 49);
            this.LoginPanel.TabIndex = 17;
            this.LoginPanel.Click += new System.EventHandler(this.panel6_Click);
            this.LoginPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.LoginPanel_Paint);
            // 
            // SalirPanel
            // 
            this.SalirPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SalirPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SalirPanel.BackgroundImage")));
            this.SalirPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SalirPanel.Location = new System.Drawing.Point(12, 315);
            this.SalirPanel.Name = "SalirPanel";
            this.SalirPanel.Size = new System.Drawing.Size(62, 49);
            this.SalirPanel.TabIndex = 18;
            this.SalirPanel.Click += new System.EventHandler(this.panel7_Click);
            this.SalirPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.SalirPanel_Paint);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(431, 367);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.LoginPanel);
            this.Controls.Add(this.SalirPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.login_FormClosing);
            this.Load += new System.EventHandler(this.login_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.login_KeyUp);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox usuarioText;
        private System.Windows.Forms.Label labelClave;
        private System.Windows.Forms.TextBox claveText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel LoginPanel;
        private System.Windows.Forms.Panel SalirPanel;
        private System.Windows.Forms.Label labelInicioSesion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton inglesRadioButton;
        private System.Windows.Forms.RadioButton espanolRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}