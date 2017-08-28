using System;
using System.Windows.Forms;

namespace myExplorer.Formularios
{
    public partial class frmFecha : Form
    {

        public DateTime Fecha { set; get; }

        public frmFecha()
        {
            InitializeComponent();
        }

        private void frmCalendario_Load(object sender, EventArgs e)
        {
            if (this.Fecha == null)
                this.Fecha = DateTime.Now;

            this.dtmFecha.MinDate = DateTime.Now.Date;
            this.dtmFecha.Value = this.Fecha;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Fecha = this.dtmFecha.Value;
            this.Close();
        }

        private void frmFecha_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void dtmFecha_ValueChanged(object sender, EventArgs e)
        {
            this.Fecha = this.dtmFecha.Value;
            lblDiaHora.Text = this.Fecha.ToString();
        }
    }
}
