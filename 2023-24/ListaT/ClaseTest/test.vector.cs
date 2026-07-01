using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas
{
    [TestClass]
    public class VectorTest
    {
        [TestMethod]
        public void AñadirElementos()
        {
            IList<int> lista = new List<int>();
            lista.Add(1);
            lista.Add(2);
            lista.Add(3);
            lista.Add(4);
            Assert.AreEqual(4, lista.Count);
        }

        [TestMethod]
        public void ContarElementos()
        {
            IList<int> lista = new List<int>();
            lista.Add(1);
            Assert.AreEqual(1, lista.Count());
            lista.Add(2);
            Assert.AreEqual(2, lista.Count());
            lista.Add(4);
            Assert.AreEqual(3, lista.Count());
        }

        [TestMethod]
        public void ObtenerYReescribirElementos()
        {
            IList<int> lista = new List<int>();
            lista.Add(1);
            lista.Add(2);
            lista.Add(4);
            Assert.AreEqual(3, lista.Count());
            Assert.AreEqual(1, lista.ElementAt(0));
            lista.Remove(1);
            lista.Insert(0, 1);
            Assert.AreEqual(3, lista.Count());
            Assert.AreEqual(1, lista.ElementAt(0));
        }

        [TestMethod]
        public void SaberSiElementoEstaEnVector()
        {
            IList<int> lista = new List<int>();
            lista.Add(1);
            lista.Add(2);
            lista.Add(4);
            Assert.AreEqual(3, lista.Count());
            Assert.AreEqual(1, lista.ElementAt(0));
            lista.Remove(1);
            lista.Insert(0, 1);
            Assert.AreEqual(3, lista.Count());
            Assert.AreEqual(1, lista.ElementAt(0));
            Assert.AreEqual(4, lista.ElementAt(2));
            Assert.AreEqual(2, lista.ElementAt(1));
        }

        [TestMethod]
        public void ConocerPrimerIndiceElemento()
        {
            IList<int> lista = new List<int>();
            lista.Add(1);
            lista.Add(2);
            lista.Add(4);
            Assert.AreEqual(0,lista.IndexOf(1));
            Assert.AreEqual(1, lista.IndexOf(2));
            Assert.AreNotEqual(2, lista.IndexOf(1));
        }

        [TestMethod]
        public void BorrarElementosEnPrimeraPosicion()
        {
            IList<int> lista = new List<int>();
            lista.Add(1);
            lista.Add(2);
            lista.Add(4);
            Assert.AreEqual(3, lista.Count());
            Assert.AreEqual(1, lista.ElementAt(0));
            lista.Remove(1);
            Assert.AreEqual(2, lista.Count());
            Assert.AreEqual(2, lista.ElementAt(0));
            lista.Remove(2);
            Assert.AreEqual(4, lista.ElementAt(0));
            Assert.AreEqual(1, lista.Count());
        }

        [TestMethod]
        public void UsoForEach()
        {
            IList<int> lista = new List<int>();
            IList<int> nuevaLista = new List<int>();
            lista.Add(1);
            lista.Add(2);
            lista.Add(4);
            foreach (int element in lista)
            {
                if (lista[2].Equals(element))
                {
                    nuevaLista.Add(element);
                }
            }
            Assert.AreEqual(3, lista.Count());
            Assert.AreEqual(1, nuevaLista.Count());
        }
    }
}
