﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Controles
{
    public class classTextos
    {
        public string TituloVentana = "MyExplorer";

        //TitulosFrm
        public string SeparadorTitle = " -> Dr. ";
        public string TitleLogin = " -> Sesion No Iniciada";
        public string TitleAdministradorUsuario = "Administrador de Usuarios.";
        public string TitleSocialWorks = "Obras Sociales";
        public string TitleSocialWork = "Obra Social - Detalles";
        public string TitleFichaPatient = "Ficha Medica";
        public string TitleListGrandfather = "Lista de Pacientes";
        public string TitleListProfessional = "Planilla de Profesionales.";

        //
        public string Nombre = "Nombre";
        public string Aplicar  = "Aplicar";
        public string Editar = "Editar";
        public string Limpiar = "Limpiar";
        public string Bloquear = "Bloquear";
        public string Desbloquear = "Desloquear";

        public string AccionIndefinida = "Accion no definida";

        // Errores
        public string ErrorQueryList = "Error al obtener registros.";
        public string ErrorQueryUpdate = "Error al actualizar registros.";
        public string ErrorQueryDelete = "Error al eliminar registros.";
        public string ErrorQueryAdd = "Error al agregar registros.";
        public string ErrorObjetIndefinido = "Error: Objeto indefinido";

        // Validaciones
        public string CasillaBusquedaVacia = "Ingrese un criterio de búsqueda.";
        public string CaillasVacias = "Se encontraron casillas vacias";
        public string None = "No Aplica";
        public string LoginInvalido = "El nombre de usuario o contraseña no es valido.";
        public string Logout = "Cerrar Sesion";
        public string IniciarSesion = "Iniciar Sesion";

        // Profesionales
        public string AddProfessional = "El Profesional a sido grabado con exito.";
        public string UpdateProfessional = "El Profesional a sido actualizado con exito.";
        public string MostrarProfesionalesBloqueados = "Mostrar Profesionales bloqueados";
        public string OcultarProfesionalesBloqueados = "Ocultar Profesionales bloqueados";

        //patología
        public string Patología = "Patología";
        public string ModificarPatología = "Modificar patología.";
        public string AgregarPatología = "Agregar patología.";

        //SocialWork
        public string AddSocialWork = "Obra Social agregada con exito.";
        public string UpdateSocialWork = "Obra Social actualizada con exito.";

        //Mensajes
        public string MsgTituloCerrarAplicacion = "Atencion";
        public string MsgCerrarAplicacion = "¿Deseas cerrar la Aplicación?";
        public string MsgTituloDiagnostico = "Atencion";
        public string MsgEliminarDiagnostico = "La accion eliminara el diagnostico\n¿Desea Continuar?";
        public string MsgTituloHistoriClinica = "Armando planilla";
        public string MsgHistoriaClinica = "SI - La planilla mostrara los registros visualizados.\nNO - La planilla mostrara los registros que cumplan la condicion.";

        //Pacientes
        public string AgregarPaciente = "El Paciente a sido grabado con exito.";
        public string ModificarPaciente = "El Paciente a sido actualizado con exito.";
        public string PacienteSeleccionado = "Paciente Seleccionado : ";

        //Conexciones
        public string ConexionExitosa = "Conexion establecida";
        public string ConexionNuevaExitosa = "Nueva coneccion establecida";
        public string ConexionErronea = "Error al conectar";
        public string RestauracionExitosa = "Copia levantada con Exito!";
        public string RestauracionErronea = "A ocurrido un error al realizar la copia.";
        public string CopiaExitosa = "Copia realizada con Exito!";
        public string CopiaErronea = "A ocurrido un error al realizar la copia.";



        public string TitleListPatient { get; set; }
    }
}
