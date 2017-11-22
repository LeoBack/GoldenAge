using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos.Query
{
    class classNameProcedures
    {
        // ABM
        public string AbmDiagnostic = "[spAbmDiagnostic-v1.0]";
        public string AbmParent = "[spAbmParent-v1.0]";
        public string AbmPatient = "[spAbmPatient-v1.0]";
        public string AbmPatientParent = "[spAbmPatientParent-v1.0]";
        public string AbmPermission = "[spAbmPermission-v1.0]";
        public string AbmProfessional = "[spAbmProfessional-v1.0]";
        public string AbmProfessionalSpeciality = "[spAbmProfessionalSpeciality-v1.0]";
        public string AbmRelationship = "[spAbmRelationship-v1.0]";
        public string AbmSocialWork = "[spAbmSocialWork-v1.0]";
        public string AbmSpeciality = "[spAbmSpecialty-v1.0]";
        public string AbmTypeDocument = "[spAbmTypeDocument-v1.0]";
        public string AbmIvaType = "[spAbmIvaType-v1.0]";
        public string AbmTypeParent = "[spAbmTypeParent-v1.0]";

        // Especiales
        public string Login = "[spLoguin-v1.0]";
        public string Session = "[spSession-v1.0]";
        public string SpecialityProfessional = "[spSpecialityProfessional-v1.0]";
        public string Contadores = "[spContadores-v1.0]"; 

        // Filtros
        public string FilterSocialWorkLimite = "[spFilterLimitSocialWorks-v1.0]";
        public string CountSocialWorkLimite = "[spFilterLimitCountSocialWork-1.0]";
        public string FiltroProfesionalesLimite = "[spFilterLimitProfessional-v1.0]";
        public string CountProfesionalesLimite = "[spFilterLimitCountProfesionales-v1.0]";
        public string FiltroPatientLimite = "[spFilterLimitPatient-v1.0]";
        public string CountPatientLimite = "[spFilterLimitCountPatient-1.0]";
        public string FiltroDiagnosticLimite = "[spFilterLimitDiagnostic-v1.0]";
        public string CountDiagnosticLimite = "[spFilterLimitCountDiagnostic-1.0]";
        public string FiltroMessageLimite = "[spFilterLimitMessage-v1.0]";
        public string CountMessageLimite = "[spFilterLimitCountMessage-1.0]";

        // Reportes
        public string RpClinicHistory = "[spRpClinicHistory-v1.0]";
        public string RpOnlyPatient = "[spRpOnlyPatient-v1.0]";
        public string RpPatientParent = "[spRpPatientParent-v1.0]";
        public string RpListPatient = "[spRpListPatient-v1.0]";
        public string RpListProfessional = "[spRpListProfessional-v1.0]";
        public string RpOnlyProfessional = "[spRpOnlyProfessional-v1.0]";
        public string RpOnlyProfessionalSpeciality = "[spRpOnlyProfessionalSpeciality-v1.0]";
    }
}
