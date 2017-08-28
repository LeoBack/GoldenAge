namespace myExplorer.Formularios
{
    partial class frmDialogoImprecion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDialogoImprecion));
            this.tlpPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.rbtPacientesAtendidosXOS = new System.Windows.Forms.RadioButton();
            this.rbtTodosLosPacientes = new System.Windows.Forms.RadioButton();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.tlpPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPanel
            // 
            this.tlpPanel.ColumnCount = 2;
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.64368F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.35632F));
            this.tlpPanel.Controls.Add(this.lblHasta, 0, 3);
            this.tlpPanel.Controls.Add(this.lblDesde, 0, 2);
            this.tlpPanel.Controls.Add(this.rbtPacientesAtendidosXOS, 1, 0);
            this.tlpPanel.Controls.Add(this.rbtTodosLosPacientes, 1, 1);
            this.tlpPanel.Controls.Add(this.dtpDesde, 1, 2);
            this.tlpPanel.Controls.Add(this.dtpHasta, 1, 3);
            this.tlpPanel.Controls.Add(this.btnImprimir, 1, 4);
            this.tlpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPanel.Location = new System.Drawing.Point(0, 0);
            this.tlpPanel.Name = "tlpPanel";
            this.tlpPanel.RowCount = 5;
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tlpPanel.Size = new System.Drawing.Size(435, 202);
            this.tlpPanel.TabIndex = 0;
            // 
            // lblHasta
            // 
            this.lblHasta.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(17, 132);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(35, 13);
            this.lblHasta.TabIndex = 1;
            this.lblHasta.Text = "Hasta";
            // 
            // lblDesde
            // 
            this.lblDesde.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(14, 89);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(38, 13);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "Desde";
            // 
            // rbtPacientesAtendidosXOS
            // 
            this.rbtPacientesAtendidosXOS.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtPacientesAtendidosXOS.AutoSize = true;
            this.rbtPacientesAtendidosXOS.Location = new System.Drawing.Point(58, 9);
            this.rbtPacientesAtendidosXOS.Name = "rbtPacientesAtendidosXOS";
            this.rbtPacientesAtendidosXOS.Size = new System.Drawing.Size(193, 17);
            this.rbtPacientesAtendidosXOS.TabIndex = 5;
            this.rbtPacientesAtendidosXOS.TabStop = true;
            this.rbtPacientesAtendidosXOS.Text = "Pacientes atendidos por obra social";
            this.rbtPacientesAtendidosXOS.UseVisualStyleBackColor = true;
            // 
            // rbtTodosLosPacientes
            // 
            this.rbtTodosLosPacientes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtTodosLosPacientes.AutoSize = true;
            this.rbtTodosLosPacientes.Location = new System.Drawing.Point(58, 47);
            this.rbtTodosLosPacientes.Name = "rbtTodosLosPacientes";
            this.rbtTodosLosPacientes.Size = new System.Drawing.Size(198, 17);
            this.rbtTodosLosPacientes.TabIndex = 6;
            this.rbtTodosLosPacientes.TabStop = true;
            this.rbtTodosLosPacientes.Text = "Todos Los pacietes de la obra social";
            this.rbtTodosLosPacientes.UseVisualStyleBackColor = true;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpDesde.Location = new System.Drawing.Point(58, 85);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpDesde.TabIndex = 3;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpHasta.Location = new System.Drawing.Point(58, 128);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpHasta.TabIndex = 2;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.Location = new System.Drawing.Point(357, 164);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 28);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // frmDialogoImprecion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 202);
            this.Controls.Add(this.tlpPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(451, 240);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(451, 240);
            this.Name = "frmDialogoImprecion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dialogo de Imprecion";
            this.Load += new System.EventHandler(this.frmDialogoImprecion_Load);
            this.tlpPanel.ResumeLayout(false);
            this.tlpPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPanel;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.RadioButton rbtPacientesAtendidosXOS;
        private System.Windows.Forms.RadioButton rbtTodosLosPacientes;
    }
}