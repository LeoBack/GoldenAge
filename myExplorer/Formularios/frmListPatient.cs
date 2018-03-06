using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
// De la solucion
using Datos.Query;
using Entidades;
using Entidades.Clases;
using Reportes;
using Controles;

namespace GoldenAge.Formularios
{
    public partial class frmListPatient : Form
    {
        // OK - 17/11/20
        #region Atributos y Propiedades

        public classQuery oQuery { set; get; }
        public classUtiles oUtil { set; get; }
        private classTextos oTxt;
        private int SelectRow;
        private int cantPag = 0;
        private int Pag = 1;
        //
        private bool PatientLocked = false;

        #endregion

        // OK - 18/02/08
        #region Formulario

        // OK - 17/09/30
        public frmListPatient()
        {
            InitializeComponent();
            oTxt = new classTextos();
        }

        // OK - 18/02/08
        private void frmListPatient_Load(object sender, EventArgs e)
        {
            if (oQuery != null && oUtil != null)
            {
                Permission();
                Text = oTxt.TitleListPatient;
                SelectRow = 0;
                tslPagina.Text = "Página: 0 de 0";
                tsbPrintList.Enabled = false;
            }
            else
                Close();
        }

        #endregion

        // OK - 17/11/23
        #region Menu Contextual Botones

        // OK - 17/11/23
        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (dgvLista.RowCount != 0)
            {
                classPatient oGf = new classPatient();
                oGf.IdPatient = Convert.ToInt32(dgvLista.Rows[SelectRow].Cells[1].Value);
                oGf = (classPatient)oQuery.AbmPatient(oGf, classQuery.eAbm.Select);
                oGf.Visible = false;

                if (oGf != null)
                    MessageBox.Show((0 != (int)oQuery.AbmPatient(oGf, classQuery.eAbm.Update)) ? oTxt.UpdateParent : oTxt.ErrorQueryUpdate);
                else
                    MessageBox.Show(oTxt.ErrorQueryList);
            }
        }

