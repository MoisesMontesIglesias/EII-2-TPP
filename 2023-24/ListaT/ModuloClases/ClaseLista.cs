using System;
using System.Collections;

namespace ModuloClase
{ 
    public class Lista<T> : IEnumerable<T>
    {
        private Nodo? Node { get; set; }
        private int numE;
        private IteradorLista iteradorLista;
        public int NumeroElementos { get { return numE; } }

        public Lista()
        {
            Node = null;
            numE = 0;
        }

        public void Añadir(T Objeto)
        {
            Nodo Nuevo = new Nodo(Objeto, null);
            if (Node == null)
            {
                Node = Nuevo;
            }
            else
            {
                Nodo ultimo = GetNodoAt(NumeroElementos - 1);
                ultimo.Siguiente = Nuevo;
            }
            numE++;
        }

        public bool Borrar(T Objeto)
        {
            if (numE == 0)
            {
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

        public int GetPosNodo(T Objeto)
        {
            int contador = 0;
            Nodo CopiaNodo = Node;
            for (int i = 0; i < NumeroElementos; i++)
            {
                if (CopiaNodo.Objeto.Equals(Objeto))
                {
                    return contador;
                }
                CopiaNodo = CopiaNodo.Siguiente;
                contador++;
            }
            return -1;
        }

        public T GetValueAt(int posicion)
        {
            return GetNodoAt(posicion).Objeto;
        }

        private Nodo GetNodoAt(int posicion)
        {
            if(posicion < 0 || posicion >= numE)
            {
                throw new IndexOutOfRangeException("Posicion errónea");
            }
            Nodo CopiaNodo = Node;
            for (int i = 0; i < posicion; i++)
            {
                CopiaNodo = CopiaNodo.Siguiente;
            }
            return CopiaNodo;
        }

        public override String ToString()
        {
            String path = "";
            Nodo copiaNodo = Node;
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
            Nodo CopiaNodo = Node;
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
            return Node.Equals(otro.Node) && numE.Equals(otro.numE);

        }

        public T Buscar(Predicate<T> funcion)
        {
            foreach (T elemento in this)
            {
                if (funcion(elemento))
                {
                    return elemento;
                }
            }
            return default;
        }

        public Lista<T> Filtrar(Predicate<T> funcion)
        {
            Lista<T> nuevaLista = new Lista<T>();
            foreach (T elemento in this)
            {
                if (funcion(elemento))
                {
                    nuevaLista.Añadir((T)elemento);
                }
            }
            return nuevaLista;
        }

        public T1 Reducir<T1>( Func<T1, T, T1> funcion)
        {
            T1 valor = default(T1);
            foreach (T elemento in this)
            {
                valor = funcion(valor, elemento);
            }
            return valor;
        }

        public Lista<T> Invertir()
        {
            Lista<T> nuevaLista = new Lista<T>();
            for(int i = numE - 1; i > -1; i--)
            {
                nuevaLista.Añadir(GetNodoAt(i).Objeto);
            }
            return nuevaLista;
        }

        public Lista<T1> Map<T1>(Func<T, T1> funcion)
        {
            Lista<T1> nuevaLista = new Lista<T1>();
            foreach (T elemento in this)
            {
                nuevaLista.Añadir(funcion(elemento));
            }
            return nuevaLista;
        }

        public void ForEach(Action<T> action)
        {
            foreach (T item in this)
            {
                action(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return iteradorLista;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return iteradorLista;
        }

        internal class Nodo
        {
            public T Objeto { get; set; }
            public Nodo Siguiente { get; set; }

            public Nodo(T Objeto, Nodo Siguiente)
            {
                this.Objeto = Objeto;
                this.Siguiente = Siguiente;
            }
        }

        internal class IteradorLista : IEnumerator<T>
        {
            private Lista<T> lista;
            private int indice;
            public IteradorLista(Lista<T> lista) 
            {
            this.lista = lista;
            }

            public T Current()
            {
                return lista.GetNodoAt(indice).Objeto;
            }

            object IEnumerator.Current => throw new NotImplementedException();

            T IEnumerator<T>.Current => throw new NotImplementedException();

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                indice++;
                if(indice > lista.NumeroElementos)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            public void Reset()
            {
                indice = -1;
            }
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}