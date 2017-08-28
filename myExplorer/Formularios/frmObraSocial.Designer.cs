namespace myExplorer.Formularios
{
    partial class frmObraSocial
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
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.lblBarrio = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.cmbBarrio = new System.Windows.Forms.ComboBox();
            this.cmbCiudad = new System.Windows.Forms.ComboBox();
            this.txtDetalle = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnAddCiudad = new System.Windows.Forms.Button();
            this.btnAddBarrio = new System.Windows.Forms.Button();
            this.lblTelefonos = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtTelefono1 = new System.Windows.Forms.TextBox();
            this.txtTelefono2 = new System.Windows.Forms.TextBox();
            this.lblTelefono1 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.tlpPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPanel
            // 
            this.tlpPanel.ColumnCount = 4;
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.21569F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 134F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tlpPanel.Controls.Add(this.lblNombre, 0, 1);
            this.tlpPanel.Controls.Add(this.lblDetalle, 0, 2);
            this.tlpPanel.Controls.Add(this.lblDescripcion, 0, 0);
            this.tlpPanel.Controls.Add(this.lblCiudad, 0, 3);
            this.tlpPanel.Controls.Add(this.lblBarrio, 0, 4);
            this.tlpPanel.Controls.Add(this.lblDireccion, 0, 5);
            this.tlpPanel.Controls.Add(this.txtDireccion, 1, 5);
            this.tlpPanel.Controls.Add(this.cmbBarrio, 1, 4);
            this.tlpPanel.Controls.Add(this.cmbCiudad, 1, 3);
            this.tlpPanel.Controls.Add(this.txtDetalle, 1, 2);
            this.tlpPanel.Controls.Add(this.txtNombre, 1, 1);
            this.tlpPanel.Controls.Add(this.btnAddCiudad, 3, 3);
            this.tlpPanel.Controls.Add(this.btnAddBarrio, 3, 4);
            this.tlpPanel.Controls.Add(this.lblTelefonos, 0, 7);
            this.tlpPanel.Controls.Add(this.btnCancelar, 3, 8);
            this.tlpPanel.Controls.Add(this.txtTelefono1, 1, 6);
            this.tlpPanel.Controls.Add(this.txtTelefono2, 1, 7);
            this.tlpPanel.Controls.Add(this.lblTelefono1, 0, 6);
            this.tlpPanel.Controls.Add(this.btnAgregar, 2, 8);
            this.tlpPanel.Controls.Add(this.lblInfo, 0, 8);
            this.tlpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPanel.Location = new System.Drawing.Point(0, 0);
            this.tlpPanel.Name = "tlpPanel";
            this.tlpPanel.RowCount = 9;
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.03468F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tlpPanel.Size = new System.Drawing.Size(408, 396);
            this.tlpPanel.TabIndex = 0;
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(28, 43);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(51, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre *";
            // 
            // lblDetalle
            // 
            this.lblDetalle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Location = new System.Drawing.Point(39, 126);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(40, 13);
            this.lblDetalle.TabIndex = 1;
            this.lblDetalle.Text = "Detalle";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDescripcion.AutoSize = true;
            this.tlpPanel.SetColumnSpan(this.lblDescripcion, 4);
            this.lblDescripcion.Location = new System.Drawing.Point(3, 12);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // lblCiudad
            // 
            this.lblCiudad.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Location = new System.Drawing.Point(32, 211);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(47, 13);
            this.lblCiudad.TabIndex = 8;
            this.lblCiudad.Text = "Ciudad *";
            // 
            // lblBarrio
            // 
            this.lblBarrio.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblBarrio.AutoSize = true;
            this.lblBarrio.Location = new System.Drawing.Point(38, 240);
            this.lblBarrio.Name = "lblBarrio";
            this.lblBarrio.Size = new System.Drawing.Size(41, 13);
            this.lblBarrio.TabIndex = 9;
            this.lblBarrio.Text = "Barrio *";
            // 
            // lblDireccion
            // 
            this.lblDireccion.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(20, 269);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(59, 13);
            this.lblDireccion.TabIndex = 12;
            this.lblDireccion.Text = "Direccion *";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPanel.SetColumnSpan(this.txtDireccion, 2);
            this.txtDireccion.Location = new System.Drawing.Point(85, 265);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(234, 20);
            this.txtDireccion.TabIndex = 13;
            // 
            // cmbBarrio
            // 
            this.cmbBarrio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPanel.SetColumnSpan(this.cmbBarrio, 2);
            this.cmbBarrio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBarrio.FormattingEnabled = true;
            this.cmbBarrio.Location = new System.Drawing.Point(85, 236);
            this.cmbBarrio.Name = "cmbBarrio";
            this.cmbBarrio.Size = new System.Drawing.Size(234, 21);
            this.cmbBarrio.TabIndex = 11;
            // 
            // cmbCiudad
            // 
            this.cmbCiudad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPanel.SetColumnSpan(this.cmbCiudad, 2);
            this.cmbCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCiudad.FormattingEnabled = true;
            this.cmbCiudad.Location = new System.Drawing.Point(85, 207);
            this.cmbCiudad.Name = "cmbCiudad";
            this.cmbCiudad.Size = new System.Drawing.Size(234, 21);
            this.cmbCiudad.TabIndex = 10;
            this.cmbCiudad.SelectedIndexChanged += new System.EventHandler(this.cmbCiudad_SelectedIndexChanged);
            // 
            // txtDetalle
            // 
            this.tlpPanel.SetColumnSpan(this.txtDetalle, 2);
            this.txtDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetalle.Location = new System.Drawing.Point(85, 66);
            this.txtDetalle.Multiline = true;
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.Size = new System.Drawing.Size(234, 134);
            this.txtDetalle.TabIndex = 4;
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPanel.SetColumnSpan(this.txtNombre, 2);
            this.txtNombre.Location = new System.Drawing.Point(85, 40);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(234, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // btnAddCiudad
            // 
            this.btnAddCiudad.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddCiudad.Location = new System.Drawing.Point(325, 206);
            this.btnAddCiudad.Name = "btnAddCiudad";
            this.btnAddCiudad.Size = new System.Drawing.Size(31, 23);
            this.btnAddCiudad.TabIndex = 14;
            this.btnAddCiudad.Text = "+";
            this.btnAddCiudad.UseVisualStyleBackColor = true;
            this.btnAddCiudad.Click += new System.EventHandler(this.btnAddCiudad_Click);
            // 
            // btnAddBarrio
            // 
            this.btnAddBarrio.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddBarrio.Location = new System.Drawing.Point(325, 235);
            this.btnAddBarrio.Name = "btnAddBarrio";
            this.btnAddBarrio.Size = new System.Drawing.Size(31, 23);
            this.btnAddBarrio.TabIndex = 15;
            this.btnAddBarrio.Text = "+";
            this.btnAddBarrio.UseVisualStyleBackColor = true;
            this.btnAddBarrio.Click += new System.EventHandler(this.btnAddBarrio_Click);
            // 
            // lblTelefonos
            // 
            this.lblTelefonos.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTelefonos.AutoSize = true;
            this.lblTelefonos.Location = new System.Drawing.Point(22, 321);
            this.lblTelefonos.Name = "lblTelefonos";
            this.lblTelefonos.Size = new System.Drawing.Size(57, 26);
            this.lblTelefonos.TabIndex = 16;
            this.lblTelefonos.Text = "Telefono Alternativo";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(325, 352);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 40);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtTelefono1
            // 
            this.txtTelefono1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPanel.SetColumnSpan(this.txtTelefono1, 2);
            this.txtTelefono1.Location = new System.Drawing.Point(85, 294);
            this.txtTelefono1.Name = "txtTelefono1";
            this.txtTelefono1.Size = new System.Drawing.Size(234, 20);
            this.txtTelefono1.TabIndex = 20;
            // 
            // txtTelefono2
            // 
            this.txtTelefono2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPanel.SetColumnSpan(this.txtTelefono2, 2);
            this.txtTelefono2.Location = new System.Drawing.Point(85, 324);
            this.txtTelefono2.Name = "txtTelefono2";
            this.txtTelefono2.Size = new System.Drawing.Size(234, 20);
            this.txtTelefono2.TabIndex = 21;
            // 
            // lblTelefono1
            // 
            this.lblTelefono1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTelefono1.AutoSize = true;
            this.lblTelefono1.Location = new System.Drawing.Point(23, 298);
            this.lblTelefono1.Name = "lblTelefono1";
            this.lblTelefono1.Size = new System.Drawing.Size(56, 13);
            this.lblTelefono1.TabIndex = 22;
            this.lblTelefono1.Text = "Telefono *";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.Location = new System.Drawing.Point(244, 352);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 40);
            this.btnAgregar.TabIndex = 7;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblInfo.AutoSize = true;
            this.tlpPanel.SetColumnSpan(this.lblInfo, 2);
            this.lblInfo.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Location = new System.Drawing.Point(3, 366);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(110, 13);
            this.lblInfo.TabIndex = 23;
            this.lblInfo.Text = "* Campos Obligatorios";
            // 
            // frmObraSocial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 396);
            this.Controls.Add(this.tlpPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmObraSocial";
            this.Text = "frmAuxABM";
            this.Load += new System.EventHandler(this.frmAuxABM_Load);
            this.tlpPanel.ResumeLayout(false);
            this.tlpPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPanel;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDetalle;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblCiudad;
        private System.Windows.Forms.Label lblBarrio;
        private System.Windows.Forms.ComboBox cmbCiudad;
        private System.Windows.Forms.ComboBox cmbBarrio;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Button btnAddCiudad;
        private System.Windows.Forms.Button btnAddBarrio;
        private System.Windows.Forms.Label lblTelefonos;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtTelefono1;
        private System.Windows.Forms.TextBox txtTelefono2;
        private System.Windows.Forms.Label lblTelefono1;
        private System.Windows.Forms.Label lblInfo;
    }
}