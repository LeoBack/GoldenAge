using System;
using System.Collections.Generic;
using System.Text;
//
using System.IO;
using Entidades.Clases;

namespace Entidades
{
    public class ClassUtiles
    {
        private int IdSession;
        public ClassProfessional oProfessional { set; get; }
        public int CantRegistrosGrilla { set; get; }


        private string PathOrigin = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        private string NameApk = "GoldenAge";
        private string NameReport = "DocumentReport";

        public ClassUtiles()
        {
            this.oProfessional = null;
            this.CantRegistrosGrilla = 20;
            this.CreateDirectory();
        }

        public ClassUtiles(ClassProfessional vProfessional, int CantRegistrosGrilla)
        {
            this.oProfessional = vProfessional;
            this.CantRegistrosGrilla = CantRegistrosGrilla;
            this.CreateDirectory();
        }

        public void SetSesion(int Id)
        {
            IdSession = Id;
        }

        public int GetSesion()
        {
            return IdSession;
        }

        public string GetPathReport()
        {
            return Path.Combine(PathOrigin, NameApk, NameReport);
        }

        private void CreateDirectory()
        {
            if (!Directory.Exists(Path.Combine(PathOrigin, NameApk)))
                Directory.CreateDirectory(Path.Combine(PathOrigin, NameApk));

            if (!Directory.Exists(Path.Combine(PathOrigin, NameApk, NameReport)))
                Directory.CreateDirectory(Path.Combine(PathOrigin, NameApk, NameReport));
        }
    }
}
