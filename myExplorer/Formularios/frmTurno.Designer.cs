namespace myExplorer.Formularios
{
    partial class frmTurno
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
            this.btnCerrar = new System.Windows.Forms.Button();
            this.tlpPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tlpTurnos = new System.Windows.Forms.TableLayoutPanel();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.btnAgregarTurno = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tslPagina = new System.Windows.Forms.ToolStripLabel();
            this.tsbSiguiente = new System.Windows.Forms.ToolStripButton();
            this.tsbAnterior = new System.Windows.Forms.ToolStripButton();
            this.tsbImprimir = new System.Windows.Forms.ToolStripButton();
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.tlpDatos = new System.Windows.Forms.TableLayoutPanel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAgrearPaciente = new System.Windows.Forms.Button();
            this.grpTurno = new System.Windows.Forms.GroupBox();
            this.tlpPanelFecha = new System.Windows.Forms.TableLayoutPanel();
            this.lblDesde = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.btnHoy = new System.Windows.Forms.Button();
            this.rbtnFecha = new System.Windows.Forms.RadioButton();
            this.lblHeader = new System.Windows.Forms.Label();
            this.rbtnPaciente = new System.Windows.Forms.RadioButton();
            this.cmsMenuEmergente = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiConfirmar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpPanel.SuspendLayout();
            this.tlpTurnos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.grpDatos.SuspendLayout();
            this.tlpDatos.SuspendLayout();
            this.grpTurno.SuspendLayout();
            this.tlpPanelFecha.SuspendLayout();
            this.cmsMenuEmergente.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Location = new System.Drawing.Point(852, 569);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(70, 39);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // tlpPanel
            // 
            this.tlpPanel.ColumnCount = 1;
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPanel.Controls.Add(this.tlpTurnos, 0, 5);
            this.tlpPanel.Controls.Add(this.grpDatos, 0, 2);
            this.tlpPanel.Controls.Add(this.btnCerrar, 0, 6);
            this.tlpPanel.Controls.Add(this.grpTurno, 0, 4);
            this.tlpPanel.Controls.Add(this.rbtnFecha, 0, 3);
            this.tlpPanel.Controls.Add(this.lblHeader, 0, 0);
            this.tlpPanel.Controls.Add(this.rbtnPaciente, 0, 1);
            this.tlpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPanel.Location = new System.Drawing.Point(0, 0);
            this.tlpPanel.Name = "tlpPanel";
            this.tlpPanel.RowCount = 7;
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpPanel.Size = new System.Drawing.Size(925, 611);
            this.tlpPanel.TabIndex = 1;
            // 
            // tlpTurnos
            // 
            this.tlpTurnos.ColumnCount = 3;
            this.tlpTurnos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTurnos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tlpTurnos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tlpTurnos.Controls.Add(this.dgvLista, 0, 1);
            this.tlpTurnos.Controls.Add(this.btnAgregarTurno, 0, 4);
            this.tlpTurnos.Controls.Add(this.btnEliminar, 1, 4);
            this.tlpTurnos.Controls.Add(this.btnConfirmar, 2, 4);
            this.tlpTurnos.Controls.Add(this.toolStrip1, 0, 0);
            this.tlpTurnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTurnos.Location = new System.Drawing.Point(3, 215);
            this.tlpTurnos.Name = "tlpTurnos";
            this.tlpTurnos.RowCount = 5;
            this.tlpTurnos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tlpTurnos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tlpTurnos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tlpTurnos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTurnos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpTurnos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTurnos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTurnos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTurnos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTurnos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTurnos.Size = new System.Drawing.Size(919, 348);
            this.tlpTurnos.TabIndex = 18;
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.AllowUserToDeleteRows = false;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tlpTurnos.SetColumnSpan(this.dgvLista, 3);
            this.dgvLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLista.Location = new System.Drawing.Point(3, 44);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            this.tlpTurnos.SetRowSpan(this.dgvLista, 3);
            this.dgvLista.Size = new System.Drawing.Size(913, 266);
            this.dgvLista.TabIndex = 10;
            this.dgvLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellClick);
            // 
            // btnAgregarTurno
            // 
            this.btnAgregarTurno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarTurno.Location = new System.Drawing.Point(673, 316);
            this.btnAgregarTurno.Name = "btnAgregarTurno";
            this.btnAgregarTurno.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarTurno.TabIndex = 9;
            this.btnAgregarTurno.Text = "Agregar";
            this.btnAgregarTurno.UseVisualStyleBackColor = true;
            this.btnAgregarTurno.Click += new System.EventHandler(this.btnAgregarTurno_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Location = new System.Drawing.Point(757, 316);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 12;
            this.btnEliminar.Text = "Cancelar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.Location = new System.Drawing.Point(841, 316);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 11;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // toolStrip1
            // 
            this.tlpTurnos.SetColumnSpan(this.toolStrip1, 3);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslPagina,
            this.tsbSiguiente,
            this.tsbAnterior,
            this.tsbImprimir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(919, 39);
            this.toolStrip1.TabIndex = 14;
            this.toolStrip1.Text = "tsMenu";
            // 
            // tslPagina
            // 
            this.tslPagina.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslPagina.Name = "tslPagina";
            this.tslPagina.Size = new System.Drawing.Size(55, 36);
            this.tslPagina.Text = "tslPagina";
            // 
            // tsbSiguiente
            // 
            this.tsbSiguiente.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbSiguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSiguiente.Image = global::myExplorer.Properties.Resources.ArrowRight;
            this.tsbSiguiente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSiguiente.Name = "tsbSiguiente";
            this.tsbSiguiente.Size = new System.Drawing.Size(36, 36);
            this.tsbSiguiente.Text = "Siguiente";
            this.tsbSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // tsbAnterior
            // 
            this.tsbAnterior.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAnterior.Image = global::myExplorer.Properties.Resources.ArrowLeft;
            this.tsbAnterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAnterior.Name = "tsbAnterior";
            this.tsbAnterior.Size = new System.Drawing.Size(36, 36);
            this.tsbAnterior.Text = "Anterior";
            this.tsbAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // tsbImprimir
            // 
            this.tsbImprimir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbImprimir.Image = global::myExplorer.Properties.Resources.Printer;
            this.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImprimir.Name = "tsbImprimir";
            this.tsbImprimir.Size = new System.Drawing.Size(89, 36);
            this.tsbImprimir.Text = "Imprimir";
            this.tsbImprimir.Click += new System.EventHandler(this.btnImprimirTurnos_Click);
            // 
            // grpDatos
            // 
            this.grpDatos.Controls.Add(this.tlpDatos);
            this.grpDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDatos.Location = new System.Drawing.Point(3, 54);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(919, 60);
            this.grpDatos.TabIndex = 12;
            this.grpDatos.TabStop = false;
            this.grpDatos.Text = "Datos del Paciente";
            // 
            // tlpDatos
            // 
            this.tlpDatos.ColumnCount = 4;
            this.tlpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tlpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 506F));
            this.tlpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tlpDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDatos.Controls.Add(this.lblNombre, 0, 0);
            this.tlpDatos.Controls.Add(this.txtNombre, 1, 0);
            this.tlpDatos.Controls.Add(this.btnBuscar, 2, 0);
            this.tlpDatos.Controls.Add(this.btnAgrearPaciente, 3, 0);
            this.tlpDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDatos.Location = new System.Drawing.Point(3, 16);
            this.tlpDatos.Name = "tlpDatos";
            this.tlpDatos.RowCount = 1;
            this.tlpDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tlpDatos.Size = new System.Drawing.Size(913, 41);
            this.tlpDatos.TabIndex = 0;
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(8, 14);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Location = new System.Drawing.Point(58, 10);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(500, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBuscar.Location = new System.Drawing.Point(564, 9);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAgrearPaciente
            // 
            this.btnAgrearPaciente.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAgrearPaciente.Location = new System.Drawing.Point(647, 9);
            this.btnAgrearPaciente.Name = "btnAgrearPaciente";
            this.btnAgrearPaciente.Size = new System.Drawing.Size(75, 23);
            this.btnAgrearPaciente.TabIndex = 3;
            this.btnAgrearPaciente.Text = "Agregar";
            this.btnAgrearPaciente.UseVisualStyleBackColor = true;
            this.btnAgrearPaciente.Click += new System.EventHandler(this.btnAgrearPaciente_Click);
            // 
            // grpTurno
            // 
            this.grpTurno.Controls.Add(this.tlpPanelFecha);
            this.grpTurno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTurno.Location = new System.Drawing.Point(3, 145);
            this.grpTurno.Name = "grpTurno";
            this.grpTurno.Size = new System.Drawing.Size(919, 64);
            this.grpTurno.TabIndex = 13;
            this.grpTurno.TabStop = false;
            this.grpTurno.Text = "Turnos";
            // 
            // tlpPanelFecha
            // 
            this.tlpPanelFecha.ColumnCount = 6;
            this.tlpPanelFecha.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tlpPanelFecha.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tlpPanelFecha.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tlpPanelFecha.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tlpPanelFecha.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 232F));
            this.tlpPanelFecha.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPanelFecha.Controls.Add(this.lblDesde, 1, 0);
            this.tlpPanelFecha.Controls.Add(this.lblHasta, 3, 0);
            this.tlpPanelFecha.Controls.Add(this.dtpDesde, 2, 0);
            this.tlpPanelFecha.Controls.Add(this.dtpHasta, 4, 0);
            this.tlpPanelFecha.Controls.Add(this.btnMostrar, 5, 0);
            this.tlpPanelFecha.Controls.Add(this.btnHoy, 0, 0);
            this.tlpPanelFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPanelFecha.Location = new System.Drawing.Point(3, 16);
            this.tlpPanelFecha.Name = "tlpPanelFecha";
            this.tlpPanelFecha.RowCount = 1;
            this.tlpPanelFecha.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpPanelFecha.Size = new System.Drawing.Size(913, 45);
            this.tlpPanelFecha.TabIndex = 0;
            // 
            // lblDesde
            // 
            this.lblDesde.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(97, 16);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(41, 13);
            this.lblDesde.TabIndex = 15;
            this.lblDesde.Text = "Desde:";
            // 
            // lblHasta
            // 
            this.lblHasta.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(373, 16);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(38, 13);
            this.lblHasta.TabIndex = 16;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpDesde.Location = new System.Drawing.Point(144, 12);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(212, 20);
            this.dtpDesde.TabIndex = 17;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpHasta.Location = new System.Drawing.Point(417, 12);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(215, 20);
            this.dtpHasta.TabIndex = 18;
            // 
            // btnMostrar
            // 
            this.btnMostrar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnMostrar.Location = new System.Drawing.Point(649, 11);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(75, 23);
            this.btnMostrar.TabIndex = 19;
            this.btnMostrar.Text = "Mostrar";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // btnHoy
            // 
            this.btnHoy.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnHoy.ForeColor = System.Drawing.Color.Green;
            this.btnHoy.Location = new System.Drawing.Point(3, 11);
            this.btnHoy.Name = "btnHoy";
            this.btnHoy.Size = new System.Drawing.Size(75, 23);
            this.btnHoy.TabIndex = 14;
            this.btnHoy.Text = "Hoy";
            this.btnHoy.UseVisualStyleBackColor = true;
            this.btnHoy.Click += new System.EventHandler(this.btnHoy_Click);
            // 
            // rbtnFecha
            // 
            this.rbtnFecha.AutoSize = true;
            this.rbtnFecha.Location = new System.Drawing.Point(3, 120);
            this.rbtnFecha.Name = "rbtnFecha";
            this.rbtnFecha.Size = new System.Drawing.Size(138, 17);
            this.rbtnFecha.TabIndex = 16;
            this.rbtnFecha.TabStop = true;
            this.rbtnFecha.Text = "Buscar turnos por fecha";
            this.rbtnFecha.UseVisualStyleBackColor = true;
            this.rbtnFecha.CheckedChanged += new System.EventHandler(this.rbtnFecha_CheckedChanged);
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHeader.AutoSize = true;
            this.lblHeader.Location = new System.Drawing.Point(3, 7);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(256, 13);
            this.lblHeader.TabIndex = 14;
            this.lblHeader.Text = "En esta ventana asignara los turnos a los pacientes. ";
            // 
            // rbtnPaciente
            // 
            this.rbtnPaciente.AutoSize = true;
            this.rbtnPaciente.Location = new System.Drawing.Point(3, 30);
            this.rbtnPaciente.Name = "rbtnPaciente";
            this.rbtnPaciente.Size = new System.Drawing.Size(152, 17);
            this.rbtnPaciente.TabIndex = 17;
            this.rbtnPaciente.TabStop = true;
            this.rbtnPaciente.Text = "Buscar turnos por paciente";
            this.rbtnPaciente.UseVisualStyleBackColor = true;
            this.rbtnPaciente.CheckedChanged += new System.EventHandler(this.rbtnPaciente_CheckedChanged);
            // 
            // cmsMenuEmergente
            // 
            this.cmsMenuEmergente.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiConfirmar,
            this.tsmiEliminar,
            this.tsmiAgregar});
            this.cmsMenuEmergente.Name = "cmsMenuEmergente";
            this.cmsMenuEmergente.Size = new System.Drawing.Size(129, 70);
            // 
            // tsmiConfirmar
            // 
            this.tsmiConfirmar.Image = global::myExplorer.Properties.Resources.EditFile;
            this.tsmiConfirmar.Name = "tsmiConfirmar";
            this.tsmiConfirmar.Size = new System.Drawing.Size(128, 22);
            this.tsmiConfirmar.Text = "Confirmar";
            this.tsmiConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // tsmiEliminar
            // 
            this.tsmiEliminar.Image = global::myExplorer.Properties.Resources.Error;
            this.tsmiEliminar.Name = "tsmiEliminar";
            this.tsmiEliminar.Size = new System.Drawing.Size(128, 22);
            this.tsmiEliminar.Text = "Cancelar";
            this.tsmiEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // tsmiAgregar
            // 
            this.tsmiAgregar.Image = global::myExplorer.Properties.Resources.Plus;
            this.tsmiAgregar.Name = "tsmiAgregar";
            this.tsmiAgregar.Size = new System.Drawing.Size(128, 22);
            this.tsmiAgregar.Text = "Agregar";
            this.tsmiAgregar.Click += new System.EventHandler(this.btnAgregarTurno_Click);
            // 
            // frmTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 611);
            this.Controls.Add(this.tlpPanel);
            this.MinimumSize = new System.Drawing.Size(556, 509);
            this.Name = "frmTurno";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Turnos";
            this.Load += new System.EventHandler(this.frmTurno_Load);
            this.tlpPanel.ResumeLayout(false);
            this.tlpPanel.PerformLayout();
            this.tlpTurnos.ResumeLayout(false);
            this.tlpTurnos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.grpDatos.ResumeLayout(false);
            this.tlpDatos.ResumeLayout(false);
            this.tlpDatos.PerformLayout();
            this.grpTurno.ResumeLayout(false);
            this.tlpPanelFecha.ResumeLayout(false);
            this.tlpPanelFecha.PerformLayout();
            this.cmsMenuEmergente.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.TableLayoutPanel tlpPanel;
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.GroupBox grpTurno;
        private System.Windows.Forms.TableLayoutPanel tlpDatos;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAgrearPaciente;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.ContextMenuStrip cmsMenuEmergente;
        private System.Windows.Forms.ToolStripMenuItem tsmiConfirmar;
        private System.Windows.Forms.ToolStripMenuItem tsmiEliminar;
        private System.Windows.Forms.ToolStripMenuItem tsmiAgregar;
        private System.Windows.Forms.Button btnHoy;
        private System.Windows.Forms.TableLayoutPanel tlpPanelFecha;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.RadioButton rbtnFecha;
        private System.Windows.Forms.RadioButton rbtnPaciente;
        private System.Windows.Forms.TableLayoutPanel tlpTurnos;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnAgregarTurno;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tslPagina;
        private System.Windows.Forms.ToolStripButton tsbSiguiente;
        private System.Windows.Forms.ToolStripButton tsbAnterior;
        private System.Windows.Forms.ToolStripButton tsbImprimir;
    }
}