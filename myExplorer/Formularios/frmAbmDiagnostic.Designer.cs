namespace myExplorer.Formularios
{
    partial class frmAbmDiagnostic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbmDiagnostic));
            this.tlpPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btnAccept = new System.Windows.Forms.Button();
            this.grpDiagnostic = new System.Windows.Forms.GroupBox();
            this.tlpDiagnostic = new System.Windows.Forms.TableLayoutPanel();
            this.rtxtDiagnostic = new System.Windows.Forms.RichTextBox();
            this.lblSpecialty = new System.Windows.Forms.Label();
            this.cmbSpecialty = new System.Windows.Forms.ComboBox();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.btnNew = new System.Windows.Forms.Button();
            this.pnl = new System.Windows.Forms.Panel();
            this.tlp = new System.Windows.Forms.TableLayoutPanel();
            this.chkNotify = new System.Windows.Forms.CheckBox();
            this.cmbDestinationSpeciality = new System.Windows.Forms.ComboBox();
            this.cmbDestinationProfessional = new System.Windows.Forms.ComboBox();
            this.btnSaveDiagnostic = new System.Windows.Forms.Button();
            this.btnPrintDiagnostic = new System.Windows.Forms.Button();
            this.grpDatePatient = new System.Windows.Forms.GroupBox();
            this.tlpPatient = new System.Windows.Forms.TableLayoutPanel();
            this.lblPatient = new System.Windows.Forms.Label();
            this.txtPatient = new System.Windows.Forms.TextBox();
            this.lblProfessionalName = new System.Windows.Forms.Label();
            this.txtProfessional = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.tlpPanel.SuspendLayout();
            this.grpDiagnostic.SuspendLayout();
            this.tlpDiagnostic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.pnl.SuspendLayout();
            this.tlp.SuspendLayout();
            this.grpDatePatient.SuspendLayout();
            this.tlpPatient.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPanel
            // 
            this.tlpPanel.ColumnCount = 2;
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.tlpPanel.Controls.Add(this.btnAccept, 1, 2);
            this.tlpPanel.Controls.Add(this.grpDiagnostic, 0, 1);
            this.tlpPanel.Controls.Add(this.grpDatePatient, 0, 0);
            this.tlpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPanel.Location = new System.Drawing.Point(0, 0);
            this.tlpPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tlpPanel.Name = "tlpPanel";
            this.tlpPanel.RowCount = 3;
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tlpPanel.Size = new System.Drawing.Size(1156, 668);
            this.tlpPanel.TabIndex = 0;
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Location = new System.Drawing.Point(1040, 598);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(112, 65);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // grpDiagnostic
            // 
            this.tlpPanel.SetColumnSpan(this.grpDiagnostic, 2);
            this.grpDiagnostic.Controls.Add(this.tlpDiagnostic);
            this.grpDiagnostic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDiagnostic.Location = new System.Drawing.Point(3, 90);
            this.grpDiagnostic.Name = "grpDiagnostic";
            this.grpDiagnostic.Size = new System.Drawing.Size(1150, 500);
            this.grpDiagnostic.TabIndex = 9;
            this.grpDiagnostic.TabStop = false;
            this.grpDiagnostic.Text = "Diagnosticos";
            // 
            // tlpDiagnostic
            // 
            this.tlpDiagnostic.ColumnCount = 4;
            this.tlpDiagnostic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 176F));
            this.tlpDiagnostic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 216F));
            this.tlpDiagnostic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDiagnostic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tlpDiagnostic.Controls.Add(this.rtxtDiagnostic, 0, 2);
            this.tlpDiagnostic.Controls.Add(this.lblSpecialty, 0, 1);
            this.tlpDiagnostic.Controls.Add(this.cmbSpecialty, 1, 1);
            this.tlpDiagnostic.Controls.Add(this.dgvLista, 0, 0);
            this.tlpDiagnostic.Controls.Add(this.btnNew, 3, 2);
            this.tlpDiagnostic.Controls.Add(this.pnl, 2, 1);
            this.tlpDiagnostic.Controls.Add(this.btnSaveDiagnostic, 3, 3);
            this.tlpDiagnostic.Controls.Add(this.btnPrintDiagnostic, 3, 4);
            this.tlpDiagnostic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDiagnostic.Location = new System.Drawing.Point(3, 22);
            this.tlpDiagnostic.Name = "tlpDiagnostic";
            this.tlpDiagnostic.RowCount = 5;
            this.tlpDiagnostic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDiagnostic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tlpDiagnostic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpDiagnostic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpDiagnostic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpDiagnostic.Size = new System.Drawing.Size(1144, 475);
            this.tlpDiagnostic.TabIndex = 7;
            // 
            // rtxtDiagnostic
            // 
            this.tlpDiagnostic.SetColumnSpan(this.rtxtDiagnostic, 3);
            this.rtxtDiagnostic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtDiagnostic.Location = new System.Drawing.Point(4, 300);
            this.rtxtDiagnostic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtxtDiagnostic.Name = "rtxtDiagnostic";
            this.tlpDiagnostic.SetRowSpan(this.rtxtDiagnostic, 3);
            this.rtxtDiagnostic.Size = new System.Drawing.Size(1013, 170);
            this.rtxtDiagnostic.TabIndex = 5;
            this.rtxtDiagnostic.Text = "";
            // 
            // lblSpecialty
            // 
            this.lblSpecialty.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSpecialty.AutoSize = true;
            this.lblSpecialty.Location = new System.Drawing.Point(14, 258);
            this.lblSpecialty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpecialty.Name = "lblSpecialty";
            this.lblSpecialty.Size = new System.Drawing.Size(158, 20);
            this.lblSpecialty.TabIndex = 0;
            this.lblSpecialty.Text = "Especialidad Tratada";
            // 
            // cmbSpecialty
            // 
            this.cmbSpecialty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSpecialty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpecialty.FormattingEnabled = true;
            this.cmbSpecialty.Location = new System.Drawing.Point(180, 254);
            this.cmbSpecialty.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSpecialty.Name = "cmbSpecialty";
            this.cmbSpecialty.Size = new System.Drawing.Size(208, 28);
            this.cmbSpecialty.TabIndex = 1;
            // 
            // dgvLista
            // 
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tlpDiagnostic.SetColumnSpan(this.dgvLista, 4);
            this.dgvLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLista.Location = new System.Drawing.Point(3, 3);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.RowTemplate.Height = 28;
            this.dgvLista.Size = new System.Drawing.Size(1138, 236);
            this.dgvLista.TabIndex = 7;
            this.dgvLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellClick);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Location = new System.Drawing.Point(1024, 302);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(110, 50);
            this.btnNew.TabIndex = 8;
            this.btnNew.Text = "Nuevo";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // pnl
            // 
            this.pnl.BackColor = System.Drawing.SystemColors.Info;
            this.pnl.Controls.Add(this.tlp);
            this.pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl.Location = new System.Drawing.Point(395, 245);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(623, 47);
            this.pnl.TabIndex = 10;
            // 
            // tlp
            // 
            this.tlp.ColumnCount = 3;
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tlp.Controls.Add(this.chkNotify, 0, 0);
            this.tlp.Controls.Add(this.cmbDestinationSpeciality, 1, 0);
            this.tlp.Controls.Add(this.cmbDestinationProfessional, 2, 0);
            this.tlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp.Location = new System.Drawing.Point(0, 0);
            this.tlp.Name = "tlp";
            this.tlp.RowCount = 1;
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp.Size = new System.Drawing.Size(623, 47);
            this.tlp.TabIndex = 0;
            // 
            // chkNotify
            // 
            this.chkNotify.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkNotify.AutoSize = true;
            this.chkNotify.Location = new System.Drawing.Point(130, 11);
            this.chkNotify.Name = "chkNotify";
            this.chkNotify.Size = new System.Drawing.Size(110, 24);
            this.chkNotify.TabIndex = 0;
            this.chkNotify.Text = "Notificar a:";
            this.chkNotify.UseVisualStyleBackColor = true;
            this.chkNotify.CheckedChanged += new System.EventHandler(this.chkNotify_CheckedChanged);
            // 
            // cmbDestinationSpeciality
            // 
            this.cmbDestinationSpeciality.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDestinationSpeciality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDestinationSpeciality.FormattingEnabled = true;
            this.cmbDestinationSpeciality.Location = new System.Drawing.Point(246, 9);
            this.cmbDestinationSpeciality.Name = "cmbDestinationSpeciality";
            this.cmbDestinationSpeciality.Size = new System.Drawing.Size(184, 28);
            this.cmbDestinationSpeciality.TabIndex = 1;
            this.cmbDestinationSpeciality.SelectedIndexChanged += new System.EventHandler(this.cmbDestinationSpeciality_SelectedIndexChanged);
            // 
            // cmbDestinationProfessional
            // 
            this.cmbDestinationProfessional.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDestinationProfessional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDestinationProfessional.FormattingEnabled = true;
            this.cmbDestinationProfessional.Location = new System.Drawing.Point(436, 9);
            this.cmbDestinationProfessional.Name = "cmbDestinationProfessional";
            this.cmbDestinationProfessional.Size = new System.Drawing.Size(184, 28);
            this.cmbDestinationProfessional.TabIndex = 2;
            // 
            // btnSaveDiagnostic
            // 
            this.btnSaveDiagnostic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveDiagnostic.Location = new System.Drawing.Point(1025, 360);
            this.btnSaveDiagnostic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSaveDiagnostic.Name = "btnSaveDiagnostic";
            this.btnSaveDiagnostic.Size = new System.Drawing.Size(110, 50);
            this.btnSaveDiagnostic.TabIndex = 4;
            this.btnSaveDiagnostic.Text = "Guardar";
            this.btnSaveDiagnostic.UseVisualStyleBackColor = true;
            this.btnSaveDiagnostic.Click += new System.EventHandler(this.btnSaveDiagnostic_Click);
            // 
            // btnPrintDiagnostic
            // 
            this.btnPrintDiagnostic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrintDiagnostic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPrintDiagnostic.Enabled = false;
            this.btnPrintDiagnostic.Location = new System.Drawing.Point(1024, 422);
            this.btnPrintDiagnostic.Name = "btnPrintDiagnostic";
            this.btnPrintDiagnostic.Size = new System.Drawing.Size(110, 50);
            this.btnPrintDiagnostic.TabIndex = 9;
            this.btnPrintDiagnostic.Text = "Imprimir";
            this.btnPrintDiagnostic.UseVisualStyleBackColor = true;
            this.btnPrintDiagnostic.Click += new System.EventHandler(this.btnPrintDiagnostic_Click);
            // 
            // grpDatePatient
            // 
            this.tlpPanel.SetColumnSpan(this.grpDatePatient, 2);
            this.grpDatePatient.Controls.Add(this.tlpPatient);
            this.grpDatePatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDatePatient.Location = new System.Drawing.Point(3, 3);
            this.grpDatePatient.Name = "grpDatePatient";
            this.grpDatePatient.Size = new System.Drawing.Size(1150, 81);
            this.grpDatePatient.TabIndex = 8;
            this.grpDatePatient.TabStop = false;
            this.grpDatePatient.Text = "Datos del Paciente";
            // 
            // tlpPatient
            // 
            this.tlpPatient.ColumnCount = 5;
            this.tlpPatient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tlpPatient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPatient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tlpPatient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPatient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 182F));
            this.tlpPatient.Controls.Add(this.lblPatient, 0, 0);
            this.tlpPatient.Controls.Add(this.txtPatient, 1, 0);
            this.tlpPatient.Controls.Add(this.lblProfessionalName, 2, 0);
            this.tlpPatient.Controls.Add(this.txtProfessional, 3, 0);
            this.tlpPatient.Controls.Add(this.btnPrint, 4, 0);
            this.tlpPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPatient.Location = new System.Drawing.Point(3, 22);
            this.tlpPatient.Name = "tlpPatient";
            this.tlpPatient.RowCount = 1;
            this.tlpPatient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPatient.Size = new System.Drawing.Size(1144, 56);
            this.tlpPatient.TabIndex = 0;
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPatient.Location = new System.Drawing.Point(3, 0);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(164, 56);
            this.lblPatient.TabIndex = 0;
            this.lblPatient.Text = "Paciente";
            this.lblPatient.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPatient
            // 
            this.txtPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPatient.Location = new System.Drawing.Point(173, 15);
            this.txtPatient.Name = "txtPatient";
            this.txtPatient.ReadOnly = true;
            this.txtPatient.Size = new System.Drawing.Size(305, 26);
            this.txtPatient.TabIndex = 2;
            // 
            // lblProfessionalName
            // 
            this.lblProfessionalName.AutoSize = true;
            this.lblProfessionalName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProfessionalName.Location = new System.Drawing.Point(484, 0);
            this.lblProfessionalName.Name = "lblProfessionalName";
            this.lblProfessionalName.Size = new System.Drawing.Size(164, 56);
            this.lblProfessionalName.TabIndex = 3;
            this.lblProfessionalName.Text = "Profesional Actual";
            this.lblProfessionalName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProfessional
            // 
            this.txtProfessional.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProfessional.Location = new System.Drawing.Point(654, 15);
            this.txtProfessional.Name = "txtProfessional";
            this.txtProfessional.ReadOnly = true;
            this.txtProfessional.Size = new System.Drawing.Size(305, 26);
            this.txtProfessional.TabIndex = 4;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(977, 9);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(151, 38);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "Imprimir H. C.";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmAbmDiagnostic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 668);
            this.Controls.Add(this.tlpPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAbmDiagnostic";
            this.Text = "Diagnostico";
            this.Load += new System.EventHandler(this.frmAbmDiagnostic_Load);
            this.tlpPanel.ResumeLayout(false);
            this.grpDiagnostic.ResumeLayout(false);
            this.tlpDiagnostic.ResumeLayout(false);
            this.tlpDiagnostic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.pnl.ResumeLayout(false);
            this.tlp.ResumeLayout(false);
            this.tlp.PerformLayout();
            this.grpDatePatient.ResumeLayout(false);
            this.tlpPatient.ResumeLayout(false);
            this.tlpPatient.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPanel;
        private System.Windows.Forms.RichTextBox rtxtDiagnostic;
        private System.Windows.Forms.Button btnSaveDiagnostic;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblSpecialty;
        private System.Windows.Forms.ComboBox cmbSpecialty;
        private System.Windows.Forms.GroupBox grpDiagnostic;
        private System.Windows.Forms.GroupBox grpDatePatient;
        private System.Windows.Forms.TableLayoutPanel tlpDiagnostic;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.TableLayoutPanel tlpPatient;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.TextBox txtPatient;
        private System.Windows.Forms.Label lblProfessionalName;
        private System.Windows.Forms.TextBox txtProfessional;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPrintDiagnostic;
        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.TableLayoutPanel tlp;
        private System.Windows.Forms.CheckBox chkNotify;
        private System.Windows.Forms.ComboBox cmbDestinationSpeciality;
        private System.Windows.Forms.ComboBox cmbDestinationProfessional;
    }
}