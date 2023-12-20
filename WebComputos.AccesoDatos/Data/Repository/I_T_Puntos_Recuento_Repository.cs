using System;
using System.Collections.Generic;
using System.Text;
using WebComputos.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebComputos.AccesoDatos.Data.Repository
{
    public interface I_T_Puntos_Recuento_Repository: IRepositor<T_Puntos_Recuento>
    {
        IEnumerable<PuntosRec> ObtenerEjercicos(int Municipio, int Eleccion, int DD);

        IEnumerable<PuntosRec> ObtenerEjercicosPorNumero(int Municipio, int Eleccion, int DD, int numejercicio);

        public void EjercicioSeleccionado(int Municipio, int Eleccion, int Ejercicio, int DD);

        IEnumerable<PuntosRec> EjercicioSeleccionadoPorNumero(int Municipio, int Eleccion, int DD, int numejercicio);

        
    }
}
