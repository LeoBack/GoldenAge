using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
// De la solucion
using Entidades;
using Datos.Query;
using Controles;
using libData.SqlServer;
using System.Configuration;
using libLocalitation.Forms;
using System.Diagnostics;

namespace myExplorer.Formularios
{
    public partial class frmMain : Form
    {
        // OK - 17/09/14
        #region Atributos y Propiedades

        private enum eUser { Invalido = 0, Valido = 1, Invitado = 2 }

        private classQuery oQuery;
        private classUtiles oUtil;
        private eUser User = eUser.Invalido;
        private classTextos oTxt = new classTextos();

        #endregion

        //-----------------------------------------------------------------
        // OK - 17/09/14
        #region Formulario
        //-----------------------------------------------------------------
        
        // OK - 17/09/14
        public frmMain()
        {
            InitializeComponent();
            Text = oTxt.TituloVentana;
            WindowState = FormWindowState.Maximized;
            IsMdiContainer = true;
        }

        // OK - 17/09/14
        private void frmMain_Load(object sender, EventArgs e)
        {
            oQuery = new classQuery(ConfigurationManager.ConnectionStrings[0].ConnectionString);
            tsslPath.Text = oQuery.ServerVersion();
            oUtil = new classUtiles();
            // Inicia Secion.
            tsbMyMessages.Visible = false;
            EnableUser(false);
            OpenSession();
        }

        // Cierra Formulario
        // OK - 17/09/14
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MdiChildren.Length != 0)
            {
                if (MessageBox.Show(oTxt.MsgCloseApk, oTxt.MsgTitleCloseApk,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    e.Cancel = true;
            }
            CerraSession();
        }

        #endregion
        //-----------------------------------------------------------------

        //-----------------------------------------------------------------
        // OK - 17/10/07
        #region msMenu
        
        #region File
 
        // Cierra Formulario
        // OK - 17/09/14
        private void tsmiSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Menu

        // Formulario de Busqueda
        // OK - 17/09/14
        private void tsmiGrandfather_Click(object sender, EventArgs e)
        {
            if (User == eUser.Valido)
            {
                frmListPatient frmBuscar = new frmListPatient();
                frmBuscar.MdiParent = this;
                frmBuscar.oQuery = oQuery;
                frmBuscar.oUtil = oUtil;
                frmBuscar.Show();
            }
        }

        // Formulario de Busqueda
        // OK - 24/09/14
        private void tsmiProfessional_Click(object sender, EventArgs e)
        {
            if (User == eUser.Valido)
            {
                frmListProfessional frmProfessional = new frmListProfessional();
                frmProfessional.MdiParent = this;
                frmProfessional.oQuery = oQuery;
                frmProfessional.oUtil = oUtil;
                frmProfessional.Show();
            }
        }

        // Formulario de Busqueda
        // OK - 24/09/14
        private void tsmiSocialWork_Click(object sender, EventArgs e)
        {
            if (User == eUser.Valido)
            {
                frmListSocialWorks frmSocialWork = new frmListSocialWorks();
                frmSocialWork.MdiParent = this;
                frmSocialWork.oQuery = oQuery;
                frmSocialWork.oUtil = oUtil;
                frmSocialWork.Show();
            }
        }

        // OK - 18/06/12
        private void tsmiStatics_Click(object sender, EventArgs e)
        {
            if (this.User == eUser.Valido)
            {
                frmEstadistica fE = new frmEstadistica();
                fE.oQuery = oQuery;
                fE.oUtil = oUtil;
                fE.ShowDialog();
            }
        }

        // Formulario Mensajes
        // OK - 17/10/24
        private void tsbMyMessages_Click(object sender, EventArgs e)
        {
            if (User == eUser.Valido)
            {
                frmMessaje frmMsj = new frmMessaje();
                frmMsj.MdiParent = this;
                frmMsj.oQuery = oQuery;
                frmMsj.oUtil = oUtil;
                frmMsj.Show();
            }
        }

        //-----------------------------------------------------------------

        // OK - 24/09/14
        private void tsmiNowUser_Click(object sender, EventArgs e)
        {
            if (User == eUser.Valido)
            {
                frmAbmProfessional frmPro = new frmAbmProfessional();
                frmPro.eModo = frmAbmProfessional.Modo.Select;
                frmPro.oQuery = oQuery;
                frmPro.oUtil = oUtil;
                frmPro.ShowDialog();
            }
        }

        // OK - 08/06/12
        private void tsmiLoginProfessional_Click(object sender, EventArgs e)
        {
            if (User == eUser.Valido)
                CerraSession();
            else
                OpenSession();
            tsmiSesion.Text = tsmiUsuario.Text;
        }

        //-----------------------------------------------------------------

        // ABM Pais
        // OK - 17/10/07
        private void tsmiAbmCountry_Click(object sender, EventArgs e)
        {
            frmLocation floc = new frmLocation(oQuery.ConexionString, frmLocation.eLocation.Country);
            floc.ShowDialog();
        }

        // ABM Provincia
        // OK - 17/10/07
        private void tsmiAbmProvince_Click(object sender, EventArgs e)
        {
            frmLocation floc = new frmLocation(oQuery.ConexionString, frmLocation.eLocation.Province);
            floc.ShowDialog();
        }

        // ABM Ciudad
        // OK - 17/10/07
        private void tsmiAbmCity_Click(object sender, EventArgs e)
        {
            frmLocation floc = new frmLocation(oQuery.ConexionString, frmLocation.eLocation.City);
            floc.ShowDialog();
        }

        //-----------------------------------------------------------------

        #endregion

        #region Help

        // Cuadro de AcercaDe
        // OK - 17/09/14
        private void tsmiAcercaDe_Click(object sender, EventArgs e)
        {
            frmAcercaDe frmAcercaDe = new frmAcercaDe();
            frmAcercaDe.ShowDialog();
        }

        // Configuracion Base de Dtos
        // OK - 17/09/14
        private void tsmiDataBase_Click(object sender, EventArgs e)
        {
            frmConect fc = new frmConect(ConfigurationManager.ConnectionStrings[0].ConnectionString);
            if (fc.ShowDialog() == DialogResult.OK)
                oQuery = new classQuery(ConfigurationManager.ConnectionStrings[0].ConnectionString);
        }

        // Abre directorio donde se alojan los reportes
        // OK - 17/11/09
        private void tsmiPathReport_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", oUtil.GetPathReport());
        }

