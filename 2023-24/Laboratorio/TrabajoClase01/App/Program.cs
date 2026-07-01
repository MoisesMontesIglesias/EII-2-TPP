using System;
using System.Security.Cryptography.X509Certificates;
using ModeloClase;

namespace App
{
    internal class Programa
    {
        static void Main(string[] args)
        {
            
        }

        public class Cultivo
        {
            Estaciones _cosecha;
            int _ritmoCrecimiento;
            int _crecimiento;
            int _cantidad;
            bool _muerto;
            string _identificador;

            public void Regar(Estaciones _cosecha)
            {
                if (_muerto == true)
                {
                    _crecimiento = _ritmoCrecimiento + 1;
                }
            }

            public void Cosechar(Estaciones _cosecha)
            {

            }
        }


    }
}
