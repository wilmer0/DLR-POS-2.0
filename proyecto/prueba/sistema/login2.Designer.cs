namespace puntoVenta.sistema
{
    partial class login2
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.usuarioText = new System.Windows.Forms.TextBox();
            this.claveText = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(304, 5);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 274);
            this.panel1.Size = new System.Drawing.Size(445, 54);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(153, 5);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(697, 37);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 68);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(77, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(95, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Clave";
            // 
            // usuarioText
            // 
            this.usuarioText.Location = new System.Drawing.Point(154, 127);
            this.usuarioText.MaxLength = 30;
            this.usuarioText.Name = "usuarioText";
            this.usuarioText.Size = new System.Drawing.Size(224, 20);
            this.usuarioText.TabIndex = 11;
            // 
            // claveText
            // 
            this.claveText.Location = new System.Drawing.Point(154, 172);
            this.claveText.MaxLength = 30;
            this.claveText.Name = "claveText";
            this.claveText.PasswordChar = '*';
            this.claveText.Size = new System.Drawing.Size(224, 20);
            this.claveText.TabIndex = 12;
            // 
            // login2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 340);
            this.Controls.Add(this.claveText);
            this.Controls.Add(this.usuarioText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "login2";
            this.Text = "login2";
            this.Load += new System.EventHandler(this.login2_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.usuarioText, 0);
            this.Controls.SetChildIndex(this.claveText, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox usuarioText;
        private System.Windows.Forms.TextBox claveText;
    }
}