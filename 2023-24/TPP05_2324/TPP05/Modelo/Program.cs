using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Program
    {
        public static int Contar<T>(IEnumerable<T> lista, Predicate<T> funcion)
        {
            int _contador = 0;
            foreach (T elemento in lista)
            {
                if (funcion(elemento))
                {
                    _contador++;
                }
            }
            return _contador;
        }

        public static int Contiene<T>(IEnumerable<T> lista, Predicate<T> funcion)
        {
            int _posicion = 0;
            foreach (T elemento in lista)
            {
                if (funcion(elemento))
                {
                    return _posicion;
                }
                _posicion++;
            }
            return -1;
        }

        public static IEnumerable<T> FiltrarEjemploClase<T>(IEnumerable<T> lista, Predicate<T> funcion)
        {
            IList<T> _nuevaLista = new List<T>();
            foreach (T elemento in lista)
            {
                if (funcion(elemento))
                {
                    _nuevaLista.Add(elemento);
                }
            }
            return _nuevaLista;
        }

        public static void Mostrar<T>(IEnumerable<T> lista, Action<T> funcion)
        {
            foreach (T elemento in lista)
            {
                funcion(elemento);
            }
        }

        public static T Buscar<T>(IEnumerable<T> lista, Predicate<T> funcion)
        {
            foreach(T elemento in lista)
            {
                if (funcion(elemento))
                {
                    return elemento;
                }
            }
            return default(T);
        }

        public static IEnumerable<T> Filtrar<T>(IEnumerable<T> lista, Predicate<T> funcion)
        {
            IList<T> nuevaLista = new List<T>();
            foreach(T elemento in lista)
            {
                if (funcion(elemento))
                {
                    nuevaLista.Add((T)elemento);
                }
            }
            return nuevaLista;
        }

        public static T1 Reducir<T1,T2>(IEnumerable<T2> lista, Func<T1, T2, T1> funcion)
        {
            T1 valor = default(T1);
            foreach(T2 elemento in lista)
            {
                valor = funcion(valor, elemento);
            }
            return valor;
        }
    }
}
