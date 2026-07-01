using System;

namespace ModuloClase
{
    public class Nodo<T>
    {
        public T Objeto { get; set; }
        public Nodo<T> Siguiente { get; set; }

        public Nodo(T Objeto, Nodo<T> Siguiente = null)
        {
            this.Objeto = Objeto;
            this.Siguiente = Siguiente;
        }
    }

    public class Lista<T>
    {
        public Nodo<T> Nodo { get; set; }
        private int numE;
        public int NumeroElementos { get { return numE; } }

        public Lista()
        {
            Nodo = null;
            numE = 0;
        }

        public void Añadir(T Objeto)
        {
            if (Objeto == null)
            {
                Console.WriteLine("No puedes añadir un objeto null");
                return;
            }
            Nodo<T> Nuevo = new Nodo<T>(Objeto, null);
            if (Nodo == null)
            {
                Nodo = Nuevo;
            }
            else
            {
                Nodo<T> ultimo = GetNodoAt(NumeroElementos - 1);
                ultimo.Siguiente = Nuevo;
            }
            numE++;
        }

        public bool Borrar(T Objeto)
        {
            if (Objeto == null)
            {
                Console.WriteLine("No puedes añadir un objeto null");
                return false;
            }
            int posicion = GetPosNodo(Objeto);
            if (posicion != -1)
            {
                Nodo<T> anterior = GetNodoAt(posicion - 1);
                anterior.Siguiente = anterior.Siguiente.Siguiente;
                numE--;
                return true;
            }
            return false;
        }

        public int GetPosNodo(T Objeto)
        {
            int contador = 0;
            for (int i = 0; i < NumeroElementos; i++)
            {
                Nodo<T> CopiaNodo = GetNodoAt(i);
                if (CopiaNodo.Objeto.Equals(Objeto))
                {
                    return contador;
                }
                contador++;
            }
            return -1;
        }

        public Nodo<T> GetNodoAt(int posicion)
        {
            Nodo<T> CopiaNodo = Nodo;
            for (int i = 0; i < posicion; i++)
            {
                CopiaNodo = CopiaNodo.Siguiente;
            }
            return CopiaNodo;
        }

        public override String ToString()
        {
            String path = "";
            Nodo<T> copiaNodo = Nodo;
            for (int i = 0; i < NumeroElementos; i++)
            {
                path += Convert.ToString(copiaNodo.Objeto) + ";";
                copiaNodo = copiaNodo.Siguiente;
            }
            return path;
        }

        public bool Contiene(T Objeto)
        {
            if (Objeto == null)
            {
                Console.WriteLine("No puedes añadir un objeto null");
                return false;
            }
            Nodo<T> CopiaNodo = Nodo;
            for (int i = 0; i < NumeroElementos; i++)
            {
                if (CopiaNodo.Objeto.Equals(Objeto))
                {
                    return true;
                }
                CopiaNodo = CopiaNodo.Siguiente;
            }
            return false;
        }

        public override bool Equals(Object obj)
        {
            Lista<T> otro = obj as Lista<T>;
            if (otro == null)
                return false;
            return Nodo.Equals(otro.Nodo) && numE.Equals(otro.numE);

        }
    }
}