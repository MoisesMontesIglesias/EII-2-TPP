
using System;

namespace Clausuras
{
    public static class ClausuraAleatorio
    {
        public static void ObtenerValor<T>(int valor, out Action<T> set, out Func<T> get)
        {
            //Se define el estado
            int _valor = valor;

            //Funciones a definir

            set = valor => _valor = valor;

            get = () => Ejercicio.ClausuraA(valor);

        }
    }
}
