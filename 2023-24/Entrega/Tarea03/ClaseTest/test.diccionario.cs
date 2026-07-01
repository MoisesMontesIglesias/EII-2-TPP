using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas
{
    [TestClass]
    public class TestDiccionario
    {
        [TestMethod]
        public void AñadirElementos()
        {
            IDictionary<string, int> diccionario = new Dictionary<string, int>();
            diccionario.Add("Hola", 0);
            diccionario.Add("Que", 1);
            diccionario.Add("Tal", 2);
            diccionario.Add("Estas", 3);
            Assert.AreEqual(4, diccionario.Count());
        }

        [TestMethod]
        public void ContarElementos()
        {
            IDictionary<string, int> diccionario = new Dictionary<string, int>();
            diccionario.Add("Hola", 0);
            Assert.AreEqual(1, diccionario.Count());
            diccionario.Add("Que", 1);
            Assert.AreEqual(2, diccionario.Count());
            diccionario.Add("Estas", 3);
            Assert.AreEqual(3, diccionario.Count());
        }

        [TestMethod]
        public void ObtenerYReescribirElementos()
        {
            IDictionary<string, int> diccionario = new Dictionary<string, int>();
            diccionario.Add("Hola", 0);
            diccionario.Add("Que", 1);
            diccionario.Add("Tal", 2);
            diccionario.Add("Estas", 3);
            Assert.AreEqual(4, diccionario.Count());
            diccionario.Remove("Hola");
            diccionario.Add("Hey", 4);
            Assert.AreEqual(4, diccionario.Count());
            Assert.AreEqual("Hey", diccionario.ElementAt(0).Key);
        }

        [TestMethod]
        public void SaberSiElementoEstaEnVector()
        {
            IDictionary<string, int> diccionario = new Dictionary<string, int>();
            diccionario.Add("Hola", 0);
            diccionario.Add("Que", 1);
            diccionario.Add("Tal", 2);
            diccionario.Add("Estas", 3);
            Assert.AreEqual("Hola", diccionario.ElementAt(0).Key);
            Assert.AreNotEqual("Hey", diccionario.ElementAt(0).Key);
            Assert.AreEqual("Que", diccionario.ElementAt(1).Key);
            Assert.AreNotEqual("que", diccionario.ElementAt(1).Key);

        }

        [TestMethod]
        public void BorrarElementosEnPrimeraPosicion()
        {
            IDictionary<string, int> diccionario = new Dictionary<string, int>();
            diccionario.Add("Hola", 0);
            diccionario.Add("Que", 1);
            diccionario.Add("Tal", 2);
            diccionario.Add("Estas", 3);
            Assert.AreEqual(4, diccionario.Count());
            Assert.AreEqual("Hola", diccionario.ElementAt(0).Key);
            diccionario.Remove("Hola");
            Assert.AreEqual(3, diccionario.Count());
            Assert.AreEqual("Que", diccionario.ElementAt(0).Key);
            diccionario.Remove("Que");
            Assert.AreEqual(2, diccionario.ElementAt(0).Value);
            Assert.AreEqual(2, diccionario.Count());
        }

        [TestMethod]
        public void UsoForEach()
        {
            IDictionary<string, int> diccionario = new Dictionary<string, int>();
            IDictionary<string, int> nuevoDiccionario = new Dictionary<string, int>();
            diccionario.Add("Hola", 0);
            diccionario.Add("Que", 1);
            diccionario.Add("Tal", 2);
            diccionario.Add("Estas", 3);
            foreach (KeyValuePair<string, int> clave in diccionario)
            {
                if(diccionario.ElementAt(2).Key == clave.Key)
                {
                    nuevoDiccionario.Add(clave);
                }
            }
            Assert.AreEqual(4, diccionario.Count());
            Assert.AreEqual(1, nuevoDiccionario.Count());
        }
    }
}
