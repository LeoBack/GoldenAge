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
    public partial class FrmListPatient : Form
    {
        // OK - 18/04/15
        #region Atributos y Propiedades

        public classQuery oQuery { set; get; }
        public ClassUtiles oUtil { set; get; }
        private classTextos oTxt;
        private int SelectRow;
        private int cantPag = 0;
        private int Pag = 1;
        //
        private bool PatientState = true;

        #endregion

        // OK - 18/04/15
        #region Formulario

        // OK - 17/09/30
        public FrmListPatient()
        {
            InitializeComponent();
            oTxt = new classTextos();
        }

        // OK - 18/04/15
        private void frmListPatient_Load(object sender, EventArgs e)
        {
            if (oQuery != null && oUtil != null)
            {
                Permission();
                Text = oTxt.TitleListPatient;
                SelectRow = 0;
                TslNumberPag.Text = "Página: 0 de 0";
                TsbPrintList.Enabled = false;
            }
            else
                Close();
        }

        #endregion

        // OK - 18/04/15
        #region Menu Contextual Botones

        // OK - 17/09/24
        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            if (DgvLista.RowCount != 0)
            {
                ClassPatient oGf = new ClassPatient();
                oGf.IdPatient = Convert.ToInt32(DgvLista.Rows[SelectRow].Cells[1].Value);
                oGf = (ClassPatient)oQuery.AbmPatient(oGf, classQuery.eAbm.Select);

                if (oGf != null)
                {
                    FrmAbmPatient frmA = new FrmAbmPatient(oGf, FrmAbmPatient.Modo.Update, oQuery, oUtil);
                    frmA.ShowDialog();
                }
                else
                    MessageBox.Show(oTxt.ErrorQueryList);
            }
        }

        // OK - 17/09/24
        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            FrmAbmPatient frmA = new FrmAbmPatient(null, FrmAbmPatient.Modo.Add, oQuery, oUtil);
            frmA.ShowDialog();
        }

        #endregion

        // OK - 18/04/15
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
        private void TsbSearch_Click(object sender, EventArgs e) => Filtrar(Pag = 1);

        // OK - 18/04/15
        private void TsbToggleStatus_Click(object sender, EventArgs e)
        {
            PatientState =! PatientState;

            if (PatientState)
            {
                //TsbToggleStatus.Text = "Ver Activos";
                TsbToggleStatus.BackColor = SystemColors.Control;
            }
            else
            {
                //TsbToggleStatus.Text = "Ver Bloqueados";
                TsbToggleStatus.BackColor = SystemColors.ControlDark;
            }
        }

        #endregion

        // OK - 18/02/08
        #region Botones

        // OK - 17/09/30
        private void tsmiSelect_Click(object sender, EventArgs e)
        {
            if (DgvLista.RowCount != 0)
            {
                ClassPatient oGf = new ClassPatient();
                oGf.IdPatient = Convert.ToInt32(DgvLista.Rows[SelectRow].Cells[1].Value);
                oGf = (ClassPatient)oQuery.AbmPatient(oGf, classQuery.eAbm.Select);

                FrmAbmPatient frmPatient = new FrmAbmPatient(oGf, FrmAbmPatient.Modo.Select, oQuery, oUtil);
                frmPatient.ShowDialog();
            }
        }

        // OK - 17/11/16
        private void tsmiDiagnostic_Click(object sender, EventArgs e)
        {
            if (DgvLista.RowCount != 0)
            {
                int IdPatient = Convert.ToInt32(DgvLista.Rows[SelectRow].Cells[1].Value);
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
            ClassPatient oP = new ClassPatient();
            oP.LastName = TstxtLastName.Text;
            oP.Name = tstxtName.Text;
            oP.NumberDocument = TstxtDocument.Text == string.Empty ? 0 : Convert.ToInt32(TstxtDocument.Text);

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
            int Id = Convert.ToInt32(DgvLista.Rows[SelectRow].Cells[1].Value);

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
            int Id = Convert.ToInt32(DgvLista.Rows[SelectRow].Cells[1].Value);

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
            if (DgvLista.RowCount >= 0)
            {
                SelectRow = e.RowIndex >= 0 ? e.RowIndex : SelectRow;
                SelectRow = DgvLista.RowCount == 1 ? 0 : SelectRow;
            }
        }

        #endregion

        // OK - 18/04/15
        #region Metodos

        // OK - 18/04/15
        private void Permission()
        {
            bool isAdmin = (oUtil.oProfessional.IdPermission == 1);
            TsmiAddFile.Visible = isAdmin;
            TsmiUpdateFile.Visible = isAdmin;
            TssMenuAbm.Visible = isAdmin;
            TsmiPrintSelect.Visible = isAdmin;
            TsmiPrintParent.Visible = isAdmin;
            TssMenuPrint.Visible = isAdmin;
            TsbPrintList.Visible = isAdmin;
            TssPrint.Visible = isAdmin;
            TsbAdd.Visible = isAdmin;
            TssAdd.Visible = isAdmin;
        }

        /// <summary>
        /// Aplica Filtros de busqueda
        /// OK - 18/02/08
        /// </summary>
        public void Filtrar(int vPag)
        {
            int affNumber = TstxtDocument.Text == string.Empty ? 0 : Convert.ToInt32(TstxtDocument.Text);

            if (oQuery.FilterLimitPatient(
                    tstxtName.TextBox.Text, TstxtLastName.TextBox.Text, affNumber, PatientState,
                vPag, oUtil.CantRegistrosGrilla))
            {
                decimal Cont = oQuery.FilterLimitCountPatient(
                    tstxtName.TextBox.Text,  TstxtLastName.TextBox.Text, affNumber);
                decimal Div = Math.Ceiling(Cont / oUtil.CantRegistrosGrilla);
                cantPag = Convert.ToInt32(Math.Round(Div, MidpointRounding.ToEven));
                TslNumberPag.Text = "Página: " + Pag.ToString() + " de " + cantPag.ToString();

                DgvLista.Columns.Clear();
                GenerarGrilla(oQuery.Table);

                if (DgvLista.RowCount != 0)
                {
                    PintarBloqueados(Color.Gray);
                    TsbPrintList.Enabled = true;
                }
                else
                    TsbPrintList.Enabled = false;
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
            int nCell = DgvLista.ColumnCount;

            for (int Fila = 0; Fila < DgvLista.Rows.Count; Fila++)
            {
                Block = Convert.ToBoolean(DgvLista.Rows[Fila].Cells[nCell - 1].Value);
                if (Block == false)
                    for (int Columna = 0; Columna < DgvLista.Rows[Fila].Cells.Count; Columna++)
                        DgvLista.Rows[Fila].Cells[Columna].Style.BackColor = Color;
            }
        }

        /// <summary>
        /// Carga la Lista debuelve la cantidad de filas.
        /// OK - 18/04/15
        /// </summary>
        /// <param name="Source"></param>
        public void GenerarGrilla(object Source)
        {
            //
            //Configuracion del DataListView
            //
            DgvLista.AutoGenerateColumns = true;
            DgvLista.AllowUserToAddRows = false;
            DgvLista.RowHeadersVisible = false;
            DgvLista.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            DgvLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvLista.ReadOnly = true;
            DgvLista.ScrollBars = ScrollBars.Both;
            DgvLista.ContextMenuStrip = CmsMenuEmergente;
            DgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvLista.MultiSelect = false;
            DgvLista.DataSource = Source;
#if (!DEBUG)
            DgvLista.Columns[0].Visible = false;
            DgvLista.Columns[1].Visible = false;
            DgvLista.Columns[DgvLista.ColumnCount -1].Visible = false;
#endif
        }

        #endregion
    }
}
