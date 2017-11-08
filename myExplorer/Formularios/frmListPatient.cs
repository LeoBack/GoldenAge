﻿using System;
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


namespace myExplorer.Formularios
{
    public partial class frmListPatient : Form
    {
        // OK - 17/09/30
        #region Atributos y Propiedades

        public classQuery oQuery { set; get; }
        public classUtiles oUtil { set; get; }
        private classTextos oTxt;
        private int SelectRow;
        private int Desde = 0;
        private int Hasta = 0;
        private int cantPag = 0;
        private int Pag = 1;

        #endregion

        // OK - 17/09/30
        #region Formulario

        // OK - 17/09/30
        public frmListPatient()
        {
            InitializeComponent();
            oTxt = new classTextos();
        }

        // OK - 17/09/30
        private void frmListPatient_Load(object sender, EventArgs e)
        {
            if (oQuery != null && oUtil != null)
            {
                Text = oTxt.TitleListPatient;
                SelectRow = 0;
                Hasta = oUtil.CantRegistrosGrilla;
                tslPagina.Text = "Página: 0 de 0";

                libFeaturesComponents.fComboBox.classControlComboBoxes.LoadComboSearch(tscmbSocialWork.ComboBox,
                    (bool)oQuery.AbmSocialWork(new classSocialWork(), classQuery.eAbm.LoadCmb), 
                    oQuery.Table);
                tsbPrintList.Enabled = false;
            }
            else
                Close();
        }

        #endregion

        // OK - 17/09/30
        #region Menu Contextual Botones

        // OK - 17/09/30
        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            classPatient oGf = null;

            if (dgvLista.Rows.Count != 0)
            {
                oGf = new classPatient();
                oGf.IdPatient = Convert.ToInt32(dgvLista.Rows[SelectRow].Cells[0].Value);
                oGf = (classPatient)oQuery.AbmPatient(oGf, classQuery.eAbm.Select);
                oGf.Visible = false;

                if (oGf != null)
                {
                    if (0 != (int)oQuery.AbmPatient(oGf, classQuery.eAbm.Update))
                        MessageBox.Show(oTxt.UpdateParent);
                    else
                        MessageBox.Show(oTxt.ErrorQueryUpdate);
                    //frmAbmPatient frmA = new frmAbmPatient();
                    //frmA.oQuery = oQuery;
                    //frmA.oUtil = oUtil;
                    //frmA.oPatient = oGf;
                    //frmA.eModo = frmAbmPatient.Modo.Delete;
                    //frmA.ShowDialog();
                }
                else
                    MessageBox.Show(oTxt.ErrorQueryList);

            }
        }

        // OK - 17/09/24
        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            classPatient oGf = new classPatient();

            if (dgvLista.Rows.Count != 0)
            {
                oGf.IdPatient = Convert.ToInt32(dgvLista.Rows[SelectRow].Cells[0].Value);
                oGf = (classPatient)oQuery.AbmPatient(oGf, classQuery.eAbm.Select);

                if (oGf != null)
                {
                    frmAbmPatient frmA = new frmAbmPatient();
                    frmA.oQuery = oQuery;
                    frmA.oUtil = oUtil;
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
            frmA.oQuery = oQuery;
            frmA.oUtil = oUtil;
            frmA.eModo = frmAbmPatient.Modo.Add;
            frmA.ShowDialog();
        }

        #endregion

        #region Paginador

        // REVISADO - 17/09/09
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (Pag < cantPag)
            {
                Pag++;
                Desde = Desde + oUtil.CantRegistrosGrilla;
                Filtrar();
            }
        }

