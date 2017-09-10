using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Grillas
{
    public class grvGrandfather
    {
        #region Atributos y Metodos

        public int IdGrandfather { set; get;}
        public string SocialWork { set; get; }
        public string Name { set; get; }
        public string LastName { set; get; }
        public string Sex { set; get; }
        public string AffiliateNumber { set; get; }

        #endregion

        #region Constructores

        public grvGrandfather()
        {
            this.IdGrandfather = 0;
            this.SocialWork = "";
            this.Name = "";
            this.LastName = "";
            this.Sex = "";
            this.AffiliateNumber = "";
        }

        public grvGrandfather(int vIdGrandfather, string vSocialWork, string vName, string vLastName,
            string vSex, string vAffiliateNumber)
        {
            this.IdGrandfather = vIdGrandfather;
            this.SocialWork= vSocialWork;
            this.Name = vName;
            this.LastName = vLastName;
            this.Sex = vSex;
            this.AffiliateNumber = vAffiliateNumber;
        }

        #endregion
    }
}
