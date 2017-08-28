using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Datos;
using Reportes;
using Entidades;
using Entidades.Clases;
using Entidades.Clases.Grillas;
using Controles;

namespace myExplorer.Formularios
{
    public partial class frmTurno : Form
    {
        #region Atributos y Propiedades

        private enum Estado { Cancelado=4, Asistio=2, NoAsistio=3, Pendiente=1, Todos=0 }

        public classConsultas oConsulta { set; get; }
        public classPersona oPersona { set; get; }
        public classUtiles oUtil { set; get; }

        private classTurnos oT;
        private List<grvTurnos> lTurnos;
        private DateTime fecha;
        private bool[] oEstado = new bool[4];
        private classValidaSqlite oValidarSql = new classValidaSqlite();
        private classTextos oTxt = new classTextos();
        private int SelectRow;

        private int Desde = 0;
        private int Hasta = 0;
        private int cantPag = 0;
        private int Pag = 1;
        private bool BuscarPorFechas;

        #endregion

        #region Formulario

        public frmTurno()
        {
            InitializeComponent();
        }

        // OK 30/05/12
        private void frmTurno_Load(object sender, EventArgs e)
        {
            this.dtpHasta.Value = DateTime.Now.AddDays(1);

            this.Hasta = this.oUtil.CantRegistrosGrilla;
            this.tslPagina.Text = "Página: 0 de 0";

            if (this.oConsulta != null || oUtil.IdUsuario != 0)
            {
                this.EnableTurno(false);

                if (oPersona != null)
                {   // Si hay persona seleccionada.
                    string name = oPersona.Apellido + ", " + oPersona.Nombre;

                    rbtnPaciente.Checked = true;
                    rbtnFecha.Checked = false;

                    txtNombre.Text = name;

                    // Traigo todo los turnos de esa persona
                    this.Filtrar();

                    if (dgvLista.Rows.Count == 0)
                        btnAgregarTurno.Enabled = true;
                    else
                        this.EnableTurno(true);
                }
                else
                {
                    rbtnPaciente.Checked = false;
                    rbtnFecha.Checked = true;
                }
            }
            else
            {
                MessageBox.Show(oTxt.ErrorObjetoIndefinido);
                this.Close();
            }
        }

        // OK 30/05/12
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Botones

        // OK 15/06/12
        private void rbtnPaciente_CheckedChanged(object sender, EventArgs e)
        {
            this.BuscarPorFechas = false;
            this.HabilitarBusquedaPorPaciente(true);
            this.EnableTurno(false);
            this.LimpiarDatosUsuario();
            this.oPersona = null;
        }

        // OK 15/06/12
        private void rbtnFecha_CheckedChanged(object sender, EventArgs e)
        {
            this.BuscarPorFechas = true;
            this.HabilitarBusquedaPorPaciente(false);
            this.EnableTurno(false);
            this.LimpiarDatosUsuario();
            this.oPersona = null;
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

        // OK 23/04/12
        #region Persona

        // OK 230412
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmSearch frmBuscar = new frmSearch();
            frmBuscar.oConsulta = this.oConsulta;
            frmBuscar.oUtil = this.oUtil;

            if (frmBuscar.ShowDialog() == DialogResult.OK)
            {
                this.oPersona = this.CargarPersona(frmBuscar.IdPersona);

                this.SelectRow = 0;
                this.Filtrar();

                // Habilito Botones
                this.EnableTurno(true);
            }
        }

        // OK 230412
        private void btnAgrearPaciente_Click(object sender, EventArgs e)
        {
            frmForm frmPaciente = new frmForm();
            frmPaciente.oConsulta = this.oConsulta;
            frmPaciente.Modo = frmForm.Vista.Nuevo;
            frmPaciente.oUtil = this.oUtil;

            if (frmPaciente.ShowDialog() == DialogResult.OK)
            {
                if (frmPaciente.oPersona.IdPersona != 0)
                {
                    this.oPersona = this.CargarPersona(frmPaciente.oPersona.IdPersona);

                    this.SelectRow = 0;
                    this.Filtrar();

                    // Habilito Botones
                    this.EnableTurno(true);
                }
            }
        }

