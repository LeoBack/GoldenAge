namespace myExplorer.Formularios
{
    partial class frmProfessional
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
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblProfessionalRegistration = new System.Windows.Forms.Label();
            this.txtProfessionalRegistration = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.tbpLogin = new System.Windows.Forms.TabPage();
            this.tlpLogin = new System.Windows.Forms.TableLayoutPanel();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.btnBloquear = new System.Windows.Forms.Button();
            this.tabSpeciality = new System.Windows.Forms.TabPage();
            this.tlpSpeciality = new System.Windows.Forms.TableLayoutPanel();
            this.lblDescriptionSpeciality = new System.Windows.Forms.Label();
            this.clbSpeciality = new System.Windows.Forms.CheckedListBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.tlpPanel.SuspendLayout();
            this.tabDatos.SuspendLayout();
            this.tbpPerfil.SuspendLayout();
            this.tlpTab.SuspendLayout();
            this.tbpLogin.SuspendLayout();
            this.tlpLogin.SuspendLayout();
            this.tabSpeciality.SuspendLayout();
            this.tlpSpeciality.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPanel
            // 
            this.tlpPanel.ColumnCount = 2;
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tlpPanel.Controls.Add(this.tabDatos, 0, 0);
            this.tlpPanel.Controls.Add(this.btnGuardar, 1, 1);
            this.tlpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPanel.Location = new System.Drawing.Point(0, 0);
            this.tlpPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tlpPanel.Name = "tlpPanel";
            this.tlpPanel.RowCount = 2;
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 417F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 178F));
            this.tlpPanel.Size = new System.Drawing.Size(608, 464);
            this.tlpPanel.TabIndex = 0;
            // 
            // tabDatos
            // 
            this.tlpPanel.SetColumnSpan(this.tabDatos, 2);
            this.tabDatos.Controls.Add(this.tbpPerfil);
            this.tabDatos.Controls.Add(this.tbpLogin);
            this.tabDatos.Controls.Add(this.tabSpeciality);
            this.tabDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDatos.Location = new System.Drawing.Point(4, 5);
            this.tabDatos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabDatos.Name = "tabDatos";
            this.tabDatos.SelectedIndex = 0;
            this.tabDatos.Size = new System.Drawing.Size(600, 407);
            this.tabDatos.TabIndex = 12;
            // 
            // tbpPerfil
            // 
            this.tbpPerfil.Controls.Add(this.tlpTab);
            this.tbpPerfil.Location = new System.Drawing.Point(4, 29);
            this.tbpPerfil.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbpPerfil.Name = "tbpPerfil";
            this.tbpPerfil.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbpPerfil.Size = new System.Drawing.Size(592, 374);
            this.tbpPerfil.TabIndex = 0;
            this.tbpPerfil.Text = "Perfil";
            this.tbpPerfil.UseVisualStyleBackColor = true;
            // 
            // tlpTab
            // 
            this.tlpTab.ColumnCount = 3;
            this.tlpTab.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tlpTab.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTab.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tlpTab.Controls.Add(this.lblName, 0, 2);
            this.tlpTab.Controls.Add(this.txtName, 1, 2);
            this.tlpTab.Controls.Add(this.lblLastName, 0, 3);
            this.tlpTab.Controls.Add(this.txtLastName, 1, 3);
            this.tlpTab.Controls.Add(this.lblProfessionalRegistration, 0, 1);
            this.tlpTab.Controls.Add(this.txtProfessionalRegistration, 1, 1);
            this.tlpTab.Controls.Add(this.lblAddress, 0, 4);
            this.tlpTab.Controls.Add(this.txtAddress, 1, 4);
            this.tlpTab.Controls.Add(this.lblLocation, 0, 5);
            this.tlpTab.Controls.Add(this.txtLocation, 1, 5);
            this.tlpTab.Controls.Add(this.lblPhone, 0, 6);
            this.tlpTab.Controls.Add(this.txtPhone, 1, 6);
            this.tlpTab.Controls.Add(this.lblEmail, 0, 7);
            this.tlpTab.Controls.Add(this.txtMail, 1, 7);
            this.tlpTab.Controls.Add(this.btnBuscar, 2, 1);
            this.tlpTab.Controls.Add(this.btnEditar, 2, 8);
            this.tlpTab.Controls.Add(this.btnEdit, 2, 5);
            this.tlpTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTab.Location = new System.Drawing.Point(4, 5);
            this.tlpTab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tlpTab.Name = "tlpTab";
            this.tlpTab.RowCount = 9;
            this.tlpTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.38636F));
            this.tlpTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.61364F));
            this.tlpTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpTab.Size = new System.Drawing.Size(584, 364);
            this.tlpTab.TabIndex = 0;
            // 
            // txtMail
            // 
            this.txtMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMail.Location = new System.Drawing.Point(120, 268);
            this.txtMail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(334, 26);
            this.txtMail.TabIndex = 4;
            this.txtMail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmail_KeyPress);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmail.Location = new System.Drawing.Point(4, 260);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(108, 43);
            this.lblEmail.TabIndex = 11;
            this.lblEmail.Text = "E-mail";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(468, 25);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBuscar.Name = "btnBuscar";
            this.tlpTab.SetRowSpan(this.btnBuscar, 2);
            this.btnBuscar.Size = new System.Drawing.Size(112, 69);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.Location = new System.Drawing.Point(120, 107);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(334, 26);
            this.txtLastName.TabIndex = 2;
            this.txtLastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(120, 67);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(334, 26);
            this.txtName.TabIndex = 1;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLastName.Location = new System.Drawing.Point(4, 100);
            this.lblLastName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(108, 40);
            this.lblLastName.TabIndex = 9;
            this.lblLastName.Text = "Apellido";
            this.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Location = new System.Drawing.Point(4, 60);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(108, 40);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "Nombre";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProfessionalRegistration
            // 
            this.lblProfessionalRegistration.AutoSize = true;
            this.lblProfessionalRegistration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProfessionalRegistration.Location = new System.Drawing.Point(3, 20);
            this.lblProfessionalRegistration.Name = "lblProfessionalRegistration";
            this.lblProfessionalRegistration.Size = new System.Drawing.Size(110, 40);
            this.lblProfessionalRegistration.TabIndex = 12;
            this.lblProfessionalRegistration.Text = "Nº MP";
            this.lblProfessionalRegistration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProfessionalRegistration
            // 
            this.txtProfessionalRegistration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProfessionalRegistration.Location = new System.Drawing.Point(119, 27);
            this.txtProfessionalRegistration.Name = "txtProfessionalRegistration";
            this.txtProfessionalRegistration.Size = new System.Drawing.Size(336, 26);
            this.txtProfessionalRegistration.TabIndex = 13;
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(119, 147);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(336, 26);
            this.txtAddress.TabIndex = 14;
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhone.Location = new System.Drawing.Point(119, 227);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(336, 26);
            this.txtPhone.TabIndex = 15;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAddress.Location = new System.Drawing.Point(3, 140);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(110, 40);
            this.lblAddress.TabIndex = 16;
            this.lblAddress.Text = "Domicilio";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPhone.Location = new System.Drawing.Point(3, 220);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(110, 40);
            this.lblPhone.TabIndex = 17;
            this.lblPhone.Text = "Telefono";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.Location = new System.Drawing.Point(468, 324);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(112, 35);
            this.btnEditar.TabIndex = 7;
            this.btnEditar.Text = "Limpiar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // tbpLogin
            // 
            this.tbpLogin.Controls.Add(this.tlpLogin);
            this.tbpLogin.Location = new System.Drawing.Point(4, 29);
            this.tbpLogin.Name = "tbpLogin";
            this.tbpLogin.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tbpLogin.Size = new System.Drawing.Size(592, 374);
            this.tbpLogin.TabIndex = 1;
            this.tbpLogin.Text = "Datos de Acceso";
            this.tbpLogin.UseVisualStyleBackColor = true;
            // 
            // tlpLogin
            // 
            this.tlpLogin.ColumnCount = 3;
            this.tlpLogin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpLogin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tlpLogin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpLogin.Controls.Add(this.lblPassword, 0, 2);
            this.tlpLogin.Controls.Add(this.txtPassword, 1, 2);
            this.tlpLogin.Controls.Add(this.lblUser, 0, 1);
            this.tlpLogin.Controls.Add(this.txtUser, 1, 1);
            this.tlpLogin.Controls.Add(this.btnBloquear, 2, 3);
            this.tlpLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLogin.Location = new System.Drawing.Point(3, 3);
            this.tlpLogin.Name = "tlpLogin";
            this.tlpLogin.RowCount = 4;
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLogin.Size = new System.Drawing.Size(586, 368);
            this.tlpLogin.TabIndex = 0;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPassword.Location = new System.Drawing.Point(4, 184);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(92, 42);
            this.lblPassword.TabIndex = 11;
            this.lblPassword.Text = "Contraseña";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(104, 192);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(356, 26);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUser.Location = new System.Drawing.Point(3, 142);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(94, 42);
            this.lblUser.TabIndex = 12;
            this.lblUser.Text = "Usuario";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUser
            // 
            this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUser.Location = new System.Drawing.Point(103, 150);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(358, 26);
            this.txtUser.TabIndex = 13;
            // 
            // btnBloquear
            // 
            this.btnBloquear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBloquear.Location = new System.Drawing.Point(471, 328);
            this.btnBloquear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBloquear.Name = "btnBloquear";
            this.btnBloquear.Size = new System.Drawing.Size(111, 35);
            this.btnBloquear.TabIndex = 14;
            this.btnBloquear.Text = "Bloquear";
            this.btnBloquear.UseVisualStyleBackColor = true;
            // 
            // tabSpeciality
            // 
            this.tabSpeciality.Controls.Add(this.tlpSpeciality);
            this.tabSpeciality.Location = new System.Drawing.Point(4, 29);
            this.tabSpeciality.Name = "tabSpeciality";
            this.tabSpeciality.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabSpeciality.Size = new System.Drawing.Size(592, 374);
            this.tabSpeciality.TabIndex = 2;
            this.tabSpeciality.Text = "Especiadades";
            this.tabSpeciality.UseVisualStyleBackColor = true;
            // 
            // tlpSpeciality
            // 
            this.tlpSpeciality.ColumnCount = 1;
            this.tlpSpeciality.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSpeciality.Controls.Add(this.lblDescriptionSpeciality, 0, 0);
            this.tlpSpeciality.Controls.Add(this.clbSpeciality, 0, 1);
            this.tlpSpeciality.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSpeciality.Location = new System.Drawing.Point(3, 3);
            this.tlpSpeciality.Name = "tlpSpeciality";
            this.tlpSpeciality.RowCount = 2;
            this.tlpSpeciality.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.31522F));
            this.tlpSpeciality.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.68478F));
            this.tlpSpeciality.Size = new System.Drawing.Size(586, 368);
            this.tlpSpeciality.TabIndex = 0;
            // 
            // lblDescriptionSpeciality
            // 
            this.lblDescriptionSpeciality.AutoSize = true;
            this.lblDescriptionSpeciality.Location = new System.Drawing.Point(3, 0);
            this.lblDescriptionSpeciality.Name = "lblDescriptionSpeciality";
            this.lblDescriptionSpeciality.Size = new System.Drawing.Size(424, 20);
            this.lblDescriptionSpeciality.TabIndex = 0;
            this.lblDescriptionSpeciality.Text = "Seleccione las especialidades en al que se desesmpeñara:";
            // 
            // clbSpeciality
            // 
            this.clbSpeciality.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbSpeciality.FormattingEnabled = true;
            this.clbSpeciality.Location = new System.Drawing.Point(3, 52);
            this.clbSpeciality.Name = "clbSpeciality";
            this.clbSpeciality.Size = new System.Drawing.Size(580, 313);
            this.clbSpeciality.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGuardar.Location = new System.Drawing.Point(489, 422);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(112, 35);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLocation.Location = new System.Drawing.Point(3, 180);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(110, 40);
            this.lblLocation.TabIndex = 18;
            this.lblLocation.Text = "Localidad";
            this.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLocation
            // 
            this.txtLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocation.Location = new System.Drawing.Point(119, 187);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(336, 26);
            this.txtLocation.TabIndex = 19;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(461, 183);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(86, 34);
            this.btnEdit.TabIndex = 20;
            this.btnEdit.Text = "Cambiar";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // frmProfessional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 464);
            this.ControlBox = false;
            this.Controls.Add(this.tlpPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmProfessional";
            this.Text = "Profesional (ABM)";
            this.Load += new System.EventHandler(this.frmProfessional_Load);
            this.tlpPanel.ResumeLayout(false);
            this.tabDatos.ResumeLayout(false);
            this.tbpPerfil.ResumeLayout(false);
            this.tlpTab.ResumeLayout(false);
            this.tlpTab.PerformLayout();
            this.tbpLogin.ResumeLayout(false);
            this.tlpLogin.ResumeLayout(false);
            this.tlpLogin.PerformLayout();
            this.tabSpeciality.ResumeLayout(false);
            this.tlpSpeciality.ResumeLayout(false);
            this.tlpSpeciality.PerformLayout();
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
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TabPage tbpLogin;
        private System.Windows.Forms.TableLayoutPanel tlpLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblProfessionalRegistration;
        private System.Windows.Forms.TextBox txtProfessionalRegistration;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TabPage tabSpeciality;
        private System.Windows.Forms.TableLayoutPanel tlpSpeciality;
        private System.Windows.Forms.Label lblDescriptionSpeciality;
        private System.Windows.Forms.CheckedListBox clbSpeciality;
        private System.Windows.Forms.Button btnBloquear;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Button btnEdit;
    }
}