        // OK - 17/09/24
        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            if (dgvLista.RowCount != 0)
            {
                classPatient oGf = new classPatient();
                oGf.IdPatient = Convert.ToInt32(dgvLista.Rows[SelectRow].Cells[1].Value);
                oGf = (classPatient)oQuery.AbmPatient(oGf, classQuery.eAbm.Select);

                if (oGf != null)
                {
                    frmAbmPatient frmA = new frmAbmPatient();
                    frmA.ObjetQuery = oQuery;
                    frmA.ObjetUtil = oUtil;
                    frmA.oPatient = oGf;
                    frmA.eModo = frmAbmPatient.Modo.Update;
                    frmA.ShowDialog();
                }
                else
                    MessageBox.Show(oTxt.ErrorQueryList);
            }
        }

        // OK - 17/09/24
        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            frmAbmPatient frmA = new frmAbmPatient();
            frmA.ObjetQuery = oQuery;
            frmA.ObjetUtil = oUtil;
            frmA.eModo = frmAbmPatient.Modo.Add;
            frmA.ShowDialog();
        }

        #endregion

        // OK - 17/11/20
        #region Paginador

        // OK - 17/11/20
        private void tsbNext_Click(object sender, EventArgs e)
        {
            if (Pag < cantPag)
                Filtrar(++Pag);
        }

        // OK - 17/11/20
        private void tsbPreview_Click(object sender, EventArgs e)
        {
            if (Pag > 1)
                Filtrar(--Pag);
        }

        // OK - 17/11/20
        private void tsbSearch_Click(object sender, EventArgs e)
        {
            Filtrar(Pag = 1);
        }

        #endregion

        // OK - 18/02/08
        #region Botones

        // OK - 17/09/30
        private void tsmiSelect_Click(object sender, EventArgs e)
        {
            if (dgvLista.RowCount != 0)
            {
                classPatient oGf = new classPatient();
                oGf.IdPatient = Convert.ToInt32(dgvLista.Rows[SelectRow].Cells[1].Value);
                oGf = (classPatient)oQuery.AbmPatient(oGf, classQuery.eAbm.Select);

                frmAbmPatient frmPatient = new frmAbmPatient();
                frmPatient.eModo = frmAbmPatient.Modo.Select;
                frmPatient.ObjetQuery = oQuery;
                frmPatient.oPatient = oGf;
                frmPatient.ObjetUtil = oUtil;
                frmPatient.ShowDialog();
            }
        }

        // OK - 17/11/16
        private void tsmiDiagnostic_Click(object sender, EventArgs e)
        {
            if (dgvLista.RowCount != 0)
            {
                int IdPatient = Convert.ToInt32(dgvLista.Rows[SelectRow].Cells[1].Value);
                frmAbmDiagnostic fDiagnostic = new frmAbmDiagnostic(IdPatient, frmAbmDiagnostic.SelectedId.Patient);
                fDiagnostic.oQuery = oQuery;
                fDiagnostic.oUtil = oUtil;
                fDiagnostic.ShowDialog();
            }
        }

        // OK - 18/02/08
        private void tsbPrintList_Click(object sender, EventArgs e)
        {
            DataSet dS = new DataSet();
            classPatient oP = new classPatient();
            oP.LastName = tstxtLastName.Text;
            oP.Name = tstxtName.Text;
            oP.NumberDocument = tstxtDocument.Text == string.Empty ? 0 : Convert.ToInt32(tstxtDocument.Text);

            if (oQuery.rpListPatient(oP.Name, oP.LastName, oP.NumberDocument))
            {
                dS.Tables.Add(oQuery.Table);
                frmVisor fReport = new frmVisor(oUtil.GetPathReport(), frmVisor.Reporte.RpListPatient, dS);
                fReport.Show();
            }
            else
                MessageBox.Show(oTxt.ErrorQueryList);
        }

        // OK - 18/02/08
        private void tsmiPrintSelect_Click(object sender, EventArgs e)
        {
            bool isOk = true;
            DataSet dS = new DataSet();
            int Id = Convert.ToInt32(dgvLista.Rows[SelectRow].Cells[1].Value);

            if (oQuery.RpSocialWork(Id))
                dS.Tables.Add(oQuery.Table);
            else
                isOk = false;

            if (oQuery.RpOnlyPatient(Id))
                dS.Tables.Add(oQuery.Table);
            else
                isOk = false;

            if (isOk)
            {
                frmVisor fReport = new frmVisor(oUtil.GetPathReport(), frmVisor.Reporte.RpOnlyPatient, dS);
                fReport.Show();
            }
            else
                MessageBox.Show(oTxt.ErrorQueryList);
        }

        // OK - 17/11/09
        private void tsmiPrintParent_Click(object sender, EventArgs e)
        {
            bool isOk = true;
            DataSet dS = new DataSet();
            int Id = Convert.ToInt32(dgvLista.Rows[SelectRow].Cells[1].Value);

            if (oQuery.RpOnlyPatient(Id))
                dS.Tables.Add(oQuery.Table);
            else
                isOk = false;

            if (oQuery.RpPatientParent(Id))
                dS.Tables.Add(oQuery.Table);
            else
                isOk = false;

            if (isOk)
            {
                frmVisor fReport = new frmVisor(oUtil.GetPathReport(), frmVisor.Reporte.RpPatientParent, dS);
                fReport.Show();
            }
            else
                MessageBox.Show(oTxt.ErrorQueryList);
        }

        // OK - 17/11/16
        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLista.RowCount >= 0)
            {
                SelectRow = e.RowIndex >= 0 ? e.RowIndex : SelectRow;
                SelectRow = dgvLista.RowCount == 1 ? 0 : SelectRow;
            }
        }

        #endregion

        // OK - 18/02/08
        #region Metodos

        // OK - 17/11/11
        private void Permission()
        {
            bool isAdmin = (oUtil.oProfessional.IdPermission == 1);
            tsmiAdd.Visible = isAdmin;
            tsmiDelete.Visible = isAdmin;
            tsmiUpdate.Visible = isAdmin;
            tssMenuAbm.Visible = isAdmin;
            tsmiPrintSelect.Visible = isAdmin;
            tsmiPrintParent.Visible = isAdmin;
            tssMenuPrint.Visible = isAdmin;
            tsbPrintList.Visible = isAdmin;
            tssPrint.Visible = isAdmin;
            tsbAdd.Visible = isAdmin;
            tssAdd.Visible = isAdmin;
        }

        /// <summary>
        /// Aplica Filtros de busqueda
        /// OK - 18/02/08
        /// </summary>
        public void Filtrar(int vPag)
        {
            int affNumber = tstxtDocument.Text == string.Empty ? 0 : Convert.ToInt32(tstxtDocument.Text);

            if (oQuery.FilterLimitPatient(
                    tstxtName.TextBox.Text, tstxtLastName.TextBox.Text, affNumber,
                vPag, oUtil.CantRegistrosGrilla))
            {
                decimal Cont = oQuery.FilterLimitCountPatient(
                    tstxtName.TextBox.Text,  tstxtLastName.TextBox.Text, affNumber);
                decimal Div = Math.Ceiling(Cont / oUtil.CantRegistrosGrilla);
                cantPag = Convert.ToInt32(Math.Round(Div, MidpointRounding.ToEven));
                tslPagina.Text = "Página: " + Pag.ToString() + " de " + cantPag.ToString();

                dgvLista.Columns.Clear();
                GenerarGrilla(oQuery.Table);

                if (dgvLista.RowCount != 0)
                {
                    PintarBloqueados(Color.Gray);
                    tsbPrintList.Enabled = true;
                }
                else
                    tsbPrintList.Enabled = false;
            }
            else
                MessageBox.Show(oTxt.ErrorQueryList);
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
        /// OK - 17/11/23
        /// </summary>
        /// <param name="Source"></param>
        public void GenerarGrilla(object Source)
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
            dgvLista.ContextMenuStrip = cmsMenuEmergente;
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLista.MultiSelect = false;
            dgvLista.DataSource = Source;
#if (!DEBUG)
            dgvLista.Columns[0].Visible = false;
            dgvLista.Columns[1].Visible = false;
            dgvLista.Columns[dgvLista.ColumnCount -1].Visible = false;
#endif
        }

        #endregion

        private void tsbPatientLoked_Click(object sender, EventArgs e)
        {
            PatientLocked = !PatientLocked;

            if (PatientLocked)
            {
                tsbPatientLoked.Text = "Ver Activos";
                tsbPatientLoked.BackColor = SystemColors.ControlDark;
            }
            else
            {
                tsbPatientLoked.Text = "Ver Bloqueados";
                tsbPatientLoked.BackColor = SystemColors.Control;
            }
        }
    }
}
