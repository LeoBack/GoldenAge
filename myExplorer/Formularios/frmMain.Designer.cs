namespace myExplorer.Formularios
{
    partial class frmMain
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.msToolBar = new System.Windows.Forms.MenuStrip();
            this.tsmiArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGrandfather = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProfessional = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSocialWorks = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiStatics = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNowUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbmCountry = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbmProvince = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbmCity = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAcercaDe = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDataBase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPrincipal = new System.Windows.Forms.ToolStrip();
            this.tsddbPaciente = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsgAgregarOB = new System.Windows.Forms.ToolStripButton();
            this.ssEstado = new System.Windows.Forms.StatusStrip();
            this.tsslPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.tsmiWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripPanel1 = new System.Windows.Forms.ToolStripPanel();
            this.tsbEstadisticas = new System.Windows.Forms.ToolStripButton();
            this.tsmiUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.msToolBar.SuspendLayout();
            this.tsPrincipal.SuspendLayout();
            this.ssEstado.SuspendLayout();
            this.toolStripPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // msToolBar
            // 
            this.msToolBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.msToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiArchivo,
            this.tsmiMenu,
            this.tsmiAyuda,
            this.tsmiWindows,
            this.tsmiUsuario});
            this.msToolBar.Location = new System.Drawing.Point(0, 0);
            this.msToolBar.MdiWindowListItem = this.tsmiWindows;
            this.msToolBar.Name = "msToolBar";
            this.msToolBar.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.msToolBar.Size = new System.Drawing.Size(1228, 35);
            this.msToolBar.TabIndex = 1;
            this.msToolBar.Text = "msMenu";
            // 
            // tsmiArchivo
            // 
            this.tsmiArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.tsmiSalir});
            this.tsmiArchivo.Name = "tsmiArchivo";
            this.tsmiArchivo.Size = new System.Drawing.Size(84, 29);
            this.tsmiArchivo.Text = "Archivo";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(207, 6);
            // 
            // tsmiSalir
            // 
            this.tsmiSalir.Image = global::myExplorer.Properties.Resources.Error;
            this.tsmiSalir.Name = "tsmiSalir";
            this.tsmiSalir.Size = new System.Drawing.Size(210, 30);
            this.tsmiSalir.Text = "Salir";
            this.tsmiSalir.Click += new System.EventHandler(this.tsmiSalir_Click);
            // 
            // tsmiMenu
            // 
            this.tsmiMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGrandfather,
            this.tsmiProfessional,
            this.tsmiSocialWorks,
            this.toolStripSeparator8,
            this.tsmiStatics,
            this.toolStripSeparator4,
            this.tsmiUser,
            this.toolStripSeparator2,
            this.tsmiLocation});
            this.tsmiMenu.Name = "tsmiMenu";
            this.tsmiMenu.Size = new System.Drawing.Size(69, 29);
            this.tsmiMenu.Text = "Menu";
            // 
            // tsmiGrandfather
            // 
            this.tsmiGrandfather.Image = global::myExplorer.Properties.Resources.hombre_negro_de_un_usuario_icono_7176_48;
            this.tsmiGrandfather.Name = "tsmiGrandfather";
            this.tsmiGrandfather.Size = new System.Drawing.Size(212, 30);
            this.tsmiGrandfather.Text = "Abuelos";
            this.tsmiGrandfather.Click += new System.EventHandler(this.tsmiGrandfather_Click);
            // 
            // tsmiProfessional
            // 
            this.tsmiProfessional.Image = global::myExplorer.Properties.Resources.hombre_negro_de_un_usuario_icono_7176_48;
            this.tsmiProfessional.Name = "tsmiProfessional";
            this.tsmiProfessional.Size = new System.Drawing.Size(212, 30);
            this.tsmiProfessional.Text = "Profesionales";
            this.tsmiProfessional.Click += new System.EventHandler(this.tsmiProfessional_Click);
            // 
            // tsmiSocialWorks
            // 
            this.tsmiSocialWorks.Image = global::myExplorer.Properties.Resources.ammo4;
            this.tsmiSocialWorks.Name = "tsmiSocialWorks";
            this.tsmiSocialWorks.Size = new System.Drawing.Size(212, 30);
            this.tsmiSocialWorks.Text = "Obras Sociales";
            this.tsmiSocialWorks.Click += new System.EventHandler(this.tsmiSocialWork_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(209, 6);
            // 
            // tsmiStatics
            // 
            this.tsmiStatics.Image = global::myExplorer.Properties.Resources.GraficoDeBarras;
            this.tsmiStatics.Name = "tsmiStatics";
            this.tsmiStatics.Size = new System.Drawing.Size(212, 30);
            this.tsmiStatics.Text = "Estadisticas";
            this.tsmiStatics.Click += new System.EventHandler(this.tsmiStatics_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(209, 6);
            // 
            // tsmiUser
            // 
            this.tsmiUser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNowUser,
            this.tsmiSesion});
            this.tsmiUser.Image = global::myExplorer.Properties.Resources.Para_Personas_mini;
            this.tsmiUser.Name = "tsmiUser";
            this.tsmiUser.Size = new System.Drawing.Size(212, 30);
            this.tsmiUser.Text = "Usuario";
            // 
            // tsmiNowUser
            // 
            this.tsmiNowUser.Image = global::myExplorer.Properties.Resources.Clipboard;
            this.tsmiNowUser.Name = "tsmiNowUser";
            this.tsmiNowUser.Size = new System.Drawing.Size(210, 30);
            this.tsmiNowUser.Text = "Usuario Actual";
            this.tsmiNowUser.Click += new System.EventHandler(this.tsmiNowUser_Click);
            // 
            // tsmiSesion
            // 
            this.tsmiSesion.Image = global::myExplorer.Properties.Resources.Para_Personas_mini;
            this.tsmiSesion.Name = "tsmiSesion";
            this.tsmiSesion.Size = new System.Drawing.Size(210, 30);
            this.tsmiSesion.Text = "Sesion";
            this.tsmiSesion.Click += new System.EventHandler(this.tsmiLoginProfessional_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(209, 6);
            // 
            // tsmiLocation
            // 
            this.tsmiLocation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbmCountry,
            this.tsmiAbmProvince,
            this.tsmiAbmCity});
            this.tsmiLocation.Image = global::myExplorer.Properties.Resources.Database3;
            this.tsmiLocation.Name = "tsmiLocation";
            this.tsmiLocation.Size = new System.Drawing.Size(212, 30);
            this.tsmiLocation.Text = "Localidades";
            // 
            // tsmiAbmCountry
            // 
            this.tsmiAbmCountry.Name = "tsmiAbmCountry";
            this.tsmiAbmCountry.Size = new System.Drawing.Size(210, 30);
            this.tsmiAbmCountry.Text = "ABM Pais";
            this.tsmiAbmCountry.Click += new System.EventHandler(this.tsmiAbmCountry_Click);
            // 
            // tsmiAbmProvince
            // 
            this.tsmiAbmProvince.Name = "tsmiAbmProvince";
            this.tsmiAbmProvince.Size = new System.Drawing.Size(210, 30);
            this.tsmiAbmProvince.Text = "ABM Provincia";
            this.tsmiAbmProvince.Click += new System.EventHandler(this.tsmiAbmProvince_Click);
            // 
            // tsmiAbmCity
            // 
            this.tsmiAbmCity.Name = "tsmiAbmCity";
            this.tsmiAbmCity.Size = new System.Drawing.Size(210, 30);
            this.tsmiAbmCity.Text = "ABM Ciudad";
            this.tsmiAbmCity.Click += new System.EventHandler(this.tsmiAbmCity_Click);
            // 
            // tsmiAyuda
            // 
            this.tsmiAyuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAcercaDe,
            this.tsmiDataBase});
            this.tsmiAyuda.Name = "tsmiAyuda";
            this.tsmiAyuda.Size = new System.Drawing.Size(75, 29);
            this.tsmiAyuda.Text = "Ayuda";
            // 
            // tsmiAcercaDe
            // 
            this.tsmiAcercaDe.Image = global::myExplorer.Properties.Resources.Info;
            this.tsmiAcercaDe.Name = "tsmiAcercaDe";
            this.tsmiAcercaDe.Size = new System.Drawing.Size(209, 30);
            this.tsmiAcercaDe.Text = "Acerca de ";
            this.tsmiAcercaDe.Click += new System.EventHandler(this.tsmiAcercaDe_Click);
            // 
            // tsmiDataBase
            // 
            this.tsmiDataBase.Name = "tsmiDataBase";
            this.tsmiDataBase.Size = new System.Drawing.Size(209, 30);
            this.tsmiDataBase.Text = "Base de Datos";
            this.tsmiDataBase.Click += new System.EventHandler(this.tsmiDataBase_Click);
            // 
            // tsPrincipal
            // 
            this.tsPrincipal.Dock = System.Windows.Forms.DockStyle.Left;
            this.tsPrincipal.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddbPaciente,
            this.toolStripSeparator3,
            this.tsgAgregarOB,
            this.tsbEstadisticas});
            this.tsPrincipal.Location = new System.Drawing.Point(3, 0);
            this.tsPrincipal.Name = "tsPrincipal";
            this.tsPrincipal.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tsPrincipal.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tsPrincipal.Size = new System.Drawing.Size(410, 32);
            this.tsPrincipal.TabIndex = 2;
            this.tsPrincipal.Text = "tsMenu";
            // 
            // tsddbPaciente
            // 
            this.tsddbPaciente.Image = global::myExplorer.Properties.Resources.hombre_negro_de_un_usuario_icono_7176_48;
            this.tsddbPaciente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbPaciente.Name = "tsddbPaciente";
            this.tsddbPaciente.Size = new System.Drawing.Size(105, 29);
            this.tsddbPaciente.Text = "Abuelos";
            this.tsddbPaciente.Click += new System.EventHandler(this.tsmiGrandfather_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            // 
            // tsgAgregarOB
            // 
            this.tsgAgregarOB.Image = global::myExplorer.Properties.Resources.ammo4;
            this.tsgAgregarOB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsgAgregarOB.Name = "tsgAgregarOB";
            this.tsgAgregarOB.Size = new System.Drawing.Size(156, 29);
            this.tsgAgregarOB.Text = "Obras Sociales";
            this.tsgAgregarOB.Click += new System.EventHandler(this.tsmiSocialWork_Click);
            // 
            // ssEstado
            // 
            this.ssEstado.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ssEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslPath});
            this.ssEstado.Location = new System.Drawing.Point(0, 528);
            this.ssEstado.Name = "ssEstado";
            this.ssEstado.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.ssEstado.Size = new System.Drawing.Size(1228, 30);
            this.ssEstado.TabIndex = 5;
            this.ssEstado.Text = "statusStrip1";
            // 
            // tsslPath
            // 
            this.tsslPath.Name = "tsslPath";
            this.tsslPath.Size = new System.Drawing.Size(47, 25);
            this.tsslPath.Text = "CNX";
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(150, 150);
            // 
            // tsmiWindows
            // 
            this.tsmiWindows.Name = "tsmiWindows";
            this.tsmiWindows.Size = new System.Drawing.Size(87, 29);
            this.tsmiWindows.Text = "Ventana";
            // 
            // toolStripPanel1
            // 
            this.toolStripPanel1.Controls.Add(this.tsPrincipal);
            this.toolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolStripPanel1.Location = new System.Drawing.Point(0, 35);
            this.toolStripPanel1.Name = "toolStripPanel1";
            this.toolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.toolStripPanel1.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolStripPanel1.Size = new System.Drawing.Size(1228, 32);
            // 
            // tsbEstadisticas
            // 
            this.tsbEstadisticas.Image = global::myExplorer.Properties.Resources.GraficoDeBarras;
            this.tsbEstadisticas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEstadisticas.Name = "tsbEstadisticas";
            this.tsbEstadisticas.Size = new System.Drawing.Size(130, 29);
            this.tsbEstadisticas.Text = "Estadisticas";
            this.tsbEstadisticas.Click += new System.EventHandler(this.tsmiStatics_Click);
            // 
            // tsmiUsuario
            // 
            this.tsmiUsuario.Image = global::myExplorer.Properties.Resources.Para_Personas_mini;
            this.tsmiUsuario.Name = "tsmiUsuario";
            this.tsmiUsuario.Size = new System.Drawing.Size(151, 29);
            this.tsmiUsuario.Text = "Iniciar Sesion";
            this.tsmiUsuario.Click += new System.EventHandler(this.tsmiLoginProfessional_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 558);
            this.Controls.Add(this.toolStripPanel1);
            this.Controls.Add(this.ssEstado);
            this.Controls.Add(this.msToolBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msToolBar;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.Text = "MyExplorer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.msToolBar.ResumeLayout(false);
            this.msToolBar.PerformLayout();
            this.tsPrincipal.ResumeLayout(false);
            this.tsPrincipal.PerformLayout();
            this.ssEstado.ResumeLayout(false);
            this.ssEstado.PerformLayout();
            this.toolStripPanel1.ResumeLayout(false);
            this.toolStripPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msToolBar;
        private System.Windows.Forms.ToolStrip tsPrincipal;
        private System.Windows.Forms.ToolStripMenuItem tsmiArchivo;
        private System.Windows.Forms.ToolStripMenuItem tsmiMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiAyuda;
        private System.Windows.Forms.ToolStripButton tsgAgregarOB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiSalir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiSocialWorks;
        private System.Windows.Forms.ToolStripMenuItem tsmiAcercaDe;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiGrandfather;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.StatusStrip ssEstado;
        private System.Windows.Forms.ToolStripStatusLabel tsslPath;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmiUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiNowUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiSesion;
        private System.Windows.Forms.ToolStripMenuItem tsmiStatics;
        private System.Windows.Forms.ToolStripMenuItem tsmiDataBase;
        private System.Windows.Forms.ToolStripMenuItem tsmiProfessional;
        private System.Windows.Forms.ToolStripMenuItem tsmiLocation;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbmCountry;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbmProvince;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbmCity;
        private System.Windows.Forms.ToolStripButton tsddbPaciente;
        private System.Windows.Forms.ToolStripMenuItem tsmiWindows;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.ToolStripPanel toolStripPanel1;
        private System.Windows.Forms.ToolStripButton tsbEstadisticas;
        private System.Windows.Forms.ToolStripMenuItem tsmiUsuario;
    }
}

