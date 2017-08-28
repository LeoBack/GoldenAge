using System;
using System.Collections.Generic;
using System.Text;

namespace Controles
{
    public class classValidaciones
    {

        /// <summary>
        /// Compara fechas con respecto a la edad.
        /// Agregar en el evento escritura.
        /// OK 01/11/11
        /// </summary>
        /// <param name="dtp"></param>
        /// <param name="Edad"></param>
        /// <returns></returns>
        public bool MenoresDeEdad(DateTime dtp, int Edad)
        {
            if (dtp.Date < (DateTime.Now.AddYears(-Edad)))
                return false;
            else
                return true;
        }

        /// <summary>
        /// Deja escribir solo numeros.
        /// Agregar en el evento escritura.
        /// OK 01/11/11
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>
        public bool isNumeric(char C)
        {
            if (!char.IsDigit(C))
            {
                if (C != Convert.ToChar("\b"))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Deja escribir solo numeros con coma "Decimales".
        /// Agregar en el evento escritura.
        /// OK 01/11/11
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>
        public bool isDecimal(char C)
        {
            if (!char.IsDigit(C))
            {
                if (C != Convert.ToChar("\b"))
                {
                    if (C != Convert.ToChar(","))
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Deja escribir solo caracteres.
        /// Agregar en el evento escritura.
        /// OK 01/11/11
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>
        public bool isChar(char C)
        {
            if (!char.IsLetter(C))
            {
                if (C != Convert.ToChar("\b"))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Valida si es direccion de mail valida.
        /// Agregar en el evento escritura.
        /// OK 01/11/11
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>
        public bool eMail(string email)
        {
            if (!email.Contains("@"))
            {
                return true;
            }
            return false;
        }
    }
}
