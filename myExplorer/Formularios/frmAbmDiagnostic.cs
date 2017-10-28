using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Controles;
using Entidades;
using Entidades.Clases;
using Datos.Query;

namespace myExplorer.Formularios
{
    public partial class frmAbmDiagnostic : Form
    {
        // OK - 17/10/05
        #region Atributos y Propiedades

        public classPatient oPatient { set; get; }
        public enum Modo { Add, Select, Update, Delete }
        public Modo eModo { set; get; }
        public classQuery oQuery { set; get; }
        public classUtiles oUtil { set; get; }
        private classTextos oTxt;
        private classDiagnostic oDiagnostic;
        private int SelectRow;

        #endregion

        // OK - 17/10/07
        #region Formulario

        // OK - 17/10/05
        public frmAbmDiagnostic()
        {
            InitializeComponent();
            oTxt = new classTextos();
        }

        // OK - 17/10/07
        private void frmAbmDiagnostic_Load(object sender, EventArgs e)
        {
            if (oQuery != null && oUtil != null)
            {
                Text = oTxt.TitleDiagnostic;
                SelectRow = 0;
                initCmbSpecialty(oUtil.oProfessional.IdProfessional);
                txtProfessional.Text = oUtil.oProfessional.LastName + ", " + oUtil.oProfessional.Name;
                txtPatient.Text = oPatient.LastName + "," + oPatient.Name;

                if (LoadViewDiagnostic())
                {
                    eModo = Modo.Add;
                    oDiagnostic = new classDiagnostic();
                    rtxtDiagnostic.Text = string.Empty;
                    EnableText(false);
                }
            }
            else
            {
                MessageBox.Show(oTxt.ErrorObjetIndefinido);
                Close();
            }
        }


        #endregion

        // OK - 17/10/07
        #region Botones

        // OK - 17/10/07
        private void btnPrint_Click(object sender, EventArgs e)
        {
            /*
             * rpClinicHistory
             * Consulta Diagnosticos y Mesnajes del paciente actual.
             */

        }

        // OK - 17/10/07
        private void btnNew_Click(object sender, EventArgs e)
        {
            eModo = Modo.Add;
            rtxtDiagnostic.Text = string.Empty;
            EnableText(true);
        }

        // OK - 17/10/07
        private void btnSaveDiagnostic_Click(object sender, EventArgs e)
        {
            if ((rtxtDiagnostic.Text != ""))
            {
                CargarObjeto();
                int IdQuery = 0;

                switch(eModo)
                {
                    case Modo.Add:

                        IdQuery = (int)oQuery.AbmDiagnostic(oDiagnostic, classQuery.eAbm.Insert);
                        if (0 != IdQuery)
                            MessageBox.Show(oTxt.AddDiagnostic);
                        else
                            MessageBox.Show(oTxt.ErrorQueryAdd);
                        break;
                    case Modo.Update:
                        IdQuery = (int)oQuery.AbmDiagnostic(oDiagnostic, classQuery.eAbm.Update);
                        if (0 != IdQuery)
                            MessageBox.Show(oTxt.UpdateDiagnostic);
                        else
                            MessageBox.Show(oTxt.ErrorQueryUpdate);
                        break;
                    default:
                        MessageBox.Show(oTxt.AccionIndefinida);
                        break;
                }
                LoadViewDiagnostic();
                EnableText(false);
            }    
        }

        // OK - 17/10/07
        private void btnAccept_Click(object sender, EventArgs e)
        {
            Close();
        }

        // OK - 17/10/07
        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectRow = dgvLista.Rows.Count != 0 ? e.RowIndex : 0;

            oDiagnostic = oQuery.AbmDiagnostic(new classDiagnostic(
                Convert.ToInt32(dgvLista.Rows[SelectRow].Cells[0].Value)), 
                classQuery.eAbm.Select) as classDiagnostic;
            EscribirEnFrm();

            if (oUtil.oProfessional.IdPermission == 1)
            {
                eModo = oDiagnostic != null ? Modo.Update : Modo.Add;
                oDiagnostic = oDiagnostic != null ? oDiagnostic : new classDiagnostic();
                //EnableText(oDiagnostic.IdProfessional == oUtil.oProfessional.IdProfessional);
                EnableText(true);
            }
        }

        #endregion

        // OK - 17/10/07
        #region Metodos

        // OK - 17/10/07
        private void EnableText(bool X)
        {
            rtxtDiagnostic.Enabled = X;
            cmbSpecialty.Enabled = X;
            btnSaveDiagnostic.Enabled = X;
        }

