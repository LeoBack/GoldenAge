using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
        /// Caracteres Permitidos: @ .
        /// Agregar en el evento escritura.
        /// OK 01/11/11
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>
        public bool eMail(char email)
        {
            String allowedLetter = email.ToString();
            if ((!allowedLetter.Contains("@")) && (!allowedLetter.Contains(".")))
            {
                return true;
            }
            return false;
        }

        // <summary>
        /// Valida si es direccion de mail valida.
        /// Formato: correo@dominio.com
        /// Agregar en el evento escritura.
        /// OK 10/10/17
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>
        public bool ComprobarFormatoEmail(string sEmailAComprobar)
        {
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(sEmailAComprobar, sFormato))
            {
                if (Regex.Replace(sEmailAComprobar, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        
        /// <summary>
        /// Valida si es Retroseso.
        /// Agregar en el evento escritura.
        /// OK 07/10/17
        /// </summary>
        /// <param name="retro"></param>
        /// <returns></returns>
        public bool isRetroceso(char retro)
        {
            if (retro != Convert.ToChar(Keys.Back))
            {
                return true;
            }
            return false;

        }

        /// <summary>
        /// Valida Carecteres aceptados de un Numero de Telefono + - () 
        /// Agregar en el evento escritura.
        /// OK 07/10/17
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public bool isPhone(char symbol)
        {
            String comp = symbol.ToString();
            if ((!comp.Contains("+")) && ((!comp.Contains("("))) && ((!comp.Contains(")"))) && ((!comp.Contains("-"))))
            {
                return true;
            }
            return false;
        }

        /// Valida si es direccion de mail valida.
        /// Formato: correo@dominio.com
        /// Agregar en el evento escritura.
        /// OK 10/10/17
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>
        public bool ComprobarFormatoTelefono(string sPhoneAComprobar)
        {
            String sFormato;
            //sFormato = @"^[+-]?\d+(\.\d+)?$";
            sFormato = @"^ [0-9, +, (),,] {1,} (, [0-9] +) {0,} $"; 
            if (Regex.IsMatch(sPhoneAComprobar, sFormato))
            {
                if (Regex.Replace(sPhoneAComprobar, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


    }
}
