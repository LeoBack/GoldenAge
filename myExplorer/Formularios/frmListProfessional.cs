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
using Reportes;

namespace myExplorer.Formularios
{
    public partial class frmListProfessional : Form
    {
        // OK - 30/09/17
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

        // OK - 30/09/17
        #region Formulario

        // OK - 30/09/17
        public frmListProfessional()
        {
            InitializeComponent();
            oTxt = new classTextos();
        }

        // OK - 30/09/17
        private void frmListProfessional_Load(object sender, EventArgs e)
        {
            if (oQuery != null && oUtil != null)
            {
                Text = oTxt.TitleListProfessional;
                SelectRow = 0;
                Hasta = oUtil.CantRegistrosGrilla;
                tslPagina.Text = "Página: 0 de 0";
                tsbPrintList.Enabled = false;
            }
            else
            {
                MessageBox.Show(oTxt.ErrorObjetIndefinido);
                Close();
            }
        }

        #endregion

        // OK - 17/09/24
        #region Menu Contextual Botones

        // OK - 17/09/24
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
                }
                else
                    MessageBox.Show(oTxt.ErrorQueryList);

            }
        }

        // OK - 17/09/24
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
                }
                else
                    MessageBox.Show(oTxt.ErrorQueryList);
            }
        }

        // OK - 17/09/24
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

        // OK - 17/11/09
        #region Botones

        // OK - 17/11/09
        private void tsbPrintList_Click(object sender, EventArgs e)
        {
            DataSet dS = new DataSet();
            classProfessional oP = new classProfessional();
            oP.LastName = tstxtLastName.Text;
            oP.Name = tstxtName.Text;

            if (oQuery.rpListProfessional(oP.Name, oP.LastName))
            {
                dS.Tables.Add(oQuery.Table);
                frmVisor fReport = new frmVisor(oUtil.GetPathReport(), frmVisor.Reporte.RpListProfessional, dS);
                fReport.Show();
            }
            else
                MessageBox.Show(oTxt.ErrorQueryList);
        }

        // OK - 17/11/09
        private void tsmiPrintSelect_Click(object sender, EventArgs e)
        {
            bool isOk = true;
            DataSet dS = new DataSet();
            int Id = Convert.ToInt32(dgvLista.Rows[SelectRow].Cells[0].Value);

            if (oQuery.RpProfessionalSpeciality(Id))
                dS.Tables.Add(oQuery.Table);
            else
                isOk = false;

            if (oQuery.RpOnlyProfessional(Id))
                dS.Tables.Add(oQuery.Table);
            else
                isOk = false;

            if (isOk)
            {
                frmVisor fReport = new frmVisor(oUtil.GetPathReport(), frmVisor.Reporte.RpOnlyProfessional, dS);
                fReport.Show();
            }
            else
                MessageBox.Show(oTxt.ErrorQueryList);
        }

        // OK - 17/09/24
        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectRow = dgvLista.Rows.Count >= 0 ? e.RowIndex : 0;
        }

        #endregion

        // OK - 17/09/24
        #region Metodos

        /// <summary>
        /// Aplica Filtros de busqueda
        /// OK - 17/09/24
        /// </summary>
        public void Filtrar()
        {
            SelectRow = 0;

            if (oQuery.FilterLimitProfession(tstxtName.TextBox.Text, tstxtLastName.TextBox.Text, Desde, Hasta))
            { 
                //decimal Cont = oQuery.CountProfesionales(oValidarSql.ValidaString(tstxtNombre.TextBox.Text), Hiden);
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
                Block = Convert.ToBoolean(dgvLista.Rows[Fila].Cells[nCell-1].Value);
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
