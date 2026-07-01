using System.Diagnostics;
namespace ModuloClase
{
    public class Pila
    {
        private int numeroMaxElementos;
        private Lista lista;
        public int NumeroTotalElementos { get { return lista.NumeroElementos; } }
        public Pila(int numeroMaxElementos)
        {
            if(numeroMaxElementos < 1)
            {
                throw new InvalidOperationException("El número de elementos debe ser >= 1");
            }
            lista = new Lista();
            this.numeroMaxElementos = numeroMaxElementos;
#if DEBUG
            Invariante();
#endif
        }

        public void Push(Object objeto)
        {
#if DEBUG
            Invariante();
            int cantidadPrevia = NumeroTotalElementos;
#endif
            if(EstaLlena())
            {
                throw new InvalidOperationException("El almacén esta lleno");
            }

            lista.Añadir(objeto);
#if DEBUG
            Debug.Assert(NumeroTotalElementos == cantidadPrevia + 1, "Fallo en postcondicion de almacenar");
            Invariante();
#endif
        }

        public Object Pop()
        {
#if DEBUG
            Invariante();
            int cantidadPrevia = NumeroTotalElementos;
#endif
            if (EstaVacía() == true)
            {
                throw new InvalidOperationException("El almacén ya está vacío, no se pueden borrar más elementos");
            }
            Nodo nodo = lista.GetNodoAt(NumeroTotalElementos);
            bool borrar = lista.Borrar(lista.GetNodoAt(NumeroTotalElementos));

#if DEBUG
            if (borrar == true)
            {
                Debug.Assert(NumeroTotalElementos == cantidadPrevia - 1, "Fallo en postcondicion de borrar");
            }
            else
            {
                Debug.Assert(NumeroTotalElementos == cantidadPrevia, "Fallo en postcondicion de borrar");
            }
            Invariante();
#endif
            return nodo.Objeto;
        }

        public bool EstaVacía()
        {
            if (NumeroTotalElementos == 0)
            {
                return true;
            }
             return false;
        }

        public bool EstaLlena()
        {
            if (numeroMaxElementos == NumeroTotalElementos)
            {
                return true;
            }
            return false;
        }
#if DEBUG
        private void Invariante()
        {
            Debug.Assert(lista != null && NumeroTotalElementos <= numeroMaxElementos, "Error en la invariante");
        }
#endif
    }
}
