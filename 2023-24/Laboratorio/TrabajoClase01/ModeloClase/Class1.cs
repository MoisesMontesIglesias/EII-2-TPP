using System;
using System.Runtime.InteropServices.ComTypes;

namespace ModeloClase
{
    public enum Estaciones { Invierno = 0, Primavera = 1, Otoño = 2, Verano = 3 };

    public class SimuladorTiempo
    {
        private static Random random;
        DateTime _fecha;
        Estaciones _estacion;

        public void AvanzarDias()
        {
            int aleatorio = random.Next(2, 12);
            _fecha = _fecha.AddDays(aleatorio);
        }

        public void AvanzarMeses()
        {
            int aleatorio = random.Next(1, 4);
            _fecha = _fecha.AddMonths(aleatorio);
            CalcularEstacion();
        }
    
        public DateTime Fecha
        {
            get
            {
                return _fecha;  
            }
        }

        private DateTime setNuevaFecha(int fecha)
        {
            return new DateTime(fecha);
        }

        public Estaciones Estacion
        {
            get
            {
                return _estacion;
            }
        }

        public void CalcularEstacion()
        {
            if(Fecha >= setNuevaFecha(2) && Fecha <= setNuevaFecha(4))
            {
                _estacion = Estaciones.Primavera;
            } else if (Fecha >= setNuevaFecha(5) && Fecha <= setNuevaFecha(7))
            {
                _estacion = Estaciones.Verano;

            } else if (Fecha >= setNuevaFecha(8) && Fecha <= setNuevaFecha(10))
            {
                _estacion = Estaciones.Otoño;
            }
            else
            {
                _estacion = Estaciones.Invierno;
            }
        }

        public override string ToString()
        {
            return $"{_fecha} {_estacion}";
        }
    }
}
