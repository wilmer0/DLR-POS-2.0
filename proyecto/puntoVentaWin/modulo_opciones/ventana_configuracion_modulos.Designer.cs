﻿namespace puntoVentaWin.modulo_opciones
{
    partial class ventana_configuracion_modulos
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.moduloCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ventanaCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridViewVentanasGuardar = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVentanasGuardar)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(695, 5);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 563);
            this.panel1.Size = new System.Drawing.Size(836, 54);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(349, 5);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(1088, 37);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.moduloCombo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 65);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Módulos";
            // 
            // moduloCombo
            // 
            this.moduloCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.moduloCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moduloCombo.FormattingEnabled = true;
            this.moduloCombo.Location = new System.Drawing.Point(90, 23);
            this.moduloCombo.Name = "moduloCombo";
            this.moduloCombo.Size = new System.Drawing.Size(304, 24);
            this.moduloCombo.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Módulo";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ventanaCombo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(444, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(404, 65);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ventanas";
            // 
            // ventanaCombo
            // 
            this.ventanaCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ventanaCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ventanaCombo.FormattingEnabled = true;
            this.ventanaCombo.Location = new System.Drawing.Point(89, 23);
            this.ventanaCombo.Name = "ventanaCombo";
            this.ventanaCombo.Size = new System.Drawing.Size(304, 24);
            this.ventanaCombo.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ventana";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.DodgerBlue;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(707, 114);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(138, 42);
            this.button4.TabIndex = 15;
            this.button4.Text = "Agregar";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridViewVentanasGuardar
            // 
            this.dataGridViewVentanasGuardar.AllowUserToAddRows = false;
            this.dataGridViewVentanasGuardar.AllowUserToDeleteRows = false;
            this.dataGridViewVentanasGuardar.AllowUserToResizeColumns = false;
            this.dataGridViewVentanasGuardar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewVentanasGuardar.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewVentanasGuardar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVentanasGuardar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.Column3});
            this.dataGridViewVentanasGuardar.Location = new System.Drawing.Point(16, 162);
            this.dataGridViewVentanasGuardar.MultiSelect = false;
            this.dataGridViewVentanasGuardar.Name = "dataGridViewVentanasGuardar";
            this.dataGridViewVentanasGuardar.ReadOnly = true;
            this.dataGridViewVentanasGuardar.RowHeadersVisible = false;
            this.dataGridViewVentanasGuardar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewVentanasGuardar.Size = new System.Drawing.Size(832, 395);
            this.dataGridViewVentanasGuardar.TabIndex = 16;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Módulo";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Ventana";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(211, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Lista módulos y ventanas";
            // 
            // ventana_configuracion_modulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 629);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewVentanasGuardar);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ventana_configuracion_modulos";
            this.Text = "ventana_configuracion_modulos";
            this.Load += new System.EventHandler(this.ventana_configuracion_modulos_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.button4, 0);
            this.Controls.SetChildIndex(this.dataGridViewVentanasGuardar, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVentanasGuardar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridViewVentanasGuardar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ComboBox moduloCombo;
        private System.Windows.Forms.ComboBox ventanaCombo;
    }
}