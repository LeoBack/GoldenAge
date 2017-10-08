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
            this.btnSaveDiagnostic = new System.Windows.Forms.Button();
            this.grpDatePatient = new System.Windows.Forms.GroupBox();
            this.tlpPatient = new System.Windows.Forms.TableLayoutPanel();
            this.lblPatient = new System.Windows.Forms.Label();
            this.txtPatient = new System.Windows.Forms.TextBox();
            this.lblProfessionalName = new System.Windows.Forms.Label();
            this.txtProfessional = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.tlpPanel.SuspendLayout();
            this.grpDiagnostic.SuspendLayout();
            this.tlpDiagnostic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
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
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
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
            this.grpDiagnostic.Location = new System.Drawing.Point(3, 75);
            this.grpDiagnostic.Name = "grpDiagnostic";
            this.grpDiagnostic.Size = new System.Drawing.Size(1150, 515);
            this.grpDiagnostic.TabIndex = 9;
            this.grpDiagnostic.TabStop = false;
            this.grpDiagnostic.Text = "Diagnosticos";
            // 
            // tlpDiagnostic
            // 
            this.tlpDiagnostic.ColumnCount = 5;
            this.tlpDiagnostic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 176F));
            this.tlpDiagnostic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 290F));
            this.tlpDiagnostic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDiagnostic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tlpDiagnostic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tlpDiagnostic.Controls.Add(this.rtxtDiagnostic, 0, 2);
            this.tlpDiagnostic.Controls.Add(this.lblSpecialty, 0, 1);
            this.tlpDiagnostic.Controls.Add(this.cmbSpecialty, 1, 1);
            this.tlpDiagnostic.Controls.Add(this.dgvLista, 0, 0);
            this.tlpDiagnostic.Controls.Add(this.btnSaveDiagnostic, 4, 3);
            this.tlpDiagnostic.Controls.Add(this.btnNew, 3, 3);
            this.tlpDiagnostic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDiagnostic.Location = new System.Drawing.Point(3, 22);
            this.tlpDiagnostic.Name = "tlpDiagnostic";
            this.tlpDiagnostic.RowCount = 4;
            this.tlpDiagnostic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDiagnostic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlpDiagnostic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 129F));
            this.tlpDiagnostic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tlpDiagnostic.Size = new System.Drawing.Size(1144, 490);
            this.tlpDiagnostic.TabIndex = 7;
            // 
            // rtxtDiagnostic
            // 
            this.tlpDiagnostic.SetColumnSpan(this.rtxtDiagnostic, 5);
            this.rtxtDiagnostic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtDiagnostic.Location = new System.Drawing.Point(4, 320);
            this.rtxtDiagnostic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rtxtDiagnostic.Name = "rtxtDiagnostic";
            this.rtxtDiagnostic.Size = new System.Drawing.Size(1136, 119);
            this.rtxtDiagnostic.TabIndex = 5;
            this.rtxtDiagnostic.Text = "";
            // 
            // lblSpecialty
            // 
            this.lblSpecialty.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSpecialty.AutoSize = true;
            this.lblSpecialty.Location = new System.Drawing.Point(14, 286);
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
            this.cmbSpecialty.Location = new System.Drawing.Point(180, 282);
            this.cmbSpecialty.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSpecialty.Name = "cmbSpecialty";
            this.cmbSpecialty.Size = new System.Drawing.Size(282, 28);
            this.cmbSpecialty.TabIndex = 1;
            // 
            // dgvLista
            // 
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tlpDiagnostic.SetColumnSpan(this.dgvLista, 5);
            this.dgvLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLista.Location = new System.Drawing.Point(3, 3);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.RowTemplate.Height = 28;
            this.dgvLista.Size = new System.Drawing.Size(1138, 271);
            this.dgvLista.TabIndex = 7;
            this.dgvLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellClick);
            // 
            // btnSaveDiagnostic
            // 
            this.btnSaveDiagnostic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveDiagnostic.Location = new System.Drawing.Point(1028, 449);
            this.btnSaveDiagnostic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSaveDiagnostic.Name = "btnSaveDiagnostic";
            this.btnSaveDiagnostic.Size = new System.Drawing.Size(112, 35);
            this.btnSaveDiagnostic.TabIndex = 4;
            this.btnSaveDiagnostic.Text = "Guardar";
            this.btnSaveDiagnostic.UseVisualStyleBackColor = true;
            this.btnSaveDiagnostic.Click += new System.EventHandler(this.btnSaveDiagnostic_Click);
            // 
            // grpDatePatient
            // 
            this.tlpPanel.SetColumnSpan(this.grpDatePatient, 2);
            this.grpDatePatient.Controls.Add(this.tlpPatient);
            this.grpDatePatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDatePatient.Location = new System.Drawing.Point(3, 3);
            this.grpDatePatient.Name = "grpDatePatient";
            this.grpDatePatient.Size = new System.Drawing.Size(1150, 66);
            this.grpDatePatient.TabIndex = 8;
            this.grpDatePatient.TabStop = false;
            this.grpDatePatient.Text = "Datos del Paciente";
            // 
            // tlpPatient
            // 
            this.tlpPatient.ColumnCount = 4;
            this.tlpPatient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tlpPatient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPatient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tlpPatient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPatient.Controls.Add(this.lblPatient, 0, 0);
            this.tlpPatient.Controls.Add(this.txtPatient, 1, 0);
            this.tlpPatient.Controls.Add(this.lblProfessionalName, 2, 0);
            this.tlpPatient.Controls.Add(this.txtProfessional, 3, 0);
            this.tlpPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPatient.Location = new System.Drawing.Point(3, 22);
            this.tlpPatient.Name = "tlpPatient";
            this.tlpPatient.RowCount = 1;
            this.tlpPatient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPatient.Size = new System.Drawing.Size(1144, 41);
            this.tlpPatient.TabIndex = 0;
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPatient.Location = new System.Drawing.Point(3, 0);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(164, 41);
            this.lblPatient.TabIndex = 0;
            this.lblPatient.Text = "Paciente";
            this.lblPatient.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPatient
            // 
            this.txtPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPatient.Location = new System.Drawing.Point(173, 7);
            this.txtPatient.Name = "txtPatient";
            this.txtPatient.ReadOnly = true;
            this.txtPatient.Size = new System.Drawing.Size(396, 26);
            this.txtPatient.TabIndex = 2;
            // 
            // lblProfessionalName
            // 
            this.lblProfessionalName.AutoSize = true;
            this.lblProfessionalName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProfessionalName.Location = new System.Drawing.Point(575, 0);
            this.lblProfessionalName.Name = "lblProfessionalName";
            this.lblProfessionalName.Size = new System.Drawing.Size(164, 41);
            this.lblProfessionalName.TabIndex = 3;
            this.lblProfessionalName.Text = "Professional";
            this.lblProfessionalName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProfessional
            // 
            this.txtProfessional.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProfessional.Location = new System.Drawing.Point(745, 7);
            this.txtProfessional.Name = "txtProfessional";
            this.txtProfessional.ReadOnly = true;
            this.txtProfessional.Size = new System.Drawing.Size(396, 26);
            this.txtProfessional.TabIndex = 4;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(901, 447);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(112, 35);
            this.btnNew.TabIndex = 8;
            this.btnNew.Text = "Nuevo";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
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
    }
}