using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Datos.Query;
using Entidades.Clases;
using Entidades;
using Controles;

namespace myExplorer.Formularios
{
    public partial class frmListProfessional : Form
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
        public frmListProfessional()
        {
            InitializeComponent();
        }

        // REVISADO - 17/09/09
        private void frmListProfessional_Load(object sender, EventArgs e)
        {
            if (oQuery != null && oUtil != null)
            {
                ConfiguracionInicial();
                Text = oTxt.TitleListProfessional;
                SelectRow = 0;
                Hasta = oUtil.CantRegistrosGrilla;
                tslPagina.Text = "Página: 0 de 0";
            }
            else
            {
                MessageBox.Show(oTxt.ErrorObjetIndefinido);
                Close();
            }
        }

        #endregion

        // OK - 24/09/17
        #region Menu Contextual Botones

        // OK - 24/09/17
        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            classProfessional oP = new classProfessional();

            if (dgvLista.Rows.Count != 0)
            {
                oP.IdProfessional = Convert.ToInt32(dgvLista.Rows[SelectRow].Cells[0].Value);
                oP = (classProfessional)oQuery.AbmProfessional(oP, classQuery.eAbm.Select);
                oP.Visible = false;

                if (oP != null)
                {
                    if (0 != (int)oQuery.AbmProfessional(oP, classQuery.eAbm.Update))
                        MessageBox.Show(oTxt.UpdateProfessional);
                    else
                        MessageBox.Show(oTxt.ErrorQueryUpdate);
                    //frmAbmProfessional frmA = new frmAbmProfessional();
                    //frmA.oQuery = oQuery;
                    //frmA.oUtil = oUtil;
                    //frmA.oProfessional = oP;
                    //frmA.eModo = frmAbmProfessional.Modo.Delete;
                    //frmA.ShowDialog();
                    frmListProfessional_Load(sender, e);
                }
                else
                    MessageBox.Show(oTxt.ErrorQueryList);

            }
        }

        // OK - 24/09/17
        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            classProfessional oP = new classProfessional();

            if (dgvLista.Rows.Count != 0)
            {
                oP.IdProfessional = Convert.ToInt32(dgvLista.Rows[SelectRow].Cells[0].Value);
                oP = (classProfessional)oQuery.AbmProfessional(oP, classQuery.eAbm.Select);

                if (oP != null)
                {
                    frmAbmProfessional frmA = new frmAbmProfessional();
                    frmA.oQuery = oQuery;
                    frmA.oUtil = oUtil;
                    frmA.oProfessional = oP;
                    frmA.eModo = frmAbmProfessional.Modo.Update;
                    frmA.ShowDialog();

                    frmListProfessional_Load(sender, e);
                }
                else
                    MessageBox.Show(oTxt.ErrorQueryList);
            }
        }

        // OK - 24/09/17
        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            frmAbmProfessional frmA = new frmAbmProfessional();
            frmA.oQuery = oQuery;
            frmA.oUtil = oUtil;
            frmA.eModo = frmAbmProfessional.Modo.Add;
            frmA.ShowDialog();
        }

        #endregion


        #region Paginador

        // REVISADO - 17/09/09
        private void tsbBuscar_Click(object sender, EventArgs e)
        {
           Filtrar();
        }

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

        #endregion

        // OK - 24/09/17
        #region Botones

        // OK - 24/09/17
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        // OK - 24/09/17
        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvLista.Rows.Count != 0)
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

            if (oQuery.FiltroProfesionalesLimite(tstxtNombre.TextBox.Text, tstxtLastName.TextBox.Text, Desde, Hasta))
            { 
                //decimal Cont = oQuery.CountProfesionales(oValidarSql.ValidaString(tstxtNombre.TextBox.Text), Hiden);
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
                Block = Convert.ToBoolean(dgvLista.Rows[Fila].Cells[nCell-1].Value);
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
            dgvLista.Columns[dgvLista.ColumnCount -1].Visible = false;
            return dgvLista.Rows.Count;
        }

        #endregion
    }
}