        // REVISADO - 17/09/09
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (Pag > 1)
            {
                Pag--;
                Desde = Desde - oUtil.CantRegistrosGrilla;
                Filtrar();
            }
        }

        // REVISADO - 17/09/09
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Filtrar();
        }

        #endregion

        // OK - 17/09/30
        #region Botones

        // OK - 17/09/30
        private void tsmiSelect_Click(object sender, EventArgs e)
        {
            classPatient oGf = null;

            if (dgvLista.Rows.Count != 0)
            {
                oGf = new classPatient();
                oGf.IdPatient = Convert.ToInt32(dgvLista.Rows[SelectRow].Cells[0].Value);
                oGf = (classPatient)oQuery.AbmPatient(oGf, classQuery.eAbm.Select);

                frmAbmPatient frmPatient = new frmAbmPatient();
                frmPatient.eModo = frmAbmPatient.Modo.Select;
                frmPatient.oQuery = oQuery;
                frmPatient.oPatient = oGf;
                frmPatient.oUtil = oUtil;
                frmPatient.ShowDialog();
            }
        }

        // OK - 17/10/05
        private void tsmiDiagnostic_Click(object sender, EventArgs e)
        {
            classPatient oGf = null;

            if (dgvLista.Rows.Count != 0)
            {
                oGf = new classPatient();
                oGf.IdPatient = Convert.ToInt32(dgvLista.Rows[SelectRow].Cells[0].Value);
                oGf = (classPatient)oQuery.AbmPatient(oGf, classQuery.eAbm.Select);

                if (oGf != null)
                {
                    frmAbmDiagnostic fDiagnostic = new frmAbmDiagnostic();
                    fDiagnostic.oQuery = oQuery;
                    fDiagnostic.oUtil = oUtil;
                    fDiagnostic.oPatient = oGf;
                    fDiagnostic.ShowDialog();
                }
                else
                    MessageBox.Show(oTxt.ErrorQueryList);
            }
        }

        // OK - 17/10/28
        private void tsbPrintList_Click(object sender, EventArgs e)
        {
            DataTable[] Tables = new DataTable[1];

            classPatient oP = new classPatient();
            oP.LastName = tstxtLastName.Text;
            oP.Name = tstxtName.Text;
            oP.AffiliateNumber = tstxtAffiliateNumber.Text == "" ? 0 : Convert.ToInt32(tstxtAffiliateNumber.Text);
            oP.IdSocialWork = Convert.ToInt32(tscmbSocialWork.ComboBox.SelectedValue);

            if (oQuery.rpListPatient(oP.Name, oP.LastName, oP.AffiliateNumber, oP.IdSocialWork))
            {
                Tables[0] = oQuery.Table;
                frmVisor fReport = new frmVisor(frmVisor.Reporte.RpDiagnostic, Tables);
                fReport.Show();
            }
            else
                MessageBox.Show(oTxt.ErrorQueryList);
        }

        // OK - 17/10/28
        private void tsmiPrintSelect_Click(object sender, EventArgs e)
        {
            DataTable[] Tables = new DataTable[1];

            if (oQuery.RpOnlyPatient(Convert.ToInt32(dgvLista.Rows[SelectRow].Cells[0].Value)))
            {
                Tables[0] = oQuery.Table;
                frmVisor fReport = new frmVisor(frmVisor.Reporte.RpOnlyPatient, Tables);
                fReport.Show();
            }
            else
                MessageBox.Show(oTxt.ErrorQueryList);
        }

        // OK - 17/10/28
        private void tsmiPrintParent_Click(object sender, EventArgs e)
        {
            DataTable[] Tables = new DataTable[1];

            if (oQuery.RpPatientParent(Convert.ToInt32(dgvLista.Rows[SelectRow].Cells[0].Value)))
            {
                Tables[0] = oQuery.Table;
                frmVisor fReport = new frmVisor(frmVisor.Reporte.RpDiagnostic, Tables);
                fReport.Show();
            }
            else
                MessageBox.Show(oTxt.ErrorQueryList);
        }

        // OK - 17/09/30
        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectRow = dgvLista.Rows.Count != 0 ? e.RowIndex : 0;
        }

        #endregion

        // OK - 17/09/30
        #region Metodos

        /// <summary>
        /// Aplica Filtros de busqueda
        /// OK - 17/09/24
        /// </summary>
        public void Filtrar()
        {
            SelectRow = 0;

            int affNumber = tstxtAffiliateNumber.TextBox.Text != "" ? Convert.ToInt32(tstxtAffiliateNumber.TextBox.Text) : 0; 

            if (oQuery.FiltroPatientLimite(
                tstxtName.TextBox.Text,  tstxtLastName.TextBox.Text, affNumber,
                Convert.ToInt32(tscmbSocialWork.ComboBox.SelectedValue),
                Desde, Hasta))
            {
                //decimal Cont = oQuery.CountGrandfather(oGrandfather);
                //decimal Div = Math.Ceiling((Cont / oUtil.CantRegistrosGrilla));
                //cantPag = Convert.ToInt32(Math.Round(Div, MidpointRounding.ToEven));

                //tslPagina.Text = "Página: " + Convert.ToString(Pag) + " de " + Convert.ToString(cantPag);

                dgvLista.Columns.Clear();
                if (GenerarGrilla(oQuery.Table) != 0)
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
            dgvLista.ContextMenuStrip = cmsMenuEmergente;
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
