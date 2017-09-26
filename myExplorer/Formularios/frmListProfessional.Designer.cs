namespace myExplorer.Formularios
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
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tslblName = new System.Windows.Forms.ToolStripLabel();
            this.tstxtNombre = new System.Windows.Forms.ToolStripTextBox();
            this.tslblLastName = new System.Windows.Forms.ToolStripLabel();
            this.tstxtLastName = new System.Windows.Forms.ToolStripTextBox();
            this.tsbBuscar = new System.Windows.Forms.ToolStripButton();
            this.tslPagina = new System.Windows.Forms.ToolStripLabel();
            this.tsbSiguiente = new System.Windows.Forms.ToolStripButton();
            this.tsbAnterior = new System.Windows.Forms.ToolStripButton();
            this.cmsMenuEmergente = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.tsMenu.SuspendLayout();
            this.cmsMenuEmergente.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPanel
            // 
            this.tlpPanel.ColumnCount = 2;
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 714F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tlpPanel.Controls.Add(this.btnCerrar, 1, 2);
            this.tlpPanel.Controls.Add(this.dgvLista, 0, 1);
            this.tlpPanel.Controls.Add(this.tsMenu, 0, 0);
            this.tlpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPanel.Location = new System.Drawing.Point(0, 0);
            this.tlpPanel.Name = "tlpPanel";
            this.tlpPanel.RowCount = 3;
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tlpPanel.Size = new System.Drawing.Size(803, 450);
            this.tlpPanel.TabIndex = 0;
            // 
            // btnCerrar
            // 
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.Location = new System.Drawing.Point(717, 397);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 49);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dgvLista
            // 
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tlpPanel.SetColumnSpan(this.dgvLista, 2);
            this.dgvLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLista.Location = new System.Drawing.Point(3, 42);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.Size = new System.Drawing.Size(797, 349);
            this.dgvLista.TabIndex = 5;
            this.dgvLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellClick);
            // 
            // tsMenu
            // 
            this.tlpPanel.SetColumnSpan(this.tsMenu, 2);
            this.tsMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.tsbAdd,
            this.tslblName,
            this.tstxtNombre,
            this.tslblLastName,
            this.tstxtLastName,
            this.tsbBuscar,
            this.tslPagina,
            this.tsbSiguiente,
            this.tsbAnterior});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(803, 39);
            this.tsMenu.TabIndex = 7;
            this.tsMenu.Text = "Menu";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbAdd
            // 
            this.tsbAdd.Image = global::myExplorer.Properties.Resources.Plus;
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(85, 36);
            this.tsbAdd.Text = "Agregar";
            this.tsbAdd.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // tslblName
            // 
            this.tslblName.Name = "tslblName";
            this.tslblName.Size = new System.Drawing.Size(51, 36);
            this.tslblName.Text = "Nombre";
            // 
            // tstxtNombre
            // 
            this.tstxtNombre.Name = "tstxtNombre";
            this.tstxtNombre.Size = new System.Drawing.Size(100, 39);
            this.tstxtNombre.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tslblLastName
            // 
            this.tslblLastName.Name = "tslblLastName";
            this.tslblLastName.Size = new System.Drawing.Size(51, 36);
            this.tslblLastName.Text = "Apellido";
            // 
            // tstxtLastName
            // 
            this.tstxtLastName.Name = "tstxtLastName";
            this.tstxtLastName.Size = new System.Drawing.Size(68, 39);
            // 
            // tsbBuscar
            // 
            this.tsbBuscar.Image = global::myExplorer.Properties.Resources.Search;
            this.tsbBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBuscar.Name = "tsbBuscar";
            this.tsbBuscar.Size = new System.Drawing.Size(78, 36);
            this.tsbBuscar.Text = "Buscar";
            this.tsbBuscar.Click += new System.EventHandler(this.tsbBuscar_Click);
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
            this.tsbSiguiente.Text = "tsbSiguiente";
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
            // cmsMenuEmergente
            // 
            this.cmsMenuEmergente.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsMenuEmergente.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUpdate,
            this.tsmiDelete,
            this.tsmiAdd});
            this.cmsMenuEmergente.Name = "cmsMenuEmergente";
            this.cmsMenuEmergente.Size = new System.Drawing.Size(134, 94);
            // 
            // tsmiUpdate
            // 
            this.tsmiUpdate.Image = global::myExplorer.Properties.Resources.EditFile;
            this.tsmiUpdate.Name = "tsmiUpdate";
            this.tsmiUpdate.Size = new System.Drawing.Size(133, 30);
            this.tsmiUpdate.Text = "Modificar";
            this.tsmiUpdate.Click += new System.EventHandler(this.tsmiUpdate_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Image = global::myExplorer.Properties.Resources.Error;
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(133, 30);
            this.tsmiDelete.Text = "Eliminar";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // tsmiAdd
            // 
            this.tsmiAdd.Image = global::myExplorer.Properties.Resources.Plus;
            this.tsmiAdd.Name = "tsmiAdd";
            this.tsmiAdd.Size = new System.Drawing.Size(133, 30);
            this.tsmiAdd.Text = "Agregar";
            this.tsmiAdd.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // frmListProfessional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 450);
            this.Controls.Add(this.tlpPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListProfessional";
            this.Text = "Lista de Profesionales";
            this.Load += new System.EventHandler(this.frmListProfessional_Load);
            this.tlpPanel.ResumeLayout(false);
            this.tlpPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.cmsMenuEmergente.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPanel;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripTextBox tstxtNombre;
        private System.Windows.Forms.ToolStripButton tsbBuscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel tslPagina;
        private System.Windows.Forms.ToolStripButton tsbSiguiente;
        private System.Windows.Forms.ToolStripButton tsbAnterior;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripLabel tslblName;
        private System.Windows.Forms.ToolStripLabel tslblLastName;
        private System.Windows.Forms.ToolStripTextBox tstxtLastName;
        private System.Windows.Forms.ContextMenuStrip cmsMenuEmergente;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdd;
    }
}