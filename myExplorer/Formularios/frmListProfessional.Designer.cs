﻿namespace GoldenAge.Formularios
{
    partial class frmListProfessional
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListProfessional));
            this.tlpPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tsFooter = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tslPagina = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tslblName = new System.Windows.Forms.ToolStripLabel();
            this.tstxtName = new System.Windows.Forms.ToolStripTextBox();
            this.tslblLastName = new System.Windows.Forms.ToolStripLabel();
            this.tstxtLastName = new System.Windows.Forms.ToolStripTextBox();
            this.tsbBuscar = new System.Windows.Forms.ToolStripButton();
            this.tsbPrintList = new System.Windows.Forms.ToolStripButton();
            this.cmsMenuEmergente = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiPrintSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpPanel.SuspendLayout();
            this.tsFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.tsMenu.SuspendLayout();
            this.cmsMenuEmergente.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPanel
            // 
            this.tlpPanel.ColumnCount = 1;
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1274F));
            this.tlpPanel.Controls.Add(this.tsFooter, 0, 2);
            this.tlpPanel.Controls.Add(this.dgvLista, 0, 1);
            this.tlpPanel.Controls.Add(this.tsMenu, 0, 0);
            this.tlpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPanel.Location = new System.Drawing.Point(0, 0);
            this.tlpPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tlpPanel.Name = "tlpPanel";
            this.tlpPanel.RowCount = 3;
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpPanel.Size = new System.Drawing.Size(1274, 435);
            this.tlpPanel.TabIndex = 0;
            // 
            // tsFooter
            // 
            this.tsFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsFooter.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsFooter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tslPagina,
            this.toolStripButton1});
            this.tsFooter.Location = new System.Drawing.Point(0, 404);
            this.tsFooter.Name = "tsFooter";
            this.tsFooter.Size = new System.Drawing.Size(1274, 31);
            this.tsFooter.TabIndex = 9;
            this.tsFooter.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLabel1.Image = global::GoldenAge.Properties.Resources.ArrowLeft;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(24, 28);
            this.toolStripLabel1.Text = "tsbPreview";
            this.toolStripLabel1.Click += new System.EventHandler(this.tsbPreview_Click);
            // 
            // tslPagina
            // 
            this.tslPagina.Name = "tslPagina";
            this.tslPagina.Size = new System.Drawing.Size(82, 28);
            this.tslPagina.Text = "tslPagina";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::GoldenAge.Properties.Resources.ArrowRight;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton1.Text = "tsbNext";
            this.toolStripButton1.Click += new System.EventHandler(this.tsbPreview_Click);
            // 
            // dgvLista
            // 
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLista.Location = new System.Drawing.Point(4, 53);
            this.dgvLista.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.Size = new System.Drawing.Size(1266, 332);
            this.dgvLista.TabIndex = 5;
            this.dgvLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellClick);
            // 
            // tsMenu
            // 
            this.tsMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.toolStripSeparator1,
            this.tslblName,
            this.tstxtName,
            this.tslblLastName,
            this.tstxtLastName,
            this.tsbBuscar,
            this.tsbPrintList});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tsMenu.Size = new System.Drawing.Size(1274, 32);
            this.tsMenu.TabIndex = 7;
            this.tsMenu.Text = "Menu";
            // 
            // tsbAdd
            // 
            this.tsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAdd.Image = global::GoldenAge.Properties.Resources.Plus;
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(28, 29);
            this.tsbAdd.Text = "Agregar";
            this.tsbAdd.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // tslblName
            // 
            this.tslblName.Name = "tslblName";
            this.tslblName.Size = new System.Drawing.Size(78, 29);
            this.tslblName.Text = "Nombre";
            // 
            // tstxtName
            // 
            this.tstxtName.Name = "tstxtName";
            this.tstxtName.Size = new System.Drawing.Size(148, 32);
            this.tstxtName.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tslblLastName
            // 
            this.tslblLastName.Name = "tslblLastName";
            this.tslblLastName.Size = new System.Drawing.Size(78, 29);
            this.tslblLastName.Text = "Apellido";
            // 
            // tstxtLastName
            // 
            this.tstxtLastName.Name = "tstxtLastName";
            this.tstxtLastName.Size = new System.Drawing.Size(100, 32);
            // 
            // tsbBuscar
            // 
            this.tsbBuscar.Image = global::GoldenAge.Properties.Resources.Search;
            this.tsbBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBuscar.Name = "tsbBuscar";
            this.tsbBuscar.Size = new System.Drawing.Size(91, 29);
            this.tsbBuscar.Text = "Buscar";
            this.tsbBuscar.Click += new System.EventHandler(this.tsbSearch_Click);
            // 
            // tsbPrintList
            // 
            this.tsbPrintList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrintList.Image = global::GoldenAge.Properties.Resources.Printer;
            this.tsbPrintList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrintList.Name = "tsbPrintList";
            this.tsbPrintList.Size = new System.Drawing.Size(28, 29);
            this.tsbPrintList.Text = "Imprimir";
            this.tsbPrintList.Click += new System.EventHandler(this.tsbPrintList_Click);
            // 
            // cmsMenuEmergente
            // 
            this.cmsMenuEmergente.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsMenuEmergente.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPrintSelect,
            this.toolStripSeparator2,
            this.tsmiUpdate,
            this.tsmiDelete,
            this.tsmiAdd});
            this.cmsMenuEmergente.Name = "cmsMenuEmergente";
            this.cmsMenuEmergente.Size = new System.Drawing.Size(268, 130);
            // 
            // tsmiPrintSelect
            // 
            this.tsmiPrintSelect.Image = global::GoldenAge.Properties.Resources.Printer;
            this.tsmiPrintSelect.Name = "tsmiPrintSelect";
            this.tsmiPrintSelect.Size = new System.Drawing.Size(267, 30);
            this.tsmiPrintSelect.Text = "Imprimir seleccionado";
            this.tsmiPrintSelect.Click += new System.EventHandler(this.tsmiPrintSelect_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(264, 6);
            // 
            // tsmiUpdate
            // 
            this.tsmiUpdate.Image = global::GoldenAge.Properties.Resources.EditFile;
            this.tsmiUpdate.Name = "tsmiUpdate";
            this.tsmiUpdate.Size = new System.Drawing.Size(267, 30);
            this.tsmiUpdate.Text = "Modificar";
            this.tsmiUpdate.Click += new System.EventHandler(this.tsmiUpdate_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Image = global::GoldenAge.Properties.Resources.Error;
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(267, 30);
            this.tsmiDelete.Text = "Eliminar";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // tsmiAdd
            // 
            this.tsmiAdd.Image = global::GoldenAge.Properties.Resources.Plus;
            this.tsmiAdd.Name = "tsmiAdd";
            this.tsmiAdd.Size = new System.Drawing.Size(267, 30);
            this.tsmiAdd.Text = "Agregar";
            this.tsmiAdd.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // frmListProfessional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 435);
            this.Controls.Add(this.tlpPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmListProfessional";
            this.Text = "Lista de Profesionales";
            this.Load += new System.EventHandler(this.frmListProfessional_Load);
            this.tlpPanel.ResumeLayout(false);
            this.tlpPanel.PerformLayout();
            this.tsFooter.ResumeLayout(false);
            this.tsFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.cmsMenuEmergente.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPanel;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripTextBox tstxtName;
        private System.Windows.Forms.ToolStripButton tsbBuscar;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripLabel tslblName;
        private System.Windows.Forms.ToolStripLabel tslblLastName;
        private System.Windows.Forms.ToolStripTextBox tstxtLastName;
        private System.Windows.Forms.ContextMenuStrip cmsMenuEmergente;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdd;
        private System.Windows.Forms.ToolStrip tsFooter;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel tslPagina;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbPrintList;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrintSelect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}