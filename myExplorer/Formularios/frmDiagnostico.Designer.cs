namespace myExplorer.Formularios
{
    partial class frmDiagnostico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDiagnostico));
            this.tlpPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.rtxtDiagnostico = new System.Windows.Forms.RichTextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnAddPatologia = new System.Windows.Forms.Button();
            this.lblPatologia = new System.Windows.Forms.Label();
            this.cmbPatologia = new System.Windows.Forms.ComboBox();
            this.tlpPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPanel
            // 
            this.tlpPanel.ColumnCount = 6;
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.03922F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.88235F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.07843F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tlpPanel.Controls.Add(this.btnGuardar, 3, 2);
            this.tlpPanel.Controls.Add(this.btnEliminar, 4, 2);
            this.tlpPanel.Controls.Add(this.btnCerrar, 5, 2);
            this.tlpPanel.Controls.Add(this.rtxtDiagnostico, 0, 1);
            this.tlpPanel.Controls.Add(this.btnAddPatologia, 2, 0);
            this.tlpPanel.Controls.Add(this.lblPatologia, 0, 0);
            this.tlpPanel.Controls.Add(this.cmbPatologia, 1, 0);
            this.tlpPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpPanel.Location = new System.Drawing.Point(0, 0);
            this.tlpPanel.Name = "tlpPanel";
            this.tlpPanel.RowCount = 3;
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.63444F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpPanel.Size = new System.Drawing.Size(850, 391);
            this.tlpPanel.TabIndex = 0;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(597, 345);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 42);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // rtxtDiagnostico
            // 
            this.tlpPanel.SetColumnSpan(this.rtxtDiagnostico, 6);
            this.rtxtDiagnostico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtDiagnostico.Location = new System.Drawing.Point(3, 46);
            this.rtxtDiagnostico.Name = "rtxtDiagnostico";
            this.rtxtDiagnostico.Size = new System.Drawing.Size(844, 293);
            this.rtxtDiagnostico.TabIndex = 3;
            this.rtxtDiagnostico.Text = "";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(678, 345);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 42);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(760, 345);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 42);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnAddPatologia
            // 
            this.btnAddPatologia.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddPatologia.Location = new System.Drawing.Point(250, 10);
            this.btnAddPatologia.Name = "btnAddPatologia";
            this.btnAddPatologia.Size = new System.Drawing.Size(29, 23);
            this.btnAddPatologia.TabIndex = 2;
            this.btnAddPatologia.Text = "+";
            this.btnAddPatologia.UseVisualStyleBackColor = true;
            this.btnAddPatologia.Click += new System.EventHandler(this.btnAddPatologia_Click);
            // 
            // lblPatologia
            // 
            this.lblPatologia.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPatologia.AutoSize = true;
            this.lblPatologia.Location = new System.Drawing.Point(22, 15);
            this.lblPatologia.Name = "lblPatologia";
            this.lblPatologia.Size = new System.Drawing.Size(51, 13);
            this.lblPatologia.TabIndex = 0;
            this.lblPatologia.Text = "Patologia";
            // 
            // cmbPatologia
            // 
            this.cmbPatologia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPatologia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPatologia.FormattingEnabled = true;
            this.cmbPatologia.Location = new System.Drawing.Point(79, 11);
            this.cmbPatologia.Name = "cmbPatologia";
            this.cmbPatologia.Size = new System.Drawing.Size(165, 21);
            this.cmbPatologia.TabIndex = 1;
            // 
            // frmDiagnostico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 393);
            this.Controls.Add(this.tlpPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDiagnostico";
            this.Text = "Diagnostico";
            this.Load += new System.EventHandler(this.frmDiagnostico_Load);
            this.tlpPanel.ResumeLayout(false);
            this.tlpPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPanel;
        private System.Windows.Forms.RichTextBox rtxtDiagnostico;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAddPatologia;
        private System.Windows.Forms.Label lblPatologia;
        private System.Windows.Forms.ComboBox cmbPatologia;
    }
}