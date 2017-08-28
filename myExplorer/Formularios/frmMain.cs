using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
// De la solucion
using Entidades;
using Datos;
using Controles;

namespace myExplorer.Formularios
{
    public partial class frmMain : Form
    {
        #region Atributos y Propiedades

        private enum EstadoUsuario { Invalido = 0, Valido = 1, Invitado = 2 }

        private classBackUp oBck;
        private classSchemaBD oBD;
        private classConsultas oConsulta;
        private classUtiles oUtil;
        private EstadoUsuario Usuario;
        private classTextos oTxt = new classTextos();

        private bool Log = false;
        private string PahtBd = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LAB\\";
        private string NameBd = "Server.db";

        private string TituloVentana = "MyExplorer";

        #endregion

        //-----------------------------------------------------------------
        #region Formulario
        //-----------------------------------------------------------------

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = "MyExplorer";
            this.WindowState = FormWindowState.Maximized;
            //tsBaseDatos.Visible = false;

            if (!System.IO.Directory.Exists(this.PahtBd))
                System.IO.Directory.CreateDirectory(this.PahtBd);

            oConsulta = new classConsultas(this.PahtBd, this.NameBd, this.Log);
            oBD = new classSchemaBD(oConsulta.Path, oConsulta.DBname, oConsulta.ActivarLog);

            if (oBD.ExistCreateBD())
                tsslPath.Text = oTxt.ConexionNuevaExitosa;
            else
                tsslPath.Text = oTxt.ConexionExitosa;
            
            oUtil = new classUtiles();

            // Inicia Secion.
            this.HabilitarUsuario(false);
            this.tsbUsuario_Click(sender, e);
        }

        // Cierra Formulario
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(oTxt.MsgCerrarAplicacion, oTxt.MsgTituloCerrarAplicacion, 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                e.Cancel = true;
        }

        #endregion
        //-----------------------------------------------------------------

        //-----------------------------------------------------------------
        #region msMenu
        //-----------------------------------------------------------------
        
        // Cierra Formulario
        private void tsmiSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Cuadro de AcercaDe
        private void tsmiAcercaDe_Click(object sender, EventArgs e)
        {
            frmAcercaDe frmAcercaDe = new frmAcercaDe();
            frmAcercaDe.ShowDialog();
        }

        #endregion
        //-----------------------------------------------------------------

        //-----------------------------------------------------------------
        #region tspPrincipal
        //-----------------------------------------------------------------

