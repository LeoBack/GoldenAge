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
        public classProfessional oProfessional { set; get; }
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
                    if (oConsulta.AddProfessional(oProfessional))
                    {
                        MessageBox.Show(oTxt.AgregarUsuario);
                        this.Acto = Modo.Modificar;
                        this.oProfessional.IdProfessional = oConsulta.UltimoIdProfessional();
                        this.IdUsuario = 0;
                        this.ini();
                    }
                    else
                        MessageBox.Show(oTxt.ErrorAgregarConsulta);

                }   //-------------------------------------------------
                else if (Acto == Modo.Modificar)
                {   //-------------------------------------------------
                    // Actualiza
                    if (oConsulta.UpdateProfessional(oProfessional))
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
                    oProfessional = oConsulta.SelectProfessional(new classProfessional(frmVer.IdSelecionado, 0,"", "", "", "", "", "", "",false));
                    this.Acto = Modo.Modificar;
                    this.ini();
                }
            }
        }

        //OK 11/06/12
        private void btnBloquear_Click(object sender, EventArgs e)
        {
            if (oProfessional != null)
            {
                if (btnBloquear.Text == oTxt.Bloquear)
                {
                    oProfessional.Visible = true;
                    btnBloquear.Text = oTxt.Desbloquear;
                }
                else
                {
                    oProfessional.Visible = false;
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
                oProfessional.IdProfessional = this.IdUsuario;
                oProfessional = oConsulta.SelectProfessional(oProfessional);
                btnBloquear.Enabled = true;
            }

            // Modo en el que se mostrara el formulario
            if (Acto == Modo.Ver && oProfessional.IdProfessional != 0)
            {
                this.EnableFrm(false);
                btnBloquear.Enabled = true;
                this.EscribirEnFrm();
            }
            else if (Acto == Modo.Modificar && oProfessional.IdProfessional != 0)
            {
                this.EnableFrm(true);
                btnBloquear.Enabled = true;
                this.EscribirEnFrm();
            }
            else if (Acto == Modo.Nuevo)
            {
                oProfessional = new classProfessional();
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
            oProfessional.ProfessionalRegistration = Convert.ToInt32(txtProfessionalRegistration.Text);
            oProfessional.Name = this.oValidarSql.ValidaString(txtName.Text);
            oProfessional.LastName = this.oValidarSql.ValidaString(txtLastName.Text);
            oProfessional.Address = this.oValidarSql.ValidaString(txtAddress.Text);
            oProfessional.Phone = this.oValidarSql.ValidaString(txtPhone.Text);
            oProfessional.Mail = this.oValidarSql.ValidaString(txtMail.Text);
            oProfessional.User = this.oValidarSql.ValidaString(txtUser.Text);
            oProfessional.Password = this.oValidarSql.ValidaString(txtPassword.Text);
        
        }

        /// <summary>
        /// Carga los elementos de formulario desde objeto.
        /// OK 07/06/12
        /// </summary>
        private void EscribirEnFrm()
        {
            txtProfessionalRegistration.Text = Convert.ToString(oProfessional.ProfessionalRegistration);
            txtName.Text = oProfessional.Name;
            txtLastName.Text = oProfessional.LastName;
            txtAddress.Text = oProfessional.Address;
            txtPhone.Text = oProfessional.Phone;
            txtMail.Text = oProfessional.Mail;
            txtUser.Text = oProfessional.User;
            txtPassword.Text = oProfessional.Password;
            
            

            if (oProfessional.Visible)
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

            if ((txtLastName.Text == "") || (txtName.Text == "") ||
                (txtPassword.Text == "") || (txtMail.Text == ""))
            {
                V = false;
                MessageBox.Show("Se encontraron casillas vacias.");
            }
            else if (txtPassword.TextLength <= 7)
            {
                V = false;
                MessageBox.Show("La contraseña debe tener como minimo 8 caracteres.");
            }
            else
            { }

            return V;
        }

        #endregion

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
