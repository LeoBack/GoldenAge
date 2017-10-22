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


namespace myExplorer.Formularios
{
    public partial class frmListPatient : Form
    {
        // OK 17/09/30
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

        // OK 17/09/30
        #region Formulario

        // OK 17/09/30
        public frmListPatient()
        {
            InitializeComponent();
            oTxt = new classTextos();
        }

        // OK 17/09/30
        private void frmListPatient_Load(object sender, EventArgs e)
        {
            if (oQuery != null && oUtil != null)
            {
                Text = oTxt.TitleListPatient;
                SelectRow = 0;
                Hasta = oUtil.CantRegistrosGrilla;
                tslPagina.Text = "Página: 0 de 0";

                libFeaturesComponents.fComboBox.classControlComboBoxes.LoadCombo(tscmbSocialWork.ComboBox,
                    (bool)oQuery.AbmSocialWork(new classSocialWork(), classQuery.eAbm.LoadCmb), 
                    oQuery.Table);
                tsbImprimir.Enabled = false;
            }
            else
                Close();
        }

        #endregion

        // OK 17/09/30
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

        // OK 17/10/05
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

        // OK 17/09/30
        #region Menu Contextual Botones

        // OK 17/09/30
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

        // OK - 24/09/17
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

        // OK - 24/09/17
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

        // OK 17/09/30
        #region Botones

        // OK 17/09/30
        private void tsbImprimir_Click(object sender, EventArgs e)
        {
            classPatient oP = new classPatient();
            oP.LastName = tstxtLastName.Text;
            oP.AffiliateNumber = Convert.ToInt32(tstxtAffiliateNumber.Text);
            oP.IdSocialWork = Convert.ToInt32(tscmbSocialWork.ComboBox.SelectedValue);

            //if (oQuery.rListaGrandfatherLimite("dtPersona", oP, Desde, Hasta))
            //{
            //    frmVisor fReport = new frmVisor(frmVisor.Reporte.ListaPacientes, oQuery.Table);
            //    fReport.Show();
            //}
            //else
            MessageBox.Show(oTxt.ErrorQueryList);
        }

        // OK 17/09/30
        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectRow = dgvLista.Rows.Count != 0 ? e.RowIndex : 0;
        }

        #endregion

        // OK 17/09/30
        #region Metodos

        /// <summary>
        /// Aplica Filtros de busqueda
        /// OK - 24/09/17
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
                GenerarGrilla(oQuery.Table);
                PintarBloqueados(Color.Gray);
                tsbImprimir.Enabled = false;
                //tsmiVerFicha.Enabled = false;
            }
            else
            {
                //tsmiVerFicha.Enabled = true;
                tsbImprimir.Enabled = true;
            }
        }

        /// <summary>
        /// Colorea la Fila de Color
        /// OK - 24/09/17
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
        /// OK 17/10/03
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