        // Formulario de Carga
        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            if (Usuario == EstadoUsuario.Valido)
            {
                frmForm frmPaciente = new frmForm();
                frmPaciente.oConsulta = this.oConsulta;
                frmPaciente.Modo = frmForm.Vista.Nuevo;
                frmPaciente.oUtil = this.oUtil;
                frmPaciente.ShowDialog();
            }
        }

        // Formulario de Busqueda
        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            if (Usuario == EstadoUsuario.Valido)
            {
                frmSearch frmBuscar = new frmSearch();
                frmBuscar.oConsulta = this.oConsulta;
                frmBuscar.oUtil = this.oUtil;
                frmBuscar.ShowDialog();
            }
        }

        // Formulario de Carga de Obras Sociales
        private void tsgAgregarOB_Click(object sender, EventArgs e)
        {
            if (Usuario == EstadoUsuario.Valido)
            {
                frmVerObraSocial frmObraSocial = new frmVerObraSocial();
                frmObraSocial.oConsulta = this.oConsulta;
                frmObraSocial.oUtil = this.oUtil;
                frmObraSocial.ShowDialog();
            }
        }

        #endregion
        //-----------------------------------------------------------------


        //-----------------------------------------------------------------
        #region tspBaseDatos 
        //-----------------------------------------------------------------

        // Restura la base de datos
        private void tsmiRestaurar_Click(object sender, EventArgs e)
        {
            if (Usuario == EstadoUsuario.Valido)
            {
                FolderBrowserDialog oF = new FolderBrowserDialog();

                if (oF.ShowDialog() == DialogResult.OK)
                {
                    oBck = new classBackUp(this.oConsulta);

                    if (!oBck.RestoreFile(oBck.Filter, oF.SelectedPath))
                        MessageBox.Show(oTxt.RestauracionExitosa);
                    else
                        MessageBox.Show(oTxt.RestauracionErronea);
                }
            }
        }

        // Realiza el BackUp
        private void tsmiCopiar_Click(object sender, EventArgs e)
        {
            if (Usuario == EstadoUsuario.Valido)
            {
                FolderBrowserDialog oF = new FolderBrowserDialog();

                if (oF.ShowDialog() == DialogResult.OK)
                {
                    oBck = new classBackUp(this.oConsulta);

                    if (!oBck.MakeCopy(oF.SelectedPath))
                        MessageBox.Show(oTxt.CopiaExitosa);
                    else
                        MessageBox.Show(oTxt.CopiaErronea);
                }
            }
        }

        #endregion 
        //-----------------------------------------------------------------


        //-----------------------------------------------------------------
        #region tspTurnos
        //-----------------------------------------------------------------

        private void tsbAsignarTurno_Click(object sender, EventArgs e)
        {
            if (Usuario == EstadoUsuario.Valido)
            {
                frmTurno fTurno = new frmTurno();
                fTurno.oConsulta = oConsulta;
                fTurno.oUtil = this.oUtil;
                fTurno.ShowDialog();
            }
        }

        #endregion


        //-----------------------------------------------------------------
        #region tspUsuario
        //-----------------------------------------------------------------
        
        // OK 08/06/12
        private void tsbUsuario_Click(object sender, EventArgs e)
        {
            if (this.Usuario == EstadoUsuario.Valido)
            {
                this.Usuario = EstadoUsuario.Invalido;
                tsbUsuario.Text = oTxt.IniciarSesion;
                this.Text = this.TituloVentana + oTxt.TituloLogin;
                // Cerrar odas los frm
                this.HabilitarUsuario(false);
                this.oUtil.IdUsuario = 0;
            }
            else
            {
                bool H = true;
                frmLogin fLogin = new frmLogin();

                while (H)
                {
                    if (fLogin.ShowDialog() == DialogResult.Yes)
                    {
                        if (oConsulta.ValidarPassword(fLogin.oUsuario))
                        {
                            this.Usuario = EstadoUsuario.Valido;
                            tsbUsuario.Text = oTxt.CerrarSesion ;
                            this.Text = this.TituloVentana + oTxt.SeparadorTitulo + fLogin.oUsuario.Nombre.ToString();
                            // Abre todas los frm
                            this.HabilitarUsuario(true);
                            this.oUtil.IdUsuario = oConsulta.SelectUsuario(fLogin.oUsuario).IdUsuario;

                            // Ventana por defect al inicio
                            this.frmAlInicio(sender, e);

                            H = false;
                        }
                        else
                        {
                            this.Usuario = EstadoUsuario.Invalido;
                            tsbUsuario.Text = oTxt.IniciarSesion;
                            this.Text = this.TituloVentana + oTxt.TituloLogin;
                            this.oUtil.IdUsuario = 0;
                            MessageBox.Show(oTxt.LoginInvalido);
                        }
                    }
                    else
                        H = false;
                }
            }
            tsmiSesion.Text = tsbUsuario.Text;
        }

        // 
        private void tsmiAgregarUsuario_Click(object sender, EventArgs e)
        {
            frmUsuario fU = new frmUsuario();
            fU.oConsulta = this.oConsulta;
            fU.oUtil = this.oUtil;
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
            if (this.Usuario == EstadoUsuario.Valido)
            {
                frmEstadistica fE = new frmEstadistica();
                fE.oConsulta = this.oConsulta;
                fE.oUtil = this.oUtil;
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
            if (Usuario == EstadoUsuario.Valido)
                this.tsbAsignarTurno_Click(sender, e);
        }

        /// <summary>
        /// Habilita los controles cuando el ususario es valido
        /// </summary>
        /// <param name="X"></param>
        private void HabilitarUsuario(bool X)
        {
            this.tsBaseDatos.Enabled = X;
            this.tspTurnos.Enabled = X;
            this.tsPrincipal.Enabled = X;
            this.tsEstadisticas.Enabled = X;
            this.tsUsuario.Enabled = true;

            this.tsmiPaciente.Enabled = X;
            this.tsmiOS.Enabled = X;
            this.tsmiBaseDeDatos.Enabled = X;
            this.tsmiTurnos.Enabled = X;
            this.tsmiAdministrador.Enabled = X;
            this.tsmiEstadisticas.Enabled = X;
        }

        #endregion
        //-----------------------------------------------------------------
    }
}
