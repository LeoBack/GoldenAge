using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Datos;
using Entidades;
using Entidades.Clases;
//using Reportes;
using Controles;

namespace myExplorer.Formularios
{
    public partial class frmUsuario : Form
    {
        #region Atributos y Propiedades

        public enum Modo { Nuevo, Ver, Modificar }

        public Modo Acto { set; get; }
        public int IdUsuario { set; get; }

        public classConsultas oConsulta { set; get; }
        public classUsuarios oUsuario { set; get; }
        public classUtiles oUtil { set; get; }

        private classValidaciones oValidar;
        private classValidaSqlite oValidarSql = new classValidaSqlite();
        private classTextos oTxt = new classTextos();

        #endregion

        #region Formulario

        public frmUsuario()
        {
            InitializeComponent();
        }

        //OK 11/06/12
        private void frmUsuario_Load(object sender, EventArgs e)
        {
            if (oConsulta != null)
            {
                this.Text = oTxt.TituloAdministradorUsuario;
                oValidar = new classValidaciones();
                this.ini();
            }
            else
                this.Close();
        }

        #endregion

        #region Botones

        //OK 08/06/12
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                this.CargarObjeto();

                if (Acto == Modo.Nuevo)
                {   //-------------------------------------------------
                    // Guarda
                    if (oConsulta.AgregarUsuario(oUsuario))
                    {
                        MessageBox.Show(oTxt.AgregarUsuario);
                        this.Acto = Modo.Modificar;
                        this.oUsuario.IdUsuario = oConsulta.UltimoIdUsuario();
                        this.IdUsuario = 0;
                        this.ini();
                    }
                    else
                        MessageBox.Show(oTxt.ErrorAgregarConsulta);

                }   //-------------------------------------------------
                else if (Acto == Modo.Modificar)
                {   //-------------------------------------------------
                    // Actualiza
                    if (oConsulta.ModificarUsuario(oUsuario))
                    {
                        MessageBox.Show(oTxt.ModificarUsuario);
                        this.Acto = Modo.Modificar;
                        this.ini();
                    }
                    else
                        MessageBox.Show(oTxt.ErrorActualizarConsulta);
                }
                else
                    MessageBox.Show(oTxt.AccionIndefinida);
            }
        }

        //OK 11/06/12
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.LimpiarFrm();
            this.Acto = Modo.Nuevo;
        }

        //OK 11/06/12
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmVerUsuarios frmVer = new frmVerUsuarios();
            frmVer.oConsulta = this.oConsulta;
            frmVer.oUtil = this.oUtil;

            if (frmVer.ShowDialog() == DialogResult.OK)
            {
                if (frmVer.IdSelecionado != 0)
                {
                    oUsuario = oConsulta.SelectUsuario(new classUsuarios(frmVer.IdSelecionado, "", "", "", "", false));
                    this.Acto = Modo.Modificar;
                    this.ini();
                }
            }
        }

        //OK 11/06/12
        private void btnBloquear_Click(object sender, EventArgs e)
        {
            if (oUsuario != null)
            {
                if (btnBloquear.Text == oTxt.Bloquear)
                {
                    oUsuario.Bloqueado = true;
                    btnBloquear.Text = oTxt.Desbloquear;
                }
                else
                {
                    oUsuario.Bloqueado = false;
                    btnBloquear.Text = oTxt.Bloquear;
                }
                btnGuardar_Click(sender, e);
            }
        }

        #endregion

        #region TXT

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        #endregion

        #region Metodos

        /// <summary>
        /// Actualiza el formulario
        /// OK 07/06/12  REVISAR
        /// </summary>
        private void ini()
        {
            if (this.IdUsuario != 0)
            {
                oUsuario.IdUsuario = this.IdUsuario;
                oUsuario = oConsulta.SelectUsuario(oUsuario);
                btnBloquear.Enabled = true;
            }

            // Modo en el que se mostrara el formulario
            if (Acto == Modo.Ver && oUsuario.IdUsuario != 0)
            {
                this.EnableFrm(false);
                btnBloquear.Enabled = true;
                this.EscribirEnFrm();
            }
            else if (Acto == Modo.Modificar && oUsuario.IdUsuario != 0)
            {
                this.EnableFrm(true);
                btnBloquear.Enabled = true;
                this.EscribirEnFrm();
            }
            else if (Acto == Modo.Nuevo)
            {
                oUsuario = new classUsuarios();
                this.EnableFrm(true);
                btnBloquear.Enabled = false;
                this.EscribirEnFrm();
            }
        }

        /// <summary>
        /// Limpia el formulario
        /// OK 03/06/12
        /// </summary>
        private void LimpiarFrm()
        {
            foreach (Control oC in this.tlpTab.Controls)
            {
                if (oC is TextBox)
                    oC.Text = "";
            }
        }

        /// <summary>
        /// Habilita TabFicha
        /// OK 07/06/12
        /// </summary>
        /// <param name="X"></param>
        private void EnableFrm(bool X)
        {
            foreach (Control C in this.tlpPanel.Controls)
            {
                if (!(C is Label))
                    C.Enabled = X;
            }
        }

        /// <summary>
        /// OK 07/06/12
        /// </summary>
        private void CargarObjeto()
        {
            oUsuario.Contrasenia = this.oValidarSql.ValidaString(txtContrasenia.Text);
            oUsuario.Nombre = this.oValidarSql.ValidaString(txtNombre.Text);
            oUsuario.Apellido = this.oValidarSql.ValidaString(txtApellido.Text);
            oUsuario.Email = this.oValidarSql.ValidaString(txtEmail.Text);

        }

        /// <summary>
        /// Carga los elementos de formulario desde objeto.
        /// OK 07/06/12
        /// </summary>
        private void EscribirEnFrm()
        {
            txtContrasenia.Text = oUsuario.Contrasenia;
            txtNombre.Text = oUsuario.Nombre;
            txtApellido.Text = oUsuario.Apellido;
            txtEmail.Text = oUsuario.Email;

            if (oUsuario.Bloqueado)
                btnBloquear.Text = "Desbloquear";
            else
                btnBloquear.Text = "Bloquear";
        }

        /// <summary>
        /// Valida los campos del Formulario.
        /// False -> Vacio - True -> Ok
        /// OK 04/03/12
        /// </summary>
        /// <returns></returns>
        private bool ValidarCampos()
        {
            bool V = true;

            if ((txtApellido.Text == "") || (txtNombre.Text == "") ||
                (txtContrasenia.Text == "") || (txtEmail.Text == ""))
            {
                V = false;
                MessageBox.Show("Se encontraron casillas vacias.");
            }
            else if (txtContrasenia.TextLength <= 7)
            {
                V = false;
                MessageBox.Show("La contraseña debe tener como minimo 8 caracteres.");
            }
            else
            { }

            return V;
        }

        #endregion
    }
}
