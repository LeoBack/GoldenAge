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

        private bool Hiden;

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

                tsbUsuario.Text = oTxt.OcultarProfesionalesBloqueados;
                Hiden = true;

            }
            else
            {
                MessageBox.Show(oTxt.ErrorObjetoIndefinido);
                Close();
            }
        }

        #endregion

        // REVISADO - 17/09/09
        #region Botones

        // REVISADO - 17/09/09
        private void tsbUsuario_Click(object sender, EventArgs e)
        {
            if (Hiden)
            {
                tsbUsuario.Text = oTxt.MostrarProfesionalesBloqueados;
                Hiden = false;
            }
            else
            {
                tsbUsuario.Text = oTxt.OcultarProfesionalesBloqueados;
                Hiden = true;
            }
            Filtrar();
        }

        // REVISADO - 17/09/09
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            //if (dgvLista.Rows.Count != 0)
            //    IdSelecionado = Convert.ToInt32(dgvLista.Rows[SelectRow].Cells[0].Value);
            //else
            //    IdSelecionado = 0;
        }

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

        // REVISADO - 17/09/09
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        // REVISADO - 17/09/09
        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvLista.Rows.Count != 0)
                SelectRow = e.RowIndex;
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            frmProfessional frmA = new frmProfessional();
            frmA.oQuery = oQuery;
            frmA.oUtil = oUtil;
            frmA.Acto = frmProfessional.Modo.Add;
            frmA.ShowDialog();

            frmListProfessional_Load(sender, e);
        }

        #endregion

        // REVISADO - 17/09/09
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
        /// REVISADO - 17/09/09
        /// </summary>
        public void Filtrar()
        {
            if (oQuery.FiltroProfesionalesLimite(tstxtNombre.TextBox.Text, Desde, Hasta))
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
                //Bloqueado = Convert.ToInt32(dgvLista.Rows[Fila].Cells[0].Value);
                
                //if (Bloqueado == lProfesional[Fila].IdProfessional)
                //    if (lProfesional[Fila].Visible == true)
                //        for (int Columna = 0; Columna < dgvLista.Rows[Fila].Cells.Count; Columna++)
                //           dgvLista.Rows[Fila].Cells[Columna].Style.BackColor = Color;
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