        #endregion

        #region Windows

        // Maximiza todas las ventanas hijas
        // OK - 17/10/24
        private void tsmiMaximizeWindows_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
                frm.WindowState = FormWindowState.Maximized;
        }

        // Minimize todas las ventanas hijas
        // OK - 17/10/24
        private void tsmiMinimizeWindows_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
                frm.WindowState = FormWindowState.Minimized;
        }

        // Cierra todas las ventanas hijas
        // OK - 17/10/24
        private void tsmiCloseWindows_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
                frm.Close();
        }

        #endregion

        #endregion

        //-----------------------------------------------------------------

        private void CerraSession()
        {
            if (oQuery.CloseSession(oUtil.GetSesion()) != 0)
            {
                User = eUser.Invalido;
                EnableUser(false);
                foreach (Form frm in this.MdiChildren)
                    frm.Close();
                tsmiUsuario.Text = oTxt.OpenSesion;
                Text = oTxt.TituloVentana + oTxt.TitleLogin;
                oUtil.oProfessional = null;
            }
        }

        private void OpenSession()
        {
            bool H = true;
            frmLogin fLogin = new frmLogin();

            while (H)
            {
                if (fLogin.ShowDialog() == DialogResult.Yes)
                {
                    oUtil.SetSesion(oQuery.OpenSession(fLogin.User, fLogin.Password));
                    if (oUtil.GetSesion() != 0)
                    {
                        Entidades.Clases.classProfessional oP = new Entidades.Clases.classProfessional();
                        oP.IdProfessional = oQuery.SessionProfessional(oUtil.GetSesion());
                        
                        oUtil.oProfessional = (Entidades.Clases.classProfessional)oQuery.AbmProfessional(
                            oP, classQuery.eAbm.Select);
                        
                        User = eUser.Valido;
                        tsmiUsuario.Text = oTxt.CloseSession;
                        Text = oTxt.TituloVentana + oTxt.SeparadorTitle + oUtil.oProfessional.User.ToString();
                        // Abre todas los frm
                        EnableUser(true);
                        H = false;
                    }
                    else
                    {
                        User = eUser.Invalido;
                        tsmiUsuario.Text = oTxt.OpenSesion;
                        Text = oTxt.TituloVentana + oTxt.TitleLogin;
                        oUtil.oProfessional = null; ;
                        MessageBox.Show(oTxt.LoginInvalido);
                    }
                }
                else
                    H = false;
            }
        }


        #region Metodos

        /// <summary>
        /// Habilita los controles cuando el ususario es valido.
        /// OK - 17/09/14
        /// </summary>
        /// <param name="X"></param>
        private void EnableUser(bool X)
        {
            tsPrincipal.Enabled = X;
            tsmiUsuario.Enabled = true;
            tsmiGrandfather.Enabled = X;
            tsmiSocialWorks.Enabled = X;
            tsmiNowUser.Enabled = X;
            tsmiStatics.Enabled = X;
        }

        /// <summary>
        /// Dialogo para restaurar la base de datos.
        /// OK - 17/09/14
        /// </summary>
        private void DialogRestoreDataBase()
        {
            //OpenFileDialog openFileData = new OpenFileDialog();
            //openFileData.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //openFileData.Filter = "mdf files (*.mdf)|*.mdf|All files (*.*)|*.*";
            //openFileData.FilterIndex = 2;
            //openFileData.RestoreDirectory = true;

            //if (openFileData.ShowDialog() == DialogResult.OK)
            //{
            //    try
            //    {
            //        System.IO.File.Copy(openFileData.FileName, System.IO.Path.Combine(PathBd, NameBd));
            //    }
            //    catch (System.IO.IOException ex) { MessageBox.Show(ex.ToString()); }
            //    catch (System.ArgumentException ex) { MessageBox.Show(ex.ToString()); }
            //    catch (System.UnauthorizedAccessException ex) { MessageBox.Show(ex.ToString()); }
            //    catch (System.NotSupportedException ex) { MessageBox.Show(ex.ToString()); }
            //}
        }

        /// <summary>
        /// Dialogo para copiar la base de datos.
        /// OK - 17/09/14
        /// </summary>
        private void DialogCopiDataBase()
        {
            //OpenFileDialog openFileData = new OpenFileDialog();
            //openFileData.InitialDirectory = PathBd;
            //openFileData.Filter = "mdf files (*.mdf)|*.mdf|All files (*.*)|*.*";
            //openFileData.FilterIndex = 2;
            //openFileData.RestoreDirectory = true;

            //if (openFileData.ShowDialog() == DialogResult.OK)
            //{
            //    try
            //    {
            //        System.IO.Directory.Move(openFileData.FileName,
            //            Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            //    }
            //    catch (System.IO.IOException ex) { MessageBox.Show(ex.ToString()); }
            //    catch (System.ArgumentException ex) { MessageBox.Show(ex.ToString()); }
            //    catch (System.UnauthorizedAccessException ex) { MessageBox.Show(ex.ToString()); }
            //}
        }

        #endregion

    }
}
