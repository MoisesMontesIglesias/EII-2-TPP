using System;
using System.Xml.Linq;

namespace ModuloClase
{
    public class Nodo
    {
        public Object Objeto { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo(Object Objeto, Nodo Siguiente = null)
        {
            this.Objeto = Objeto;
            this.Siguiente = Siguiente;
        }
    }

    public class Lista
    {
        public Nodo Nodo { get; set; }
        private int numE;
        public int NumeroElementos { get { return numE; } }

        public Lista()
        {
            Nodo = null;
            numE = 0;
        }

        public void Añadir(Object Objeto)
        {
            if (Objeto == null)
            {
                Console.WriteLine("No puedes añadir un objeto null");
                return;
            }
            Nodo Nuevo = new Nodo(Objeto, null);
            if (Nodo == null)
            {
                Nodo = Nuevo;
            }
            else
            {
                Nodo ultimo = GetNodoAt(NumeroElementos - 1);
                ultimo.Siguiente = Nuevo;
            }
            numE++;
        }

        public bool Borrar(Object Objeto)
        {
            if (Objeto == null)
            {
                Console.WriteLine("No puedes añadir un objeto null");
                return false;
            }
            int posicion = GetPosNodo(Objeto);
            if (posicion != -1)
            {
                Nodo anterior = GetNodoAt(posicion - 1);
                anterior.Siguiente = anterior.Siguiente.Siguiente;
                numE--;
                return true;
            }
            return false;
        }

        public int GetPosNodo(Object Objeto)
        {
            int contador = 0;
            for (int i = 0; i < NumeroElementos; i++)
            {
                Nodo CopiaNodo = GetNodoAt(i);
                if (CopiaNodo.Objeto.Equals(Objeto))
                {
                    return contador;
                }
                contador++;
            }
            return -1;
        }

        public Nodo GetNodoAt(int posicion)
        {
            Nodo CopiaNodo = Nodo;
            for (int i = 0; i < posicion; i++)
            {
                CopiaNodo = CopiaNodo.Siguiente;
            }
            return CopiaNodo;
        }

        public override String ToString()
        {
            String path = "";
            for (int i = 0; i < NumeroElementos; i++)
            {
                path += Convert.ToString(Nodo) + ";";
                Nodo = Nodo.Siguiente;
            }
            return path;
        }

        public bool Contiene(Object Objeto)
        {
            if (Objeto == null)
            {
                Console.WriteLine("No puedes añadir un objeto null");
                return false;
            }
            Nodo CopiaNodo = Nodo;
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

        public override bool Equals(object obj)
        {
            Lista otro = obj as Lista;
            if (otro == null)
                return false;
            return Nodo.Equals(otro.Nodo) && numE.Equals(otro.numE);

        }
    }
}