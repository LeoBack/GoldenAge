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
        // OK 08/06/12
        #region Atributos y Propiedades

        public classProfessional oProfessional { set; get; }
        private classValidaSqlite oValidarSql = new classValidaSqlite();
        private classTextos oTxt = new classTextos();

        #endregion

        // OK 08/06/12
        #region Formulario

        // OK 08/06/12
        public frmLogin()
        {
            InitializeComponent();
        }

        // OK 08/06/12
        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtNombre.Focus();
        }

        // OK 08/06/12
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" || txtPasw.Text != "")
                oProfessional = new classProfessional();
                oProfessional.User = oValidarSql.ValidaString(txtNombre.Text);
                oProfessional.Password = oValidarSql.ValidaString(txtPasw.Text);
        }

        #endregion
    }
}
