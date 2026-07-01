using System;

namespace ModuloClase
{
    internal class Nodo
    {
        public int Dato { get; set; }
        public Nodo Siguiente { get; set; }
        public Nodo(int Dato, Nodo Siguiente)
        {
            this.Dato = Dato;
            this.Siguiente = Siguiente;
        }
    }

    public class Lista
    {
        private Nodo Nodo { get; set; }
        private int NumeroElementos { get; set; }

        public Lista()
        {
            Nodo = null;
        }

        public void Añadir(int Dato)
        {
            Nodo nuevo = new Nodo(Dato, null);
            if (Nodo == null)
            {
                Nodo = nuevo;
                NumeroElementos++;
            }
            else
            {
                Nodo ultimo = GetNode(NumeroElementos - 1);
                ultimo.Siguiente = nuevo;
                NumeroElementos++;
            }
        }

        public bool Borrar(int Dato)
        {
            int posicion = IndexOf(element);
            if (posicion != -1)
            {
                Nodo anterior = getNode(posicion - 1);
                anterior.Siguiente = anterior.Siguiente.Siguiente;
                NumeroElementos--;
                return true;
            }
            return false;
        }

        public Nodo getElemento(int Dato)
        {
            return getNode(Dato).getValue();
        }
    }
}