using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Libro
    {
        private string _libro;
        private string _titulo;
        private int _numPaginas;
        private int _añoPubli;
        private string _genero;
        public string GetLibro() { return _libro; }
        public string GetTitulo() { return _titulo; }
        public Libro(string libro, string titulo, int numPaginas, int añoPubli, string genero)
        {
            _libro = libro;
            _titulo = titulo;
            _numPaginas = numPaginas;
            _añoPubli = añoPubli;
            _genero = genero;
        }
    }
}
