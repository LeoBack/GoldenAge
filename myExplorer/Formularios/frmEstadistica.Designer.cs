namespace myExplorer.Formularios
{
    partial class frmEstadistica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEstadistica));
            this.tlpPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.tlpFiltro = new System.Windows.Forms.TableLayoutPanel();
            this.likMensual = new System.Windows.Forms.LinkLabel();
            this.likAnual = new System.Windows.Forms.LinkLabel();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.grpFiltro = new System.Windows.Forms.GroupBox();
            this.tlpInforme = new System.Windows.Forms.TableLayoutPanel();
            this.rbtPaciente = new System.Windows.Forms.RadioButton();
            this.rbtDiagnostico = new System.Windows.Forms.RadioButton();
            this.rbtObraSocial = new System.Windows.Forms.RadioButton();
            this.grpInforme = new System.Windows.Forms.GroupBox();
            this.tlpPanel.SuspendLayout();
            this.tlpFiltro.SuspendLayout();
            this.grpFiltro.SuspendLayout();
            this.tlpInforme.SuspendLayout();
            this.grpInforme.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPanel
            // 
            this.tlpPanel.BackColor = System.Drawing.SystemColors.Control;
            this.tlpPanel.ColumnCount = 2;
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 396F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tlpPanel.Controls.Add(this.grpInforme, 0, 2);
            this.tlpPanel.Controls.Add(this.grpFiltro, 0, 1);
            this.tlpPanel.Controls.Add(this.btnGenerar, 1, 3);
            this.tlpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPanel.Location = new System.Drawing.Point(0, 0);
            this.tlpPanel.Name = "tlpPanel";
            this.tlpPanel.RowCount = 4;
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tlpPanel.Size = new System.Drawing.Size(490, 288);
            this.tlpPanel.TabIndex = 0;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnGenerar.Location = new System.Drawing.Point(399, 255);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 3;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // tlpFiltro
            // 
            this.tlpFiltro.ColumnCount = 3;
            this.tlpFiltro.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tlpFiltro.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 265F));
            this.tlpFiltro.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.tlpFiltro.Controls.Add(this.lblDesde, 0, 0);
            this.tlpFiltro.Controls.Add(this.lblHasta, 0, 1);
            this.tlpFiltro.Controls.Add(this.dtpDesde, 1, 0);
            this.tlpFiltro.Controls.Add(this.dtpHasta, 1, 1);
            this.tlpFiltro.Controls.Add(this.likAnual, 2, 0);
            this.tlpFiltro.Controls.Add(this.likMensual, 2, 1);
            this.tlpFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFiltro.Location = new System.Drawing.Point(3, 16);
            this.tlpFiltro.Name = "tlpFiltro";
            this.tlpFiltro.RowCount = 2;
            this.tlpFiltro.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpFiltro.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tlpFiltro.Size = new System.Drawing.Size(478, 73);
            this.tlpFiltro.TabIndex = 0;
            // 
            // likMensual
            // 
            this.likMensual.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.likMensual.AutoSize = true;
            this.likMensual.Location = new System.Drawing.Point(335, 48);
            this.likMensual.Name = "likMensual";
            this.likMensual.Size = new System.Drawing.Size(85, 13);
            this.likMensual.TabIndex = 5;
            this.likMensual.TabStop = true;
            this.likMensual.Text = "Informe Mensual";
            this.likMensual.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.likMensual_LinkClicked);
            // 
            // likAnual
            // 
            this.likAnual.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.likAnual.AutoSize = true;
            this.likAnual.Location = new System.Drawing.Point(335, 11);
            this.likAnual.Name = "likAnual";
            this.likAnual.Size = new System.Drawing.Size(72, 13);
            this.likAnual.TabIndex = 4;
            this.likAnual.TabStop = true;
            this.likAnual.Text = "Informe Anual";
            this.likAnual.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.likAnual_LinkClicked);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpHasta.Location = new System.Drawing.Point(70, 44);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(220, 20);
            this.dtpHasta.TabIndex = 3;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpDesde.Location = new System.Drawing.Point(70, 8);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(220, 20);
            this.dtpDesde.TabIndex = 2;
            // 
            // lblHasta
            // 
            this.lblHasta.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(29, 48);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(35, 13);
            this.lblHasta.TabIndex = 1;
            this.lblHasta.Text = "Hasta";
            // 
            // lblDesde
            // 
            this.lblDesde.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(26, 11);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(38, 13);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "Desde";
            // 
            // grpFiltro
            // 
            this.grpFiltro.BackColor = System.Drawing.SystemColors.Control;
            this.tlpPanel.SetColumnSpan(this.grpFiltro, 2);
            this.grpFiltro.Controls.Add(this.tlpFiltro);
            this.grpFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFiltro.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpFiltro.Location = new System.Drawing.Point(3, 29);
            this.grpFiltro.Name = "grpFiltro";
            this.grpFiltro.Size = new System.Drawing.Size(484, 92);
            this.grpFiltro.TabIndex = 1;
            this.grpFiltro.TabStop = false;
            this.grpFiltro.Text = "Filtros";
            // 
            // tlpInforme
            // 
            this.tlpInforme.ColumnCount = 2;
            this.tlpInforme.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tlpInforme.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tlpInforme.Controls.Add(this.rbtObraSocial, 1, 0);
            this.tlpInforme.Controls.Add(this.rbtDiagnostico, 1, 1);
            this.tlpInforme.Controls.Add(this.rbtPaciente, 1, 2);
            this.tlpInforme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInforme.Location = new System.Drawing.Point(3, 16);
            this.tlpInforme.Name = "tlpInforme";
            this.tlpInforme.RowCount = 3;
            this.tlpInforme.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tlpInforme.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpInforme.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpInforme.Size = new System.Drawing.Size(478, 96);
            this.tlpInforme.TabIndex = 0;
            // 
            // rbtPaciente
            // 
            this.rbtPaciente.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtPaciente.AutoSize = true;
            this.rbtPaciente.Location = new System.Drawing.Point(71, 72);
            this.rbtPaciente.Name = "rbtPaciente";
            this.rbtPaciente.Size = new System.Drawing.Size(204, 17);
            this.rbtPaciente.TabIndex = 2;
            this.rbtPaciente.TabStop = true;
            this.rbtPaciente.Text = "Caracteristicas de nuestros pacientes.";
            this.rbtPaciente.UseVisualStyleBackColor = true;
            // 
            // rbtDiagnostico
            // 
            this.rbtDiagnostico.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtDiagnostico.AutoSize = true;
            this.rbtDiagnostico.Location = new System.Drawing.Point(71, 40);
            this.rbtDiagnostico.Name = "rbtDiagnostico";
            this.rbtDiagnostico.Size = new System.Drawing.Size(161, 17);
            this.rbtDiagnostico.TabIndex = 1;
            this.rbtDiagnostico.TabStop = true;
            this.rbtDiagnostico.Text = "Estadisticas de diagnosticos.";
            this.rbtDiagnostico.UseVisualStyleBackColor = true;
            // 
            // rbtObraSocial
            // 
            this.rbtObraSocial.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtObraSocial.AutoSize = true;
            this.rbtObraSocial.Location = new System.Drawing.Point(71, 8);
            this.rbtObraSocial.Name = "rbtObraSocial";
            this.rbtObraSocial.Size = new System.Drawing.Size(206, 17);
            this.rbtObraSocial.TabIndex = 0;
            this.rbtObraSocial.TabStop = true;
            this.rbtObraSocial.Text = "Cantidad de pacientes por obra social.";
            this.rbtObraSocial.UseVisualStyleBackColor = true;
            // 
            // grpInforme
            // 
            this.grpInforme.BackColor = System.Drawing.SystemColors.Control;
            this.tlpPanel.SetColumnSpan(this.grpInforme, 2);
            this.grpInforme.Controls.Add(this.tlpInforme);
            this.grpInforme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInforme.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpInforme.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpInforme.Location = new System.Drawing.Point(3, 127);
            this.grpInforme.Name = "grpInforme";
            this.grpInforme.Size = new System.Drawing.Size(484, 115);
            this.grpInforme.TabIndex = 0;
            this.grpInforme.TabStop = false;
            this.grpInforme.Text = "Informe";
            // 
            // frmEstadistica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 288);
            this.Controls.Add(this.tlpPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(506, 326);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(506, 326);
            this.Name = "frmEstadistica";
            this.ShowInTaskbar = false;
            this.Text = "Editor de Estadisticas";
            this.Load += new System.EventHandler(this.frmEstadistica_Load);
            this.tlpPanel.ResumeLayout(false);
            this.tlpFiltro.ResumeLayout(false);
            this.tlpFiltro.PerformLayout();
            this.grpFiltro.ResumeLayout(false);
            this.tlpInforme.ResumeLayout(false);
            this.tlpInforme.PerformLayout();
            this.grpInforme.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPanel;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.GroupBox grpInforme;
        private System.Windows.Forms.TableLayoutPanel tlpInforme;
        private System.Windows.Forms.RadioButton rbtObraSocial;
        private System.Windows.Forms.RadioButton rbtDiagnostico;
        private System.Windows.Forms.RadioButton rbtPaciente;
        private System.Windows.Forms.GroupBox grpFiltro;
        private System.Windows.Forms.TableLayoutPanel tlpFiltro;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.LinkLabel likAnual;
        private System.Windows.Forms.LinkLabel likMensual;
    }
}