namespace myExplorer.Formularios
{
    partial class frmForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmForm));
            this.btnCerrar = new System.Windows.Forms.Button();
            this.tlpPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNumeroAfiliado = new System.Windows.Forms.TextBox();
            this.lblNumeroAfiliado = new System.Windows.Forms.Label();
            this.lblEdad = new System.Windows.Forms.Label();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.lblSexo = new System.Windows.Forms.Label();
            this.rbtMasculino = new System.Windows.Forms.RadioButton();
            this.lblFechaNac = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.rbtFemenino = new System.Windows.Forms.RadioButton();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnModificarPerfil = new System.Windows.Forms.Button();
            this.cmbTipoPaciente = new System.Windows.Forms.ComboBox();
            this.lblTipoPaciente = new System.Windows.Forms.Label();
            this.cmbObraSocial = new System.Windows.Forms.ComboBox();
            this.lblObraSocial = new System.Windows.Forms.Label();
            this.pcbFoto = new System.Windows.Forms.PictureBox();
            this.lblFoto = new System.Windows.Forms.Label();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.lblBarrio = new System.Windows.Forms.Label();
            this.cmbCiudad = new System.Windows.Forms.ComboBox();
            this.cmbBarrio = new System.Windows.Forms.ComboBox();
            this.btnPlusObraSocial = new System.Windows.Forms.Button();
            this.btnPlusCiudad = new System.Windows.Forms.Button();
            this.btnPlusBarrio = new System.Windows.Forms.Button();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.lblDomicilio = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefonoParticular = new System.Windows.Forms.TextBox();
            this.lblTelefonoParticular = new System.Windows.Forms.Label();
            this.dtpUltimaVisita = new System.Windows.Forms.DateTimePicker();
            this.lblUltimaVisita = new System.Windows.Forms.Label();
            this.lblNvisitas = new System.Windows.Forms.Label();
            this.txtNvisitas = new System.Windows.Forms.TextBox();
            this.tabCarpeta = new System.Windows.Forms.TabControl();
            this.tabDatos = new System.Windows.Forms.TabPage();
            this.tabDiagnosticos = new System.Windows.Forms.TabPage();
            this.tlpPanelDiagnostico = new System.Windows.Forms.TableLayoutPanel();
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.lblIdentificacion = new System.Windows.Forms.Label();
            this.dgvDiagnostico = new System.Windows.Forms.DataGridView();
            this.lblPrimeraVisita = new System.Windows.Forms.Label();
            this.dtpPrimeraVisita = new System.Windows.Forms.DateTimePicker();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.tlpPanelPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.cmsMenuEmergente = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFoto)).BeginInit();
            this.tabCarpeta.SuspendLayout();
            this.tabDatos.SuspendLayout();
            this.tabDiagnosticos.SuspendLayout();
            this.tlpPanelDiagnostico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiagnostico)).BeginInit();
            this.tlpPanelPrincipal.SuspendLayout();
            this.cmsMenuEmergente.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCerrar.Location = new System.Drawing.Point(691, 406);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 42);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // tlpPanel
            // 
            this.tlpPanel.ColumnCount = 8;
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.9206F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.98714F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.86495F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.44848F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.627F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.11765F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tlpPanel.Controls.Add(this.lblApellido, 0, 1);
            this.tlpPanel.Controls.Add(this.txtApellido, 1, 1);
            this.tlpPanel.Controls.Add(this.txtNumeroAfiliado, 1, 0);
            this.tlpPanel.Controls.Add(this.lblNumeroAfiliado, 0, 0);
            this.tlpPanel.Controls.Add(this.lblEdad, 0, 5);
            this.tlpPanel.Controls.Add(this.txtEdad, 1, 5);
            this.tlpPanel.Controls.Add(this.lblSexo, 0, 4);
            this.tlpPanel.Controls.Add(this.rbtMasculino, 1, 4);
            this.tlpPanel.Controls.Add(this.lblFechaNac, 0, 3);
            this.tlpPanel.Controls.Add(this.lblNombre, 0, 2);
            this.tlpPanel.Controls.Add(this.txtNombre, 1, 2);
            this.tlpPanel.Controls.Add(this.dtpFechaNacimiento, 1, 3);
            this.tlpPanel.Controls.Add(this.rbtFemenino, 2, 4);
            this.tlpPanel.Controls.Add(this.btnGuardar, 6, 10);
            this.tlpPanel.Controls.Add(this.btnModificarPerfil, 5, 10);
            this.tlpPanel.Controls.Add(this.cmbTipoPaciente, 4, 1);
            this.tlpPanel.Controls.Add(this.lblTipoPaciente, 3, 1);
            this.tlpPanel.Controls.Add(this.cmbObraSocial, 4, 0);
            this.tlpPanel.Controls.Add(this.lblObraSocial, 3, 0);
            this.tlpPanel.Controls.Add(this.pcbFoto, 4, 3);
            this.tlpPanel.Controls.Add(this.lblFoto, 3, 3);
            this.tlpPanel.Controls.Add(this.lblCiudad, 0, 6);
            this.tlpPanel.Controls.Add(this.lblBarrio, 0, 7);
            this.tlpPanel.Controls.Add(this.cmbCiudad, 1, 6);
            this.tlpPanel.Controls.Add(this.cmbBarrio, 1, 7);
            this.tlpPanel.Controls.Add(this.btnPlusObraSocial, 6, 0);
            this.tlpPanel.Controls.Add(this.btnPlusCiudad, 3, 6);
            this.tlpPanel.Controls.Add(this.btnPlusBarrio, 3, 7);
            this.tlpPanel.Controls.Add(this.txtDomicilio, 1, 8);
            this.tlpPanel.Controls.Add(this.lblDomicilio, 0, 8);
            this.tlpPanel.Controls.Add(this.txtTelefono, 1, 9);
            this.tlpPanel.Controls.Add(this.lblTelefono, 0, 9);
            this.tlpPanel.Controls.Add(this.txtTelefonoParticular, 4, 9);
            this.tlpPanel.Controls.Add(this.lblTelefonoParticular, 3, 9);
            this.tlpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPanel.Location = new System.Drawing.Point(3, 3);
            this.tlpPanel.Name = "tlpPanel";
            this.tlpPanel.RowCount = 11;
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpPanel.Size = new System.Drawing.Size(755, 363);
            this.tlpPanel.TabIndex = 0;
            // 
            // lblApellido
            // 
            this.lblApellido.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(28, 38);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(44, 13);
            this.lblApellido.TabIndex = 13;
            this.lblApellido.Text = "Apellido";
            // 
            // txtApellido
            // 
            this.txtApellido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPanel.SetColumnSpan(this.txtApellido, 2);
            this.txtApellido.Location = new System.Drawing.Point(78, 35);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(202, 20);
            this.txtApellido.TabIndex = 1;
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroAfiliado_KeyPress);
            // 
            // txtNumeroAfiliado
            // 
            this.txtNumeroAfiliado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPanel.SetColumnSpan(this.txtNumeroAfiliado, 2);
            this.txtNumeroAfiliado.Location = new System.Drawing.Point(78, 5);
            this.txtNumeroAfiliado.Name = "txtNumeroAfiliado";
            this.txtNumeroAfiliado.Size = new System.Drawing.Size(202, 20);
            this.txtNumeroAfiliado.TabIndex = 0;
            // 
            // lblNumeroAfiliado
            // 
            this.lblNumeroAfiliado.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNumeroAfiliado.AutoSize = true;
            this.lblNumeroAfiliado.Location = new System.Drawing.Point(16, 8);
            this.lblNumeroAfiliado.Name = "lblNumeroAfiliado";
            this.lblNumeroAfiliado.Size = new System.Drawing.Size(56, 13);
            this.lblNumeroAfiliado.TabIndex = 12;
            this.lblNumeroAfiliado.Text = "N° Afiliado";
            // 
            // lblEdad
            // 
            this.lblEdad.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblEdad.AutoSize = true;
            this.lblEdad.Location = new System.Drawing.Point(40, 158);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(32, 13);
            this.lblEdad.TabIndex = 17;
            this.lblEdad.Text = "Edad";
            // 
            // txtEdad
            // 
            this.txtEdad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEdad.Location = new System.Drawing.Point(78, 155);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.ReadOnly = true;
            this.txtEdad.Size = new System.Drawing.Size(75, 20);
            this.txtEdad.TabIndex = 6;
            // 
            // lblSexo
            // 
            this.lblSexo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSexo.AutoSize = true;
            this.lblSexo.Location = new System.Drawing.Point(41, 128);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(31, 13);
            this.lblSexo.TabIndex = 16;
            this.lblSexo.Text = "Sexo";
            // 
            // rbtMasculino
            // 
            this.rbtMasculino.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtMasculino.AutoSize = true;
            this.rbtMasculino.Location = new System.Drawing.Point(78, 126);
            this.rbtMasculino.Name = "rbtMasculino";
            this.rbtMasculino.Size = new System.Drawing.Size(73, 17);
            this.rbtMasculino.TabIndex = 4;
            this.rbtMasculino.TabStop = true;
            this.rbtMasculino.Text = "Masculino";
            this.rbtMasculino.UseVisualStyleBackColor = true;
            // 
            // lblFechaNac
            // 
            this.lblFechaNac.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblFechaNac.AutoSize = true;
            this.lblFechaNac.Location = new System.Drawing.Point(12, 92);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(60, 26);
            this.lblFechaNac.TabIndex = 15;
            this.lblFechaNac.Text = "Fecha de Nacimiento";
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(28, 68);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 14;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPanel.SetColumnSpan(this.txtNombre, 2);
            this.txtNombre.Location = new System.Drawing.Point(78, 65);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(202, 20);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroAfiliado_KeyPress);
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPanel.SetColumnSpan(this.dtpFechaNacimiento, 2);
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(78, 95);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(202, 20);
            this.dtpFechaNacimiento.TabIndex = 3;
            this.dtpFechaNacimiento.CloseUp += new System.EventHandler(this.dtpFechaNacimiento_CloseUp);
            // 
            // rbtFemenino
            // 
            this.rbtFemenino.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtFemenino.AutoSize = true;
            this.rbtFemenino.Location = new System.Drawing.Point(159, 126);
            this.rbtFemenino.Name = "rbtFemenino";
            this.rbtFemenino.Size = new System.Drawing.Size(71, 17);
            this.rbtFemenino.TabIndex = 5;
            this.rbtFemenino.TabStop = true;
            this.rbtFemenino.Text = "Femenino";
            this.rbtFemenino.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tlpPanel.SetColumnSpan(this.btnGuardar, 2);
            this.btnGuardar.Location = new System.Drawing.Point(583, 315);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 42);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnModificarPerfil
            // 
            this.btnModificarPerfil.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnModificarPerfil.Location = new System.Drawing.Point(502, 315);
            this.btnModificarPerfil.Name = "btnModificarPerfil";
            this.btnModificarPerfil.Size = new System.Drawing.Size(75, 42);
            this.btnModificarPerfil.TabIndex = 13;
            this.btnModificarPerfil.Text = "Editar";
            this.btnModificarPerfil.UseVisualStyleBackColor = true;
            this.btnModificarPerfil.Click += new System.EventHandler(this.btnModificarPerfil_Click);
            // 
            // cmbTipoPaciente
            // 
            this.cmbTipoPaciente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPanel.SetColumnSpan(this.cmbTipoPaciente, 2);
            this.cmbTipoPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoPaciente.FormattingEnabled = true;
            this.cmbTipoPaciente.Location = new System.Drawing.Point(399, 34);
            this.cmbTipoPaciente.Name = "cmbTipoPaciente";
            this.cmbTipoPaciente.Size = new System.Drawing.Size(178, 21);
            this.cmbTipoPaciente.TabIndex = 11;
            // 
            // lblTipoPaciente
            // 
            this.lblTipoPaciente.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTipoPaciente.AutoSize = true;
            this.lblTipoPaciente.Location = new System.Drawing.Point(305, 38);
            this.lblTipoPaciente.Name = "lblTipoPaciente";
            this.lblTipoPaciente.Size = new System.Drawing.Size(88, 13);
            this.lblTipoPaciente.TabIndex = 23;
            this.lblTipoPaciente.Text = "Tipo de Paciente";
            // 
            // cmbObraSocial
            // 
            this.cmbObraSocial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPanel.SetColumnSpan(this.cmbObraSocial, 2);
            this.cmbObraSocial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbObraSocial.FormattingEnabled = true;
            this.cmbObraSocial.Location = new System.Drawing.Point(399, 4);
            this.cmbObraSocial.Name = "cmbObraSocial";
            this.cmbObraSocial.Size = new System.Drawing.Size(178, 21);
            this.cmbObraSocial.TabIndex = 9;
            // 
            // lblObraSocial
            // 
            this.lblObraSocial.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblObraSocial.AutoSize = true;
            this.lblObraSocial.Location = new System.Drawing.Point(303, 2);
            this.lblObraSocial.Name = "lblObraSocial";
            this.lblObraSocial.Size = new System.Drawing.Size(90, 26);
            this.lblObraSocial.TabIndex = 21;
            this.lblObraSocial.Text = "Afiliado a la Obra Social";
            // 
            // pcbFoto
            // 
            this.tlpPanel.SetColumnSpan(this.pcbFoto, 2);
            this.pcbFoto.Location = new System.Drawing.Point(399, 93);
            this.pcbFoto.Name = "pcbFoto";
            this.tlpPanel.SetRowSpan(this.pcbFoto, 5);
            this.pcbFoto.Size = new System.Drawing.Size(149, 142);
            this.pcbFoto.TabIndex = 26;
            this.pcbFoto.TabStop = false;
            this.pcbFoto.Visible = false;
            // 
            // lblFoto
            // 
            this.lblFoto.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblFoto.AutoSize = true;
            this.lblFoto.Location = new System.Drawing.Point(365, 98);
            this.lblFoto.Name = "lblFoto";
            this.lblFoto.Size = new System.Drawing.Size(28, 13);
            this.lblFoto.TabIndex = 27;
            this.lblFoto.Text = "Foto";
            this.lblFoto.Visible = false;
            // 
            // lblCiudad
            // 
            this.lblCiudad.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.Location = new System.Drawing.Point(32, 188);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(40, 13);
            this.lblCiudad.TabIndex = 28;
            this.lblCiudad.Text = "Ciudad";
            // 
            // lblBarrio
            // 
            this.lblBarrio.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblBarrio.AutoSize = true;
            this.lblBarrio.Location = new System.Drawing.Point(38, 218);
            this.lblBarrio.Name = "lblBarrio";
            this.lblBarrio.Size = new System.Drawing.Size(34, 13);
            this.lblBarrio.TabIndex = 29;
            this.lblBarrio.Text = "Barrio";
            // 
            // cmbCiudad
            // 
            this.cmbCiudad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPanel.SetColumnSpan(this.cmbCiudad, 2);
            this.cmbCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCiudad.FormattingEnabled = true;
            this.cmbCiudad.Location = new System.Drawing.Point(78, 184);
            this.cmbCiudad.Name = "cmbCiudad";
            this.cmbCiudad.Size = new System.Drawing.Size(202, 21);
            this.cmbCiudad.TabIndex = 30;
            this.cmbCiudad.SelectedIndexChanged += new System.EventHandler(this.cmbCiudad_SelectedIndexChanged);
            // 
            // cmbBarrio
            // 
            this.cmbBarrio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPanel.SetColumnSpan(this.cmbBarrio, 2);
            this.cmbBarrio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBarrio.FormattingEnabled = true;
            this.cmbBarrio.Location = new System.Drawing.Point(78, 214);
            this.cmbBarrio.Name = "cmbBarrio";
            this.cmbBarrio.Size = new System.Drawing.Size(202, 21);
            this.cmbBarrio.TabIndex = 31;
            // 
            // btnPlusObraSocial
            // 
            this.btnPlusObraSocial.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPlusObraSocial.Location = new System.Drawing.Point(583, 3);
            this.btnPlusObraSocial.Name = "btnPlusObraSocial";
            this.btnPlusObraSocial.Size = new System.Drawing.Size(30, 23);
            this.btnPlusObraSocial.TabIndex = 32;
            this.btnPlusObraSocial.Text = "+";
            this.btnPlusObraSocial.UseVisualStyleBackColor = true;
            this.btnPlusObraSocial.Click += new System.EventHandler(this.btnPlusObraSocial_Click);
            // 
            // btnPlusCiudad
            // 
            this.btnPlusCiudad.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPlusCiudad.Location = new System.Drawing.Point(286, 183);
            this.btnPlusCiudad.Name = "btnPlusCiudad";
            this.btnPlusCiudad.Size = new System.Drawing.Size(30, 23);
            this.btnPlusCiudad.TabIndex = 34;
            this.btnPlusCiudad.Text = "+";
            this.btnPlusCiudad.UseVisualStyleBackColor = true;
            this.btnPlusCiudad.Click += new System.EventHandler(this.btnPlusCiudad_Click);
            // 
            // btnPlusBarrio
            // 
            this.btnPlusBarrio.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPlusBarrio.Location = new System.Drawing.Point(286, 213);
            this.btnPlusBarrio.Name = "btnPlusBarrio";
            this.btnPlusBarrio.Size = new System.Drawing.Size(30, 23);
            this.btnPlusBarrio.TabIndex = 35;
            this.btnPlusBarrio.Text = "+";
            this.btnPlusBarrio.UseVisualStyleBackColor = true;
            this.btnPlusBarrio.Click += new System.EventHandler(this.btnPlusBarrio_Click);
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPanel.SetColumnSpan(this.txtDomicilio, 2);
            this.txtDomicilio.Location = new System.Drawing.Point(78, 247);
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(202, 20);
            this.txtDomicilio.TabIndex = 7;
            // 
            // lblDomicilio
            // 
            this.lblDomicilio.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDomicilio.AutoSize = true;
            this.lblDomicilio.Location = new System.Drawing.Point(23, 251);
            this.lblDomicilio.Name = "lblDomicilio";
            this.lblDomicilio.Size = new System.Drawing.Size(49, 13);
            this.lblDomicilio.TabIndex = 18;
            this.lblDomicilio.Text = "Domicilio";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPanel.SetColumnSpan(this.txtTelefono, 2);
            this.txtTelefono.Location = new System.Drawing.Point(78, 282);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(202, 20);
            this.txtTelefono.TabIndex = 36;
            // 
            // lblTelefono
            // 
            this.lblTelefono.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(23, 285);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(49, 13);
            this.lblTelefono.TabIndex = 19;
            this.lblTelefono.Text = "Telefono";
            // 
            // txtTelefonoParticular
            // 
            this.txtTelefonoParticular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPanel.SetColumnSpan(this.txtTelefonoParticular, 3);
            this.txtTelefonoParticular.Location = new System.Drawing.Point(399, 282);
            this.txtTelefonoParticular.Name = "txtTelefonoParticular";
            this.txtTelefonoParticular.Size = new System.Drawing.Size(214, 20);
            this.txtTelefonoParticular.TabIndex = 37;
            // 
            // lblTelefonoParticular
            // 
            this.lblTelefonoParticular.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTelefonoParticular.AutoSize = true;
            this.lblTelefonoParticular.Location = new System.Drawing.Point(297, 285);
            this.lblTelefonoParticular.Name = "lblTelefonoParticular";
            this.lblTelefonoParticular.Size = new System.Drawing.Size(96, 13);
            this.lblTelefonoParticular.TabIndex = 38;
            this.lblTelefonoParticular.Text = "Telefono Particular";
            // 
            // dtpUltimaVisita
            // 
            this.dtpUltimaVisita.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tlpPanelDiagnostico.SetColumnSpan(this.dtpUltimaVisita, 2);
            this.dtpUltimaVisita.Enabled = false;
            this.dtpUltimaVisita.Location = new System.Drawing.Point(407, 36);
            this.dtpUltimaVisita.Name = "dtpUltimaVisita";
            this.dtpUltimaVisita.Size = new System.Drawing.Size(227, 20);
            this.dtpUltimaVisita.TabIndex = 9;
            // 
            // lblUltimaVisita
            // 
            this.lblUltimaVisita.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblUltimaVisita.AutoSize = true;
            this.lblUltimaVisita.Location = new System.Drawing.Point(337, 39);
            this.lblUltimaVisita.Name = "lblUltimaVisita";
            this.lblUltimaVisita.Size = new System.Drawing.Size(64, 13);
            this.lblUltimaVisita.TabIndex = 20;
            this.lblUltimaVisita.Text = "Ultima Visita";
            // 
            // lblNvisitas
            // 
            this.lblNvisitas.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNvisitas.AutoSize = true;
            this.lblNvisitas.Location = new System.Drawing.Point(349, 9);
            this.lblNvisitas.Name = "lblNvisitas";
            this.lblNvisitas.Size = new System.Drawing.Size(52, 13);
            this.lblNvisitas.TabIndex = 24;
            this.lblNvisitas.Text = "N° Visitas";
            // 
            // txtNvisitas
            // 
            this.txtNvisitas.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNvisitas.Location = new System.Drawing.Point(407, 5);
            this.txtNvisitas.Name = "txtNvisitas";
            this.txtNvisitas.ReadOnly = true;
            this.txtNvisitas.Size = new System.Drawing.Size(46, 20);
            this.txtNvisitas.TabIndex = 25;
            // 
            // tabCarpeta
            // 
            this.tlpPanelPrincipal.SetColumnSpan(this.tabCarpeta, 2);
            this.tabCarpeta.Controls.Add(this.tabDatos);
            this.tabCarpeta.Controls.Add(this.tabDiagnosticos);
            this.tabCarpeta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCarpeta.Location = new System.Drawing.Point(3, 3);
            this.tabCarpeta.Name = "tabCarpeta";
            this.tabCarpeta.SelectedIndex = 0;
            this.tabCarpeta.Size = new System.Drawing.Size(769, 395);
            this.tabCarpeta.TabIndex = 0;
            // 
            // tabDatos
            // 
            this.tabDatos.BackColor = System.Drawing.SystemColors.Control;
            this.tabDatos.Controls.Add(this.tlpPanel);
            this.tabDatos.Location = new System.Drawing.Point(4, 22);
            this.tabDatos.Name = "tabDatos";
            this.tabDatos.Padding = new System.Windows.Forms.Padding(3);
            this.tabDatos.Size = new System.Drawing.Size(761, 369);
            this.tabDatos.TabIndex = 0;
            this.tabDatos.Text = "Datos Personales";
            // 
            // tabDiagnosticos
            // 
            this.tabDiagnosticos.Controls.Add(this.tlpPanelDiagnostico);
            this.tabDiagnosticos.Location = new System.Drawing.Point(4, 22);
            this.tabDiagnosticos.Name = "tabDiagnosticos";
            this.tabDiagnosticos.Padding = new System.Windows.Forms.Padding(3);
            this.tabDiagnosticos.Size = new System.Drawing.Size(761, 369);
            this.tabDiagnosticos.TabIndex = 1;
            this.tabDiagnosticos.Text = "Diagnosticos";
            this.tabDiagnosticos.UseVisualStyleBackColor = true;
            // 
            // tlpPanelDiagnostico
            // 
            this.tlpPanelDiagnostico.ColumnCount = 6;
            this.tlpPanelDiagnostico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tlpPanelDiagnostico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 239F));
            this.tlpPanelDiagnostico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tlpPanelDiagnostico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 157F));
            this.tlpPanelDiagnostico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tlpPanelDiagnostico.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPanelDiagnostico.Controls.Add(this.txtIdentificacion, 1, 0);
            this.tlpPanelDiagnostico.Controls.Add(this.lblIdentificacion, 0, 0);
            this.tlpPanelDiagnostico.Controls.Add(this.dgvDiagnostico, 1, 2);
            this.tlpPanelDiagnostico.Controls.Add(this.lblUltimaVisita, 2, 1);
            this.tlpPanelDiagnostico.Controls.Add(this.lblPrimeraVisita, 0, 1);
            this.tlpPanelDiagnostico.Controls.Add(this.dtpPrimeraVisita, 1, 1);
            this.tlpPanelDiagnostico.Controls.Add(this.lblNvisitas, 2, 0);
            this.tlpPanelDiagnostico.Controls.Add(this.txtNvisitas, 3, 0);
            this.tlpPanelDiagnostico.Controls.Add(this.dtpUltimaVisita, 3, 1);
            this.tlpPanelDiagnostico.Controls.Add(this.btnAgregar, 5, 4);
            this.tlpPanelDiagnostico.Controls.Add(this.btnModificar, 4, 4);
            this.tlpPanelDiagnostico.Controls.Add(this.btnExportar, 5, 0);
            this.tlpPanelDiagnostico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPanelDiagnostico.Location = new System.Drawing.Point(3, 3);
            this.tlpPanelDiagnostico.Name = "tlpPanelDiagnostico";
            this.tlpPanelDiagnostico.RowCount = 4;
            this.tlpPanelDiagnostico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpPanelDiagnostico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpPanelDiagnostico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tlpPanelDiagnostico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPanelDiagnostico.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tlpPanelDiagnostico.Size = new System.Drawing.Size(755, 363);
            this.tlpPanelDiagnostico.TabIndex = 0;
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtIdentificacion.Location = new System.Drawing.Point(87, 5);
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.ReadOnly = true;
            this.txtIdentificacion.Size = new System.Drawing.Size(227, 20);
            this.txtIdentificacion.TabIndex = 3;
            // 
            // lblIdentificacion
            // 
            this.lblIdentificacion.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblIdentificacion.AutoSize = true;
            this.lblIdentificacion.Location = new System.Drawing.Point(11, 9);
            this.lblIdentificacion.Name = "lblIdentificacion";
            this.lblIdentificacion.Size = new System.Drawing.Size(70, 13);
            this.lblIdentificacion.TabIndex = 26;
            this.lblIdentificacion.Text = "Identificacion";
            // 
            // dgvDiagnostico
            // 
            this.dgvDiagnostico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tlpPanelDiagnostico.SetColumnSpan(this.dgvDiagnostico, 6);
            this.dgvDiagnostico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDiagnostico.Location = new System.Drawing.Point(3, 82);
            this.dgvDiagnostico.Name = "dgvDiagnostico";
            this.dgvDiagnostico.Size = new System.Drawing.Size(749, 241);
            this.dgvDiagnostico.TabIndex = 0;
            this.dgvDiagnostico.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiagnostico_CellClick);
            // 
            // lblPrimeraVisita
            // 
            this.lblPrimeraVisita.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPrimeraVisita.AutoSize = true;
            this.lblPrimeraVisita.Location = new System.Drawing.Point(11, 39);
            this.lblPrimeraVisita.Name = "lblPrimeraVisita";
            this.lblPrimeraVisita.Size = new System.Drawing.Size(70, 13);
            this.lblPrimeraVisita.TabIndex = 27;
            this.lblPrimeraVisita.Text = "Primera Visita";
            // 
            // dtpPrimeraVisita
            // 
            this.dtpPrimeraVisita.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpPrimeraVisita.Enabled = false;
            this.dtpPrimeraVisita.Location = new System.Drawing.Point(87, 36);
            this.dtpPrimeraVisita.Name = "dtpPrimeraVisita";
            this.dtpPrimeraVisita.Size = new System.Drawing.Size(227, 20);
            this.dtpPrimeraVisita.TabIndex = 28;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(649, 329);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(564, 329);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 2;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExportar.Location = new System.Drawing.Point(649, 3);
            this.btnExportar.Name = "btnExportar";
            this.tlpPanelDiagnostico.SetRowSpan(this.btnExportar, 3);
            this.btnExportar.Size = new System.Drawing.Size(99, 73);
            this.btnExportar.TabIndex = 1;
            this.btnExportar.Text = "Historia Clinica";
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // tlpPanelPrincipal
            // 
            this.tlpPanelPrincipal.ColumnCount = 2;
            this.tlpPanelPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPanelPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tlpPanelPrincipal.Controls.Add(this.btnCerrar, 1, 1);
            this.tlpPanelPrincipal.Controls.Add(this.tabCarpeta, 0, 0);
            this.tlpPanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPanelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPanelPrincipal.Name = "tlpPanelPrincipal";
            this.tlpPanelPrincipal.RowCount = 2;
            this.tlpPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tlpPanelPrincipal.Size = new System.Drawing.Size(775, 454);
            this.tlpPanelPrincipal.TabIndex = 0;
            // 
            // cmsMenuEmergente
            // 
            this.cmsMenuEmergente.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificarToolStripMenuItem,
            this.agregarToolStripMenuItem});
            this.cmsMenuEmergente.Name = "cmsMenuEmergente";
            this.cmsMenuEmergente.Size = new System.Drawing.Size(153, 70);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Image = global::myExplorer.Properties.Resources.EditFile;
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.modificarToolStripMenuItem.Text = "Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Image = global::myExplorer.Properties.Resources.Plus;
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.agregarToolStripMenuItem.Text = "Agregar";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // frmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 454);
            this.Controls.Add(this.tlpPanelPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(100, 100);
            this.Name = "frmForm";
            this.Text = "Ficha Medica";
            this.Load += new System.EventHandler(this.frmForm_Load);
            this.tlpPanel.ResumeLayout(false);
            this.tlpPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFoto)).EndInit();
            this.tabCarpeta.ResumeLayout(false);
            this.tabDatos.ResumeLayout(false);
            this.tabDiagnosticos.ResumeLayout(false);
            this.tlpPanelDiagnostico.ResumeLayout(false);
            this.tlpPanelDiagnostico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiagnostico)).EndInit();
            this.tlpPanelPrincipal.ResumeLayout(false);
            this.cmsMenuEmergente.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.TableLayoutPanel tlpPanel;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DateTimePicker dtpUltimaVisita;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblFechaNac;
        private System.Windows.Forms.Label lblNumeroAfiliado;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.RadioButton rbtMasculino;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblDomicilio;
        private System.Windows.Forms.TextBox txtNumeroAfiliado;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblUltimaVisita;
        private System.Windows.Forms.RadioButton rbtFemenino;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.TabControl tabCarpeta;
        private System.Windows.Forms.TabPage tabDatos;
        private System.Windows.Forms.TabPage tabDiagnosticos;
        private System.Windows.Forms.TableLayoutPanel tlpPanelPrincipal;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TableLayoutPanel tlpPanelDiagnostico;
        private System.Windows.Forms.DataGridView dgvDiagnostico;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtIdentificacion;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.ContextMenuStrip cmsMenuEmergente;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Button btnModificarPerfil;
        private System.Windows.Forms.ComboBox cmbObraSocial;
        private System.Windows.Forms.Label lblObraSocial;
        private System.Windows.Forms.ComboBox cmbTipoPaciente;
        private System.Windows.Forms.Label lblTipoPaciente;
        private System.Windows.Forms.Label lblNvisitas;
        private System.Windows.Forms.TextBox txtNvisitas;
        private System.Windows.Forms.PictureBox pcbFoto;
        private System.Windows.Forms.Label lblFoto;
        private System.Windows.Forms.Label lblIdentificacion;
        private System.Windows.Forms.Label lblPrimeraVisita;
        private System.Windows.Forms.DateTimePicker dtpPrimeraVisita;
        private System.Windows.Forms.Label lblCiudad;
        private System.Windows.Forms.Label lblBarrio;
        private System.Windows.Forms.ComboBox cmbCiudad;
        private System.Windows.Forms.ComboBox cmbBarrio;
        private System.Windows.Forms.Button btnPlusObraSocial;
        private System.Windows.Forms.Button btnPlusCiudad;
        private System.Windows.Forms.Button btnPlusBarrio;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtTelefonoParticular;
        private System.Windows.Forms.Label lblTelefonoParticular;

    }
}