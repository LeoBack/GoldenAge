namespace GoldenAge.Formularios
{
    partial class FrmListPatient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListPatient));
            this.TlpPanel = new System.Windows.Forms.TableLayoutPanel();
            this.TsFooter = new System.Windows.Forms.ToolStrip();
            this.TsbPrevious = new System.Windows.Forms.ToolStripLabel();
            this.TslNumberPag = new System.Windows.Forms.ToolStripLabel();
            this.TsbNext = new System.Windows.Forms.ToolStripButton();
            this.TsMenu = new System.Windows.Forms.ToolStrip();
            this.TsbAdd = new System.Windows.Forms.ToolStripButton();
            this.TssAdd = new System.Windows.Forms.ToolStripSeparator();
            this.TslblLastName = new System.Windows.Forms.ToolStripLabel();
            this.TstxtLastName = new System.Windows.Forms.ToolStripTextBox();
            this.TslblName = new System.Windows.Forms.ToolStripLabel();
            this.tstxtName = new System.Windows.Forms.ToolStripTextBox();
            this.TslDocument = new System.Windows.Forms.ToolStripLabel();
            this.TstxtDocument = new System.Windows.Forms.ToolStripTextBox();
            this.TsbToggleStatus = new System.Windows.Forms.ToolStripButton();
            this.TsbBuscar = new System.Windows.Forms.ToolStripButton();
            this.TssPrint = new System.Windows.Forms.ToolStripSeparator();
            this.TsbPrintList = new System.Windows.Forms.ToolStripButton();
            this.DgvLista = new System.Windows.Forms.DataGridView();
            this.CmsMenuEmergente = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TsmiSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiDiagnostic = new System.Windows.Forms.ToolStripMenuItem();
            this.TssMenuPrint = new System.Windows.Forms.ToolStripSeparator();
            this.TsmiPrintSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiPrintParent = new System.Windows.Forms.ToolStripMenuItem();
            this.TssMenuAbm = new System.Windows.Forms.ToolStripSeparator();
            this.TsmiUpdateFile = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiAddFile = new System.Windows.Forms.ToolStripMenuItem();
            this.TlpPanel.SuspendLayout();
            this.TsFooter.SuspendLayout();
            this.TsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLista)).BeginInit();
            this.CmsMenuEmergente.SuspendLayout();
            this.SuspendLayout();
            // 
            // TlpPanel
            // 
            this.TlpPanel.ColumnCount = 1;
            this.TlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpPanel.Controls.Add(this.TsFooter, 0, 2);
            this.TlpPanel.Controls.Add(this.TsMenu, 0, 0);
            this.TlpPanel.Controls.Add(this.DgvLista, 0, 1);
            this.TlpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpPanel.Location = new System.Drawing.Point(0, 0);
            this.TlpPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TlpPanel.Name = "TlpPanel";
            this.TlpPanel.RowCount = 3;
            this.TlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.TlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.TlpPanel.Size = new System.Drawing.Size(1237, 540);
            this.TlpPanel.TabIndex = 0;
            // 
            // TsFooter
            // 
            this.TsFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TsFooter.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.TsFooter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsbPrevious,
            this.TslNumberPag,
            this.TsbNext});
            this.TsFooter.Location = new System.Drawing.Point(0, 509);
            this.TsFooter.Name = "TsFooter";
            this.TsFooter.Size = new System.Drawing.Size(1237, 31);
            this.TsFooter.TabIndex = 9;
            this.TsFooter.Text = "toolStrip1";
            // 
            // TsbPrevious
            // 
            this.TsbPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsbPrevious.Image = global::GoldenAge.Properties.Resources.ArrowLeft;
            this.TsbPrevious.Name = "TsbPrevious";
            this.TsbPrevious.Size = new System.Drawing.Size(24, 28);
            this.TsbPrevious.Text = "tsbPreview";
            this.TsbPrevious.Click += new System.EventHandler(this.tsbPreview_Click);
            // 
            // TslNumberPag
            // 
            this.TslNumberPag.Name = "TslNumberPag";
            this.TslNumberPag.Size = new System.Drawing.Size(82, 28);
            this.TslNumberPag.Text = "tslPagina";
            // 
            // TsbNext
            // 
            this.TsbNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsbNext.Image = global::GoldenAge.Properties.Resources.ArrowRight;
            this.TsbNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbNext.Name = "TsbNext";
            this.TsbNext.Size = new System.Drawing.Size(28, 28);
            this.TsbNext.Text = "tsbNext";
            this.TsbNext.Click += new System.EventHandler(this.tsbNext_Click);
            // 
            // TsMenu
            // 
            this.TsMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.TsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsbAdd,
            this.TssAdd,
            this.TslblLastName,
            this.TstxtLastName,
            this.TslblName,
            this.tstxtName,
            this.TslDocument,
            this.TstxtDocument,
            this.TsbToggleStatus,
            this.TsbBuscar,
            this.TssPrint,
            this.TsbPrintList});
            this.TsMenu.Location = new System.Drawing.Point(0, 0);
            this.TsMenu.Name = "TsMenu";
            this.TsMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.TsMenu.Size = new System.Drawing.Size(1237, 31);
            this.TsMenu.TabIndex = 0;
            this.TsMenu.Text = "Menu";
            // 
            // TsbAdd
            // 
            this.TsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsbAdd.Image = global::GoldenAge.Properties.Resources.Plus;
            this.TsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbAdd.Name = "TsbAdd";
            this.TsbAdd.Size = new System.Drawing.Size(28, 28);
            this.TsbAdd.Text = "Nueva Ficha";
            this.TsbAdd.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // TssAdd
            // 
            this.TssAdd.Name = "TssAdd";
            this.TssAdd.Size = new System.Drawing.Size(6, 31);
            // 
            // TslblLastName
            // 
            this.TslblLastName.Name = "TslblLastName";
            this.TslblLastName.Size = new System.Drawing.Size(78, 28);
            this.TslblLastName.Text = "Apellido";
            // 
            // TstxtLastName
            // 
            this.TstxtLastName.Name = "TstxtLastName";
            this.TstxtLastName.Size = new System.Drawing.Size(148, 31);
            // 
            // TslblName
            // 
            this.TslblName.Name = "TslblName";
            this.TslblName.Size = new System.Drawing.Size(78, 28);
            this.TslblName.Text = "Nombre";
            // 
            // tstxtName
            // 
            this.tstxtName.Name = "tstxtName";
            this.tstxtName.Size = new System.Drawing.Size(100, 31);
            // 
            // TslDocument
            // 
            this.TslDocument.Name = "TslDocument";
            this.TslDocument.Size = new System.Drawing.Size(132, 28);
            this.TslDocument.Text = "Nº Documento";
            // 
            // TstxtDocument
            // 
            this.TstxtDocument.Name = "TstxtDocument";
            this.TstxtDocument.Size = new System.Drawing.Size(100, 31);
            // 
            // TsbToggleStatus
            // 
            this.TsbToggleStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsbToggleStatus.Image = global::GoldenAge.Properties.Resources.Padlock2;
            this.TsbToggleStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbToggleStatus.Name = "TsbToggleStatus";
            this.TsbToggleStatus.Size = new System.Drawing.Size(28, 28);
            this.TsbToggleStatus.Text = "Habilitados";
            this.TsbToggleStatus.ToolTipText = "Cambia el resultado de la busqueda\r\nPacientes con Ingreso / Pacientes con Egreso";
            this.TsbToggleStatus.Click += new System.EventHandler(this.TsbToggleStatus_Click);
            // 
            // TsbBuscar
            // 
            this.TsbBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsbBuscar.Image = global::GoldenAge.Properties.Resources.Search;
            this.TsbBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbBuscar.Name = "TsbBuscar";
            this.TsbBuscar.Size = new System.Drawing.Size(28, 28);
            this.TsbBuscar.Text = "Buscar";
            this.TsbBuscar.Click += new System.EventHandler(this.tsbSearch_Click);
            // 
            // TssPrint
            // 
            this.TssPrint.Name = "TssPrint";
            this.TssPrint.Size = new System.Drawing.Size(6, 31);
            // 
            // TsbPrintList
            // 
            this.TsbPrintList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsbPrintList.Image = global::GoldenAge.Properties.Resources.Printer;
            this.TsbPrintList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbPrintList.Name = "TsbPrintList";
            this.TsbPrintList.Size = new System.Drawing.Size(28, 28);
            this.TsbPrintList.Text = "Imprimir";
            this.TsbPrintList.Click += new System.EventHandler(this.tsbPrintList_Click);
            // 
            // DgvLista
            // 
            this.DgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvLista.Location = new System.Drawing.Point(4, 53);
            this.DgvLista.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DgvLista.Name = "DgvLista";
            this.DgvLista.Size = new System.Drawing.Size(1229, 437);
            this.DgvLista.TabIndex = 1;
            this.DgvLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellClick);
            // 
            // CmsMenuEmergente
            // 
            this.CmsMenuEmergente.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.CmsMenuEmergente.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmiSelect,
            this.TsmiDiagnostic,
            this.TssMenuPrint,
            this.TsmiPrintSelect,
            this.TsmiPrintParent,
            this.TssMenuAbm,
            this.TsmiUpdateFile,
            this.TsmiAddFile});
            this.CmsMenuEmergente.Name = "cmsMenuEmergente";
            this.CmsMenuEmergente.Size = new System.Drawing.Size(302, 196);
            // 
            // TsmiSelect
            // 
            this.TsmiSelect.Image = global::GoldenAge.Properties.Resources.Clipboard;
            this.TsmiSelect.Name = "TsmiSelect";
            this.TsmiSelect.Size = new System.Drawing.Size(301, 30);
            this.TsmiSelect.Text = "Ver Ficha";
            this.TsmiSelect.Click += new System.EventHandler(this.tsmiSelect_Click);
            // 
            // TsmiDiagnostic
            // 
            this.TsmiDiagnostic.Image = global::GoldenAge.Properties.Resources.Clipboard;
            this.TsmiDiagnostic.Name = "TsmiDiagnostic";
            this.TsmiDiagnostic.Size = new System.Drawing.Size(301, 30);
            this.TsmiDiagnostic.Text = "Diagnosticos";
            this.TsmiDiagnostic.Click += new System.EventHandler(this.tsmiDiagnostic_Click);
            // 
            // TssMenuPrint
            // 
            this.TssMenuPrint.Name = "TssMenuPrint";
            this.TssMenuPrint.Size = new System.Drawing.Size(298, 6);
            // 
            // TsmiPrintSelect
            // 
            this.TsmiPrintSelect.Image = global::GoldenAge.Properties.Resources.Printer;
            this.TsmiPrintSelect.Name = "TsmiPrintSelect";
            this.TsmiPrintSelect.Size = new System.Drawing.Size(301, 30);
            this.TsmiPrintSelect.Text = "Imprimir seleccionado";
            this.TsmiPrintSelect.Click += new System.EventHandler(this.tsmiPrintSelect_Click);
            // 
            // TsmiPrintParent
            // 
            this.TsmiPrintParent.Image = global::GoldenAge.Properties.Resources.Printer;
            this.TsmiPrintParent.Name = "TsmiPrintParent";
            this.TsmiPrintParent.Size = new System.Drawing.Size(301, 30);
            this.TsmiPrintParent.Text = "Imprimir personas a cargo";
            this.TsmiPrintParent.Click += new System.EventHandler(this.tsmiPrintParent_Click);
            // 
            // TssMenuAbm
            // 
            this.TssMenuAbm.Name = "TssMenuAbm";
            this.TssMenuAbm.Size = new System.Drawing.Size(298, 6);
            // 
            // TsmiUpdateFile
            // 
            this.TsmiUpdateFile.Image = global::GoldenAge.Properties.Resources.EditFile;
            this.TsmiUpdateFile.Name = "TsmiUpdateFile";
            this.TsmiUpdateFile.Size = new System.Drawing.Size(301, 30);
            this.TsmiUpdateFile.Text = "Modificar Ficha";
            this.TsmiUpdateFile.Click += new System.EventHandler(this.tsmiUpdate_Click);
            // 
            // TsmiAddFile
            // 
            this.TsmiAddFile.Image = global::GoldenAge.Properties.Resources.Plus;
            this.TsmiAddFile.Name = "TsmiAddFile";
            this.TsmiAddFile.Size = new System.Drawing.Size(301, 30);
            this.TsmiAddFile.Text = "Nueva Ficha";
            this.TsmiAddFile.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // FrmListPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 540);
            this.Controls.Add(this.TlpPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmListPatient";
            this.Text = "Buscar [fichas de pacientes]";
            this.Load += new System.EventHandler(this.frmListPatient_Load);
            this.TlpPanel.ResumeLayout(false);
            this.TlpPanel.PerformLayout();
            this.TsFooter.ResumeLayout(false);
            this.TsFooter.PerformLayout();
            this.TsMenu.ResumeLayout(false);
            this.TsMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLista)).EndInit();
            this.CmsMenuEmergente.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TlpPanel;
        private System.Windows.Forms.ToolStrip TsMenu;
        private System.Windows.Forms.ToolStripLabel TslblLastName;
        private System.Windows.Forms.ToolStripTextBox TstxtLastName;
        private System.Windows.Forms.DataGridView DgvLista;
        private System.Windows.Forms.ContextMenuStrip CmsMenuEmergente;
        private System.Windows.Forms.ToolStripMenuItem TsmiSelect;
        private System.Windows.Forms.ToolStripButton TsbPrintList;
        private System.Windows.Forms.ToolStripButton TsbBuscar;
        private System.Windows.Forms.ToolStripMenuItem TsmiUpdateFile;
        private System.Windows.Forms.ToolStripLabel TslblName;
        private System.Windows.Forms.ToolStripTextBox tstxtName;
        private System.Windows.Forms.ToolStripMenuItem TsmiAddFile;
        private System.Windows.Forms.ToolStripSeparator TssMenuPrint;
        private System.Windows.Forms.ToolStripMenuItem TsmiDiagnostic;
        private System.Windows.Forms.ToolStripButton TsbAdd;
        private System.Windows.Forms.ToolStrip TsFooter;
        private System.Windows.Forms.ToolStripLabel TsbPrevious;
        private System.Windows.Forms.ToolStripLabel TslNumberPag;
        private System.Windows.Forms.ToolStripButton TsbNext;
        private System.Windows.Forms.ToolStripSeparator TssAdd;
        private System.Windows.Forms.ToolStripSeparator TssPrint;
        private System.Windows.Forms.ToolStripMenuItem TsmiPrintSelect;
        private System.Windows.Forms.ToolStripMenuItem TsmiPrintParent;
        private System.Windows.Forms.ToolStripSeparator TssMenuAbm;
        private System.Windows.Forms.ToolStripLabel TslDocument;
        private System.Windows.Forms.ToolStripTextBox TstxtDocument;
        private System.Windows.Forms.ToolStripButton TsbToggleStatus;
    }
}