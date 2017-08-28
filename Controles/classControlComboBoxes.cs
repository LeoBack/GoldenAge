using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Controles
{
    public class classControlComboBoxes
    {
        /// <summary>
        /// Muestar el valor de la pocicion indicada.
        /// </summary>
        /// <param name="Control"></param>
        /// <param name="Valor"></param>
        public void IndexCombos(ComboBox Control, int Valor)
        {
            int count = Control.Items.Count;
            int cont = 0;

            if (Valor != 0)
            {
                while (cont <= count)
                {
                    Control.SelectedIndex = cont;
                    if (Convert.ToInt32(Control.SelectedValue) == Valor)
                        break;
                    cont++;
                }
            }
        }

        /// <summary>
        /// Carga el Control COMBOBOX desde una consulta.
        /// OK 04/04/12
        /// </summary>
        /// <param name="Control"></param>
        /// <param name="Consulta"></param>
        /// <param name="Table"></param>
        public void CargaCombo(ComboBox Control, bool Consulta, System.Data.DataTable Table)
        {
            if (Consulta)
            {
                Control.DisplayMember = "Valor";
                Control.ValueMember = "Id";
                Control.DataSource = Table;
            }
            else
            {
                Control.Items.Add("Error");
            }
        }
    }
}
