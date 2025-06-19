using System;
using System.Collections.Generic;
using G1asistenciaEC.controlador;
using G1asistenciaEC.modelo;

namespace G1asistenciaEC.negocio
{
    public class asistenciasMatriculadosN
    {
        private readonly asistenciasMatriculadosC _controlador = new asistenciasMatriculadosC();

        public modelo.asistenciasMatriculadosM ObtenerPorMatriculaYFecha(string idMatricula, DateTime fecha)
        {
            var asistenciaControlador = _controlador.ObtenerPorMatriculaYFecha(idMatricula, fecha);
            return MapearModelo(asistenciaControlador);
        }

        public List<modelo.asistenciasMatriculadosM> ObtenerPorGradoYSeccionYFecha(string grado, string seccion, DateTime fecha)
        {
            var asistenciasControlador = _controlador.ObtenerPorGradoYSeccionYFecha(grado, seccion, fecha);
            var asistenciasModelo = new List<modelo.asistenciasMatriculadosM>();
            foreach (var asistencia in asistenciasControlador)
            {
                asistenciasModelo.Add(MapearModelo(asistencia));
            }
            return asistenciasModelo;
        }

        public void Insertar(modelo.asistenciasMatriculadosM asistencia)
        {
            _controlador.Insertar(MapearControlador(asistencia));
        }

        public void Modificar(modelo.asistenciasMatriculadosM asistencia)
        {
            _controlador.Modificar(MapearControlador(asistencia));
        }

        private modelo.asistenciasMatriculadosM MapearModelo(controlador.asistenciasMatriculadosM asistencia)
        {
            if (asistencia == null) return null;

            return new modelo.asistenciasMatriculadosM
            {
                IdMatricula = asistencia.IdMatricula,
                Estado = asistencia.Estado,
                Fecha = asistencia.Fecha
            };
        }

        private controlador.asistenciasMatriculadosM MapearControlador(modelo.asistenciasMatriculadosM asistencia)
        {
            return new controlador.asistenciasMatriculadosM
            {
                IdMatricula = asistencia.IdMatricula,
                Estado = asistencia.Estado,
                Fecha = asistencia.Fecha
            };
        }
    }
}