namespace myExplorer.Formularios
{
    partial class frmAbmSocialWork
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
            this.tlpPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblTelefonos = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAlternativePhone = new System.Windows.Forms.TextBox();
            this.lblTelefono1 = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.tlpPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPanel
            // 
            this.tlpPanel.ColumnCount = 3;
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tlpPanel.Controls.Add(this.lblNombre, 0, 1);
            this.tlpPanel.Controls.Add(this.lblDetalle, 0, 2);
            this.tlpPanel.Controls.Add(this.txtDescription, 1, 2);
            this.tlpPanel.Controls.Add(this.txtName, 1, 1);
            this.tlpPanel.Controls.Add(this.lblTelefonos, 0, 5);
            this.tlpPanel.Controls.Add(this.btnCancelar, 2, 6);
            this.tlpPanel.Controls.Add(this.txtPhone, 1, 4);
            this.tlpPanel.Controls.Add(this.txtAlternativePhone, 1, 5);
            this.tlpPanel.Controls.Add(this.lblTelefono1, 0, 4);
            this.tlpPanel.Controls.Add(this.lblDireccion, 0, 3);
            this.tlpPanel.Controls.Add(this.txtAddress, 1, 3);
            this.tlpPanel.Controls.Add(this.lblInfo, 0, 6);
            this.tlpPanel.Controls.Add(this.btnAgregar, 1, 6);
            this.tlpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPanel.Location = new System.Drawing.Point(0, 0);
            this.tlpPanel.Name = "tlpPanel";
            this.tlpPanel.RowCount = 7;
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tlpPanel.Size = new System.Drawing.Size(390, 204);
            this.tlpPanel.TabIndex = 0;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNombre.Location = new System.Drawing.Point(3, 34);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(74, 27);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre *";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetalle.Location = new System.Drawing.Point(3, 61);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(74, 27);
            this.lblDetalle.TabIndex = 1;
            this.lblDetalle.Text = "Descripcion";
            this.lblDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDescription.Location = new System.Drawing.Point(83, 64);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(218, 20);
            this.txtDescription.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtName.Location = new System.Drawing.Point(83, 37);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(218, 20);
            this.txtName.TabIndex = 3;
            // 
            // lblTelefonos
            // 
            this.lblTelefonos.AutoSize = true;
            this.lblTelefonos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTelefonos.Location = new System.Drawing.Point(3, 142);
            this.lblTelefonos.Name = "lblTelefonos";
            this.lblTelefonos.Size = new System.Drawing.Size(74, 27);
            this.lblTelefonos.TabIndex = 16;
            this.lblTelefonos.Text = "Telefono Alternativo";
            this.lblTelefonos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(307, 172);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 27);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPhone.Location = new System.Drawing.Point(83, 118);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(218, 20);
            this.txtPhone.TabIndex = 20;
            // 
            // txtAlternativePhone
            // 
            this.txtAlternativePhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAlternativePhone.Location = new System.Drawing.Point(83, 145);
            this.txtAlternativePhone.Name = "txtAlternativePhone";
            this.txtAlternativePhone.Size = new System.Drawing.Size(218, 20);
            this.txtAlternativePhone.TabIndex = 21;
            // 
            // lblTelefono1
            // 
            this.lblTelefono1.AutoSize = true;
            this.lblTelefono1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTelefono1.Location = new System.Drawing.Point(3, 115);
            this.lblTelefono1.Name = "lblTelefono1";
            this.lblTelefono1.Size = new System.Drawing.Size(74, 27);
            this.lblTelefono1.TabIndex = 22;
            this.lblTelefono1.Text = "Telefono";
            this.lblTelefono1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDireccion.Location = new System.Drawing.Point(3, 88);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(74, 27);
            this.lblDireccion.TabIndex = 12;
            this.lblDireccion.Text = "Domicilio";
            this.lblDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAddress.Location = new System.Drawing.Point(83, 91);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(218, 20);
            this.txtAddress.TabIndex = 13;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInfo.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Location = new System.Drawing.Point(3, 169);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(74, 35);
            this.lblInfo.TabIndex = 23;
            this.lblInfo.Text = "* Campos Obligatorios";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.Location = new System.Drawing.Point(226, 172);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 27);
            this.btnAgregar.TabIndex = 7;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // frmAbmSocialWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 204);
            this.Controls.Add(this.tlpPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbmSocialWork";
            this.Text = "ABM Obra Social";
            this.Load += new System.EventHandler(this.frmAuxABM_Load);
            this.tlpPanel.ResumeLayout(false);
            this.tlpPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPanel;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblTelefonos;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAlternativePhone;
        private System.Windows.Forms.Label lblTelefono1;
        private System.Windows.Forms.Label lblInfo;
    }
}