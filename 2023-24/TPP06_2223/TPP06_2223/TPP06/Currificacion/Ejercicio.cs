
using System.Collections.Generic;
using System;
using System.ComponentModel;

namespace Currificacion
{
    public static class Ejercicio
    {
        //Ejercicio 1..

        //Implementar de forma currificada el método Buscar entregado en la sesión anterior.
        //Demostrar el uso de su invocación y de la aplicación parcial.

        //Resuelto por el profe:

        static T Buscar<T> (IEnumerable<T> secuencia, Predicate<T> condicion)
        {
            foreach(var e in secuencia)
            {
                if (condicion(e))
                {
                    return e;
                }
            }
            return default (T);
        }

        static Func<Predicate<T>, T> BuscarCurry<T>(IEnumerable<T> secuencia) //Predicate<T> condicion)
        {
            return condicion =>
            {
                foreach (var e in secuencia)
                {
                    if (condicion(e))
                    {
                        return e;
                    }
                }
                return default(T);
            };
        }

        //Ejercicio 2.

        // Si - > 5 / 3 = 1 ; Resto = 2

        // Entonces -> 3 * 1 + 2 = 5;

        //Currifíquese la función y compruébese mediante el uso de la aplicación parcial el siguiente ejemplo:

        // Se sabe que la división:  20 / 6 = 3. Se desconoce el valor del resto.
        // Partiendo del valor 0, e incrementalmente, obténgase el resto.

        public static bool ComprobarDivision(int divisor, int dividendo, int cociente, int resto)
        {
            return dividendo == cociente * divisor + resto;
        }

        public static Func<int, Func<int, Func<int, bool>>> Current(int divisor)
        {
            return dividendo => cociente => resto =>
            {
                return dividendo == cociente * divisor + resto;
            };
        }

        public static Func<string, Func<bool, Func<char, bool>>> CurrentEj(int divisor)
        {
            return dividendo => cociente => resto =>
            {
                return true;
            };
        }
    }
}
