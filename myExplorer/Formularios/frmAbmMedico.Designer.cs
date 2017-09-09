namespace myExplorer.Formularios
{
    partial class frmUsuario
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
            this.tabDatos = new System.Windows.Forms.TabControl();
            this.tbpPerfil = new System.Windows.Forms.TabPage();
            this.tlpTab = new System.Windows.Forms.TableLayoutPanel();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.txtProfessionalRegistration = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.tbpAcceso = new System.Windows.Forms.TabPage();
            this.tlpAcceso = new System.Windows.Forms.TableLayoutPanel();
            this.lblContrasenia = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblNameUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.btnBloquear = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDescripcionEspecialidad = new System.Windows.Forms.Label();
            this.clbEspecialidades = new System.Windows.Forms.CheckedListBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.tlpPanel.SuspendLayout();
            this.tabDatos.SuspendLayout();
            this.tbpPerfil.SuspendLayout();
            this.tlpTab.SuspendLayout();
            this.tbpAcceso.SuspendLayout();
            this.tlpAcceso.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPanel
            // 
            this.tlpPanel.ColumnCount = 2;
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tlpPanel.Controls.Add(this.tabDatos, 0, 0);
            this.tlpPanel.Controls.Add(this.btnGuardar, 1, 1);
            this.tlpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPanel.Location = new System.Drawing.Point(0, 0);
            this.tlpPanel.Name = "tlpPanel";
            this.tlpPanel.RowCount = 2;
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 271F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tlpPanel.Size = new System.Drawing.Size(405, 308);
            this.tlpPanel.TabIndex = 0;
            // 
            // tabDatos
            // 
            this.tlpPanel.SetColumnSpan(this.tabDatos, 2);
            this.tabDatos.Controls.Add(this.tbpPerfil);
            this.tabDatos.Controls.Add(this.tbpAcceso);
            this.tabDatos.Controls.Add(this.tabPage1);
            this.tabDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDatos.Location = new System.Drawing.Point(3, 3);
            this.tabDatos.Name = "tabDatos";
            this.tabDatos.SelectedIndex = 0;
            this.tabDatos.Size = new System.Drawing.Size(399, 265);
            this.tabDatos.TabIndex = 12;
            // 
            // tbpPerfil
            // 
            this.tbpPerfil.Controls.Add(this.tlpTab);
            this.tbpPerfil.Location = new System.Drawing.Point(4, 22);
            this.tbpPerfil.Name = "tbpPerfil";
            this.tbpPerfil.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tbpPerfil.Size = new System.Drawing.Size(391, 239);
            this.tbpPerfil.TabIndex = 0;
            this.tbpPerfil.Text = "Perfil";
            this.tbpPerfil.UseVisualStyleBackColor = true;
            // 
            // tlpTab
            // 
            this.tlpTab.ColumnCount = 3;
            this.tlpTab.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tlpTab.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTab.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tlpTab.Controls.Add(this.txtMail, 1, 6);
            this.tlpTab.Controls.Add(this.lblEmail, 0, 6);
            this.tlpTab.Controls.Add(this.btnBuscar, 2, 1);
            this.tlpTab.Controls.Add(this.txtLastName, 1, 3);
            this.tlpTab.Controls.Add(this.txtName, 1, 2);
            this.tlpTab.Controls.Add(this.lblApellido, 0, 3);
            this.tlpTab.Controls.Add(this.lblNombre, 0, 2);
            this.tlpTab.Controls.Add(this.lblMatricula, 0, 1);
            this.tlpTab.Controls.Add(this.txtProfessionalRegistration, 1, 1);
            this.tlpTab.Controls.Add(this.txtAddress, 1, 4);
            this.tlpTab.Controls.Add(this.txtPhone, 1, 5);
            this.tlpTab.Controls.Add(this.label1, 0, 4);
            this.tlpTab.Controls.Add(this.label2, 0, 5);
            this.tlpTab.Controls.Add(this.btnEditar, 2, 8);
            this.tlpTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTab.Location = new System.Drawing.Point(3, 3);
            this.tlpTab.Name = "tlpTab";
            this.tlpTab.RowCount = 9;
            this.tlpTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.38636F));
            this.tlpTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.61364F));
            this.tlpTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tlpTab.Size = new System.Drawing.Size(385, 233);
            this.tlpTab.TabIndex = 0;
            // 
            // txtMail
            // 
            this.txtMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMail.Location = new System.Drawing.Point(80, 145);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(218, 20);
            this.txtMail.TabIndex = 4;
            this.txtMail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmail_KeyPress);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmail.Location = new System.Drawing.Point(3, 142);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(71, 26);
            this.lblEmail.TabIndex = 11;
            this.lblEmail.Text = "E-mail";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(307, 15);
            this.btnBuscar.Name = "btnBuscar";
            this.tlpTab.SetRowSpan(this.btnBuscar, 2);
            this.btnBuscar.Size = new System.Drawing.Size(75, 45);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.Location = new System.Drawing.Point(80, 67);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(218, 20);
            this.txtLastName.TabIndex = 2;
            this.txtLastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(80, 41);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(218, 20);
            this.txtName.TabIndex = 1;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblApellido.Location = new System.Drawing.Point(3, 64);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(71, 26);
            this.lblApellido.TabIndex = 9;
            this.lblApellido.Text = "Apellido";
            this.lblApellido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNombre.Location = new System.Drawing.Point(3, 38);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(71, 26);
            this.lblNombre.TabIndex = 8;
            this.lblNombre.Text = "Nombre";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMatricula
            // 
            this.lblMatricula.AutoSize = true;
            this.lblMatricula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMatricula.Location = new System.Drawing.Point(2, 12);
            this.lblMatricula.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(73, 26);
            this.lblMatricula.TabIndex = 12;
            this.lblMatricula.Text = "Nº MP";
            this.lblMatricula.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProfessionalRegistration
            // 
            this.txtProfessionalRegistration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProfessionalRegistration.Location = new System.Drawing.Point(79, 15);
            this.txtProfessionalRegistration.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtProfessionalRegistration.Name = "txtProfessionalRegistration";
            this.txtProfessionalRegistration.Size = new System.Drawing.Size(220, 20);
            this.txtProfessionalRegistration.TabIndex = 13;
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(79, 93);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(220, 20);
            this.txtAddress.TabIndex = 14;
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhone.Location = new System.Drawing.Point(79, 119);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(220, 20);
            this.txtPhone.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(2, 90);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 26);
            this.label1.TabIndex = 16;
            this.label1.Text = "Domicilio";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(2, 116);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 26);
            this.label2.TabIndex = 17;
            this.label2.Text = "Telefono";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.Location = new System.Drawing.Point(307, 207);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 7;
            this.btnEditar.Text = "Limpiar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // tbpAcceso
            // 
            this.tbpAcceso.Controls.Add(this.tlpAcceso);
            this.tbpAcceso.Location = new System.Drawing.Point(4, 22);
            this.tbpAcceso.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbpAcceso.Name = "tbpAcceso";
            this.tbpAcceso.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbpAcceso.Size = new System.Drawing.Size(391, 239);
            this.tbpAcceso.TabIndex = 1;
            this.tbpAcceso.Text = "Datos de Acceso";
            this.tbpAcceso.UseVisualStyleBackColor = true;
            // 
            // tlpAcceso
            // 
            this.tlpAcceso.ColumnCount = 3;
            this.tlpAcceso.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tlpAcceso.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tlpAcceso.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpAcceso.Controls.Add(this.lblContrasenia, 0, 2);
            this.tlpAcceso.Controls.Add(this.txtPassword, 1, 2);
            this.tlpAcceso.Controls.Add(this.lblNameUser, 0, 1);
            this.tlpAcceso.Controls.Add(this.txtUser, 1, 1);
            this.tlpAcceso.Controls.Add(this.btnBloquear, 2, 3);
            this.tlpAcceso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAcceso.Location = new System.Drawing.Point(2, 2);
            this.tlpAcceso.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tlpAcceso.Name = "tlpAcceso";
            this.tlpAcceso.RowCount = 4;
            this.tlpAcceso.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAcceso.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpAcceso.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpAcceso.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAcceso.Size = new System.Drawing.Size(387, 235);
            this.tlpAcceso.TabIndex = 0;
            this.tlpAcceso.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // lblContrasenia
            // 
            this.lblContrasenia.AutoSize = true;
            this.lblContrasenia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblContrasenia.Location = new System.Drawing.Point(3, 117);
            this.lblContrasenia.Name = "lblContrasenia";
            this.lblContrasenia.Size = new System.Drawing.Size(61, 27);
            this.lblContrasenia.TabIndex = 11;
            this.lblContrasenia.Text = "Contraseña";
            this.lblContrasenia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(70, 120);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(234, 20);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblNameUser
            // 
            this.lblNameUser.AutoSize = true;
            this.lblNameUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNameUser.Location = new System.Drawing.Point(2, 90);
            this.lblNameUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNameUser.Name = "lblNameUser";
            this.lblNameUser.Size = new System.Drawing.Size(63, 27);
            this.lblNameUser.TabIndex = 12;
            this.lblNameUser.Text = "Usuario";
            this.lblNameUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUser
            // 
            this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUser.Location = new System.Drawing.Point(69, 93);
            this.txtUser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(236, 20);
            this.txtUser.TabIndex = 13;
            // 
            // btnBloquear
            // 
            this.btnBloquear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBloquear.Location = new System.Drawing.Point(310, 209);
            this.btnBloquear.Name = "btnBloquear";
            this.btnBloquear.Size = new System.Drawing.Size(74, 23);
            this.btnBloquear.TabIndex = 14;
            this.btnBloquear.Text = "Bloquear";
            this.btnBloquear.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(391, 239);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Especiadades";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblDescripcionEspecialidad, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.clbEspecialidades, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.31522F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.68478F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(387, 235);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblDescripcionEspecialidad
            // 
            this.lblDescripcionEspecialidad.AutoSize = true;
            this.lblDescripcionEspecialidad.Location = new System.Drawing.Point(2, 0);
            this.lblDescripcionEspecialidad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescripcionEspecialidad.Name = "lblDescripcionEspecialidad";
            this.lblDescripcionEspecialidad.Size = new System.Drawing.Size(285, 13);
            this.lblDescripcionEspecialidad.TabIndex = 0;
            this.lblDescripcionEspecialidad.Text = "Seleccione las especialidades en al que se desesmpeñara:";
            // 
            // clbEspecialidades
            // 
            this.clbEspecialidades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbEspecialidades.FormattingEnabled = true;
            this.clbEspecialidades.Location = new System.Drawing.Point(2, 33);
            this.clbEspecialidades.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clbEspecialidades.Name = "clbEspecialidades";
            this.clbEspecialidades.Size = new System.Drawing.Size(383, 200);
            this.clbEspecialidades.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGuardar.Location = new System.Drawing.Point(325, 274);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 308);
            this.Controls.Add(this.tlpPanel);
            this.Name = "frmUsuario";
            this.Text = "ABM Medico";
            this.Load += new System.EventHandler(this.frmUsuario_Load);
            this.tlpPanel.ResumeLayout(false);
            this.tabDatos.ResumeLayout(false);
            this.tbpPerfil.ResumeLayout(false);
            this.tlpTab.ResumeLayout(false);
            this.tlpTab.PerformLayout();
            this.tbpAcceso.ResumeLayout(false);
            this.tlpAcceso.ResumeLayout(false);
            this.tlpAcceso.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPanel;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TabControl tabDatos;
        private System.Windows.Forms.TabPage tbpPerfil;
        private System.Windows.Forms.TableLayoutPanel tlpTab;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TabPage tbpAcceso;
        private System.Windows.Forms.TableLayoutPanel tlpAcceso;
        private System.Windows.Forms.Label lblContrasenia;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblNameUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblMatricula;
        private System.Windows.Forms.TextBox txtProfessionalRegistration;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblDescripcionEspecialidad;
        private System.Windows.Forms.CheckedListBox clbEspecialidades;
        private System.Windows.Forms.Button btnBloquear;
    }
}