using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Datos;
using Entidades.Clases;
using Entidades;
using Controles;

namespace myExplorer.Formularios
{
    public partial class frmListProfessional : Form
    {
        // REVISADO - 17/09/09
        #region Atributos y Propiedades

        public classConsultas oConsulta { set; get; }
        public classUtiles oUtil { set; get; }
        public int IdSelecionado { set; get; }

        private List<classProfessional> lProfesional;
        private bool Hiden;
        private int SelectRow;

        private classValidaSqlite oValidarSql = new classValidaSqlite();
        private classTextos oTxt = new classTextos();

        private int Desde = 0;
        private int Hasta = 0;
        private int cantPag = 0;
        private int Pag = 1;

        #endregion

        // REVISADO - 17/09/09
        #region Formulario

        // REVISADO - 17/09/09
        public frmListProfessional()
        {
            InitializeComponent();
        }

        // REVISADO - 17/09/09
        private void frmAux_Load(object sender, EventArgs e)
        {
            if (oConsulta != null && oUtil != null)
            {
                this.Text = oTxt.TituloListaProfesionales;
                this.IdSelecionado = 0;
                this.SelectRow = 0;

                tsbUsuario.Text = oTxt.OcultarProfesionalesBloqueados;
                this.Hiden = true;

                this.Hasta = this.oUtil.CantRegistrosGrilla;
                this.tslPagina.Text = "Página: 0 de 0";
            }
            else
            {
                MessageBox.Show(oTxt.ErrorObjetoIndefinido);
                this.Close();
            }
        }

        #endregion

        // REVISADO - 17/09/09
        #region Botones

        // REVISADO - 17/09/09
        private void tsbUsuario_Click(object sender, EventArgs e)
        {
            if (this.Hiden)
            {
                tsbUsuario.Text = oTxt.MostrarProfesionalesBloqueados;
                this.Hiden = false;
            }
            else
            {
                tsbUsuario.Text = oTxt.OcultarProfesionalesBloqueados;
                this.Hiden = true;
            }
            this.Filtrar();
        }

        // REVISADO - 17/09/09
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvLista.Rows.Count != 0)
                this.IdSelecionado = Convert.ToInt32(dgvLista.Rows[this.SelectRow].Cells[0].Value);
            else
                this.IdSelecionado = 0;
        }

        // REVISADO - 17/09/09
        private void tsbBuscar_Click(object sender, EventArgs e)
        {
           this.Filtrar();
        }

        // REVISADO - 17/09/09
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (this.Pag < this.cantPag)
            {
                this.Pag++;
                this.Desde = this.Desde + this.oUtil.CantRegistrosGrilla;
                this.Filtrar();
            }
        }

        // REVISADO - 17/09/09
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (this.Pag > 1)
            {
                this.Pag--;
                this.Desde = this.Desde - this.oUtil.CantRegistrosGrilla;
                this.Filtrar();
            }
        }

        // REVISADO - 17/09/09
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // REVISADO - 17/09/09
        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvLista.Rows.Count != 0)
                this.SelectRow = e.RowIndex;
        }

        #endregion

        // REVISADO - 17/09/09
        #region Metodos

        /// <summary>
        /// Aplica Filtros de busqueda
        /// REVISADO - 17/09/09
        /// </summary>
        public void Filtrar()
        {
            lProfesional = oConsulta.FiltroProfesionalesLimite(
                this.oValidarSql.ValidaString(tstxtNombre.TextBox.Text),
                this.Hiden, this.Desde, this.Hasta);

            decimal Cont = oConsulta.CountProfesionales(this.oValidarSql.ValidaString(tstxtNombre.TextBox.Text), this.Hiden);
            decimal Div = Math.Ceiling((Cont / this.oUtil.CantRegistrosGrilla));
            this.cantPag = Convert.ToInt32(Math.Round(Div, MidpointRounding.ToEven));

            this.tslPagina.Text = "Página: " + Convert.ToString(this.Pag) + " de " + Convert.ToString(this.cantPag);

            if (oConsulta.Error)
            {
                dgvLista.Columns.Clear();
                this.GenerarGrilla(lProfesional);
                this.PintarBloqueados(Color.Gray);
            }
            else
                MessageBox.Show(oTxt.ErrorListaConsulta);
        }

        /// <summary>
        /// Colorea la Fila de Color
        /// REVISADO - 17/09/09
        /// </summary>
        /// <param name="Color"></param>
        public void PintarBloqueados(Color Color)
        {
            int Bloqueado = 0;

            for (int Fila = 0; Fila < dgvLista.Rows.Count; Fila++)
            {
                Bloqueado = Convert.ToInt32(dgvLista.Rows[Fila].Cells[0].Value);
                
                if (Bloqueado == lProfesional[Fila].IdProfessional)
                    if (lProfesional[Fila].Visible == true)
                        for (int Columna = 0; Columna < dgvLista.Rows[Fila].Cells.Count; Columna++)
                           dgvLista.Rows[Fila].Cells[Columna].Style.BackColor = Color;
            }
        }

        /// <summary>
        /// Carga la Lista de Obras Sociales
        /// REVISADO - 17/09/09
        /// </summary>
        /// <param name="Source"></param>
        public void GenerarGrilla(object Source)
        {
            //
            //Columna Oculta ID
            //
            dgvLista.Columns.Add("grvId", "ID");
            dgvLista.Columns["grvId"].DataPropertyName = "IdProfessional";
            dgvLista.Columns["grvId"].Visible = false;
            dgvLista.Columns["grvId"].DefaultCellStyle.NullValue = "0";
            //
            //Columna Name
            //
            dgvLista.Columns.Add("grvName", "Nombre");
            dgvLista.Columns["grvName"].DataPropertyName = "Name";
            dgvLista.Columns["grvName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLista.Columns["grvName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLista.Columns["grvName"].DefaultCellStyle.NullValue = "No especificado";
            //
            //Columna LastName
            //
            dgvLista.Columns.Add("grvLastName", "Apellido");
            dgvLista.Columns["grvLastName"].DataPropertyName = "LastName";
            dgvLista.Columns["grvLastName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLista.Columns["grvLastName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLista.Columns["grvLastName"].DefaultCellStyle.NullValue = "No especificado";
            //
            //Columna ProfessionalRegistration
            //
            dgvLista.Columns.Add("grvEmail", "Matricula");
            dgvLista.Columns["grvRegistration"].DataPropertyName = "ProfessionalRegistration";
            dgvLista.Columns["grvRegistration"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLista.Columns["grvRegistration"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLista.Columns["grvRegistration"].DefaultCellStyle.NullValue = "No especificado";
            //
            //Columna Phone
            //
            dgvLista.Columns.Add("grvPhone", "Telefono");
            dgvLista.Columns["grvPhone"].DataPropertyName = "Phone";
            dgvLista.Columns["grvPhone"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLista.Columns["grvPhone"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLista.Columns["grvPhone"].DefaultCellStyle.NullValue = "No especificado";
            //
            //Configuracion del DataListView
            //
            dgvLista.AutoGenerateColumns = false;
            dgvLista.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLista.ReadOnly = true;
            dgvLista.ScrollBars = ScrollBars.Both;
            //dgvLista.ContextMenuStrip = cmsMenuEmergente;
            //dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvLista.MultiSelect = false;
            dgvLista.DataSource = Source;
        }

        #endregion
    }
}