        #endregion

        #region Turno

        // OK 15/06/12
        private void btnHoy_Click(object sender, EventArgs e)
        {
            this.dtpDesde.Value = DateTime.Now.Date;
            this.dtpHasta.Value = DateTime.Now.Date.AddDays(1);
            // Busco 
            this.btnMostrar_Click(sender, e);
        }

        // OK 15/06/12
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (dtpDesde.Value <= dtpHasta.Value || dtpDesde.Value == dtpHasta.Value)
            {
                this.Filtrar();
                // Habilito Botones
                this.EnableTurno(false);
            }
            else
                MessageBox.Show("La fecha 'Hasta' debe ser mayor que la fecha 'Desde'");
        }

        #endregion

        #region Grilla

        //OK 21/06/12
        private void btnImprimirTurnos_Click(object sender, EventArgs e)
        {
            frmVisor fReport = null;

            if (rbtnFecha.Checked)
            {
                if (MessageBox.Show(this.oTxt.MsgHistoriaClinica, this.oTxt.MsgTituloHistoriClinica, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (oConsulta.rTurnosDelDiaLimite("dtListaTurno", dtpDesde.Value, dtpHasta.Value, oUtil.IdUsuario, this.Desde, this.Hasta))
                    fReport = new frmVisor(frmVisor.Reporte.ListaTurnos, oConsulta.Table);
                }
                else
                {
                    if (oConsulta.rTurnosDelDia("dtListaTurno", dtpDesde.Value, dtpHasta.Value, oUtil.IdUsuario))
                        fReport = new frmVisor(frmVisor.Reporte.ListaTurnos, oConsulta.Table);
                }
            }

            if (rbtnPaciente.Checked)
            {
                if (MessageBox.Show(this.oTxt.MsgHistoriaClinica, this.oTxt.MsgTituloHistoriClinica, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (oConsulta.rTurnosLimite("dtListaTurno", new classTurnos(0, DateTime.Now, 1, this.oPersona.IdPersona, oUtil.IdUsuario), this.Desde, this.Hasta))
                    fReport = new frmVisor(frmVisor.Reporte.ListaTurnos, oConsulta.Table);
                }
                else
                {
                    if (oConsulta.rTurnos("dtListaTurno", new classTurnos(0, DateTime.Now, 1, this.oPersona.IdPersona, oUtil.IdUsuario)))
                        fReport = new frmVisor(frmVisor.Reporte.ListaTurnos, oConsulta.Table);
                }
            }

            fReport.Show();
        }

        // OK 30/05/12
        private void btnAgregarTurno_Click(object sender, EventArgs e)
        {
            // Fmr Fecha
            frmFecha fC = new frmFecha(); 
            fC.Fecha = DateTime.Now;

            if (fC.ShowDialog() == DialogResult.OK)
            {
                this.fecha = fC.Fecha;
                oConsulta.AgregarTurno(new classTurnos(0, fecha, (int)Estado.Pendiente, this.oPersona.IdPersona, oUtil.IdUsuario));

                //Cargar todos los turnos de este paciente mostrar si tiene
                this.GenerarGrilla(oConsulta.FiltroTurnos(
                    new classTurnos(0, fecha, (int)Estado.Pendiente, this.oPersona.IdPersona, oUtil.IdUsuario)));
                // Habilito Botones
                this.EnableTurno(true);
            }
        }

        // OK 30/05/12
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (dgvLista.Rows.Count != 0)
            {
                int IdTurno = Convert.ToInt32(dgvLista.Rows[this.SelectRow].Cells[0].Value);
                oT = oConsulta.SelectTurno(new classTurnos(IdTurno, this.fecha, (int)Estado.Asistio, 0, oUtil.IdUsuario));

                if (DateTime.Now.Date >= oT.Turno.Date)
                {
                    this.DialogResult = MessageBox.Show("Si - El paciente asistio.\nNo - El paciente no asistio.", "Estado del Turno",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    
                    if (this.DialogResult == DialogResult.Yes)
                    {
                        oT.Estado = (int)Estado.Asistio;
                        this.Executar(oT);
                        this.DialogResult = DialogResult.None;
                    }

                    if (this.DialogResult == DialogResult.No)
                    {
                        oT.Estado = (int)Estado.NoAsistio;
                        this.Executar(oT);
                        this.DialogResult = DialogResult.None;
                    }

                    if (this.DialogResult == DialogResult.Cancel)
                    {
                        this.DialogResult = DialogResult.None;
                    }
                }
                else if (DateTime.Now.Date == oT.Turno.Date)
                {
                    oT.Estado = (int)Estado.Asistio;
                    this.Executar(oT);
                }
                else
                    MessageBox.Show("La fecha del turno es superior a la fecha del día.");
            }
        }

        private void Executar(classTurnos oT)
        {
            if (oConsulta.ModificarTurno(oT))
                MessageBox.Show("Estado actualizado");

            //Cargar todos los turnos de este paciente mostrar si tiene
            this.GenerarGrilla(oConsulta.FiltroTurnos(
                new classTurnos(0, fecha, (int)Estado.Todos, this.oPersona.IdPersona, oUtil.IdUsuario)));
        }

        // OK 30/05/12
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvLista.Rows.Count != 0)
            {
                int IdTurno = Convert.ToInt32(dgvLista.Rows[this.SelectRow].Cells[0].Value);
                oT = oConsulta.SelectTurno(new classTurnos(IdTurno, this.fecha, (int)Estado.Cancelado, 0, oUtil.IdUsuario));

                if (DateTime.Now <= oT.Turno)
                {
                    if (oT.Estado == (int)Estado.Cancelado)
                    {
                        if (MessageBox.Show("¿Recupera el turno?.", "Estado del turno", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            oT.Estado = (int)Estado.Pendiente;
                        else
                            oT.Estado = (int)Estado.Cancelado;
                    }
                    else
                        oT.Estado = (int)Estado.Cancelado;

                    this.Executar(oT);

                    if (dgvLista.Rows.Count == 0)
                    {
                        // Habilito Botones
                        this.EnableTurno(false);
                        btnAgregarTurno.Enabled = true;
                    }
                }
                else
                    MessageBox.Show("El turno no se puede descartar.");
            }
        }

        // OK 30/05/12
        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        { 
            if (dgvLista.Rows.Count != 0)
                this.SelectRow = e.RowIndex;
        }

        #endregion

        #endregion

        #region metodos

        public void Filtrar()
        {
            decimal Cont = 0;
            //this.SelectRow = 0;

            if (BuscarPorFechas)
            {
                lTurnos = oConsulta.FiltroTurnosDelDiaLimite(this.dtpDesde.Value.Date, this.dtpHasta.Value.Date,
                    oUtil.IdUsuario, this.Desde, this.Hasta);

                Cont = oConsulta.CountTurnosDelDia(this.dtpDesde.Value.Date, this.dtpHasta.Value.Date,
                    oUtil.IdUsuario);
            }
            else
            {
                classTurnos oTu = new classTurnos(0, fecha, (int)Estado.Todos, this.oPersona.IdPersona, oUtil.IdUsuario);
                // Traigo todo los turnos de esa persona
                lTurnos = oConsulta.FiltroTurnosLimite(oTu, this.Desde, this.Hasta);

                Cont = oConsulta.CountTurnos(oTu);
            }
            
            decimal Div = Math.Ceiling((Cont / this.oUtil.CantRegistrosGrilla));
            this.cantPag = Convert.ToInt32(Math.Round(Div, MidpointRounding.ToEven));

            this.tslPagina.Text = "Página: " + Convert.ToString(this.Pag) + " de " + Convert.ToString(this.cantPag);

            if (oConsulta.Error)
            {
                dgvLista.Columns.Clear();
                this.GenerarGrilla(lTurnos);
            }
            else
                MessageBox.Show(oTxt.ErrorListaConsulta);
        }


        private void LimpiarDatosUsuario()
        {
            foreach (Control oC in this.tlpDatos.Controls)
            {
                if (oC is TextBox)
                    oC.Text = "";
            }
        }

        /// <summary>
        /// OK 15/06/12
        /// </summary>
        /// <param name="X"></param>
        private void HabilitarBusquedaPorPaciente(bool X)
        {
            foreach (Control C in tlpDatos.Controls)
            {
                C.Enabled = X;
            }
            foreach (Control C in tlpPanelFecha.Controls)
            {
                C.Enabled = !X;
            }
        }

        /// <summary>
        /// 
        /// OK 30/05/12
        /// </summary>
        /// <param name="X"></param>
        private void EnableTurno(bool X)
        {
            btnConfirmar.Enabled = X;
            btnEliminar.Enabled = X;
            btnAgregarTurno.Enabled = X;
            tsmiConfirmar.Enabled = X;
            tsmiEliminar.Enabled = X;
            tsmiAgregar.Enabled = X;
        }

        /// <summary>
        /// Trae los datos del paciente "ID nesesario".
        /// OK 30/05/12
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        private classPersona CargarPersona(int Id)
        {
            classPersona oP = new classPersona();
            oP.IdPersona = Id;
            oP = oConsulta.SelectPersona(oP);
            txtNombre.Text = oP.Apellido + ", " + oP.Nombre;

            return oP;
        }

        /// <summary>
        /// Carga la Lista debuelve la cantidad de filas.
        /// OK 30/05/12
        /// </summary>
        /// <param name="Source"></param>
        private int GenerarGrilla(object Source)
        {
            if (dgvLista.Columns.Count != 0)
                dgvLista.Columns.Clear();

            //
            //Columna Oculta ID
            //
            dgvLista.Columns.Add("grvId", "ID");
            dgvLista.Columns["grvId"].DataPropertyName = "Id";
            dgvLista.Columns["grvId"].Visible = false;
            dgvLista.Columns["grvId"].DefaultCellStyle.NullValue = "0";
            //
            //Columna Estado
            //
            dgvLista.Columns.Add("grvPaciente", "Paciente");
            dgvLista.Columns["grvPaciente"].DataPropertyName = "Paciente";
            dgvLista.Columns["grvPaciente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLista.Columns["grvPaciente"].DefaultCellStyle.NullValue = "No especificado";
            dgvLista.Columns["grvPaciente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //
            //Columna Estado
            //
            dgvLista.Columns.Add("grvEstado", "Estado");
            dgvLista.Columns["grvEstado"].DataPropertyName = "EstadoNombre";
            dgvLista.Columns["grvEstado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLista.Columns["grvEstado"].DefaultCellStyle.NullValue = "No especificado";
            dgvLista.Columns["grvEstado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //
            //Columna Dia
            //
            dgvLista.Columns.Add("drvDia", "Dia");
            dgvLista.Columns["drvDia"].DataPropertyName = "Dia";
            dgvLista.Columns["drvDia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLista.Columns["drvDia"].DefaultCellStyle.NullValue = "No especificado";
            dgvLista.Columns["drvDia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            //
            //Columna Hora
            //
            dgvLista.Columns.Add("drvHora", "Hora");
            dgvLista.Columns["drvHora"].DataPropertyName = "Hora";
            dgvLista.Columns["drvHora"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLista.Columns["drvHora"].DefaultCellStyle.NullValue = "No especificado";
            dgvLista.Columns["drvHora"].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            //
            //Columna Turno
            //
            dgvLista.Columns.Add("drvAt", "Atendido por:");
            dgvLista.Columns["drvAt"].DataPropertyName = "Usuario";
            dgvLista.Columns["drvAt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvLista.Columns["drvAt"].DefaultCellStyle.NullValue = "No especificado";
            dgvLista.Columns["drvAt"].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            //
            //Configuracion del DataListView
            //
            dgvLista.AutoGenerateColumns = false;
            dgvLista.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLista.ReadOnly = true;
            dgvLista.ScrollBars = ScrollBars.Both;
            dgvLista.ContextMenuStrip = cmsMenuEmergente;
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLista.MultiSelect = false;
            dgvLista.DataSource = Source;

            return dgvLista.Rows.Count;
        }

        #endregion

    }
}
