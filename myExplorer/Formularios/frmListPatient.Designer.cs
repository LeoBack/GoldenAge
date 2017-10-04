namespace myExplorer.Formularios
{
    partial class frmListPatient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListPatient));
            this.tlpPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tslblLastName = new System.Windows.Forms.ToolStripLabel();
            this.tstxtLastName = new System.Windows.Forms.ToolStripTextBox();
            this.tslblName = new System.Windows.Forms.ToolStripLabel();
            this.tstxtName = new System.Windows.Forms.ToolStripTextBox();
            this.tslblAffiliateNumber = new System.Windows.Forms.ToolStripLabel();
            this.tstxtAffiliateNumber = new System.Windows.Forms.ToolStripTextBox();
            this.tslblSocialWork = new System.Windows.Forms.ToolStripLabel();
            this.tscmbSocialWork = new System.Windows.Forms.ToolStripComboBox();
            this.tslPagina = new System.Windows.Forms.ToolStripLabel();
            this.tsbSiguiente = new System.Windows.Forms.ToolStripButton();
            this.tsbAnterior = new System.Windows.Forms.ToolStripButton();
            this.tsbBuscar = new System.Windows.Forms.ToolStripButton();
            this.tsbImprimir = new System.Windows.Forms.ToolStripButton();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.btnClosed = new System.Windows.Forms.Button();
            this.cmsMenuEmergente = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDiagnostic = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpPanel.SuspendLayout();
            this.tsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.cmsMenuEmergente.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPanel
            // 
            this.tlpPanel.ColumnCount = 3;
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.55109F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.89783F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.tlpPanel.Controls.Add(this.tsMenu, 0, 0);
            this.tlpPanel.Controls.Add(this.dgvLista, 0, 1);
            this.tlpPanel.Controls.Add(this.btnClosed, 2, 2);
            this.tlpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPanel.Location = new System.Drawing.Point(0, 0);
            this.tlpPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tlpPanel.Name = "tlpPanel";
            this.tlpPanel.RowCount = 3;
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpPanel.Size = new System.Drawing.Size(1353, 605);
            this.tlpPanel.TabIndex = 0;
            // 
            // tsMenu
            // 
            this.tlpPanel.SetColumnSpan(this.tsMenu, 3);
            this.tsMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblLastName,
            this.tstxtLastName,
            this.tslblName,
            this.tstxtName,
            this.tslblAffiliateNumber,
            this.tstxtAffiliateNumber,
            this.tslblSocialWork,
            this.tscmbSocialWork,
            this.tslPagina,
            this.tsbSiguiente,
            this.tsbAnterior,
            this.tsbBuscar,
            this.tsbImprimir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tsMenu.Size = new System.Drawing.Size(1353, 39);
            this.tsMenu.TabIndex = 0;
            this.tsMenu.Text = "Menu";
            // 
            // tslblLastName
            // 
            this.tslblLastName.Name = "tslblLastName";
            this.tslblLastName.Size = new System.Drawing.Size(78, 36);
            this.tslblLastName.Text = "Apellido";
            // 
            // tstxtLastName
            // 
            this.tstxtLastName.Name = "tstxtLastName";
            this.tstxtLastName.Size = new System.Drawing.Size(148, 39);
            // 
            // tslblName
            // 
            this.tslblName.Name = "tslblName";
            this.tslblName.Size = new System.Drawing.Size(78, 36);
            this.tslblName.Text = "Nombre";
            // 
            // tstxtName
            // 
            this.tstxtName.Name = "tstxtName";
            this.tstxtName.Size = new System.Drawing.Size(100, 39);
            // 
            // tslblAffiliateNumber
            // 
            this.tslblAffiliateNumber.Name = "tslblAffiliateNumber";
            this.tslblAffiliateNumber.Size = new System.Drawing.Size(98, 36);
            this.tslblAffiliateNumber.Text = "N° Afiliado";
            // 
            // tstxtAffiliateNumber
            // 
            this.tstxtAffiliateNumber.Name = "tstxtAffiliateNumber";
            this.tstxtAffiliateNumber.Size = new System.Drawing.Size(148, 39);
            // 
            // tslblSocialWork
            // 
            this.tslblSocialWork.Name = "tslblSocialWork";
            this.tslblSocialWork.Size = new System.Drawing.Size(103, 36);
            this.tslblSocialWork.Text = "Obra Social";
            // 
            // tscmbSocialWork
            // 
            this.tscmbSocialWork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscmbSocialWork.Name = "tscmbSocialWork";
            this.tscmbSocialWork.Size = new System.Drawing.Size(180, 39);
            // 
            // tslPagina
            // 
            this.tslPagina.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslPagina.Name = "tslPagina";
            this.tslPagina.Size = new System.Drawing.Size(82, 36);
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
            // tsbBuscar
            // 
            this.tsbBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBuscar.Image = global::myExplorer.Properties.Resources.Search;
            this.tsbBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBuscar.Name = "tsbBuscar";
            this.tsbBuscar.Size = new System.Drawing.Size(36, 36);
            this.tsbBuscar.Text = "Buscar";
            this.tsbBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // tsbImprimir
            // 
            this.tsbImprimir.Image = global::myExplorer.Properties.Resources.Printer;
            this.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImprimir.Name = "tsbImprimir";
            this.tsbImprimir.Size = new System.Drawing.Size(116, 36);
            this.tsbImprimir.Text = "Imprimir";
            this.tsbImprimir.Click += new System.EventHandler(this.tsbImprimir_Click);
            // 
            // dgvLista
            // 
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tlpPanel.SetColumnSpan(this.dgvLista, 3);
            this.dgvLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLista.Location = new System.Drawing.Point(4, 70);
            this.dgvLista.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.Size = new System.Drawing.Size(1345, 455);
            this.dgvLista.TabIndex = 1;
            this.dgvLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellClick);
            // 
            // btnClosed
            // 
            this.btnClosed.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClosed.Location = new System.Drawing.Point(1224, 535);
            this.btnClosed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClosed.Name = "btnClosed";
            this.btnClosed.Size = new System.Drawing.Size(112, 65);
            this.btnClosed.TabIndex = 2;
            this.btnClosed.Text = "Cerrar";
            this.btnClosed.UseVisualStyleBackColor = true;
            this.btnClosed.Click += new System.EventHandler(this.btnClosed_Click);
            // 
            // cmsMenuEmergente
            // 
            this.cmsMenuEmergente.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsMenuEmergente.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSelect,
            this.tsmiDiagnostic,
            this.toolStripSeparator1,
            this.tsmiUpdate,
            this.tsmiDelete,
            this.tsmiAdd});
            this.cmsMenuEmergente.Name = "cmsMenuEmergente";
            this.cmsMenuEmergente.Size = new System.Drawing.Size(196, 160);
            // 
            // tsmiSelect
            // 
            this.tsmiSelect.Image = global::myExplorer.Properties.Resources.Clipboard;
            this.tsmiSelect.Name = "tsmiSelect";
            this.tsmiSelect.Size = new System.Drawing.Size(195, 30);
            this.tsmiSelect.Text = "Ver Ficha";
            this.tsmiSelect.Click += new System.EventHandler(this.tsmiSelect_Click);
            // 
            // tsmiDiagnostic
            // 
            this.tsmiDiagnostic.Image = global::myExplorer.Properties.Resources.Clipboard;
            this.tsmiDiagnostic.Name = "tsmiDiagnostic";
            this.tsmiDiagnostic.Size = new System.Drawing.Size(195, 30);
            this.tsmiDiagnostic.Text = "Diagnosticos";
            this.tsmiDiagnostic.Click += new System.EventHandler(this.tsmiDiagnostic_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(192, 6);
            // 
            // tsmiUpdate
            // 
            this.tsmiUpdate.Image = global::myExplorer.Properties.Resources.EditFile;
            this.tsmiUpdate.Name = "tsmiUpdate";
            this.tsmiUpdate.Size = new System.Drawing.Size(195, 30);
            this.tsmiUpdate.Text = "Modificar";
            this.tsmiUpdate.Click += new System.EventHandler(this.tsmiUpdate_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Image = global::myExplorer.Properties.Resources.Error;
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(195, 30);
            this.tsmiDelete.Text = "Eliminar";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // tsmiAdd
            // 
            this.tsmiAdd.Image = global::myExplorer.Properties.Resources.Plus;
            this.tsmiAdd.Name = "tsmiAdd";
            this.tsmiAdd.Size = new System.Drawing.Size(195, 30);
            this.tsmiAdd.Text = "Agregar";
            this.tsmiAdd.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // frmListPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 605);
            this.Controls.Add(this.tlpPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmListPatient";
            this.Text = "Buscar Pacientes";
            this.Load += new System.EventHandler(this.frmListPatient_Load);
            this.tlpPanel.ResumeLayout(false);
            this.tlpPanel.PerformLayout();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.cmsMenuEmergente.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPanel;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripLabel tslblLastName;
        private System.Windows.Forms.ToolStripTextBox tstxtLastName;
        private System.Windows.Forms.ToolStripLabel tslblAffiliateNumber;
        private System.Windows.Forms.ToolStripComboBox tscmbSocialWork;
        private System.Windows.Forms.ToolStripLabel tslblSocialWork;
        private System.Windows.Forms.ToolStripTextBox tstxtAffiliateNumber;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.Button btnClosed;
        private System.Windows.Forms.ContextMenuStrip cmsMenuEmergente;
        private System.Windows.Forms.ToolStripMenuItem tsmiSelect;
        private System.Windows.Forms.ToolStripButton tsbImprimir;
        private System.Windows.Forms.ToolStripButton tsbBuscar;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdate;
        private System.Windows.Forms.ToolStripButton tsbAnterior;
        private System.Windows.Forms.ToolStripButton tsbSiguiente;
        private System.Windows.Forms.ToolStripLabel tslPagina;
        private System.Windows.Forms.ToolStripLabel tslblName;
        private System.Windows.Forms.ToolStripTextBox tstxtName;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiDiagnostic;
    }
}