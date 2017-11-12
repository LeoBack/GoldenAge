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
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGrandfather = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProfessional = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSocialWorks = new System.Windows.Forms.ToolStripMenuItem();
            this.tssStatics = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiStatics = new System.Windows.Forms.ToolStripMenuItem();
            this.tssMessage = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiMessaje = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNowUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.tssLocation = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbmCountry = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbmProvince = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbmCity = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAcercaDe = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDataBase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPathReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMaximizeWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMinimizeWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCloseWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPrincipal = new System.Windows.Forms.ToolStrip();
            this.tsbPatient = new System.Windows.Forms.ToolStripButton();
            this.tssProfession = new System.Windows.Forms.ToolStripSeparator();
            this.tsbProfession = new System.Windows.Forms.ToolStripButton();
            this.tsbSocialWorks = new System.Windows.Forms.ToolStripButton();
            this.tssMesage = new System.Windows.Forms.ToolStripSeparator();
            this.tsbMyMessages = new System.Windows.Forms.ToolStripButton();
            this.ssEstado = new System.Windows.Forms.StatusStrip();
            this.tsslPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.tspTools = new System.Windows.Forms.ToolStripPanel();
            this.msToolBar.SuspendLayout();
            this.tsPrincipal.SuspendLayout();
            this.ssEstado.SuspendLayout();
            this.tspTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // msToolBar
            // 
            this.msToolBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.msToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiMenu,
            this.tsmiHelp,
            this.tsmiWindows,
            this.tsmiUsuario});
            this.msToolBar.Location = new System.Drawing.Point(0, 0);
            this.msToolBar.MdiWindowListItem = this.tsmiWindows;
            this.msToolBar.Name = "msToolBar";
            this.msToolBar.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.msToolBar.Size = new System.Drawing.Size(1086, 35);
            this.msToolBar.TabIndex = 1;
            this.msToolBar.Text = "msMenu";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.tsmiSalir});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(84, 29);
            this.tsmiFile.Text = "Archivo";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(126, 6);
            // 
            // tsmiSalir
            // 
            this.tsmiSalir.Name = "tsmiSalir";
            this.tsmiSalir.Size = new System.Drawing.Size(129, 30);
            this.tsmiSalir.Text = "Salir";
            this.tsmiSalir.Click += new System.EventHandler(this.tsmiSalir_Click);
            // 
            // tsmiMenu
            // 
            this.tsmiMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiGrandfather,
            this.tsmiProfessional,
            this.tsmiSocialWorks,
            this.tssStatics,
            this.tsmiStatics,
            this.tssMessage,
            this.tsmiMessaje,
            this.tsmiUser,
            this.tssLocation,
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
            // tssStatics
            // 
            this.tssStatics.Name = "tssStatics";
            this.tssStatics.Size = new System.Drawing.Size(209, 6);
            // 
            // tsmiStatics
            // 
            this.tsmiStatics.Image = global::myExplorer.Properties.Resources.GraficoDeBarras;
            this.tsmiStatics.Name = "tsmiStatics";
            this.tsmiStatics.Size = new System.Drawing.Size(212, 30);
            this.tsmiStatics.Text = "Estadisticas";
            this.tsmiStatics.Click += new System.EventHandler(this.tsmiStatics_Click);
            // 
            // tssMessage
            // 
            this.tssMessage.Name = "tssMessage";
            this.tssMessage.Size = new System.Drawing.Size(209, 6);
            // 
            // tsmiMessaje
            // 
            this.tsmiMessaje.Image = global::myExplorer.Properties.Resources.Email;
            this.tsmiMessaje.Name = "tsmiMessaje";
            this.tsmiMessaje.Size = new System.Drawing.Size(212, 30);
            this.tsmiMessaje.Text = "Mensajes";
            this.tsmiMessaje.Click += new System.EventHandler(this.tsbMyMessages_Click);
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
            this.tsmiNowUser.Image = global::myExplorer.Properties.Resources.hombre_negro_de_un_usuario_icono_7176_48;
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
            // tssLocation
            // 
            this.tssLocation.Name = "tssLocation";
            this.tssLocation.Size = new System.Drawing.Size(209, 6);
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
            // tsmiHelp
            // 
            this.tsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAcercaDe,
            this.tsmiDataBase,
            this.tsmiPathReport});
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(75, 29);
            this.tsmiHelp.Text = "Ayuda";
            // 
            // tsmiAcercaDe
            // 
            this.tsmiAcercaDe.Image = global::myExplorer.Properties.Resources.Info;
            this.tsmiAcercaDe.Name = "tsmiAcercaDe";
            this.tsmiAcercaDe.Size = new System.Drawing.Size(312, 30);
            this.tsmiAcercaDe.Text = "Acerca de ";
            this.tsmiAcercaDe.Click += new System.EventHandler(this.tsmiAcercaDe_Click);
            // 
            // tsmiDataBase
            // 
            this.tsmiDataBase.Image = global::myExplorer.Properties.Resources.Database3;
            this.tsmiDataBase.Name = "tsmiDataBase";
            this.tsmiDataBase.Size = new System.Drawing.Size(312, 30);
            this.tsmiDataBase.Text = "Base de Datos";
            this.tsmiDataBase.Click += new System.EventHandler(this.tsmiDataBase_Click);
            // 
            // tsmiPathReport
            // 
            this.tsmiPathReport.Name = "tsmiPathReport";
            this.tsmiPathReport.Size = new System.Drawing.Size(312, 30);
            this.tsmiPathReport.Text = "Abrir directorio de reportes";
            this.tsmiPathReport.Click += new System.EventHandler(this.tsmiPathReport_Click);
            // 
            // tsmiWindows
            // 
            this.tsmiWindows.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tsmiWindows.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMaximizeWindows,
            this.tsmiMinimizeWindows,
            this.tsmiCloseWindows,
            this.toolStripSeparator5});
            this.tsmiWindows.Name = "tsmiWindows";
            this.tsmiWindows.Size = new System.Drawing.Size(87, 29);
            this.tsmiWindows.Text = "Ventana";
            // 
            // tsmiMaximizeWindows
            // 
            this.tsmiMaximizeWindows.Name = "tsmiMaximizeWindows";
            this.tsmiMaximizeWindows.Size = new System.Drawing.Size(187, 30);
            this.tsmiMaximizeWindows.Text = "Maximizar";
            this.tsmiMaximizeWindows.Click += new System.EventHandler(this.tsmiMaximizeWindows_Click);
            // 
            // tsmiMinimizeWindows
            // 
            this.tsmiMinimizeWindows.Name = "tsmiMinimizeWindows";
            this.tsmiMinimizeWindows.Size = new System.Drawing.Size(187, 30);
            this.tsmiMinimizeWindows.Text = "Minimizar";
            this.tsmiMinimizeWindows.Click += new System.EventHandler(this.tsmiMinimizeWindows_Click);
            // 
            // tsmiCloseWindows
            // 
            this.tsmiCloseWindows.Name = "tsmiCloseWindows";
            this.tsmiCloseWindows.Size = new System.Drawing.Size(187, 30);
            this.tsmiCloseWindows.Text = "Cerrar todo";
            this.tsmiCloseWindows.Click += new System.EventHandler(this.tsmiCloseWindows_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(184, 6);
            // 
            // tsmiUsuario
            // 
            this.tsmiUsuario.Image = global::myExplorer.Properties.Resources.Para_Personas_mini;
            this.tsmiUsuario.Name = "tsmiUsuario";
            this.tsmiUsuario.Size = new System.Drawing.Size(151, 29);
            this.tsmiUsuario.Text = "Iniciar Sesion";
            this.tsmiUsuario.Click += new System.EventHandler(this.tsmiLoginProfessional_Click);
            // 
            // tsPrincipal
            // 
            this.tsPrincipal.Dock = System.Windows.Forms.DockStyle.None;
            this.tsPrincipal.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPatient,
            this.tssProfession,
            this.tsbProfession,
            this.tsbSocialWorks,
            this.tssMesage,
            this.tsbMyMessages});
            this.tsPrincipal.Location = new System.Drawing.Point(3, 0);
            this.tsPrincipal.Name = "tsPrincipal";
            this.tsPrincipal.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tsPrincipal.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tsPrincipal.Size = new System.Drawing.Size(648, 32);
            this.tsPrincipal.TabIndex = 2;
            this.tsPrincipal.Text = "tsMenu";
            // 
            // tsbPatient
            // 
            this.tsbPatient.Image = global::myExplorer.Properties.Resources.hombre_negro_de_un_usuario_icono_7176_48;
            this.tsbPatient.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPatient.Name = "tsbPatient";
            this.tsbPatient.Size = new System.Drawing.Size(105, 29);
            this.tsbPatient.Text = "Abuelos";
            this.tsbPatient.Click += new System.EventHandler(this.tsmiGrandfather_Click);
            // 
            // tssProfession
            // 
            this.tssProfession.Name = "tssProfession";
            this.tssProfession.Size = new System.Drawing.Size(6, 32);
            // 
            // tsbProfession
            // 
            this.tsbProfession.Image = global::myExplorer.Properties.Resources.hombre_negro_de_un_usuario_icono_7176_48;
            this.tsbProfession.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbProfession.Name = "tsbProfession";
            this.tsbProfession.Size = new System.Drawing.Size(145, 29);
            this.tsbProfession.Text = "Profesionales";
            this.tsbProfession.Click += new System.EventHandler(this.tsmiProfessional_Click);
            // 
            // tsbSocialWorks
            // 
            this.tsbSocialWorks.Image = global::myExplorer.Properties.Resources.ammo4;
            this.tsbSocialWorks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSocialWorks.Name = "tsbSocialWorks";
            this.tsbSocialWorks.Size = new System.Drawing.Size(156, 29);
            this.tsbSocialWorks.Text = "Obras Sociales";
            this.tsbSocialWorks.Click += new System.EventHandler(this.tsmiSocialWork_Click);
            // 
            // tssMesage
            // 
            this.tssMesage.Name = "tssMesage";
            this.tssMesage.Size = new System.Drawing.Size(6, 32);
            // 
            // tsbMyMessages
            // 
            this.tsbMyMessages.Image = global::myExplorer.Properties.Resources.Email;
            this.tsbMyMessages.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMyMessages.Name = "tsbMyMessages";
            this.tsbMyMessages.Size = new System.Drawing.Size(171, 29);
            this.tsbMyMessages.Text = "(0) Mis Mensajes";
            this.tsbMyMessages.Click += new System.EventHandler(this.tsbMyMessages_Click);
            // 
            // ssEstado
            // 
            this.ssEstado.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ssEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslPath});
            this.ssEstado.Location = new System.Drawing.Point(0, 501);
            this.ssEstado.Name = "ssEstado";
            this.ssEstado.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.ssEstado.Size = new System.Drawing.Size(1086, 30);
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
            // tspTools
            // 
            this.tspTools.Controls.Add(this.tsPrincipal);
            this.tspTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.tspTools.Location = new System.Drawing.Point(0, 35);
            this.tspTools.Name = "tspTools";
            this.tspTools.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.tspTools.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.tspTools.Size = new System.Drawing.Size(1086, 32);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 531);
            this.Controls.Add(this.tspTools);
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
            this.tspTools.ResumeLayout(false);
            this.tspTools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msToolBar;
        private System.Windows.Forms.ToolStrip tsPrincipal;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripButton tsbSocialWorks;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiSalir;
        private System.Windows.Forms.ToolStripSeparator tssLocation;
        private System.Windows.Forms.ToolStripMenuItem tsmiSocialWorks;
        private System.Windows.Forms.ToolStripMenuItem tsmiAcercaDe;
        private System.Windows.Forms.ToolStripSeparator tssProfession;
        private System.Windows.Forms.ToolStripMenuItem tsmiGrandfather;
        private System.Windows.Forms.ToolStripSeparator tssStatics;
        private System.Windows.Forms.StatusStrip ssEstado;
        private System.Windows.Forms.ToolStripStatusLabel tsslPath;
        private System.Windows.Forms.ToolStripSeparator tssMessage;
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
        private System.Windows.Forms.ToolStripButton tsbPatient;
        private System.Windows.Forms.ToolStripMenuItem tsmiWindows;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.ToolStripPanel tspTools;
        private System.Windows.Forms.ToolStripMenuItem tsmiUsuario;
        private System.Windows.Forms.ToolStripMenuItem tsmiMessaje;
        private System.Windows.Forms.ToolStripMenuItem tsmiMaximizeWindows;
        private System.Windows.Forms.ToolStripMenuItem tsmiMinimizeWindows;
        private System.Windows.Forms.ToolStripMenuItem tsmiCloseWindows;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbMyMessages;
        private System.Windows.Forms.ToolStripButton tsbProfession;
        private System.Windows.Forms.ToolStripSeparator tssMesage;
        private System.Windows.Forms.ToolStripMenuItem tsmiPathReport;
    }
}