        // OK - 17/10/07
        private bool LoadViewDiagnostic()
        {
            classDiagnostic oD = new classDiagnostic();
            oD.IdPatient = oPatient.IdPatient;
            List<classDiagnostic> lDiagnostic = oQuery.AbmDiagnostic(oD, classQuery.eAbm.SelectAll) as List<classDiagnostic>;
            DataTable dT = new DataTable("AbmDiagnostic");
            dT.Columns.Add("Id", typeof(Int32));
            dT.Columns.Add("Fecha", typeof(DateTime));
            dT.Columns.Add("Profesional", typeof(string));
            dT.Columns.Add("Speciliadad", typeof(string));
            dT.Columns.Add("Diagnostico", typeof(string));
            foreach (classDiagnostic iD in lDiagnostic)
            {
                classProfessional oP = oQuery.AbmProfessional(new classProfessional(iD.IdProfessional), classQuery.eAbm.Select) as classProfessional;
                oP = oP == null ? new classProfessional() : oP;
                classSpecialty oS = oQuery.AbmSpeciality(new classSpecialty(iD.IdSpeciality), classQuery.eAbm.Select) as classSpecialty;
                oS = oS == null ? new classSpecialty() : oS;
                dT.Rows.Add(new object[] { iD.IdDiagnostic, iD.Date, oP.LastName + ", " + oP.Name, oS.Description, iD.Detail });
            }
            GenerarGrilla(dT);
            return lDiagnostic != null;
        }

        // OK - 17/10/07
        private void CargarObjeto()
        {
            oDiagnostic.IdPatient = oPatient.IdPatient;
            oDiagnostic.Date = DateTime.Now;
            oDiagnostic.IdProfessional = oUtil.oProfessional.IdProfessional;
            oDiagnostic.Detail = rtxtDiagnostic.Text;
            oDiagnostic.IdSpeciality = Convert.ToInt32(cmbSpecialty.SelectedValue);
            oDiagnostic.Visible = true;
        }

        /// <summary>
        /// Carga los elementos de formulario desde objeto.
        /// OK - 17/10/07
        /// </summary>
        private void EscribirEnFrm()
        {
            rtxtDiagnostic.Text = oDiagnostic.Detail;
            libFeaturesComponents.fComboBox.classControlComboBoxes.IndexCombos(cmbSpecialty, oDiagnostic.IdSpeciality);
        }

        // OK - 17/10/07
        private void initCmbSpecialty(int IdProfessional)
        {
            if (oUtil.oProfessional.IdPermission == 1)
            {
                libFeaturesComponents.fComboBox.classControlComboBoxes.LoadCombo(cmbSpecialty,
                    (bool)oQuery.AbmSpeciality(new classSpecialty(), classQuery.eAbm.LoadCmb), oQuery.Table); 
            }
            else
            {
                classProfessionalSpeciality oPs = new classProfessionalSpeciality();
                oPs.IdProfessional = IdProfessional;

                List<classProfessionalSpeciality> lPs = null;
                lPs = oQuery.AbmProfessionalSpeciality(oPs, classQuery.eAbm.SelectAll) as List<classProfessionalSpeciality>;

                DataTable dT = new DataTable("AbmDiagnostic");
                dT.Columns.Add("Id", typeof(Int32));
                dT.Columns.Add("Value", typeof(string));
                foreach (classProfessionalSpeciality iPs in lPs)
                {
                    classSpecialty oS = oQuery.AbmSpeciality(new classSpecialty(iPs.IdSpeciality), classQuery.eAbm.Select) as classSpecialty;
                    dT.Rows.Add(new object[] { oS.IdSpecialty, oS.Description });
                }
                libFeaturesComponents.fComboBox.classControlComboBoxes.LoadCombo(cmbSpecialty, dT.Rows.Count != 0, dT);
            }
        }

        /// <summary>
        /// Carga la Lista debuelve la cantidad de filas.
        /// OK - 17/10/03
        /// </summary>
        /// <param name="Source"></param>
        public int GenerarGrilla(object Source)
        {
            //
            //Configuracion del DataListView
            //
            dgvLista.AutoGenerateColumns = true;
            dgvLista.AllowUserToAddRows = false;
            dgvLista.RowHeadersVisible = false;
            dgvLista.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLista.ReadOnly = true;
            dgvLista.ScrollBars = ScrollBars.Both;
            //dgvLista.ContextMenuStrip = cmsMenuEmergente;
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLista.MultiSelect = false;
            dgvLista.DataSource = Source;
#if (!DEBUG)
            dgvLista.Columns[0].Visible = false;
            //dgvLista.Columns[dgvLista.ColumnCount -1].Visible = false;
#endif
            return dgvLista.Rows.Count;
        }

        #endregion

    }
}
