﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Clases
{
    public class ClassPermission
    {
        #region Atributos y Metodos

        public int IdPermission { set; get; }
        public string Description { set; get; }
        public bool Visible { set; get; }
        
        #endregion

        #region Constructores

        public ClassPermission()
        {
            IdPermission = 0;
            Description = string.Empty;
            Visible = true;
        }

        public ClassPermission(int vIdPermission)
        {
            IdPermission = vIdPermission;
            Description = string.Empty;
            Visible = true;
        }

        public ClassPermission(int vIdPermission, string vDescription, bool vVisible)
        {
            IdPermission = vIdPermission;
            Description = vDescription;
            Visible = vVisible;
        }

        #endregion

        #region Metodos
        public override string ToString()
        {
            return
            "IdPermission: " + IdPermission.ToString() +
            "\nDescription: " + Description +
            "\nVisible: " + Visible.ToString();
        }

        #endregion
    }
}
