using System;
using System.Collections.Generic;
using G1asistenciaEC.controlador;
using G1asistenciaEC.modelo;

namespace G1asistenciaEC.negocio
{
    public class asistenciasMatriculadosN
    {
        private readonly asistenciasMatriculadosC _controlador = new asistenciasMatriculadosC();

        public asistenciasMatriculadosM ObtenerPorMatriculaYFecha(string idMatricula, DateTime fecha)
        {
            try
            {
                if (string.IsNullOrEmpty(idMatricula))
                    throw new ArgumentException("El ID de matrícula no puede estar vacío.");

                if (fecha == DateTime.MinValue || fecha == DateTime.MaxValue)
                    throw new ArgumentException("La fecha proporcionada no es válida.");

                var asistencia = _controlador.ObtenerPorMatriculaYFecha(idMatricula, fecha);
                return asistencia;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener asistencia: {ex.Message}", ex);
            }
        }

        public List<asistenciasMatriculadosM> ObtenerPorGradoYSeccionYFecha(string grado, string seccion, DateTime fecha)
        {
            try
            {
                if (string.IsNullOrEmpty(grado))
                    throw new ArgumentException("El grado no puede estar vacío.");

                if (string.IsNullOrEmpty(seccion))
                    throw new ArgumentException("La sección no puede estar vacía.");

                if (fecha == DateTime.MinValue || fecha == DateTime.MaxValue)
                    throw new ArgumentException("La fecha proporcionada no es válida.");

                var asistencias = _controlador.ObtenerPorGradoYSeccionYFecha(grado, seccion, fecha);
                return asistencias ?? new List<asistenciasMatriculadosM>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener asistencias por grado y sección: {ex.Message}", ex);
            }
        }

        public List<asistenciasMatriculadosM> ObtenerAsistenciasPorFecha(DateTime fecha)
        {
            try
            {
                if (fecha == DateTime.MinValue || fecha == DateTime.MaxValue)
                    throw new ArgumentException("La fecha proporcionada no es válida.");

                var asistencias = _controlador.ObtenerAsistenciasPorFecha(fecha);
                return asistencias ?? new List<asistenciasMatriculadosM>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener asistencias por fecha: {ex.Message}", ex);
            }
        }

        public void Insertar(asistenciasMatriculadosM asistencia)
        {
            try
            {
                if (asistencia == null)
                    throw new ArgumentNullException(nameof(asistencia), "La asistencia no puede ser nula.");

                if (string.IsNullOrEmpty(asistencia.IdMatricula))
                    throw new ArgumentException("El ID de matrícula no puede estar vacío.");

                if (string.IsNullOrEmpty(asistencia.Estado))
                    throw new ArgumentException("El estado de asistencia no puede estar vacío.");

                if (asistencia.Fecha == DateTime.MinValue || asistencia.Fecha == DateTime.MaxValue)
                    throw new ArgumentException("La fecha de asistencia no es válida.");

                if (!ValidarEstadoAsistencia(asistencia.Estado))
                    throw new ArgumentException("El estado de asistencia no es válido. Use 'A', 'T' o 'F'.");

                _controlador.Insertar(asistencia);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al insertar asistencia: {ex.Message}", ex);
            }
        }

        public void Modificar(asistenciasMatriculadosM asistencia)
        {
            try
            {
                if (asistencia == null)
                    throw new ArgumentNullException(nameof(asistencia), "La asistencia no puede ser nula.");

                if (string.IsNullOrEmpty(asistencia.IdMatricula))
                    throw new ArgumentException("El ID de matrícula no puede estar vacío.");

                if (string.IsNullOrEmpty(asistencia.Estado))
                    throw new ArgumentException("El estado de asistencia no puede estar vacío.");

                if (asistencia.Fecha == DateTime.MinValue || asistencia.Fecha == DateTime.MaxValue)
                    throw new ArgumentException("La fecha de asistencia no es válida.");

                if (!ValidarEstadoAsistencia(asistencia.Estado))
                    throw new ArgumentException("El estado de asistencia no es válido. Use 'A', 'T' o 'F'.");

                var asistenciaExistente = ObtenerPorMatriculaYFecha(asistencia.IdMatricula, asistencia.Fecha);
                if (asistenciaExistente == null)
                    throw new Exception("La asistencia que intenta modificar no existe.");

                _controlador.Modificar(asistencia);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al modificar asistencia: {ex.Message}", ex);
            }
        }

        private bool ValidarEstadoAsistencia(string estado)
        {
            if (string.IsNullOrEmpty(estado)) return false;
            estado = estado.Trim().ToUpper();
            return estado == "A" || estado == "T" || estado == "F";
        }
    }
}