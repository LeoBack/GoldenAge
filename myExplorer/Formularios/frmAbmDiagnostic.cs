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
using Reportes;

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

        // OK - 17/11/09
        #region Formulario

        // OK - 17/10/05
        public frmAbmDiagnostic()
        {
            InitializeComponent();
            oTxt = new classTextos();
        }

        // OK - 17/11/09
        private void frmAbmDiagnostic_Load(object sender, EventArgs e)
        {
            if (oQuery != null && oUtil != null)
            {
                Text = oTxt.TitleDiagnostic;
                SelectRow = 0;
                initCmbSpecialty(oUtil.oProfessional.IdProfessional);
                initDestinationSpeciality();
                txtProfessional.Text = oUtil.oProfessional.LastName + ", " + oUtil.oProfessional.Name;
                txtPatient.Text = oPatient.LastName + "," + oPatient.Name;
                EnableDestination(false);

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

        // OK - 17/11/09
        #region Botones

        // OK - 17/10/31
        private void cmbDestinationSpeciality_SelectedIndexChanged(object sender, EventArgs e)
        {
            initDestinationProfessional(Convert.ToInt32(cmbDestinationSpeciality.SelectedValue));
        }

        // OK - 17/10/31
        private void chkNotify_CheckedChanged(object sender, EventArgs e)
        {
            EnableDestination(chkNotify.Checked);
        }

        // OK - 17/11/09
        private void btnDelete_Click(object sender, EventArgs e)
        {
            switch((Modo)btnDelete.Tag)
            {
                case Modo.Delete:
                    oDiagnostic.Visible = false;
                    break;
                case Modo.Update:
                    oDiagnostic.Visible = true;
                    break;
            }
            
            if (0 != (int)oQuery.AbmDiagnostic(oDiagnostic, classQuery.eAbm.Update))
                MessageBox.Show(oTxt.UpdateDiagnostic);
            else
                MessageBox.Show(oTxt.ErrorQueryAdd);

            LoadViewDiagnostic();
            EnableText(false);
        }

        // OK - 17/11/09
        private void btnPrintDiagnostic_Click(object sender, EventArgs e)
        {
            bool isOk = true;
            DataSet dS = new DataSet();

            if (oQuery.RpOnlyPatient(oPatient.IdPatient))
                dS.Tables.Add(oQuery.Table);
            else
                isOk = false;

            if (oQuery.RpDiagnostic(oDiagnostic.IdDiagnostic))
                dS.Tables.Add(oQuery.Table);
            else
                isOk = false;

            if (isOk)
            {
                frmVisor fReport = new frmVisor(oUtil.GetPathReport(), frmVisor.Reporte.RpDiagnostic, dS);
                fReport.Show();
            }
            else
                MessageBox.Show(oTxt.ErrorQueryList);
        }

        // OK - 17/11/09
        private void btnPrintHistory_Click(object sender, EventArgs e)
        {
            bool isOk = true;
            DataSet dS = new DataSet();

            if (oQuery.RpOnlyPatient(oPatient.IdPatient))
                dS.Tables.Add(oQuery.Table);
            else
                isOk = false;

            if (oQuery.RpClinicHistory(oPatient.IdPatient))
                dS.Tables.Add(oQuery.Table);
            else
                isOk = false;

            if (isOk)
            {
                frmVisor fReport = new frmVisor(oUtil.GetPathReport(), frmVisor.Reporte.RpClinicHistory, dS);
                fReport.Show();
            }
            else
                MessageBox.Show(oTxt.ErrorQueryList);
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

        // OK - 17/11/09
        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectRow = dgvLista.Rows.Count != 0 ? e.RowIndex : 0;

            oDiagnostic = oQuery.AbmDiagnostic(new classDiagnostic(
                Convert.ToInt32(dgvLista.Rows[SelectRow].Cells[0].Value)), 
                classQuery.eAbm.Select) as classDiagnostic;
            EscribirEnFrm();

            bool isAdmin = oUtil.oProfessional.IdPermission == 1 ? true : false;
            bool isThis = oUtil.oProfessional.IdProfessional == oDiagnostic.IdProfessional ? true : false;

            EnableText(isAdmin);
            ShowBtnDelete(isAdmin | isThis);

            if (isAdmin)
            {
                eModo = oDiagnostic != null ? Modo.Update : Modo.Add;
                oDiagnostic = oDiagnostic != null ? oDiagnostic : new classDiagnostic();
            }
        }

        #endregion

        // OK - 17/11/09
        #region Metodos

        // OK - 17/11/09
        private void ShowBtnDelete(bool X)
        {
            btnDelete.Enabled = X;
            if (oDiagnostic.Visible)
            {
                btnDelete.Tag = Modo.Delete;
                btnDelete.Text = "Eliminar";
            }
            else
            {
                btnDelete.Tag = Modo.Update;
                btnDelete.Text = "Restaurar";
            }
        }

        // OK - 17/10/31
        private void initDestinationProfessional(int IdSpeciality)
        {
            libFeaturesComponents.fComboBox.classControlComboBoxes.LoadCombo(cmbDestinationProfessional,
                (bool)oQuery.ProfessionalSpeciality(IdSpeciality), oQuery.Table);
        }

        // OK - 17/10/31
        private void initDestinationSpeciality()
        {
            libFeaturesComponents.fComboBox.classControlComboBoxes.LoadComboSearch(cmbDestinationSpeciality,
                (bool)oQuery.AbmSpeciality(new classSpecialty(), classQuery.eAbm.LoadCmb), oQuery.Table);
        }

        // OK - 17/10/31
        private void EnableDestination(bool X)
        {
            cmbDestinationProfessional.Enabled = cmbDestinationSpeciality.Enabled = X;
        }

        // OK - 17/11/09
        private void EnableText(bool X)
        {
            rtxtDiagnostic.Enabled = X;
            cmbSpecialty.Enabled = X;
            btnSaveDiagnostic.Enabled = X;
        }

        // OK - 17/11/09
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
            dT.Columns.Add("Visible", typeof(string));
            foreach (classDiagnostic iD in lDiagnostic)
            {
                classProfessional oP = oQuery.AbmProfessional(new classProfessional(iD.IdProfessional), classQuery.eAbm.Select) as classProfessional;
                oP = oP == null ? new classProfessional() : oP;
                classSpecialty oS = oQuery.AbmSpeciality(new classSpecialty(iD.IdSpeciality), classQuery.eAbm.Select) as classSpecialty;
                oS = oS == null ? new classSpecialty() : oS;

                bool isShowRow = iD.Visible;
                if (!isShowRow)
                {
                    isShowRow = oUtil.oProfessional.IdProfessional == iD.IdProfessional ? true : isShowRow;
                    isShowRow = oUtil.oProfessional.IdPermission == 1 ? true : isShowRow;
                }
                if (isShowRow)
                    dT.Rows.Add(new object[] { iD.IdDiagnostic, iD.Date, oP.LastName + ", " + oP.Name, oS.Description, iD.Detail, iD.Visible });
            }
            GenerarGrilla(dT);
            PintarBloqueados(Color.Gray);
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
            oDiagnostic.IdDestinationProfessional = Convert.ToInt32(cmbDestinationProfessional.SelectedValue);
            oDiagnostic.IdDestinationSpeciality = Convert.ToInt32(cmbDestinationSpeciality.SelectedValue);
            oDiagnostic.DestinationRead = chkNotify.Checked;
            oDiagnostic.Visible = true;
        }

        /// <summary>
        /// Carga los elementos de formulario desde objeto.
        /// OK - 17/10/31
        /// </summary>
        private void EscribirEnFrm()
        {
            rtxtDiagnostic.Text = oDiagnostic.Detail;
            cmbDestinationSpeciality.SelectedIndexChanged -= cmbDestinationSpeciality_SelectedIndexChanged;
            libFeaturesComponents.fComboBox.classControlComboBoxes.IndexCombos(cmbSpecialty, oDiagnostic.IdSpeciality);
            libFeaturesComponents.fComboBox.classControlComboBoxes.IndexCombos(cmbDestinationProfessional, oDiagnostic.IdDestinationProfessional);
            libFeaturesComponents.fComboBox.classControlComboBoxes.IndexCombos(cmbDestinationSpeciality, oDiagnostic.IdDestinationSpeciality);
            cmbDestinationSpeciality.SelectedIndexChanged += cmbDestinationSpeciality_SelectedIndexChanged;
            chkNotify.Checked = oDiagnostic.DestinationRead;
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
        /// Colorea la Fila de Color
        /// OK - 17/09/24
        /// </summary>
        /// <param name="Color"></param>
        public void PintarBloqueados(Color Color)
        {
            bool Block = false;
            int nCell = dgvLista.ColumnCount;

            for (int Fila = 0; Fila < dgvLista.Rows.Count; Fila++)
            {
                Block = Convert.ToBoolean(dgvLista.Rows[Fila].Cells[nCell - 1].Value);
                if (Block == false)
                    for (int Columna = 0; Columna < dgvLista.Rows[Fila].Cells.Count; Columna++)
                        dgvLista.Rows[Fila].Cells[Columna].Style.BackColor = Color;
            }
        }

        /// <summary>
        /// Carga la Lista debuelve la cantidad de filas.
        /// OK - 17/11/09
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
            dgvLista.Columns[dgvLista.ColumnCount -1].Visible = false;
#endif
            return dgvLista.Rows.Count;
        }

        #endregion
    }
}
