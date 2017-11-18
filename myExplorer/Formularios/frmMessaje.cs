using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
// De la solucion
using Datos.Query;
using Entidades;
using Entidades.Clases;
using Controles;

namespace myExplorer.Formularios
{
    public partial class frmMessaje : Form
    {
        // OK - 17/11/16
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

        // OK - 17/11/16
        #region Formulario

        // OK - 17/11/16
        public frmMessaje()
        {
            InitializeComponent();
            oTxt = new classTextos();
        }

        // OK - 17/11/16
        private void frmMessaje_Load(object sender, EventArgs e)
        {
            if (oQuery != null && oUtil != null)
            {
                Text = oTxt.TitleMessages;
                SelectRow = 0;
                Hasta = oUtil.CantRegistrosGrilla;
                tslPagina.Text = "Página: 0 de 0";
            }
            else
                Close();
        }

        #endregion

        // OK 17/09/30
        #region Menu Contextual Botones

        // OK 17/09/30
        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            classSocialWork oSw = new classSocialWork();

            if (dgvLista.Rows.Count != 0)
            {
                oSw.IdSocialWork = Convert.ToInt32(dgvLista.Rows[SelectRow].Cells[0].Value);
                oSw = (classSocialWork)oQuery.AbmSocialWork(oSw, classQuery.eAbm.Select);
                oSw.Visible = false;

                if (oSw != null)
                {
                    if (0 != (int)oQuery.AbmSocialWork(oSw, classQuery.eAbm.Update))
                        MessageBox.Show(oTxt.UpdateSocialWork);
                    else
                        MessageBox.Show(oTxt.ErrorQueryUpdate);
                    //frmAbmSocialWork frmA = new frmAbmSocialWork();
                    //frmA.oQuery = oQuery;
                    //frmA.oUtil = oUtil;
                    //frmA.oSocialWork = oSw;
                    //frmA.eModo = frmAbmSocialWork.Modo.Delete;
                    //frmA.ShowDialog();
                }
                else
                    MessageBox.Show(oTxt.ErrorQueryList);

            }
        }

        // OK - 24/09/17
        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            classSocialWork oSw = new classSocialWork();

            if (dgvLista.Rows.Count != 0)
            {
                oSw.IdSocialWork = Convert.ToInt32(dgvLista.Rows[SelectRow].Cells[0].Value);
                oSw = (classSocialWork)oQuery.AbmSocialWork(oSw, classQuery.eAbm.Select);

                if (oSw != null)
                {
                    frmAbmSocialWork frmA = new frmAbmSocialWork();
                    frmA.oQuery = oQuery;
                    frmA.oUtil = oUtil;
                    frmA.oSocialWork = oSw;
                    frmA.eModo = frmAbmSocialWork.Modo.Update;
                    frmA.ShowDialog();
                }
                else
                    MessageBox.Show(oTxt.ErrorQueryList);
            }
        }

        // OK - 24/09/17
        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            frmAbmSocialWork frmA = new frmAbmSocialWork();
            frmA.oQuery = oQuery;
            frmA.oUtil = oUtil;
            frmA.eModo = frmAbmSocialWork.Modo.Add;
            frmA.ShowDialog();
        }

        #endregion

        // REVISADO - 17/09/09
        #region Paginador

        // REVISADO - 17/09/09
        private void tsbNext_Click(object sender, EventArgs e)
        {
            if (Pag < cantPag)
            {
                Pag++;
                Desde = Desde + oUtil.CantRegistrosGrilla;
                Filtrar();
            }
        }

        // REVISADO - 17/09/09
        private void tsbPreview_Click(object sender, EventArgs e)
        {
            if (Pag > 1)
            {
                Pag--;
                Desde = Desde - oUtil.CantRegistrosGrilla;
                Filtrar();
            }
        }

        // REVISADO - 17/09/09
        private void tsbSearch_Click(object sender, EventArgs e)
        {
            Filtrar();
        }

        #endregion

        // OK - 17/11/16
        #region Botones

        // OK - 17/11/16
        private void tsbRead_Click(object sender, EventArgs e)
        {
            if (dgvLista.RowCount != 0)
            {
                classDiagnostic oD = new classDiagnostic(Convert.ToInt32(dgvLista.Rows[SelectRow].Cells[0].Value));
                oD = oQuery.AbmDiagnostic(oD, classQuery.eAbm.Select) as classDiagnostic;
                if (oD != null)
                {
                    oD.DestinationRead = false;
                    if (0 != (int)oQuery.AbmDiagnostic(oD, classQuery.eAbm.Update))
                        MessageBox.Show(oTxt.UpdateDiagnostic);
                    else
                        MessageBox.Show(oTxt.ErrorQueryUpdate);
                    Filtrar();
                }
                else
                    MessageBox.Show(oTxt.ErrorQuerySelect);
            }
        }

        // OK - 17/11/16
        private void tsbOpen_Click(object sender, EventArgs e)
        {
            if (dgvLista.RowCount != 0)
            {
                int IdDiagnostic = Convert.ToInt32(dgvLista.Rows[SelectRow].Cells[0].Value);
                frmAbmDiagnostic fDiagnostic = new frmAbmDiagnostic(IdDiagnostic, frmAbmDiagnostic.SelectedId.Diagnostic);
                fDiagnostic.oQuery = oQuery;
                fDiagnostic.oUtil = oUtil;
                fDiagnostic.ShowDialog();
            }
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

        // OK - 17/11/16
        #region Metodos

        /// <summary>
        /// Aplica Filtros de busqueda
        /// OK - 24/09/17
        /// </summary>
        private void Filtrar()
        {
            SelectRow = 0;
            
            if (oQuery.FilterLimitMessage(1, oUtil.oProfessional.IdProfessional, 0, 1))
            {
                //decimal Cont = oQuery.CountSocialWork(tstxtNombre.TextBox.Text);
                //decimal Div = Math.Ceiling((Cont / oUtil.CantRegistrosGrilla));
                //cantPag = Convert.ToInt32(Math.Round(Div, MidpointRounding.ToEven));

                //tslPagina.Text = "Página: " + Convert.ToString(Pag) + " de " + Convert.ToString(cantPag);

                dgvLista.Columns.Clear();
                GenerarGrilla(oQuery.Table);
                PintarBloqueados(Color.Gray);
            }
            else
                MessageBox.Show(oTxt.ErrorQueryList);
        }

        /// <summary>
        /// Colorea la Fila de Color
        /// OK - 24/09/17
        /// </summary>
        /// <param name="Color"></param>
        private void PintarBloqueados(Color Color)
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
        private int GenerarGrilla(object Source)
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
            dgvLista.Columns[dgvLista.ColumnCount - 1].Visible = false;
#endif
            return dgvLista.Rows.Count;
        }

        #endregion
    }
}
