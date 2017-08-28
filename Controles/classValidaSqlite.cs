using System;
using System.Collections.Generic;
using System.Text;

namespace Controles
{
    public class classValidaSqlite
    {
        public string Texto { set; get; }

        public classValidaSqlite()
        {
            this.Texto = "";
        }

        public classValidaSqlite(string Texto)
        {
            this.Texto = Texto;
        }

        public string ValidaString(string CadenaString)
        {
            string txtR = "";
            foreach (char A in CadenaString)
            {
                if (A.ToString() == "'")
                    txtR = txtR + '-';
                //else if (A.ToString() == "@")
                    //txtR = txtR + '-';
                else if (A.ToString() == "#")
                    txtR = txtR + '-';
                else if (A.ToString() == Convert.ToString('"'))
                    txtR = txtR + '-';
                else if (A.ToString() == "/")
                    txtR = txtR + '-';
                else if (A.ToString() == "\\")
                    txtR = txtR + '-';
                else
                    txtR = txtR + A;
            }
            return txtR;
        }
    }
}
