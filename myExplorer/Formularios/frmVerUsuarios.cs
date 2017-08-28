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
    public partial class frmVerUsuarios : Form
    {
        #region Atributos y Propiedades

        public classConsultas oConsulta { set; get; }
        public classUtiles oUtil { set; get; }
        public int IdSelecionado { set; get; }

        private List<classUsuarios> lUsuarios;
        private bool Hiden;
        private int SelectRow;

        private classValidaSqlite oValidarSql = new classValidaSqlite();
        private classTextos oTxt = new classTextos();

        private int Desde = 0;
        private int Hasta = 0;
        private int cantPag = 0;
        private int Pag = 1;

        #endregion

        //OK 11/06/12
        #region Formulario

        //OK 25/05/12
        public frmVerUsuarios()
        {
            InitializeComponent();
        }

        //OK 11/06/12
        private void frmAux_Load(object sender, EventArgs e)
        {
            if (oConsulta != null && oUtil != null)
            {
                this.Text = oTxt.TituloListaUsuarios;
                this.IdSelecionado = 0;
                this.SelectRow = 0;

                tsbUsuario.Text = oTxt.OcultarUsuariosBloqueados;
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

        //OK 11/06/12
        #region Botones

        //OK 11/06/12
        private void tsbUsuario_Click(object sender, EventArgs e)
        {
            if (this.Hiden)
            {
                tsbUsuario.Text = oTxt.MostrarUsuariosBloqueados;
                this.Hiden = false;
            }
            else
            {
                tsbUsuario.Text = oTxt.OcultarUsuariosBloqueados;
                this.Hiden = true;
            }
            this.Filtrar();
        }

        //OK 11/06/12
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvLista.Rows.Count != 0)
                this.IdSelecionado = Convert.ToInt32(dgvLista.Rows[this.SelectRow].Cells[0].Value);
            else
                this.IdSelecionado = 0;
        }

        //OK 24/05/12
        private void tsbBuscar_Click(object sender, EventArgs e)
        {
           this.Filtrar();
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
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //OK 24/05/12
        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvLista.Rows.Count != 0)
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
            lUsuarios = oConsulta.FiltroUsuarioLimite(
                this.oValidarSql.ValidaString(tstxtNombre.TextBox.Text), 
                this.Hiden, this.Desde, this.Hasta);

            decimal Cont = oConsulta.CountUsuarios(this.oValidarSql.ValidaString(tstxtNombre.TextBox.Text), this.Hiden);
            decimal Div = Math.Ceiling((Cont / this.oUtil.CantRegistrosGrilla));
            this.cantPag = Convert.ToInt32(Math.Round(Div, MidpointRounding.ToEven));

            this.tslPagina.Text = "Página: " + Convert.ToString(this.Pag) + " de " + Convert.ToString(this.cantPag);
            
            if (oConsulta.Error)
            {
                dgvLista.Columns.Clear();
                this.GenerarGrilla(lUsuarios);
                this.PintarBloqueados(Color.Gray);
            }
            else
                MessageBox.Show(oTxt.ErrorListaConsulta);
        }

        /// <summary>
        /// Colorea la Fila de Color
        /// OK 11/06/12
        /// </summary>
        /// <param name="Color"></param>
        public void PintarBloqueados(Color Color)
        {
            int Bloqueado = 0;

            for (int Fila = 0; Fila < dgvLista.Rows.Count; Fila++)
            {
                Bloqueado = Convert.ToInt32(dgvLista.Rows[Fila].Cells[0].Value);
                
                if (Bloqueado == lUsuarios[Fila].IdUsuario)
                    if (lUsuarios[Fila].Bloqueado == true)
                        for (int Columna = 0; Columna < dgvLista.Rows[Fila].Cells.Count; Columna++)
                            dgvLista.Rows[Fila].Cells[Columna].Style.BackColor = Color;
            }
        }

        /// <summary>
        /// Carga la Lista de Obras Sociales
        /// OK 11/06/12
        /// </summary>
        /// <param name="Source"></param>
        public void GenerarGrilla(object Source)
        {
            //
            //Columna Oculta ID
            //
            dgvLista.Columns.Add("grvId", "ID");
            dgvLista.Columns["grvId"].DataPropertyName = "IdUsuario";
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
            dgvLista.Columns.Add("grvApellido", "Apellido");
            dgvLista.Columns["grvApellido"].DataPropertyName = "Apellido";
            dgvLista.Columns["grvApellido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLista.Columns["grvApellido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLista.Columns["grvApellido"].DefaultCellStyle.NullValue = "No especificado";
            //
            //Columna Email
            //
            dgvLista.Columns.Add("grvEmail", "Email");
            dgvLista.Columns["grvEmail"].DataPropertyName = "Email";
            dgvLista.Columns["grvEmail"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLista.Columns["grvEmail"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLista.Columns["grvEmail"].DefaultCellStyle.NullValue = "No especificado";
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
