using ModuloClase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloClases
{
    public class Pila
    {
        private int numeroMaxElementos;
        private Lista lista;
        public int NumeroTotalElementos { get { return lista.NumeroElementos; } }
        public Pila(int numeroMaxElementos)
        {
            lista = new Lista();
            this.numeroMaxElementos = numeroMaxElementos;
#if DEBUG
            Invariante();
#endif
        }

        public void Push(Object objeto)
        {
            if (objeto == null)
            {
                Console.WriteLine("No puedes añadir un objeto null");
                return;
            }
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
            Object objeto = lista.GetNodoAt(NumeroTotalElementos-1);
            bool borrar = lista.Borrar(objeto);

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
            return objeto;
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
