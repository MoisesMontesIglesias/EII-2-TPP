using ModuloClase;
internal class Programa
    {
        static void Main(string[] args)
        {
            Lista<int> lista = new Lista<int>();
            lista.Añadir(1);
            lista.Añadir(2);
            lista.Añadir(4);
            Console.WriteLine(lista.NumeroElementos);
            lista.Borrar(4);
            Console.WriteLine(lista.NumeroElementos);
            lista.Borrar(2);
            Console.WriteLine(lista.NumeroElementos);
            Console.WriteLine(lista.ToString());
            Console.WriteLine(lista.Contiene(3));
            Console.WriteLine(lista.Contiene(7));
        }
    }
