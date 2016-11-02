namespace prueba
{
    partial class padre
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
            this.txt_padre = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ck_estado = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_padre
            // 
            this.txt_padre.Location = new System.Drawing.Point(34, 57);
            this.txt_padre.Name = "txt_padre";
            this.txt_padre.Size = new System.Drawing.Size(377, 20);
            this.txt_padre.TabIndex = 0;
            this.txt_padre.TextChanged += new System.EventHandler(this.txt_padre_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(183, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ck_estado
            // 
            this.ck_estado.AutoSize = true;
            this.ck_estado.Location = new System.Drawing.Point(34, 104);
            this.ck_estado.Name = "ck_estado";
            this.ck_estado.Size = new System.Drawing.Size(58, 17);
            this.ck_estado.TabIndex = 2;
            this.ck_estado.Text = "estado";
            this.ck_estado.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 184);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(454, 150);
            this.dataGridView1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 353);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // padre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(478, 398);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ck_estado);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_padre);
            this.Name = "padre";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.padre_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox txt_padre;
        private System.Windows.Forms.CheckBox ck_estado;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
    }
}

