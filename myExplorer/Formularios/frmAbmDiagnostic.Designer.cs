﻿namespace myExplorer.Formularios
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
            this.btnNew = new System.Windows.Forms.Button();
            this.grpDatePatient = new System.Windows.Forms.GroupBox();
            this.tlpPatient = new System.Windows.Forms.TableLayoutPanel();
            this.lblPatient = new System.Windows.Forms.Label();
            this.txtPatient = new System.Windows.Forms.TextBox();
            this.lblProfessionalName = new System.Windows.Forms.Label();
            this.txtProfessional = new System.Windows.Forms.TextBox();
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
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tlpPanel.Controls.Add(this.btnAccept, 1, 2);
            this.tlpPanel.Controls.Add(this.grpDiagnostic, 0, 1);
            this.tlpPanel.Controls.Add(this.grpDatePatient, 0, 0);
            this.tlpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPanel.Location = new System.Drawing.Point(0, 0);
            this.tlpPanel.Name = "tlpPanel";
            this.tlpPanel.RowCount = 3;
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tlpPanel.Size = new System.Drawing.Size(771, 434);
            this.tlpPanel.TabIndex = 0;
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Location = new System.Drawing.Point(693, 388);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 42);
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
            this.grpDiagnostic.Location = new System.Drawing.Point(2, 49);
            this.grpDiagnostic.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpDiagnostic.Name = "grpDiagnostic";
            this.grpDiagnostic.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpDiagnostic.Size = new System.Drawing.Size(767, 334);
            this.grpDiagnostic.TabIndex = 9;
            this.grpDiagnostic.TabStop = false;
            this.grpDiagnostic.Text = "Diagnosticos";
            // 
            // tlpDiagnostic
            // 
            this.tlpDiagnostic.ColumnCount = 4;
            this.tlpDiagnostic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tlpDiagnostic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 193F));
            this.tlpDiagnostic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDiagnostic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tlpDiagnostic.Controls.Add(this.rtxtDiagnostic, 0, 2);
            this.tlpDiagnostic.Controls.Add(this.lblSpecialty, 0, 1);
            this.tlpDiagnostic.Controls.Add(this.cmbSpecialty, 1, 1);
            this.tlpDiagnostic.Controls.Add(this.dgvLista, 0, 0);
            this.tlpDiagnostic.Controls.Add(this.btnSaveDiagnostic, 3, 3);
            this.tlpDiagnostic.Controls.Add(this.btnNew, 3, 2);
            this.tlpDiagnostic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDiagnostic.Location = new System.Drawing.Point(2, 15);
            this.tlpDiagnostic.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tlpDiagnostic.Name = "tlpDiagnostic";
            this.tlpDiagnostic.RowCount = 4;
            this.tlpDiagnostic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tlpDiagnostic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpDiagnostic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDiagnostic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tlpDiagnostic.Size = new System.Drawing.Size(763, 317);
            this.tlpDiagnostic.TabIndex = 7;
            // 
            // rtxtDiagnostic
            // 
            this.tlpDiagnostic.SetColumnSpan(this.rtxtDiagnostic, 3);
            this.rtxtDiagnostic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtDiagnostic.Location = new System.Drawing.Point(3, 215);
            this.rtxtDiagnostic.Name = "rtxtDiagnostic";
            this.tlpDiagnostic.SetRowSpan(this.rtxtDiagnostic, 2);
            this.rtxtDiagnostic.Size = new System.Drawing.Size(675, 99);
            this.rtxtDiagnostic.TabIndex = 5;
            this.rtxtDiagnostic.Text = "";
            // 
            // lblSpecialty
            // 
            this.lblSpecialty.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSpecialty.AutoSize = true;
            this.lblSpecialty.Location = new System.Drawing.Point(7, 193);
            this.lblSpecialty.Name = "lblSpecialty";
            this.lblSpecialty.Size = new System.Drawing.Size(107, 13);
            this.lblSpecialty.TabIndex = 0;
            this.lblSpecialty.Text = "Especialidad Tratada";
            // 
            // cmbSpecialty
            // 
            this.cmbSpecialty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSpecialty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpecialty.FormattingEnabled = true;
            this.cmbSpecialty.Location = new System.Drawing.Point(120, 190);
            this.cmbSpecialty.Name = "cmbSpecialty";
            this.cmbSpecialty.Size = new System.Drawing.Size(187, 21);
            this.cmbSpecialty.TabIndex = 1;
            // 
            // dgvLista
            // 
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tlpDiagnostic.SetColumnSpan(this.dgvLista, 4);
            this.dgvLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLista.Location = new System.Drawing.Point(2, 2);
            this.dgvLista.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.RowTemplate.Height = 28;
            this.dgvLista.Size = new System.Drawing.Size(759, 183);
            this.dgvLista.TabIndex = 7;
            this.dgvLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellClick);
            // 
            // btnSaveDiagnostic
            // 
            this.btnSaveDiagnostic.Location = new System.Drawing.Point(684, 261);
            this.btnSaveDiagnostic.Name = "btnSaveDiagnostic";
            this.btnSaveDiagnostic.Size = new System.Drawing.Size(75, 39);
            this.btnSaveDiagnostic.TabIndex = 4;
            this.btnSaveDiagnostic.Text = "Guardar";
            this.btnSaveDiagnostic.UseVisualStyleBackColor = true;
            this.btnSaveDiagnostic.Click += new System.EventHandler(this.btnSaveDiagnostic_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Location = new System.Drawing.Point(683, 217);
            this.btnNew.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 39);
            this.btnNew.TabIndex = 8;
            this.btnNew.Text = "Nuevo";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // grpDatePatient
            // 
            this.tlpPanel.SetColumnSpan(this.grpDatePatient, 2);
            this.grpDatePatient.Controls.Add(this.tlpPatient);
            this.grpDatePatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDatePatient.Location = new System.Drawing.Point(2, 2);
            this.grpDatePatient.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpDatePatient.Name = "grpDatePatient";
            this.grpDatePatient.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpDatePatient.Size = new System.Drawing.Size(767, 43);
            this.grpDatePatient.TabIndex = 8;
            this.grpDatePatient.TabStop = false;
            this.grpDatePatient.Text = "Datos del Paciente";
            // 
            // tlpPatient
            // 
            this.tlpPatient.ColumnCount = 4;
            this.tlpPatient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tlpPatient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPatient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tlpPatient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPatient.Controls.Add(this.lblPatient, 0, 0);
            this.tlpPatient.Controls.Add(this.txtPatient, 1, 0);
            this.tlpPatient.Controls.Add(this.lblProfessionalName, 2, 0);
            this.tlpPatient.Controls.Add(this.txtProfessional, 3, 0);
            this.tlpPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPatient.Location = new System.Drawing.Point(2, 15);
            this.tlpPatient.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tlpPatient.Name = "tlpPatient";
            this.tlpPatient.RowCount = 1;
            this.tlpPatient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPatient.Size = new System.Drawing.Size(763, 26);
            this.tlpPatient.TabIndex = 0;
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPatient.Location = new System.Drawing.Point(2, 0);
            this.lblPatient.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(109, 26);
            this.lblPatient.TabIndex = 0;
            this.lblPatient.Text = "Paciente";
            this.lblPatient.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPatient
            // 
            this.txtPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPatient.Location = new System.Drawing.Point(115, 3);
            this.txtPatient.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPatient.Name = "txtPatient";
            this.txtPatient.ReadOnly = true;
            this.txtPatient.Size = new System.Drawing.Size(264, 20);
            this.txtPatient.TabIndex = 2;
            // 
            // lblProfessionalName
            // 
            this.lblProfessionalName.AutoSize = true;
            this.lblProfessionalName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProfessionalName.Location = new System.Drawing.Point(383, 0);
            this.lblProfessionalName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProfessionalName.Name = "lblProfessionalName";
            this.lblProfessionalName.Size = new System.Drawing.Size(109, 26);
            this.lblProfessionalName.TabIndex = 3;
            this.lblProfessionalName.Text = "Professional";
            this.lblProfessionalName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProfessional
            // 
            this.txtProfessional.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProfessional.Location = new System.Drawing.Point(496, 3);
            this.txtProfessional.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtProfessional.Name = "txtProfessional";
            this.txtProfessional.ReadOnly = true;
            this.txtProfessional.Size = new System.Drawing.Size(265, 20);
            this.txtProfessional.TabIndex = 4;
            // 
            // frmAbmDiagnostic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 434);
            this.Controls.Add(this.tlpPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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