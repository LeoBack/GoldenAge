using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Clases
{
    public class classUsuarios
    {
        #region Atributos y Metodos

        public int IdUsuario { set; get; }
        public string Nombre { set; get; }
        public string Apellido { set; get; }
        public string Contrasenia { set; get; }
        public string Email { set; get; }
        public bool Bloqueado { set; get; }

        #endregion

        #region Constructores

        public classUsuarios()
        {
            this.IdUsuario = 0;
            this.Nombre = "";
            this.Apellido = "";
            this.Contrasenia = "";
            this.Email = "";
            this.Bloqueado = false;
        }

        public classUsuarios(int IdUsuario, string Nombre, string Apellido, 
            string Contrasenia, string Email, bool Bloqueado)
        {
            this.IdUsuario = IdUsuario;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Contrasenia = Contrasenia;
            this.Email = Email;
            this.Bloqueado = Bloqueado;
        }

        #endregion
    }
}
