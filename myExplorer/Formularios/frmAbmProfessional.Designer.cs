﻿namespace GoldenAge.Formularios
{
    partial class frmAbmProfessional
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
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.btnLocalitation = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtProfessionalRegistration = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblProfessionalRegistration = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.tbpLogin = new System.Windows.Forms.TabPage();
            this.tlpLogin = new System.Windows.Forms.TableLayoutPanel();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.btnBlocked = new System.Windows.Forms.Button();
            this.cmbTypeAccess = new System.Windows.Forms.ComboBox();
            this.lblTypeAccess = new System.Windows.Forms.Label();
            this.tabSpeciality = new System.Windows.Forms.TabPage();
            this.tlpSpeciality = new System.Windows.Forms.TableLayoutPanel();
            this.lblDescriptionSpeciality = new System.Windows.Forms.Label();
            this.clbSpeciality = new System.Windows.Forms.CheckedListBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnUpdateSpeciality = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
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
            this.tlpPanel.Controls.Add(this.btnSave, 1, 1);
            this.tlpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPanel.Location = new System.Drawing.Point(0, 0);
            this.tlpPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tlpPanel.Name = "tlpPanel";
            this.tlpPanel.RowCount = 2;
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 417F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 178F));
            this.tlpPanel.Size = new System.Drawing.Size(608, 465);
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
            this.tabDatos.TabIndex = 0;
            // 
            // tbpPerfil
            // 
            this.tbpPerfil.Controls.Add(this.tlpTab);
            this.tbpPerfil.Location = new System.Drawing.Point(4, 29);
            this.tbpPerfil.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbpPerfil.Name = "tbpPerfil";
            this.tbpPerfil.Padding = new System.Windows.Forms.Padding(3);
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
            this.tlpTab.Controls.Add(this.lblAddress, 0, 4);
            this.tlpTab.Controls.Add(this.txtAddress, 1, 4);
            this.tlpTab.Controls.Add(this.lblLocation, 0, 5);
            this.tlpTab.Controls.Add(this.txtLocation, 1, 5);
            this.tlpTab.Controls.Add(this.lblPhone, 0, 6);
            this.tlpTab.Controls.Add(this.txtPhone, 1, 6);
            this.tlpTab.Controls.Add(this.lblEmail, 0, 7);
            this.tlpTab.Controls.Add(this.txtMail, 1, 7);
            this.tlpTab.Controls.Add(this.btnLocalitation, 2, 5);
            this.tlpTab.Controls.Add(this.txtName, 1, 1);
            this.tlpTab.Controls.Add(this.txtLastName, 1, 2);
            this.tlpTab.Controls.Add(this.txtProfessionalRegistration, 1, 3);
            this.tlpTab.Controls.Add(this.lblLastName, 0, 2);
            this.tlpTab.Controls.Add(this.lblProfessionalRegistration, 0, 3);
            this.tlpTab.Controls.Add(this.lblName, 0, 1);
            this.tlpTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTab.Location = new System.Drawing.Point(3, 3);
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
            this.tlpTab.Size = new System.Drawing.Size(586, 368);
            this.tlpTab.TabIndex = 0;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAddress.Location = new System.Drawing.Point(3, 142);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(110, 40);
            this.lblAddress.TabIndex = 6;
            this.lblAddress.Text = "Domicilio";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(118, 149);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(2);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(340, 26);
            this.txtAddress.TabIndex = 7;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLocation.Location = new System.Drawing.Point(3, 182);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(110, 40);
            this.lblLocation.TabIndex = 8;
            this.lblLocation.Text = "Localidad";
            this.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLocation
            // 
            this.txtLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocation.Location = new System.Drawing.Point(118, 189);
            this.txtLocation.Margin = new System.Windows.Forms.Padding(2);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.ReadOnly = true;
            this.txtLocation.Size = new System.Drawing.Size(340, 26);
            this.txtLocation.TabIndex = 9;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPhone.Location = new System.Drawing.Point(3, 222);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(110, 40);
            this.lblPhone.TabIndex = 11;
            this.lblPhone.Text = "Telefono";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhone.Location = new System.Drawing.Point(118, 229);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(2);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(340, 26);
            this.txtPhone.TabIndex = 12;
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmail.Location = new System.Drawing.Point(4, 262);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(108, 45);
            this.lblEmail.TabIndex = 13;
            this.lblEmail.Text = "E-mail";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMail
            // 
            this.txtMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMail.Location = new System.Drawing.Point(120, 271);
            this.txtMail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(336, 26);
            this.txtMail.TabIndex = 14;
            this.txtMail.Leave += new System.EventHandler(this.ValidarCorreoLeave);
            // 
            // btnLocalitation
            // 
            this.btnLocalitation.Location = new System.Drawing.Point(462, 184);
            this.btnLocalitation.Margin = new System.Windows.Forms.Padding(2);
            this.btnLocalitation.Name = "btnLocalitation";
            this.btnLocalitation.Size = new System.Drawing.Size(86, 34);
            this.btnLocalitation.TabIndex = 10;
            this.btnLocalitation.Text = "Cambiar";
            this.btnLocalitation.UseVisualStyleBackColor = true;
            this.btnLocalitation.Click += new System.EventHandler(this.btnLocalitation_Click);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(120, 29);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(336, 26);
            this.txtName.TabIndex = 1;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.Location = new System.Drawing.Point(120, 69);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(336, 26);
            this.txtLastName.TabIndex = 3;
            this.txtLastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // txtProfessionalRegistration
            // 
            this.txtProfessionalRegistration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProfessionalRegistration.Location = new System.Drawing.Point(118, 109);
            this.txtProfessionalRegistration.Margin = new System.Windows.Forms.Padding(2);
            this.txtProfessionalRegistration.Name = "txtProfessionalRegistration";
            this.txtProfessionalRegistration.Size = new System.Drawing.Size(340, 26);
            this.txtProfessionalRegistration.TabIndex = 5;
            this.txtProfessionalRegistration.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLastName.Location = new System.Drawing.Point(4, 62);
            this.lblLastName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(108, 40);
            this.lblLastName.TabIndex = 2;
            this.lblLastName.Text = "Apellido";
            this.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProfessionalRegistration
            // 
            this.lblProfessionalRegistration.AutoSize = true;
            this.lblProfessionalRegistration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProfessionalRegistration.Location = new System.Drawing.Point(3, 102);
            this.lblProfessionalRegistration.Name = "lblProfessionalRegistration";
            this.lblProfessionalRegistration.Size = new System.Drawing.Size(110, 40);
            this.lblProfessionalRegistration.TabIndex = 4;
            this.lblProfessionalRegistration.Text = "Nº MP";
            this.lblProfessionalRegistration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Location = new System.Drawing.Point(4, 22);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(108, 40);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Nombre";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbpLogin
            // 
            this.tbpLogin.Controls.Add(this.tlpLogin);
            this.tbpLogin.Location = new System.Drawing.Point(4, 29);
            this.tbpLogin.Margin = new System.Windows.Forms.Padding(2);
            this.tbpLogin.Name = "tbpLogin";
            this.tbpLogin.Padding = new System.Windows.Forms.Padding(2);
            this.tbpLogin.Size = new System.Drawing.Size(592, 374);
            this.tbpLogin.TabIndex = 1;
            this.tbpLogin.Text = "Datos de Acceso";
            this.tbpLogin.UseVisualStyleBackColor = true;
            // 
            // tlpLogin
            // 
            this.tlpLogin.ColumnCount = 3;
            this.tlpLogin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tlpLogin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.77778F));
            this.tlpLogin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.22222F));
            this.tlpLogin.Controls.Add(this.lblPassword, 0, 2);
            this.tlpLogin.Controls.Add(this.txtPassword, 1, 2);
            this.tlpLogin.Controls.Add(this.lblUser, 0, 1);
            this.tlpLogin.Controls.Add(this.txtUser, 1, 1);
            this.tlpLogin.Controls.Add(this.btnBlocked, 2, 4);
            this.tlpLogin.Controls.Add(this.cmbTypeAccess, 1, 3);
            this.tlpLogin.Controls.Add(this.lblTypeAccess, 0, 3);
            this.tlpLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLogin.Location = new System.Drawing.Point(2, 2);
            this.tlpLogin.Margin = new System.Windows.Forms.Padding(2);
            this.tlpLogin.Name = "tlpLogin";
            this.tlpLogin.RowCount = 5;
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLogin.Size = new System.Drawing.Size(588, 370);
            this.tlpLogin.TabIndex = 0;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPassword.Location = new System.Drawing.Point(4, 164);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(128, 42);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Contraseña";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(140, 172);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(316, 26);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUser.Location = new System.Drawing.Point(3, 122);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(130, 42);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Usuario";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUser
            // 
            this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUser.Location = new System.Drawing.Point(138, 130);
            this.txtUser.Margin = new System.Windows.Forms.Padding(2);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(320, 26);
            this.txtUser.TabIndex = 1;
            // 
            // btnBlocked
            // 
            this.btnBlocked.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBlocked.Location = new System.Drawing.Point(479, 316);
            this.btnBlocked.Name = "btnBlocked";
            this.btnBlocked.Size = new System.Drawing.Size(106, 51);
            this.btnBlocked.TabIndex = 4;
            this.btnBlocked.Text = "Bloquear";
            this.btnBlocked.UseVisualStyleBackColor = true;
            this.btnBlocked.Click += new System.EventHandler(this.btnBlocked_Click);
            // 
            // cmbTypeAccess
            // 
            this.cmbTypeAccess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTypeAccess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeAccess.FormattingEnabled = true;
            this.cmbTypeAccess.Location = new System.Drawing.Point(138, 213);
            this.cmbTypeAccess.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTypeAccess.Name = "cmbTypeAccess";
            this.cmbTypeAccess.Size = new System.Drawing.Size(320, 28);
            this.cmbTypeAccess.TabIndex = 6;
            // 
            // lblTypeAccess
            // 
            this.lblTypeAccess.AutoSize = true;
            this.lblTypeAccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTypeAccess.Location = new System.Drawing.Point(3, 206);
            this.lblTypeAccess.Name = "lblTypeAccess";
            this.lblTypeAccess.Size = new System.Drawing.Size(130, 42);
            this.lblTypeAccess.TabIndex = 5;
            this.lblTypeAccess.Text = "Tipo de Acceso";
            this.lblTypeAccess.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabSpeciality
            // 
            this.tabSpeciality.Controls.Add(this.tlpSpeciality);
            this.tabSpeciality.Location = new System.Drawing.Point(4, 29);
            this.tabSpeciality.Margin = new System.Windows.Forms.Padding(2);
            this.tabSpeciality.Name = "tabSpeciality";
            this.tabSpeciality.Padding = new System.Windows.Forms.Padding(2);
            this.tabSpeciality.Size = new System.Drawing.Size(592, 374);
            this.tabSpeciality.TabIndex = 2;
            this.tabSpeciality.Text = "Especiadades";
            this.tabSpeciality.UseVisualStyleBackColor = true;
            // 
            // tlpSpeciality
            // 
            this.tlpSpeciality.ColumnCount = 2;
            this.tlpSpeciality.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 314F));
            this.tlpSpeciality.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSpeciality.Controls.Add(this.lblDescriptionSpeciality, 0, 0);
            this.tlpSpeciality.Controls.Add(this.clbSpeciality, 0, 1);
            this.tlpSpeciality.Controls.Add(this.txtDescription, 0, 2);
            this.tlpSpeciality.Controls.Add(this.btnUpdateSpeciality, 1, 2);
            this.tlpSpeciality.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSpeciality.Location = new System.Drawing.Point(2, 2);
            this.tlpSpeciality.Margin = new System.Windows.Forms.Padding(2);
            this.tlpSpeciality.Name = "tlpSpeciality";
            this.tlpSpeciality.RowCount = 3;
            this.tlpSpeciality.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.31522F));
            this.tlpSpeciality.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.68478F));
            this.tlpSpeciality.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpSpeciality.Size = new System.Drawing.Size(588, 370);
            this.tlpSpeciality.TabIndex = 0;
            // 
            // lblDescriptionSpeciality
            // 
            this.lblDescriptionSpeciality.AutoSize = true;
            this.tlpSpeciality.SetColumnSpan(this.lblDescriptionSpeciality, 2);
            this.lblDescriptionSpeciality.Location = new System.Drawing.Point(3, 0);
            this.lblDescriptionSpeciality.Name = "lblDescriptionSpeciality";
            this.lblDescriptionSpeciality.Size = new System.Drawing.Size(424, 20);
            this.lblDescriptionSpeciality.TabIndex = 0;
            this.lblDescriptionSpeciality.Text = "Seleccione las especialidades en al que se desesmpeñara:";
            // 
            // clbSpeciality
            // 
            this.tlpSpeciality.SetColumnSpan(this.clbSpeciality, 2);
            this.clbSpeciality.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbSpeciality.FormattingEnabled = true;
            this.clbSpeciality.Location = new System.Drawing.Point(2, 45);
            this.clbSpeciality.Margin = new System.Windows.Forms.Padding(2);
            this.clbSpeciality.Name = "clbSpeciality";
            this.clbSpeciality.Size = new System.Drawing.Size(584, 277);
            this.clbSpeciality.TabIndex = 1;
            this.clbSpeciality.SelectedIndexChanged += new System.EventHandler(this.clbSpeciality_SelectedIndexChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(2, 334);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(310, 26);
            this.txtDescription.TabIndex = 2;
            // 
            // btnUpdateSpeciality
            // 
            this.btnUpdateSpeciality.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnUpdateSpeciality.Location = new System.Drawing.Point(316, 326);
            this.btnUpdateSpeciality.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdateSpeciality.Name = "btnUpdateSpeciality";
            this.btnUpdateSpeciality.Size = new System.Drawing.Size(111, 42);
            this.btnUpdateSpeciality.TabIndex = 3;
            this.btnUpdateSpeciality.Text = "Modificar";
            this.btnUpdateSpeciality.UseVisualStyleBackColor = true;
            this.btnUpdateSpeciality.Click += new System.EventHandler(this.btnUpdateSpeciality_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.Location = new System.Drawing.Point(489, 422);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 35);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmAbmProfessional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 465);
            this.Controls.Add(this.tlpPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbmProfessional";
            this.Text = "Profesional (ABM)";
            this.Load += new System.EventHandler(this.frmAbmProfessional_Load);
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
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tabDatos;
        private System.Windows.Forms.TabPage tbpPerfil;
        private System.Windows.Forms.TableLayoutPanel tlpTab;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label lblEmail;
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
        private System.Windows.Forms.Button btnBlocked;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Button btnLocalitation;
        private System.Windows.Forms.ComboBox cmbTypeAccess;
        private System.Windows.Forms.Label lblTypeAccess;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnUpdateSpeciality;
    }
}