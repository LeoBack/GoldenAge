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
using Controles;

namespace myExplorer.Formularios
{
    public partial class frmListSocialWorks : Form
    {
        // OK - 24/09/17
        #region Atributos y Propiedades

        public classQuery oQuery { set; get; }
        public classUtiles oUtil { set; get; }

        private classTextos oTxt = new classTextos();

        private int SelectRow;
        private int Desde = 0;
        private int Hasta = 0;
        private int cantPag = 0;
        private int Pag = 1;

        #endregion

        // REVISADO - 17/09/09
        #region Formulario

        // OK - 17/09/09
        public frmListSocialWorks()
        {
            InitializeComponent();
        }

        // REVISADO - 17/09/09
        private void frmListSocialWorks_Load(object sender, EventArgs e)
        {
            if (oQuery != null && oUtil != null)
            {
                ConfiguracionInicial();
                Text = oTxt.TitleSocialWorks;
                SelectRow = 0;
                Hasta = oUtil.CantRegistrosGrilla;
                tslPagina.Text = "Página: 0 de 0";

                lblInfo.Text = "";
            }
            else
                Close();
        }

        #endregion

        // OK - 24/09/17
        #region Menu Contextual Botones

        // OK - 24/09/17
        private void tsmiDelete_Click(object sender, EventArgs e)
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
                    frmA.eModo = frmAbmSocialWork.Modo.Delete;
                    frmA.ShowDialog();

                    frmListSocialWorks_Load(sender, e);
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

                    frmListSocialWorks_Load(sender, e);
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
        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            Filtrar();
        }

        #endregion

        // OK - 24/09/17
        #region Botones

        // OK - 24/09/17
        private void tsbImprimir_Click(object sender, EventArgs e)
        {
            if (dgvLista.Rows.Count != 0)
            {
                frmDialogoImprecion fIm = new frmDialogoImprecion();
                fIm.oQuery = oQuery;
                fIm.oUtil = oUtil;
                fIm.IdSocialWork = Convert.ToInt32(dgvLista.Rows[SelectRow].Cells[0].Value);

                if (fIm.IdSocialWork != 0)
                    fIm.ShowDialog();
            }
        }

        // OK - 24/09/17
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        // OK - 24/09/17
        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLista.Rows.Count != 0)
            SelectRow = e.RowIndex;
        }

        #endregion

        // OK - 24/09/17
        #region Metodos

        /// <summary>
        /// Configura el formulario.
        /// OK - 24/09/17
        /// </summary>
        public void ConfiguracionInicial()
        {
            Size sBtn = new Size(75, 42);
            //btnBuscar.Size = sBtn;
            //btnSeleccionar.Size = sBtn;
            //btnCancelar.Size = sBtn;
        }

        /// <summary>
        /// Aplica Filtros de busqueda
        /// OK - 24/09/17
        /// </summary>
        public void Filtrar()
        {
            SelectRow = 0;

            if (oQuery.FiltroSocialWorkLimite(tstxtNombre.TextBox.Text, Desde, Hasta))
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
        /// Carga la Lista de Obras Sociales
        /// OK - 24/09/17
        /// </summary>
        /// <param name="Source"></param>
        public int GenerarGrilla(object Source)
        {
            //
            //Configuracion del DataListView
            //
            dgvLista.AutoGenerateColumns = true;
            dgvLista.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLista.ReadOnly = true;
            dgvLista.ScrollBars = ScrollBars.Both;
            dgvLista.ContextMenuStrip = cmsMenuEmergente;
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLista.MultiSelect = false;
            dgvLista.DataSource = Source;
            dgvLista.Columns[0].Visible = false;
            dgvLista.Columns[dgvLista.ColumnCount - 1].Visible = false;
            return dgvLista.Rows.Count;
        }

        #endregion
    }
}