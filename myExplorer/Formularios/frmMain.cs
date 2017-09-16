﻿using System;
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
        }

        // OK - 17/09/14
        private void frmMain_Load(object sender, EventArgs e)
        {
            oQuery = new classQuery(ConfigurationManager.ConnectionStrings[0].ConnectionString);
            tsslPath.Text = oQuery.ServerVersion();
            oUtil = new classUtiles();
            // Inicia Secion.
            EnableUser(false);
            tsbProfessional_Click(sender, e);
        }

        // Cierra Formulario
        // OK - 17/09/14
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(oTxt.MsgCerrarAplicacion, oTxt.MsgTituloCerrarAplicacion, 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                e.Cancel = true;
        }

        #endregion
        //-----------------------------------------------------------------

        //-----------------------------------------------------------------
        // OK - 17/09/14
        #region msMenu
        //-----------------------------------------------------------------
        
        // Cierra Formulario
        // OK - 17/09/14
        private void tsmiSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Cuadro de AcercaDe
        // OK - 17/09/14
        private void tsmiAcercaDe_Click(object sender, EventArgs e)
        {
            frmAcercaDe frmAcercaDe = new frmAcercaDe();
            frmAcercaDe.ShowDialog();
        }

        private void tsmiDataBase_Click(object sender, EventArgs e)
        {
            frmConect fc = new frmConect(ConfigurationManager.ConnectionStrings[0].ConnectionString);
            if (fc.ShowDialog() == DialogResult.OK)
                this.oQuery = new classQuery(ConfigurationManager.ConnectionStrings[0].ConnectionString);
        }

        #endregion
        //-----------------------------------------------------------------

        //-----------------------------------------------------------------
        // OK - 17/09/14
        #region tspPrincipal
        //-----------------------------------------------------------------

        // Formulario de Carga
        // OK - 17/09/14
        private void tsbAddGrandfather_Click(object sender, EventArgs e)
        {
            if (User == eUser.Valido)
            {
                frmGrandfather frmAbmGrandfather = new frmGrandfather();
                frmAbmGrandfather.oQuery = oQuery;
                frmAbmGrandfather.Modo = frmGrandfather.Vista.Nuevo;
                frmAbmGrandfather.oUtil = oUtil;
                frmAbmGrandfather.ShowDialog();
            }
        }

        // Formulario de Busqueda
        // OK - 17/09/14
        private void tsbListGrandfather_Click(object sender, EventArgs e)
        {
            if (User == eUser.Valido)
            {
                frmListGrandfather frmBuscar = new frmListGrandfather();
                frmBuscar.oQuery = oQuery;
                frmBuscar.oUtil = oUtil;
                frmBuscar.ShowDialog();
            }
        }

        // Formulario de Carga de Obras Sociales
        // OK - 17/09/14
        private void tsgAddSocialWork_Click(object sender, EventArgs e)
        {
            if (User == eUser.Valido)
            {
                frmListSocialWorks frmSocialWork = new frmListSocialWorks();
                frmSocialWork.oQuery = oQuery;
                frmSocialWork.oUtil = oUtil;
                frmSocialWork.ShowDialog();
            }
        }

        #endregion
        //-----------------------------------------------------------------

        //-----------------------------------------------------------------
        // OK - 17/09/16
        #region tspProfessional
        //-----------------------------------------------------------------
        
        // OK 08/06/12
        private void tsbProfessional_Click(object sender, EventArgs e)
        {
            if (User == eUser.Valido)
            {
                User = eUser.Invalido;
                tsbUsuario.Text = oTxt.IniciarSesion;
                Text = oTxt.TituloVentana + oTxt.TituloLogin;
                // Cerrar odas los frm
                EnableUser(false);
                oUtil.oProfessional = null;
            }
            else
            {
                bool H = true;
                frmLogin fLogin = new frmLogin();

                while (H)
                {
                    if (fLogin.ShowDialog() == DialogResult.Yes)
                    {
                        int Id = oQuery.ValidarPassword(fLogin.oProfessional);
                        if (Id != 0)
                        {
                            User = eUser.Valido;
                            tsbUsuario.Text = oTxt.CerrarSesion;
                            Text = oTxt.TituloVentana + oTxt.SeparadorTitulo + fLogin.oProfessional.User.ToString();
                            // Abre todas los frm
                            EnableUser(true);
                            oUtil.oProfessional = (Entidades.Clases.classProfessional)oQuery.AbmProfessional(
                                new Entidades.Clases.classProfessional(Id), classQuery.eAbm.Select); 
                            // Ventana por defecto al inicio
                            frmAlInicio(sender, e);
                            H = false;
                        }
                        else
                        {
                            User = eUser.Invalido;
                            tsbUsuario.Text = oTxt.IniciarSesion;
                            Text = oTxt.TituloVentana + oTxt.TituloLogin;
                            oUtil.oProfessional = null; ;
                            MessageBox.Show(oTxt.LoginInvalido);
                        }
                    }
                    else
                    H = false;
                }
            }
            tsmiSesion.Text = tsbUsuario.Text;
        }

        // OK 08/06/12
        private void tsmiAddProfessional_Click(object sender, EventArgs e)
        {
            frmProfessional fU = new frmProfessional();
            fU.oQuery = oQuery;
            fU.oUtil = oUtil;
            fU.Show();
        }

        #endregion
        //-----------------------------------------------------------------

        //-----------------------------------------------------------------
        #region tsEstadistica
        //-----------------------------------------------------------------

        //OK 18/06/12
        private void tsEstadisticas_Click(object sender, EventArgs e)
        {
            if (this.User == eUser.Valido)
            {
                frmEstadistica fE = new frmEstadistica();
                fE.oQuery = oQuery;
                fE.oUtil = oUtil;
                fE.ShowDialog();
            }
        }

        #endregion
        //-----------------------------------------------------------------

        //-----------------------------------------------------------------
        #region Metodos
        //-----------------------------------------------------------------

        private void frmAlInicio(object sender, EventArgs e)
        {
            //if (User == eUser.Valido)
        }

        /// <summary>
        /// Habilita los controles cuando el ususario es valido.
        /// OK - 17/09/14
        /// </summary>
        /// <param name="X"></param>
        private void EnableUser(bool X)
        {
            tsPrincipal.Enabled = X;
            tsEstadisticas.Enabled = X;
            tsUsuario.Enabled = true;

            tsmiPaciente.Enabled = X;
            tsmiOS.Enabled = X;
            tsmiAdministrador.Enabled = X;
            tsmiEstadisticas.Enabled = X;
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

        //-----------------------------------------------------------------
    }
}
