﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Clases
{
    public class ClassIvaType
    {
        #region Atributos y Metodos

        public int IdIvaType { set; get; }
        public string Description { set; get; }
        public bool Visible { set; get; }

        #endregion

        #region Constructores

        public ClassIvaType()
        {
            IdIvaType = 0;
            Description = string.Empty;
            Visible = true;
        }

        public ClassIvaType(int vIdIvaType)
        {
            IdIvaType = vIdIvaType;
            Description = string.Empty;
            Visible = true;
        }

        public ClassIvaType(int vIdIvaType, string vDescription, bool vVisible)
        {
            IdIvaType = vIdIvaType;
            Description = vDescription;
            Visible = vVisible;
        }

        #endregion

        #region Metodos
        public override string ToString()
        {
            return
            "IdIvaType: " + IdIvaType.ToString() +
            "\nDescription: " + Description +
            "\nVisible: " + Visible.ToString();
        }

        #endregion

    }
}
