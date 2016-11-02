namespace puntoVenta
{
    partial class prestamo
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.monto_txt = new System.Windows.Forms.TextBox();
            this.tasa_txt = new System.Windows.Forms.TextBox();
            this.meses_txt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amortizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.interes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Monto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tasa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(288, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "meses";
            // 
            // monto_txt
            // 
            this.monto_txt.Location = new System.Drawing.Point(90, 38);
            this.monto_txt.Name = "monto_txt";
            this.monto_txt.Size = new System.Drawing.Size(100, 20);
            this.monto_txt.TabIndex = 4;
            this.monto_txt.Text = "1000";
            // 
            // tasa_txt
            // 
            this.tasa_txt.Location = new System.Drawing.Point(90, 91);
            this.tasa_txt.Name = "tasa_txt";
            this.tasa_txt.Size = new System.Drawing.Size(100, 20);
            this.tasa_txt.TabIndex = 5;
            this.tasa_txt.Text = "4";
            // 
            // meses_txt
            // 
            this.meses_txt.Location = new System.Drawing.Point(331, 38);
            this.meses_txt.Name = "meses_txt";
            this.meses_txt.Size = new System.Drawing.Size(100, 20);
            this.meses_txt.TabIndex = 6;
            this.meses_txt.Text = "5";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(291, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 88);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.saldo,
            this.amortizacion,
            this.interes,
            this.cuota});
            this.dataGridView1.Location = new System.Drawing.Point(49, 158);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(545, 334);
            this.dataGridView1.TabIndex = 10;
            // 
            // codigo
            // 
            this.codigo.HeaderText = "codigo";
            this.codigo.Name = "codigo";
            // 
            // saldo
            // 
            this.saldo.HeaderText = "Saldo";
            this.saldo.Name = "saldo";
            // 
            // amortizacion
            // 
            this.amortizacion.HeaderText = "Amortizacion";
            this.amortizacion.Name = "amortizacion";
            // 
            // interes
            // 
            this.interes.HeaderText = "Interes";
            this.interes.Name = "interes";
            // 
            // cuota
            // 
            this.cuota.HeaderText = "Cuota";
            this.cuota.Name = "cuota";
            // 
            // prestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 569);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.meses_txt);
            this.Controls.Add(this.tasa_txt);
            this.Controls.Add(this.monto_txt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "prestamo";
            this.Text = "prestamo";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox monto_txt;
        private System.Windows.Forms.TextBox tasa_txt;
        private System.Windows.Forms.TextBox meses_txt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn amortizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn interes;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuota;
    }
}