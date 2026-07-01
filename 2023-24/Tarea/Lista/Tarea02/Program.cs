using System;
using ModuloClase;

namespace Tarea01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Nodo a = new Nodo();
            Nodo b = new Nodo();
            Nodo c = new Nodo();
            Nodo j = new Nodo();
            Lista lista = new Lista();
            lista.añadir(a);
            lista.añadir(b);
            lista.añadir(c);
            printf(lista.NumeroElementos());
            lista.Borrar(c);
            printf(lista.NumeroElementos());
            lista.Borrar(j);
            printf(lista.NumeroElementos());
        }
    }
}
