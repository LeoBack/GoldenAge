using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Controles;
using Entidades;
using Entidades.Clases;
using Datos.Query;

namespace myExplorer.Formularios
{
    public partial class frmAbmDiagnostic : Form
    {
        // OK 17/10/05
        #region Atributos y Propiedades

        public classPatient oPatient { set; get; }
        public enum Modo { Add, Select, Update, Delete }
        public Modo eModo { set; get; }
        public classQuery oQuery { set; get; }
        public classUtiles oUtil { set; get; }
        private classTextos oTxt;
        private int SelectRow;

        #endregion

        // OK 17/10/05
        #region Formulario

        // OK 17/10/05
        public frmAbmDiagnostic()
        {
            InitializeComponent();
            oTxt = new classTextos();
        }

        // OK 17/10/05
        private void frmAbmDiagnostic_Load(object sender, EventArgs e)
        {
            if (oQuery != null && oUtil != null)
            {
                Text = oTxt.TitleDiagnostic;
                SelectRow = 0;
                initCmbSpecialty();
                txtPatient.Text = oPatient.LastName + "," + oPatient.Name;

                classDiagnostic oD = new classDiagnostic();
                oD.IdPatient = oPatient.IdPatient;

                List<classDiagnostic> lDiagnostic = oQuery.AbmDiagnostic(oD, classQuery.eAbm.SelectAll) as List<classDiagnostic>;
                DataTable dT = new DataTable("AbmDiagnostic");
                dT.Columns.Add("Id", typeof(Int32));
                dT.Columns.Add("Fecha", typeof(DateTime));
                dT.Columns.Add("Profesional", typeof(string));
                dT.Columns.Add("Diagnostico", typeof(string));
                foreach(classDiagnostic iD in lDiagnostic)
                    dT.Rows.Add(new object[] { iD.IdDiagnostic, iD.Date, "", iD.Detail });
                GenerarGrilla(dT);
            }
            else
            {
                MessageBox.Show(oTxt.ErrorObjetIndefinido);
                Close();
            }
        }

        #endregion

        // OK 03/06/12
        #region Botones

        // OK 03/06/12
        private void btnDeleteDiagnostic_Click(object sender, EventArgs e)
        {
            //bool error = false;
            //// Eliminar el Diagnostico
            //if (MessageBox.Show(oTxt.MsgEliminarDiagnostico, oTxt.MsgTituloDiagnostico, 
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            //    //error = oQuery.DeleteDiagnostic(oDiagnostico, false);
            //error = (bool)oQuery.AbmDiagnostic(oDiagnostico, classQuery.eAbm.Delete);

            //if (!error)
            //    MessageBox.Show(oTxt.ErrorQueryDelete);
            //else
            //    this.Close();
        }

        // OK 03/06/12
        private void btnSaveDiagnostic_Click(object sender, EventArgs e)
        {
            //bool error = false;
            //// Guardar el nuevo diagnostico.
            //if ((rtxtDiagnostico.Text != ""))
            //{
            //    if (Modo == Vista.Nuevo)
            //    {
            //        this.oDiagnostico.Diagnostico = this.oValidarSql.ValidaString(rtxtDiagnostico.Text);
            //        this.oDiagnostico.IdDetalle = Convert.ToInt32(cmbPatologia.SelectedValue);
            //        this.oDiagnostico.Fecha = DateTime.Now;
            //        error = oQuery.AgregarDiagnostico(oDiagnostico);
            //    }
            //    if (Modo == Vista.Modificar)
            //    {
            //        this.oDiagnostico.Diagnostico = this.oValidarSql.ValidaString(rtxtDiagnostico.Text);
            //        this.oDiagnostico.IdDetalle = Convert.ToInt32(cmbPatologia.SelectedValue);
            //        error = oQuery.ModificarDiagnostico(oDiagnostico);
            //    }
            //}

            //if (!error)
            //    MessageBox.Show(oTxt.ErrorAgregarConsulta);
            //else
            //    this.Close();
        }

        // OK 03/06/12
        private void btnAccept_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectRow = dgvLista.Rows.Count != 0 ? e.RowIndex : 0;
        }


        #endregion


        #region Metodos

        private void initCmbSpecialty()
        {
            libFeaturesComponents.fComboBox.classControlComboBoxes.LoadCombo(cmbSpecialty, 
                (bool)oQuery.AbmSpeciality(new classSpecialty(), classQuery.eAbm.LoadCmb), 
                oQuery.Table);
        }

        /// <summary>
        /// Aplica Filtros de busqueda
        /// OK - 24/09/17
        /// </summary>
        public void Filtrar()
        {
            SelectRow = 0;

            //if (oQuery.FiltroProfesionalesLimite(tstxtNombre.TextBox.Text, tstxtLastName.TextBox.Text, Desde, Hasta))
            if(SelectRow!=0)
            {
                //decimal Cont = oQuery.CountProfesionales(oValidarSql.ValidaString(tstxtNombre.TextBox.Text), Hiden);
                //decimal Div = Math.Ceiling((Cont / oUtil.CantRegistrosGrilla));
                //cantPag = Convert.ToInt32(Math.Round(Div, MidpointRounding.ToEven));

                //tslPagina.Text = "Página: " + Convert.ToString(Pag) + " de " + Convert.ToString(cantPag);

                dgvLista.Columns.Clear();
                GenerarGrilla(oQuery.Table);
            }
            else
                MessageBox.Show(oTxt.ErrorQueryList);
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
            //dgvLista.ContextMenuStrip = cmsMenuEmergente;
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLista.MultiSelect = false;
            dgvLista.DataSource = Source;
#if RELEASE
            dgvLista.Columns[0].Visible = false;
            dgvLista.Columns[dgvLista.ColumnCount -1].Visible = false;
#endif
            return dgvLista.Rows.Count;
        }

        #endregion
    }
}
