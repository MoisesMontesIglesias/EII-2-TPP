using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Tuplas<T,Q>
    {
        private T valor1;
        private Q valor2;
        public Tuplas(T valor1, Q valor2)
        {
            this.valor1 = valor1;
            this.valor2 = valor2;
        }
    }
}
