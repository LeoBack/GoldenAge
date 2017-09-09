using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//
using Controles;
using Entidades.Clases;
using Datos;

namespace myExplorer.Formularios
{
    public partial class frmLogin : Form
    {
        #region Atributos y Propiedades

        public classProfessional oUsuario { set; get; }
        private classValidaSqlite oValidarSql = new classValidaSqlite();
        private classTextos oTxt = new classTextos();

        #endregion

        #region Formulario

        public frmLogin()
        {
            InitializeComponent();
        }

        //OK    15/06/12
        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtNombre.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
        //    if (txtNombre.Text != "" || txtPasw.Text != "")
        //        oUsuario = new classProfessional(0, oValidarSql.ValidaString(txtNombre.Text), "",
        //            oValidarSql.ValidaString(txtPasw.Text), "", false);
        //    else
        //        MessageBox.Show(oTxt.LoginInvalido);
        }

        #endregion
    }
}
