using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
// De la solucion
using Datos;
using Entidades;
using Entidades.Clases;
using Controles;

namespace myExplorer.Formularios
{
    public partial class frmVerObraSocial : Form
    {
        #region Atributos y Propiedades

        public classConsultas oConsulta { set; get; }
        public classUtiles oUtil { set; get; }
        private List<classObraSocial> lObraSocial;
        private classValidaSqlite oValidarSql = new classValidaSqlite();

        private classTextos oTxt = new classTextos();

        private int SelectRow;

        private int Desde = 0;
        private int Hasta = 0;
        private int cantPag = 0;
        private int Pag = 1;

        #endregion

        //OK 03/06/12
        #region Formulario

        //OK 25/05/12
        public frmVerObraSocial()
        {
            InitializeComponent();
        }

        //OK 25/05/12
        private void frmAux_Load(object sender, EventArgs e)
        {
            this.Text = oTxt.TituloObrasSociales;

            if (oConsulta != null)
            {
                this.SelectRow = 0;
                lblInfo.Text = "";

                this.Hasta = this.oUtil.CantRegistrosGrilla;
                this.tslPagina.Text = "Página: 0 de 0";
            }
            else
                this.Close();
        }

        #endregion

        //OK 03/06/12
        #region Botones

        private void tsbImprimir_Click(object sender, EventArgs e)
        {
            if (dgvLista.Rows.Count != 0)
            {
                frmDialogoImprecion fIm = new frmDialogoImprecion();
                fIm.oConsulta = this.oConsulta;
                fIm.oUtil = this.oUtil;
                fIm.IdObraSocial = Convert.ToInt32(dgvLista.Rows[this.SelectRow].Cells[0].Value);

                if (fIm.IdObraSocial != 0)
                    fIm.ShowDialog();
            }
        }

        // OK 24/06/12
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (this.Pag < this.cantPag)
            {
                this.Pag++;
                this.Desde = this.Desde + this.oUtil.CantRegistrosGrilla;
                this.Filtrar();
            }
        }

        // OK 24/06/12
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (this.Pag > 1)
            {
                this.Pag--;
                this.Desde = this.Desde - this.oUtil.CantRegistrosGrilla;
                this.Filtrar();
            }
        }

        //OK 24/05/12
        private void tsbBuscar_Click(object sender, EventArgs e)
        {
           this.Filtrar();
        }

        //OK 03/06/12
        private void tsbAgregar_Click(object sender, EventArgs e)
        {
                frmObraSocial frmA = new frmObraSocial();
                frmA.oConsulta = this.oConsulta;
                frmA.oUtil = this.oUtil;
                frmA.Acto = frmObraSocial.Accion.Nuevo;
                frmA.ShowDialog();

                frmAux_Load(sender, e);
        }

        //OK 03/06/12
        private void tsmiEliminar_Click(object sender, EventArgs e)
        {
            classObraSocial oOS = new classObraSocial();

            if (dgvLista.Rows.Count != 0)
            {
                oOS.Id = Convert.ToInt32(dgvLista.Rows[this.SelectRow].Cells["grvId"].Value);
                oOS = oConsulta.SelectObraSocial(oOS);
            }

            if (oConsulta.Error)
            {
                frmObraSocial frmA = new frmObraSocial();
                frmA.oConsulta = this.oConsulta;
                frmA.oUtil = this.oUtil;
                frmA.oObraSocial = oOS;
                frmA.Acto = frmObraSocial.Accion.Eliminar;
                frmA.ShowDialog();

                frmAux_Load(sender, e);
            }
            else
            {
                MessageBox.Show(oTxt.ErrorListaConsulta);
                this.Close();
            }
        }

        //OK 03/06/12
        private void tsmiModificar_Click(object sender, EventArgs e)
        {
            classObraSocial oOS = new classObraSocial();

            if (dgvLista.Rows.Count != 0)
            {
                oOS.Id = Convert.ToInt32(dgvLista.Rows[this.SelectRow].Cells["grvId"].Value);
                oOS = oConsulta.SelectObraSocial(oOS);
            }

            if (oConsulta.Error)
            {
                frmObraSocial frmA = new frmObraSocial();
                frmA.oConsulta = this.oConsulta;
                frmA.oUtil = this.oUtil;
                frmA.oObraSocial = oOS;
                frmA.Acto = frmObraSocial.Accion.Modificar;
                frmA.ShowDialog();

                frmAux_Load(sender, e);
            }
            else
            {
                MessageBox.Show(oTxt.ErrorListaConsulta);
                this.Close();
            }
        }

        //OK 03/06/12
        private void tsmiAgregar_Click(object sender, EventArgs e)
        {
            tsbAgregar_Click(sender, e);
        }

        //OK 24/05/12
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        //OK 24/05/12
        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelectRow = e.RowIndex;
        }

        #endregion

        //OK 03/06/12
        #region Metodos

        /// <summary>
        /// Aplica Filtros de busqueda
        /// OK 21/03/12
        /// </summary>
        public void Filtrar()
        {
            lObraSocial = oConsulta.FiltroObraSocialLimite(
                this.oValidarSql.ValidaString(tstxtNombre.TextBox.Text),
                this.Desde, this.Hasta);

            decimal Cont = oConsulta.CountObraSocial(tstxtNombre.TextBox.Text);
            decimal Div = Math.Ceiling((Cont / this.oUtil.CantRegistrosGrilla));
            this.cantPag = Convert.ToInt32(Math.Round(Div, MidpointRounding.ToEven));

            this.tslPagina.Text = "Página: " +Convert.ToString(this.Pag) + " de " + Convert.ToString(this.cantPag);

            if (oConsulta.Error)
            {
                dgvLista.Columns.Clear();
                this.GenerarGrilla(lObraSocial);
            }
            else
                MessageBox.Show(oTxt.ErrorListaConsulta);
        }

        /// <summary>
        /// Carga la Lista de Obras Sociales
        /// OK 18/04/12
        /// </summary>
        /// <param name="Source"></param>
        public void GenerarGrilla(object Source)
        {
            //
            //Columna Oculta ID
            //
            dgvLista.Columns.Add("grvId", "ID");
            dgvLista.Columns["grvId"].DataPropertyName = "Id";
            dgvLista.Columns["grvId"].Visible = false;
            dgvLista.Columns["grvId"].DefaultCellStyle.NullValue = "0";
            //
            //Columna Nombre
            //
            dgvLista.Columns.Add("grvNombre", "Nombre");
            dgvLista.Columns["grvNombre"].DataPropertyName = "Nombre";
            dgvLista.Columns["grvNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLista.Columns["grvNombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLista.Columns["grvNombre"].DefaultCellStyle.NullValue = "No especificado";
            //
            //Columna Detalle
            //
            dgvLista.Columns.Add("grvDescripcion", "Descripcion");
            dgvLista.Columns["grvDescripcion"].DataPropertyName = "Descripcion";
            dgvLista.Columns["grvDescripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLista.Columns["grvDescripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLista.Columns["grvDescripcion"].DefaultCellStyle.NullValue = "No especificado";
            //
            //Configuracion del DataListView
            //
            dgvLista.AutoGenerateColumns = false;
            dgvLista.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLista.ReadOnly = true;
            dgvLista.ScrollBars = ScrollBars.Both;
            dgvLista.ContextMenuStrip = cmsMenuEmergente;
            //dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvLista.MultiSelect = false;
            dgvLista.DataSource = Source;
        }

        #endregion


    }
}