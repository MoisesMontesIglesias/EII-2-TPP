using System;
using Modelo;
using System.Collections.Generic;
using System.Linq;

namespace TPP07
{
    class Program
    {
        static void Main()
        {

            IEnumerable<int> valores = Enumerable.Range(1, 9);

            Console.WriteLine("Colecciones de enteros.");

            //Uso de métodos extensores
            //Map transforma una secuencia de <T>s en una secuencia de <Q>s.
            valores.Map(n => n * n).ForEach(Console.WriteLine);
            Console.WriteLine();

            valores.Map(n => n * n).Map(n => n / 2.0).ForEach(Console.WriteLine);
            Console.WriteLine();

            valores.Map(n => new Angulo(n))
                .Map(a => a.Grados)
                .ForEach(a => Console.WriteLine(a)); // .ForEach(Console.WriteLine) <- ¿Sabes el motivo?

            Console.WriteLine();

            Console.WriteLine("\nColecciones de Personas.");

            var personas = Factoria.CrearPersonas();

            var nombres = personas.Map(p => p.Nombre);
            nombres.ForEach(Console.WriteLine);
            Console.WriteLine();

            var iniciales = personas.Map(p => p.Nombre).Map(cadena => cadena[0]);
            iniciales.ForEach(Console.WriteLine);
            Console.WriteLine();
            personas.Map(p => p.Nif + "\t" + p.Nombre + "\t" + p.Apellido).ForEach(Console.WriteLine);


            //¿Qué estamos haciendo aquí?
            var info = personas.Map(p => new
            {
                Nombre = p.Nombre,
                Dni = p.Nif
            }
            );

            info.ForEach(Console.WriteLine);

            /* EJERCICIO:
            * - Añade el método Map a tu lista genérica.
            * - A partir de una lista de enteros: Calcula la suma de los cuadrados de la colección.
            * - A partir de una lista de Personas: Calcula la longitud media de los nombres de la colección.
            */


            //Método ZIP de Linq: Combina dos secuencias:

            var combinación = valores.Zip(personas.Map(p => p.Nombre));
            combinación.Map(c => c.First + " : " + c.Second).ForEach(Console.WriteLine);


            /* EJERCICIO: Implementa el método Zip de LINQ:
             * - Colecciones potecialmente infinitas.
             * - Trabajará con tuplas .
             * */
            static IEnumerable<Tuplas<T, Q>> ZipLazy<T, Q>(IEnumerable<T> a, IEnumerable<Q> b)
            {
                var valor1 = a.GetEnumerator();
                var valor2 = b.GetEnumerator();
                while (valor1.MoveNext() && valor2.MoveNext())
                {
                    yield return new Tuplas<T,Q>(valor1.Current, valor2.Current);
                }
            }
        }
    }
}

            
        

    


