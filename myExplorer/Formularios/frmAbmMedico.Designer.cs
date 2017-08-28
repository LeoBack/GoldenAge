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
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.tbpAcceso = new System.Windows.Forms.TabPage();
            this.tlpAcceso = new System.Windows.Forms.TableLayoutPanel();
            this.lblContrasenia = new System.Windows.Forms.Label();
            this.txtContrasenia = new System.Windows.Forms.TextBox();
            this.lblNameUser = new System.Windows.Forms.Label();
            this.txtNameUser = new System.Windows.Forms.TextBox();
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
            this.tlpPanel.Size = new System.Drawing.Size(607, 474);
            this.tlpPanel.TabIndex = 0;
            // 
            // tabDatos
            // 
            this.tlpPanel.SetColumnSpan(this.tabDatos, 2);
            this.tabDatos.Controls.Add(this.tbpPerfil);
            this.tabDatos.Controls.Add(this.tbpAcceso);
            this.tabDatos.Controls.Add(this.tabPage1);
            this.tabDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDatos.Location = new System.Drawing.Point(4, 5);
            this.tabDatos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabDatos.Name = "tabDatos";
            this.tabDatos.SelectedIndex = 0;
            this.tabDatos.Size = new System.Drawing.Size(599, 407);
            this.tabDatos.TabIndex = 12;
            // 
            // tbpPerfil
            // 
            this.tbpPerfil.Controls.Add(this.tlpTab);
            this.tbpPerfil.Location = new System.Drawing.Point(4, 29);
            this.tbpPerfil.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbpPerfil.Name = "tbpPerfil";
            this.tbpPerfil.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbpPerfil.Size = new System.Drawing.Size(591, 374);
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
            this.tlpTab.Controls.Add(this.txtEmail, 1, 6);
            this.tlpTab.Controls.Add(this.lblEmail, 0, 6);
            this.tlpTab.Controls.Add(this.btnBuscar, 2, 1);
            this.tlpTab.Controls.Add(this.txtApellido, 1, 3);
            this.tlpTab.Controls.Add(this.txtNombre, 1, 2);
            this.tlpTab.Controls.Add(this.lblApellido, 0, 3);
            this.tlpTab.Controls.Add(this.lblNombre, 0, 2);
            this.tlpTab.Controls.Add(this.lblMatricula, 0, 1);
            this.tlpTab.Controls.Add(this.textBox1, 1, 1);
            this.tlpTab.Controls.Add(this.textBox2, 1, 4);
            this.tlpTab.Controls.Add(this.textBox3, 1, 5);
            this.tlpTab.Controls.Add(this.label1, 0, 4);
            this.tlpTab.Controls.Add(this.label2, 0, 5);
            this.tlpTab.Controls.Add(this.btnEditar, 2, 8);
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
            this.tlpTab.Size = new System.Drawing.Size(583, 364);
            this.tlpTab.TabIndex = 0;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(120, 227);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(333, 26);
            this.txtEmail.TabIndex = 4;
            this.txtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmail_KeyPress);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmail.Location = new System.Drawing.Point(4, 220);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(108, 40);
            this.lblEmail.TabIndex = 11;
            this.lblEmail.Text = "E-mail";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(467, 25);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBuscar.Name = "btnBuscar";
            this.tlpTab.SetRowSpan(this.btnBuscar, 2);
            this.btnBuscar.Size = new System.Drawing.Size(112, 70);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtApellido
            // 
            this.txtApellido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApellido.Location = new System.Drawing.Point(120, 107);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(333, 26);
            this.txtApellido.TabIndex = 2;
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress);
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Location = new System.Drawing.Point(120, 67);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(333, 26);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblApellido.Location = new System.Drawing.Point(4, 100);
            this.lblApellido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(108, 40);
            this.lblApellido.TabIndex = 9;
            this.lblApellido.Text = "Apellido";
            this.lblApellido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNombre.Location = new System.Drawing.Point(4, 60);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(108, 40);
            this.lblNombre.TabIndex = 8;
            this.lblNombre.Text = "Nombre";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMatricula
            // 
            this.lblMatricula.AutoSize = true;
            this.lblMatricula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMatricula.Location = new System.Drawing.Point(3, 20);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(110, 40);
            this.lblMatricula.TabIndex = 12;
            this.lblMatricula.Text = "Nº MP";
            this.lblMatricula.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(119, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(335, 26);
            this.textBox1.TabIndex = 13;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(119, 147);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(335, 26);
            this.textBox2.TabIndex = 14;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(119, 187);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(335, 26);
            this.textBox3.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 40);
            this.label1.TabIndex = 16;
            this.label1.Text = "Domicilio";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 40);
            this.label2.TabIndex = 17;
            this.label2.Text = "Telefono";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.Location = new System.Drawing.Point(467, 324);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(112, 35);
            this.btnEditar.TabIndex = 7;
            this.btnEditar.Text = "Limpiar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // tbpAcceso
            // 
            this.tbpAcceso.Controls.Add(this.tlpAcceso);
            this.tbpAcceso.Location = new System.Drawing.Point(4, 29);
            this.tbpAcceso.Name = "tbpAcceso";
            this.tbpAcceso.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAcceso.Size = new System.Drawing.Size(591, 374);
            this.tbpAcceso.TabIndex = 1;
            this.tbpAcceso.Text = "Datos de Acceso";
            this.tbpAcceso.UseVisualStyleBackColor = true;
            // 
            // tlpAcceso
            // 
            this.tlpAcceso.ColumnCount = 3;
            this.tlpAcceso.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpAcceso.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tlpAcceso.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpAcceso.Controls.Add(this.lblContrasenia, 0, 2);
            this.tlpAcceso.Controls.Add(this.txtContrasenia, 1, 2);
            this.tlpAcceso.Controls.Add(this.lblNameUser, 0, 1);
            this.tlpAcceso.Controls.Add(this.txtNameUser, 1, 1);
            this.tlpAcceso.Controls.Add(this.btnBloquear, 2, 3);
            this.tlpAcceso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAcceso.Location = new System.Drawing.Point(3, 3);
            this.tlpAcceso.Name = "tlpAcceso";
            this.tlpAcceso.RowCount = 4;
            this.tlpAcceso.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAcceso.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpAcceso.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpAcceso.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAcceso.Size = new System.Drawing.Size(585, 368);
            this.tlpAcceso.TabIndex = 0;
            this.tlpAcceso.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // lblContrasenia
            // 
            this.lblContrasenia.AutoSize = true;
            this.lblContrasenia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblContrasenia.Location = new System.Drawing.Point(4, 184);
            this.lblContrasenia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContrasenia.Name = "lblContrasenia";
            this.lblContrasenia.Size = new System.Drawing.Size(92, 42);
            this.lblContrasenia.TabIndex = 11;
            this.lblContrasenia.Text = "Contraseña";
            this.lblContrasenia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtContrasenia
            // 
            this.txtContrasenia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContrasenia.Location = new System.Drawing.Point(104, 192);
            this.txtContrasenia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtContrasenia.Name = "txtContrasenia";
            this.txtContrasenia.Size = new System.Drawing.Size(355, 26);
            this.txtContrasenia.TabIndex = 4;
            this.txtContrasenia.UseSystemPasswordChar = true;
            // 
            // lblNameUser
            // 
            this.lblNameUser.AutoSize = true;
            this.lblNameUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNameUser.Location = new System.Drawing.Point(3, 142);
            this.lblNameUser.Name = "lblNameUser";
            this.lblNameUser.Size = new System.Drawing.Size(94, 42);
            this.lblNameUser.TabIndex = 12;
            this.lblNameUser.Text = "Usuario";
            this.lblNameUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNameUser
            // 
            this.txtNameUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNameUser.Location = new System.Drawing.Point(103, 150);
            this.txtNameUser.Name = "txtNameUser";
            this.txtNameUser.Size = new System.Drawing.Size(357, 26);
            this.txtNameUser.TabIndex = 13;
            // 
            // btnBloquear
            // 
            this.btnBloquear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBloquear.Location = new System.Drawing.Point(469, 328);
            this.btnBloquear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBloquear.Name = "btnBloquear";
            this.btnBloquear.Size = new System.Drawing.Size(112, 35);
            this.btnBloquear.TabIndex = 14;
            this.btnBloquear.Text = "Bloquear";
            this.btnBloquear.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(591, 374);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.31522F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.68478F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(585, 368);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblDescripcionEspecialidad
            // 
            this.lblDescripcionEspecialidad.AutoSize = true;
            this.lblDescripcionEspecialidad.Location = new System.Drawing.Point(3, 0);
            this.lblDescripcionEspecialidad.Name = "lblDescripcionEspecialidad";
            this.lblDescripcionEspecialidad.Size = new System.Drawing.Size(424, 20);
            this.lblDescripcionEspecialidad.TabIndex = 0;
            this.lblDescripcionEspecialidad.Text = "Seleccione las especialidades en al que se desesmpeñara:";
            // 
            // clbEspecialidades
            // 
            this.clbEspecialidades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbEspecialidades.FormattingEnabled = true;
            this.clbEspecialidades.Location = new System.Drawing.Point(3, 52);
            this.clbEspecialidades.Name = "clbEspecialidades";
            this.clbEspecialidades.Size = new System.Drawing.Size(579, 313);
            this.clbEspecialidades.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGuardar.Location = new System.Drawing.Point(488, 422);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(112, 35);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 474);
            this.Controls.Add(this.tlpPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TabPage tbpAcceso;
        private System.Windows.Forms.TableLayoutPanel tlpAcceso;
        private System.Windows.Forms.Label lblContrasenia;
        private System.Windows.Forms.TextBox txtContrasenia;
        private System.Windows.Forms.Label lblNameUser;
        private System.Windows.Forms.TextBox txtNameUser;
        private System.Windows.Forms.Label lblMatricula;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblDescripcionEspecialidad;
        private System.Windows.Forms.CheckedListBox clbEspecialidades;
        private System.Windows.Forms.Button btnBloquear;
    }
}