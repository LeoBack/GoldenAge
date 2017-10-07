namespace myExplorer.Formularios
{
    partial class frmAbmPatient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbmPatient));
            this.btnSave = new System.Windows.Forms.Button();
            this.tlpPanelPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.tabCarpeta = new System.Windows.Forms.TabControl();
            this.tabData = new System.Windows.Forms.TabPage();
            this.tlpPanlData = new System.Windows.Forms.TableLayoutPanel();
            this.grpDataPersonal = new System.Windows.Forms.GroupBox();
            this.tlpDataPersonal = new System.Windows.Forms.TableLayoutPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblDocument = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.cmbTypeDocument = new System.Windows.Forms.ComboBox();
            this.lblSexo = new System.Windows.Forms.Label();
            this.rbtMale = new System.Windows.Forms.RadioButton();
            this.lblBirthdate = new System.Windows.Forms.Label();
            this.dtpBirthdate = new System.Windows.Forms.DateTimePicker();
            this.txtYearOld = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.rbtFemale = new System.Windows.Forms.RadioButton();
            this.txtNumberDocument = new System.Windows.Forms.TextBox();
            this.btnLocalitation = new System.Windows.Forms.Button();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtLocationPatient = new System.Windows.Forms.TextBox();
            this.grpSocialWork = new System.Windows.Forms.GroupBox();
            this.tlpSocialWork = new System.Windows.Forms.TableLayoutPanel();
            this.lblSocialWork = new System.Windows.Forms.Label();
            this.cmbSocialWork = new System.Windows.Forms.ComboBox();
            this.lblAffiliateNumber = new System.Windows.Forms.Label();
            this.txtAffiliateNumber = new System.Windows.Forms.TextBox();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.tlpStatus = new System.Windows.Forms.TableLayoutPanel();
            this.lblReasonExit = new System.Windows.Forms.Label();
            this.txtReasonExit = new System.Windows.Forms.TextBox();
            this.lblDateAdmission = new System.Windows.Forms.Label();
            this.dtpDateAdmission = new System.Windows.Forms.DateTimePicker();
            this.lblEgressDate = new System.Windows.Forms.Label();
            this.dtpEgressDate = new System.Windows.Forms.DateTimePicker();
            this.btnBlocked = new System.Windows.Forms.Button();
            this.tbpResponsables = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLocalitationParent = new System.Windows.Forms.Button();
            this.dtvParent = new System.Windows.Forms.DataGridView();
            this.txtParentAddress = new System.Windows.Forms.TextBox();
            this.lblParentAddress = new System.Windows.Forms.Label();
            this.lblParentLocation = new System.Windows.Forms.Label();
            this.txtLocationParent = new System.Windows.Forms.TextBox();
            this.txtParentNumberDocument = new System.Windows.Forms.TextBox();
            this.lblParentNumberDocument = new System.Windows.Forms.Label();
            this.lblParentLastName = new System.Windows.Forms.Label();
            this.lblParentName = new System.Windows.Forms.Label();
            this.txtParentLastName = new System.Windows.Forms.TextBox();
            this.txtParentName = new System.Windows.Forms.TextBox();
            this.lblParentRelationship = new System.Windows.Forms.Label();
            this.cmbParentRelationship = new System.Windows.Forms.ComboBox();
            this.lblParentPhone = new System.Windows.Forms.Label();
            this.txtParentPhone = new System.Windows.Forms.TextBox();
            this.lblParentAlternativePhone = new System.Windows.Forms.Label();
            this.txtParentAlternativePhone = new System.Windows.Forms.TextBox();
            this.lblParentEmail = new System.Windows.Forms.Label();
            this.txtParentEmail = new System.Windows.Forms.TextBox();
            this.btnApplyParent = new System.Windows.Forms.Button();
            this.cmsMenuEmergente = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpPanelPrincipal.SuspendLayout();
            this.tabCarpeta.SuspendLayout();
            this.tabData.SuspendLayout();
            this.tlpPanlData.SuspendLayout();
            this.grpDataPersonal.SuspendLayout();
            this.tlpDataPersonal.SuspendLayout();
            this.grpSocialWork.SuspendLayout();
            this.tlpSocialWork.SuspendLayout();
            this.grpStatus.SuspendLayout();
            this.tlpStatus.SuspendLayout();
            this.tbpResponsables.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtvParent)).BeginInit();
            this.cmsMenuEmergente.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.Location = new System.Drawing.Point(657, 339);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tlpPanelPrincipal
            // 
            this.tlpPanelPrincipal.ColumnCount = 2;
            this.tlpPanelPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPanelPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tlpPanelPrincipal.Controls.Add(this.tabCarpeta, 0, 0);
            this.tlpPanelPrincipal.Controls.Add(this.btnSave, 1, 1);
            this.tlpPanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPanelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPanelPrincipal.Name = "tlpPanelPrincipal";
            this.tlpPanelPrincipal.RowCount = 2;
            this.tlpPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlpPanelPrincipal.Size = new System.Drawing.Size(735, 370);
            this.tlpPanelPrincipal.TabIndex = 0;
            // 
            // tabCarpeta
            // 
            this.tlpPanelPrincipal.SetColumnSpan(this.tabCarpeta, 2);
            this.tabCarpeta.Controls.Add(this.tabData);
            this.tabCarpeta.Controls.Add(this.tbpResponsables);
            this.tabCarpeta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCarpeta.Location = new System.Drawing.Point(3, 3);
            this.tabCarpeta.Name = "tabCarpeta";
            this.tabCarpeta.SelectedIndex = 0;
            this.tabCarpeta.Size = new System.Drawing.Size(729, 326);
            this.tabCarpeta.TabIndex = 0;
            // 
            // tabData
            // 
            this.tabData.BackColor = System.Drawing.SystemColors.Control;
            this.tabData.Controls.Add(this.tlpPanlData);
            this.tabData.Location = new System.Drawing.Point(4, 22);
            this.tabData.Name = "tabData";
            this.tabData.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabData.Size = new System.Drawing.Size(721, 300);
            this.tabData.TabIndex = 0;
            this.tabData.Text = "Datos Personales";
            // 
            // tlpPanlData
            // 
            this.tlpPanlData.ColumnCount = 3;
            this.tlpPanlData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.51494F));
            this.tlpPanlData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.97364F));
            this.tlpPanlData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.5993F));
            this.tlpPanlData.Controls.Add(this.grpDataPersonal, 0, 0);
            this.tlpPanlData.Controls.Add(this.grpSocialWork, 0, 1);
            this.tlpPanlData.Controls.Add(this.grpStatus, 1, 1);
            this.tlpPanlData.Controls.Add(this.btnBlocked, 2, 2);
            this.tlpPanlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPanlData.Location = new System.Drawing.Point(3, 3);
            this.tlpPanlData.Name = "tlpPanlData";
            this.tlpPanlData.RowCount = 3;
            this.tlpPanlData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.92771F));
            this.tlpPanlData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.07229F));
            this.tlpPanlData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpPanlData.Size = new System.Drawing.Size(715, 294);
            this.tlpPanlData.TabIndex = 0;
            // 
            // grpDataPersonal
            // 
            this.tlpPanlData.SetColumnSpan(this.grpDataPersonal, 3);
            this.grpDataPersonal.Controls.Add(this.tlpDataPersonal);
            this.grpDataPersonal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDataPersonal.Location = new System.Drawing.Point(2, 2);
            this.grpDataPersonal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpDataPersonal.Name = "grpDataPersonal";
            this.grpDataPersonal.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpDataPersonal.Size = new System.Drawing.Size(711, 161);
            this.grpDataPersonal.TabIndex = 50;
            this.grpDataPersonal.TabStop = false;
            this.grpDataPersonal.Text = "Datos Personales";
            // 
            // tlpDataPersonal
            // 
            this.tlpDataPersonal.ColumnCount = 7;
            this.tlpDataPersonal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tlpDataPersonal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tlpDataPersonal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.tlpDataPersonal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpDataPersonal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tlpDataPersonal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 221F));
            this.tlpDataPersonal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDataPersonal.Controls.Add(this.lblName, 4, 0);
            this.tlpDataPersonal.Controls.Add(this.txtName, 5, 0);
            this.tlpDataPersonal.Controls.Add(this.lblLastName, 0, 0);
            this.tlpDataPersonal.Controls.Add(this.txtAddress, 5, 3);
            this.tlpDataPersonal.Controls.Add(this.txtLastName, 1, 0);
            this.tlpDataPersonal.Controls.Add(this.lblDocument, 0, 2);
            this.tlpDataPersonal.Controls.Add(this.lblLocation, 0, 3);
            this.tlpDataPersonal.Controls.Add(this.cmbTypeDocument, 1, 2);
            this.tlpDataPersonal.Controls.Add(this.lblSexo, 0, 1);
            this.tlpDataPersonal.Controls.Add(this.rbtMale, 1, 1);
            this.tlpDataPersonal.Controls.Add(this.lblBirthdate, 4, 1);
            this.tlpDataPersonal.Controls.Add(this.dtpBirthdate, 5, 1);
            this.tlpDataPersonal.Controls.Add(this.txtYearOld, 6, 1);
            this.tlpDataPersonal.Controls.Add(this.txtPhone, 5, 2);
            this.tlpDataPersonal.Controls.Add(this.lblPhone, 4, 2);
            this.tlpDataPersonal.Controls.Add(this.rbtFemale, 2, 1);
            this.tlpDataPersonal.Controls.Add(this.txtNumberDocument, 2, 2);
            this.tlpDataPersonal.Controls.Add(this.btnLocalitation, 3, 3);
            this.tlpDataPersonal.Controls.Add(this.lblAddress, 4, 3);
            this.tlpDataPersonal.Controls.Add(this.txtLocationPatient, 1, 3);
            this.tlpDataPersonal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDataPersonal.Location = new System.Drawing.Point(2, 15);
            this.tlpDataPersonal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tlpDataPersonal.Name = "tlpDataPersonal";
            this.tlpDataPersonal.RowCount = 4;
            this.tlpDataPersonal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDataPersonal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDataPersonal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDataPersonal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDataPersonal.Size = new System.Drawing.Size(707, 144);
            this.tlpDataPersonal.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Location = new System.Drawing.Point(362, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(79, 36);
            this.lblName.TabIndex = 14;
            this.lblName.Text = "Nombre";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDataPersonal.SetColumnSpan(this.txtName, 2);
            this.txtName.Location = new System.Drawing.Point(447, 8);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(257, 20);
            this.txtName.TabIndex = 2;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLastName.Location = new System.Drawing.Point(3, 0);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(77, 36);
            this.lblLastName.TabIndex = 13;
            this.lblLastName.Text = "Apellido";
            this.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(447, 116);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(215, 20);
            this.txtAddress.TabIndex = 7;
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDataPersonal.SetColumnSpan(this.txtLastName, 3);
            this.txtLastName.Location = new System.Drawing.Point(86, 8);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(270, 20);
            this.txtLastName.TabIndex = 1;
            this.txtLastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // lblDocument
            // 
            this.lblDocument.AutoSize = true;
            this.lblDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDocument.Location = new System.Drawing.Point(2, 72);
            this.lblDocument.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDocument.Name = "lblDocument";
            this.lblDocument.Size = new System.Drawing.Size(79, 36);
            this.lblDocument.TabIndex = 39;
            this.lblDocument.Text = "Nº Documento";
            this.lblDocument.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLocation.Location = new System.Drawing.Point(2, 108);
            this.lblLocation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(79, 36);
            this.lblLocation.TabIndex = 48;
            this.lblLocation.Text = "localidad";
            this.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTypeDocument
            // 
            this.cmbTypeDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTypeDocument.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeDocument.FormattingEnabled = true;
            this.cmbTypeDocument.Location = new System.Drawing.Point(85, 79);
            this.cmbTypeDocument.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbTypeDocument.Name = "cmbTypeDocument";
            this.cmbTypeDocument.Size = new System.Drawing.Size(80, 21);
            this.cmbTypeDocument.TabIndex = 53;
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSexo.Location = new System.Drawing.Point(3, 36);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(77, 36);
            this.lblSexo.TabIndex = 16;
            this.lblSexo.Text = "Sexo";
            this.lblSexo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rbtMale
            // 
            this.rbtMale.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtMale.AutoSize = true;
            this.rbtMale.Location = new System.Drawing.Point(86, 45);
            this.rbtMale.Name = "rbtMale";
            this.rbtMale.Size = new System.Drawing.Size(73, 17);
            this.rbtMale.TabIndex = 4;
            this.rbtMale.TabStop = true;
            this.rbtMale.Text = "Masculino";
            this.rbtMale.UseVisualStyleBackColor = true;
            // 
            // lblBirthdate
            // 
            this.lblBirthdate.AutoSize = true;
            this.lblBirthdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBirthdate.Location = new System.Drawing.Point(362, 36);
            this.lblBirthdate.Name = "lblBirthdate";
            this.lblBirthdate.Size = new System.Drawing.Size(79, 36);
            this.lblBirthdate.TabIndex = 15;
            this.lblBirthdate.Text = "Fecha de Nacimiento";
            this.lblBirthdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpBirthdate
            // 
            this.dtpBirthdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpBirthdate.Location = new System.Drawing.Point(447, 44);
            this.dtpBirthdate.Name = "dtpBirthdate";
            this.dtpBirthdate.Size = new System.Drawing.Size(215, 20);
            this.dtpBirthdate.TabIndex = 3;
            // 
            // txtYearOld
            // 
            this.txtYearOld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtYearOld.Location = new System.Drawing.Point(668, 44);
            this.txtYearOld.Name = "txtYearOld";
            this.txtYearOld.ReadOnly = true;
            this.txtYearOld.Size = new System.Drawing.Size(36, 20);
            this.txtYearOld.TabIndex = 6;
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhone.Location = new System.Drawing.Point(447, 80);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(215, 20);
            this.txtPhone.TabIndex = 36;
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPhone.Location = new System.Drawing.Point(361, 72);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(81, 36);
            this.lblPhone.TabIndex = 54;
            this.lblPhone.Text = "Telefono";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rbtFemale
            // 
            this.rbtFemale.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rbtFemale.AutoSize = true;
            this.rbtFemale.Location = new System.Drawing.Point(170, 45);
            this.rbtFemale.Name = "rbtFemale";
            this.rbtFemale.Size = new System.Drawing.Size(71, 17);
            this.rbtFemale.TabIndex = 5;
            this.rbtFemale.TabStop = true;
            this.rbtFemale.Text = "Femenino";
            this.rbtFemale.UseVisualStyleBackColor = true;
            // 
            // txtNumberDocument
            // 
            this.txtNumberDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDataPersonal.SetColumnSpan(this.txtNumberDocument, 2);
            this.txtNumberDocument.Location = new System.Drawing.Point(169, 80);
            this.txtNumberDocument.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNumberDocument.Name = "txtNumberDocument";
            this.txtNumberDocument.Size = new System.Drawing.Size(188, 20);
            this.txtNumberDocument.TabIndex = 40;
            this.txtNumberDocument.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // btnLocalitation
            // 
            this.btnLocalitation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLocalitation.Location = new System.Drawing.Point(291, 114);
            this.btnLocalitation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLocalitation.Name = "btnLocalitation";
            this.btnLocalitation.Size = new System.Drawing.Size(66, 23);
            this.btnLocalitation.TabIndex = 55;
            this.btnLocalitation.Text = "Cambiar";
            this.btnLocalitation.UseVisualStyleBackColor = true;
            this.btnLocalitation.Click += new System.EventHandler(this.btnLocalitationPatient_Click);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAddress.Location = new System.Drawing.Point(362, 108);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(79, 36);
            this.lblAddress.TabIndex = 18;
            this.lblAddress.Text = "Domicilio";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLocationPatient
            // 
            this.txtLocationPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpDataPersonal.SetColumnSpan(this.txtLocationPatient, 2);
            this.txtLocationPatient.Location = new System.Drawing.Point(85, 116);
            this.txtLocationPatient.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLocationPatient.Name = "txtLocationPatient";
            this.txtLocationPatient.ReadOnly = true;
            this.txtLocationPatient.Size = new System.Drawing.Size(202, 20);
            this.txtLocationPatient.TabIndex = 49;
            // 
            // grpSocialWork
            // 
            this.grpSocialWork.Controls.Add(this.tlpSocialWork);
            this.grpSocialWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSocialWork.Location = new System.Drawing.Point(2, 167);
            this.grpSocialWork.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpSocialWork.Name = "grpSocialWork";
            this.grpSocialWork.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpSocialWork.Size = new System.Drawing.Size(378, 97);
            this.grpSocialWork.TabIndex = 51;
            this.grpSocialWork.TabStop = false;
            this.grpSocialWork.Text = "Datos Obra Social";
            // 
            // tlpSocialWork
            // 
            this.tlpSocialWork.ColumnCount = 3;
            this.tlpSocialWork.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.24852F));
            this.tlpSocialWork.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.75148F));
            this.tlpSocialWork.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tlpSocialWork.Controls.Add(this.lblSocialWork, 0, 0);
            this.tlpSocialWork.Controls.Add(this.cmbSocialWork, 1, 0);
            this.tlpSocialWork.Controls.Add(this.lblAffiliateNumber, 0, 1);
            this.tlpSocialWork.Controls.Add(this.txtAffiliateNumber, 1, 1);
            this.tlpSocialWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSocialWork.Location = new System.Drawing.Point(2, 15);
            this.tlpSocialWork.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tlpSocialWork.Name = "tlpSocialWork";
            this.tlpSocialWork.RowCount = 2;
            this.tlpSocialWork.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSocialWork.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSocialWork.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tlpSocialWork.Size = new System.Drawing.Size(374, 80);
            this.tlpSocialWork.TabIndex = 22;
            // 
            // lblSocialWork
            // 
            this.lblSocialWork.AutoSize = true;
            this.lblSocialWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSocialWork.Location = new System.Drawing.Point(3, 0);
            this.lblSocialWork.Name = "lblSocialWork";
            this.lblSocialWork.Size = new System.Drawing.Size(91, 40);
            this.lblSocialWork.TabIndex = 21;
            this.lblSocialWork.Text = "Obra Social";
            this.lblSocialWork.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbSocialWork
            // 
            this.cmbSocialWork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSocialWork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSocialWork.FormattingEnabled = true;
            this.cmbSocialWork.Location = new System.Drawing.Point(100, 9);
            this.cmbSocialWork.Name = "cmbSocialWork";
            this.cmbSocialWork.Size = new System.Drawing.Size(198, 21);
            this.cmbSocialWork.TabIndex = 9;
            // 
            // lblAffiliateNumber
            // 
            this.lblAffiliateNumber.AutoSize = true;
            this.lblAffiliateNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAffiliateNumber.Location = new System.Drawing.Point(3, 40);
            this.lblAffiliateNumber.Name = "lblAffiliateNumber";
            this.lblAffiliateNumber.Size = new System.Drawing.Size(91, 40);
            this.lblAffiliateNumber.TabIndex = 12;
            this.lblAffiliateNumber.Text = "N° Afiliado";
            this.lblAffiliateNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAffiliateNumber
            // 
            this.txtAffiliateNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAffiliateNumber.Location = new System.Drawing.Point(100, 50);
            this.txtAffiliateNumber.Name = "txtAffiliateNumber";
            this.txtAffiliateNumber.Size = new System.Drawing.Size(198, 20);
            this.txtAffiliateNumber.TabIndex = 0;
            this.txtAffiliateNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // grpStatus
            // 
            this.tlpPanlData.SetColumnSpan(this.grpStatus, 2);
            this.grpStatus.Controls.Add(this.tlpStatus);
            this.grpStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpStatus.Location = new System.Drawing.Point(384, 167);
            this.grpStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpStatus.Size = new System.Drawing.Size(329, 97);
            this.grpStatus.TabIndex = 52;
            this.grpStatus.TabStop = false;
            this.grpStatus.Text = "Estado";
            // 
            // tlpStatus
            // 
            this.tlpStatus.ColumnCount = 3;
            this.tlpStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.47581F));
            this.tlpStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.52419F));
            this.tlpStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tlpStatus.Controls.Add(this.lblReasonExit, 0, 2);
            this.tlpStatus.Controls.Add(this.txtReasonExit, 1, 2);
            this.tlpStatus.Controls.Add(this.lblDateAdmission, 0, 0);
            this.tlpStatus.Controls.Add(this.dtpDateAdmission, 1, 0);
            this.tlpStatus.Controls.Add(this.lblEgressDate, 0, 1);
            this.tlpStatus.Controls.Add(this.dtpEgressDate, 1, 1);
            this.tlpStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStatus.Location = new System.Drawing.Point(2, 15);
            this.tlpStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tlpStatus.Name = "tlpStatus";
            this.tlpStatus.RowCount = 3;
            this.tlpStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpStatus.Size = new System.Drawing.Size(325, 80);
            this.tlpStatus.TabIndex = 48;
            // 
            // lblReasonExit
            // 
            this.lblReasonExit.AutoSize = true;
            this.lblReasonExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReasonExit.Location = new System.Drawing.Point(2, 52);
            this.lblReasonExit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReasonExit.Name = "lblReasonExit";
            this.lblReasonExit.Size = new System.Drawing.Size(102, 28);
            this.lblReasonExit.TabIndex = 44;
            this.lblReasonExit.Text = "Motivo del Egreso";
            this.lblReasonExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtReasonExit
            // 
            this.txtReasonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReasonExit.Location = new System.Drawing.Point(108, 56);
            this.txtReasonExit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtReasonExit.Name = "txtReasonExit";
            this.txtReasonExit.Size = new System.Drawing.Size(197, 20);
            this.txtReasonExit.TabIndex = 47;
            // 
            // lblDateAdmission
            // 
            this.lblDateAdmission.AutoSize = true;
            this.lblDateAdmission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDateAdmission.Location = new System.Drawing.Point(2, 0);
            this.lblDateAdmission.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDateAdmission.Name = "lblDateAdmission";
            this.lblDateAdmission.Size = new System.Drawing.Size(102, 26);
            this.lblDateAdmission.TabIndex = 42;
            this.lblDateAdmission.Text = "Fecha Ingreso";
            this.lblDateAdmission.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpDateAdmission
            // 
            this.dtpDateAdmission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDateAdmission.Location = new System.Drawing.Point(108, 3);
            this.dtpDateAdmission.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpDateAdmission.Name = "dtpDateAdmission";
            this.dtpDateAdmission.Size = new System.Drawing.Size(197, 20);
            this.dtpDateAdmission.TabIndex = 45;
            // 
            // lblEgressDate
            // 
            this.lblEgressDate.AutoSize = true;
            this.lblEgressDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEgressDate.Location = new System.Drawing.Point(2, 26);
            this.lblEgressDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEgressDate.Name = "lblEgressDate";
            this.lblEgressDate.Size = new System.Drawing.Size(102, 26);
            this.lblEgressDate.TabIndex = 43;
            this.lblEgressDate.Text = "Fecha Egreso";
            this.lblEgressDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpEgressDate
            // 
            this.dtpEgressDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEgressDate.Location = new System.Drawing.Point(108, 29);
            this.dtpEgressDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpEgressDate.Name = "dtpEgressDate";
            this.dtpEgressDate.Size = new System.Drawing.Size(197, 20);
            this.dtpEgressDate.TabIndex = 46;
            // 
            // btnBlocked
            // 
            this.btnBlocked.Location = new System.Drawing.Point(634, 269);
            this.btnBlocked.Name = "btnBlocked";
            this.btnBlocked.Size = new System.Drawing.Size(67, 21);
            this.btnBlocked.TabIndex = 53;
            this.btnBlocked.Text = "Bloquear";
            this.btnBlocked.UseVisualStyleBackColor = true;
            this.btnBlocked.Click += new System.EventHandler(this.btnBlocked_Click);
            // 
            // tbpResponsables
            // 
            this.tbpResponsables.Controls.Add(this.tableLayoutPanel1);
            this.tbpResponsables.Location = new System.Drawing.Point(4, 22);
            this.tbpResponsables.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbpResponsables.Name = "tbpResponsables";
            this.tbpResponsables.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbpResponsables.Size = new System.Drawing.Size(721, 300);
            this.tbpResponsables.TabIndex = 2;
            this.tbpResponsables.Text = "Responsables";
            this.tbpResponsables.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.Controls.Add(this.btnLocalitationParent, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.dtvParent, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtParentAddress, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblParentAddress, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblParentLocation, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtLocationParent, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtParentNumberDocument, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblParentNumberDocument, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblParentLastName, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblParentName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtParentLastName, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtParentName, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblParentRelationship, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbParentRelationship, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblParentPhone, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtParentPhone, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblParentAlternativePhone, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.txtParentAlternativePhone, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblParentEmail, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.txtParentEmail, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.btnApplyParent, 4, 9);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(717, 296);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnLocalitationParent
            // 
            this.btnLocalitationParent.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLocalitationParent.Location = new System.Drawing.Point(545, 137);
            this.btnLocalitationParent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLocalitationParent.Name = "btnLocalitationParent";
            this.btnLocalitationParent.Size = new System.Drawing.Size(66, 21);
            this.btnLocalitationParent.TabIndex = 20;
            this.btnLocalitationParent.Text = "Cambiar";
            this.btnLocalitationParent.UseVisualStyleBackColor = true;
            this.btnLocalitationParent.Click += new System.EventHandler(this.btnLocalitationParent_Click);
            // 
            // dtvParent
            // 
            this.dtvParent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtvParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtvParent.Location = new System.Drawing.Point(2, 15);
            this.dtvParent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtvParent.Name = "dtvParent";
            this.tableLayoutPanel1.SetRowSpan(this.dtvParent, 10);
            this.dtvParent.RowTemplate.Height = 28;
            this.dtvParent.Size = new System.Drawing.Size(257, 279);
            this.dtvParent.TabIndex = 0;
            // 
            // txtParentAddress
            // 
            this.txtParentAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtParentAddress, 2);
            this.txtParentAddress.Location = new System.Drawing.Point(371, 168);
            this.txtParentAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtParentAddress.Name = "txtParentAddress";
            this.txtParentAddress.Size = new System.Drawing.Size(249, 20);
            this.txtParentAddress.TabIndex = 13;
            // 
            // lblParentAddress
            // 
            this.lblParentAddress.AutoSize = true;
            this.lblParentAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblParentAddress.Location = new System.Drawing.Point(263, 163);
            this.lblParentAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblParentAddress.Name = "lblParentAddress";
            this.lblParentAddress.Size = new System.Drawing.Size(104, 30);
            this.lblParentAddress.TabIndex = 7;
            this.lblParentAddress.Text = "Domicilio";
            this.lblParentAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblParentLocation
            // 
            this.lblParentLocation.AutoSize = true;
            this.lblParentLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblParentLocation.Location = new System.Drawing.Point(263, 133);
            this.lblParentLocation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblParentLocation.Name = "lblParentLocation";
            this.lblParentLocation.Size = new System.Drawing.Size(104, 30);
            this.lblParentLocation.TabIndex = 18;
            this.lblParentLocation.Text = "Localidad";
            this.lblParentLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLocationParent
            // 
            this.txtLocationParent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocationParent.Location = new System.Drawing.Point(371, 138);
            this.txtLocationParent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLocationParent.Name = "txtLocationParent";
            this.txtLocationParent.Size = new System.Drawing.Size(170, 20);
            this.txtLocationParent.TabIndex = 19;
            // 
            // txtParentNumberDocument
            // 
            this.txtParentNumberDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtParentNumberDocument, 2);
            this.txtParentNumberDocument.Location = new System.Drawing.Point(371, 108);
            this.txtParentNumberDocument.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtParentNumberDocument.Name = "txtParentNumberDocument";
            this.txtParentNumberDocument.Size = new System.Drawing.Size(249, 20);
            this.txtParentNumberDocument.TabIndex = 12;
            this.txtParentNumberDocument.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // lblParentNumberDocument
            // 
            this.lblParentNumberDocument.AutoSize = true;
            this.lblParentNumberDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblParentNumberDocument.Location = new System.Drawing.Point(263, 103);
            this.lblParentNumberDocument.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblParentNumberDocument.Name = "lblParentNumberDocument";
            this.lblParentNumberDocument.Size = new System.Drawing.Size(104, 30);
            this.lblParentNumberDocument.TabIndex = 5;
            this.lblParentNumberDocument.Text = "DNI";
            this.lblParentNumberDocument.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblParentLastName
            // 
            this.lblParentLastName.AutoSize = true;
            this.lblParentLastName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblParentLastName.Location = new System.Drawing.Point(263, 73);
            this.lblParentLastName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblParentLastName.Name = "lblParentLastName";
            this.lblParentLastName.Size = new System.Drawing.Size(104, 30);
            this.lblParentLastName.TabIndex = 4;
            this.lblParentLastName.Text = "Apellido";
            this.lblParentLastName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblParentName
            // 
            this.lblParentName.AutoSize = true;
            this.lblParentName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblParentName.Location = new System.Drawing.Point(263, 43);
            this.lblParentName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblParentName.Name = "lblParentName";
            this.lblParentName.Size = new System.Drawing.Size(104, 30);
            this.lblParentName.TabIndex = 3;
            this.lblParentName.Text = "Nombre";
            this.lblParentName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtParentLastName
            // 
            this.txtParentLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtParentLastName, 2);
            this.txtParentLastName.Location = new System.Drawing.Point(371, 78);
            this.txtParentLastName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtParentLastName.Name = "txtParentLastName";
            this.txtParentLastName.Size = new System.Drawing.Size(249, 20);
            this.txtParentLastName.TabIndex = 11;
            this.txtParentLastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // txtParentName
            // 
            this.txtParentName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtParentName, 2);
            this.txtParentName.Location = new System.Drawing.Point(371, 48);
            this.txtParentName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtParentName.Name = "txtParentName";
            this.txtParentName.Size = new System.Drawing.Size(249, 20);
            this.txtParentName.TabIndex = 10;
            this.txtParentName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // lblParentRelationship
            // 
            this.lblParentRelationship.AutoSize = true;
            this.lblParentRelationship.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblParentRelationship.Location = new System.Drawing.Point(263, 13);
            this.lblParentRelationship.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblParentRelationship.Name = "lblParentRelationship";
            this.lblParentRelationship.Size = new System.Drawing.Size(104, 30);
            this.lblParentRelationship.TabIndex = 9;
            this.lblParentRelationship.Text = "Parentesco";
            this.lblParentRelationship.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbParentRelationship
            // 
            this.cmbParentRelationship.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.cmbParentRelationship, 2);
            this.cmbParentRelationship.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParentRelationship.FormattingEnabled = true;
            this.cmbParentRelationship.Location = new System.Drawing.Point(371, 17);
            this.cmbParentRelationship.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbParentRelationship.Name = "cmbParentRelationship";
            this.cmbParentRelationship.Size = new System.Drawing.Size(249, 21);
            this.cmbParentRelationship.TabIndex = 17;
            // 
            // lblParentPhone
            // 
            this.lblParentPhone.AutoSize = true;
            this.lblParentPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblParentPhone.Location = new System.Drawing.Point(263, 193);
            this.lblParentPhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblParentPhone.Name = "lblParentPhone";
            this.lblParentPhone.Size = new System.Drawing.Size(104, 30);
            this.lblParentPhone.TabIndex = 2;
            this.lblParentPhone.Text = "Telefono";
            this.lblParentPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtParentPhone
            // 
            this.txtParentPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtParentPhone, 2);
            this.txtParentPhone.Location = new System.Drawing.Point(371, 198);
            this.txtParentPhone.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtParentPhone.Name = "txtParentPhone";
            this.txtParentPhone.Size = new System.Drawing.Size(249, 20);
            this.txtParentPhone.TabIndex = 16;
            this.txtParentPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // lblParentAlternativePhone
            // 
            this.lblParentAlternativePhone.AutoSize = true;
            this.lblParentAlternativePhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblParentAlternativePhone.Location = new System.Drawing.Point(263, 223);
            this.lblParentAlternativePhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblParentAlternativePhone.Name = "lblParentAlternativePhone";
            this.lblParentAlternativePhone.Size = new System.Drawing.Size(104, 30);
            this.lblParentAlternativePhone.TabIndex = 6;
            this.lblParentAlternativePhone.Text = "Telefono Alt";
            this.lblParentAlternativePhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtParentAlternativePhone
            // 
            this.txtParentAlternativePhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtParentAlternativePhone, 2);
            this.txtParentAlternativePhone.Location = new System.Drawing.Point(371, 228);
            this.txtParentAlternativePhone.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtParentAlternativePhone.Name = "txtParentAlternativePhone";
            this.txtParentAlternativePhone.Size = new System.Drawing.Size(249, 20);
            this.txtParentAlternativePhone.TabIndex = 15;
            this.txtParentAlternativePhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // lblParentEmail
            // 
            this.lblParentEmail.AutoSize = true;
            this.lblParentEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblParentEmail.Location = new System.Drawing.Point(263, 253);
            this.lblParentEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblParentEmail.Name = "lblParentEmail";
            this.lblParentEmail.Size = new System.Drawing.Size(104, 30);
            this.lblParentEmail.TabIndex = 8;
            this.lblParentEmail.Text = "Correo";
            this.lblParentEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtParentEmail
            // 
            this.txtParentEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtParentEmail, 2);
            this.txtParentEmail.Location = new System.Drawing.Point(371, 258);
            this.txtParentEmail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtParentEmail.Name = "txtParentEmail";
            this.txtParentEmail.Size = new System.Drawing.Size(249, 20);
            this.txtParentEmail.TabIndex = 14;
            // 
            // btnApplyParent
            // 
            this.btnApplyParent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyParent.Location = new System.Drawing.Point(650, 268);
            this.btnApplyParent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnApplyParent.Name = "btnApplyParent";
            this.tableLayoutPanel1.SetRowSpan(this.btnApplyParent, 2);
            this.btnApplyParent.Size = new System.Drawing.Size(65, 26);
            this.btnApplyParent.TabIndex = 1;
            this.btnApplyParent.Text = "Aplicar";
            this.btnApplyParent.UseVisualStyleBackColor = true;
            this.btnApplyParent.Click += new System.EventHandler(this.btnApplyParent_Click);
            // 
            // cmsMenuEmergente
            // 
            this.cmsMenuEmergente.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsMenuEmergente.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificarToolStripMenuItem,
            this.agregarToolStripMenuItem});
            this.cmsMenuEmergente.Name = "cmsMenuEmergente";
            this.cmsMenuEmergente.Size = new System.Drawing.Size(134, 64);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Image = global::myExplorer.Properties.Resources.EditFile;
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(133, 30);
            this.modificarToolStripMenuItem.Text = "Modificar";
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Image = global::myExplorer.Properties.Resources.Plus;
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(133, 30);
            this.agregarToolStripMenuItem.Text = "Agregar";
            // 
            // frmAbmPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 370);
            this.Controls.Add(this.tlpPanelPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(96, 88);
            this.Name = "frmAbmPatient";
            this.Text = "Abuelo (ABM)";
            this.Load += new System.EventHandler(this.frmAbmPatient_Load);
            this.tlpPanelPrincipal.ResumeLayout(false);
            this.tabCarpeta.ResumeLayout(false);
            this.tabData.ResumeLayout(false);
            this.tlpPanlData.ResumeLayout(false);
            this.grpDataPersonal.ResumeLayout(false);
            this.tlpDataPersonal.ResumeLayout(false);
            this.tlpDataPersonal.PerformLayout();
            this.grpSocialWork.ResumeLayout(false);
            this.tlpSocialWork.ResumeLayout(false);
            this.tlpSocialWork.PerformLayout();
            this.grpStatus.ResumeLayout(false);
            this.tlpStatus.ResumeLayout(false);
            this.tlpStatus.PerformLayout();
            this.tbpResponsables.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtvParent)).EndInit();
            this.cmsMenuEmergente.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPanelPrincipal;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ContextMenuStrip cmsMenuEmergente;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.Windows.Forms.TabControl tabCarpeta;
        private System.Windows.Forms.TabPage tabData;
        private System.Windows.Forms.TableLayoutPanel tlpPanlData;
        private System.Windows.Forms.GroupBox grpDataPersonal;
        private System.Windows.Forms.TableLayoutPanel tlpDataPersonal;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblDocument;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.ComboBox cmbTypeDocument;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.RadioButton rbtMale;
        private System.Windows.Forms.Label lblBirthdate;
        private System.Windows.Forms.DateTimePicker dtpBirthdate;
        private System.Windows.Forms.TextBox txtYearOld;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.RadioButton rbtFemale;
        private System.Windows.Forms.TextBox txtNumberDocument;
        private System.Windows.Forms.Button btnLocalitation;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtLocationPatient;
        private System.Windows.Forms.GroupBox grpSocialWork;
        private System.Windows.Forms.TableLayoutPanel tlpSocialWork;
        private System.Windows.Forms.Label lblSocialWork;
        private System.Windows.Forms.ComboBox cmbSocialWork;
        private System.Windows.Forms.Label lblAffiliateNumber;
        private System.Windows.Forms.TextBox txtAffiliateNumber;
        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.TableLayoutPanel tlpStatus;
        private System.Windows.Forms.Label lblReasonExit;
        private System.Windows.Forms.TextBox txtReasonExit;
        private System.Windows.Forms.Label lblDateAdmission;
        private System.Windows.Forms.DateTimePicker dtpDateAdmission;
        private System.Windows.Forms.Label lblEgressDate;
        private System.Windows.Forms.DateTimePicker dtpEgressDate;
        private System.Windows.Forms.Button btnBlocked;
        private System.Windows.Forms.TabPage tbpResponsables;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblParentName;
        private System.Windows.Forms.TextBox txtParentName;
        private System.Windows.Forms.Label lblParentLastName;
        private System.Windows.Forms.Label lblParentNumberDocument;
        private System.Windows.Forms.Label lblParentPhone;
        private System.Windows.Forms.Label lblParentAlternativePhone;
        private System.Windows.Forms.Label lblParentEmail;
        private System.Windows.Forms.Label lblParentRelationship;
        private System.Windows.Forms.DataGridView dtvParent;
        private System.Windows.Forms.TextBox txtParentLastName;
        private System.Windows.Forms.TextBox txtParentNumberDocument;
        private System.Windows.Forms.TextBox txtParentEmail;
        private System.Windows.Forms.TextBox txtParentAlternativePhone;
        private System.Windows.Forms.TextBox txtParentPhone;
        private System.Windows.Forms.ComboBox cmbParentRelationship;
        private System.Windows.Forms.Button btnApplyParent;
        private System.Windows.Forms.Label lblParentLocation;
        private System.Windows.Forms.TextBox txtParentAddress;
        private System.Windows.Forms.TextBox txtLocationParent;
        private System.Windows.Forms.Label lblParentAddress;
        private System.Windows.Forms.Button btnLocalitationParent;

    }
}