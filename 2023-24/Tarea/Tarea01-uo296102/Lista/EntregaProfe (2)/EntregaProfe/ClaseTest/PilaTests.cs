
namespace Pruebas
{
    [TestClass]
    public class PilaTests
    {
        Pila pila = new Pila(6);
        Pila pilaTexto = new Pila(3);
        [TestMethod]
        public void inicializarLista()
        {
            pila.Push(1);
            pila.Push(2);
            pila.Push(3);
            pila.Push(4);
            pila.Push(5);
            pila.Push(6);
        }

        [TestMethod]
        public void PruebaMétodoPushCorrecto()
        {
            Assert.IsFalse(pila.EstaLlena(), "La lista no está llena");
            Assert.IsTrue(pila.EstaVacía(), "La lista está vacía");
            Assert.AreEqual(0, pila.NumeroTotalElementos);
            pila.Push(1);
            pila.Push(2);
            pila.Push(3);
            Assert.AreEqual(3, pila.NumeroTotalElementos);
            Assert.IsFalse(pila.EstaLlena(), "La lista no está llena");
            Assert.IsFalse(pila.EstaVacía(), "La lista no está vacía");
            pila.Push(4);
            pila.Push(5);
            pila.Push(6);
            Assert.AreEqual(6, pila.NumeroTotalElementos);
            Assert.IsTrue(pila.EstaLlena(), "La lista está llena");
            Assert.IsFalse(pila.EstaVacía(), "La lista no está vacía");
        }

        [TestMethod]
        public void PruebaMétodoPushDatoNull()
        {
            pila.Push(1);
            pila.Push(2);
            pila.Push(3);
            pila.Push(4);
            pila.Push(5);
            pila.Push(null);
            Assert.AreEqual(5, pila.NumeroTotalElementos, "No se añadió ningún elemento");
        }

        [TestMethod]
        public void PruebaMétodoBorrarCorrecto()
        {
            Assert.IsFalse(pila.EstaLlena(), "La lista no está llena");
            Assert.IsTrue(pila.EstaVacía(), "La lista está vacía");
            Assert.AreEqual(0, pila.NumeroTotalElementos);
            pila.Push(1);
            pila.Push(2);
            pila.Push(3);
            Assert.AreEqual(3, pila.NumeroTotalElementos);
            Assert.IsFalse(pila.EstaLlena(), "La lista no está llena");
            Assert.IsFalse(pila.EstaVacía(), "La lista no está vacía");
            Assert.AreEqual(3, pila.Pop(), "Se borra el último elemento");
            Assert.AreEqual(2, pila.NumeroTotalElementos);
            pila.Push(3);
            pila.Push(4);
            pila.Push(5);
            pila.Push(6);
            Assert.AreEqual(6, pila.NumeroTotalElementos);
            Assert.IsTrue(pila.EstaLlena(), "La lista está llena");
            Assert.IsFalse(pila.EstaVacía(), "La lista no está vacía");
            Assert.AreEqual(6, pila.Pop(), "Se borra el último elemento");
            Assert.AreEqual(5, pila.NumeroTotalElementos);
            Assert.IsFalse(pila.EstaLlena(), "La lista no está llena");
        }

        [TestMethod]
        public void PruebaMétodoBorrarDatoNull()
        {
            Assert.IsFalse(pila.EstaLlena(), "La lista no está llena");
            Assert.IsTrue(pila.EstaVacía(), "La lista está vacía");
            Assert.AreEqual(0, pila.NumeroTotalElementos);
            pila.Push(1);
            pila.Push(2);
            pila.Push(3);
            Assert.AreEqual(3, pila.NumeroTotalElementos);
            Assert.IsFalse(pila.EstaLlena(), "La lista no está llena");
            Assert.IsFalse(pila.EstaVacía(), "La lista no está vacía");
            Assert.AreEqual(3, pila.Pop(), "No se borra ningún elemento");
            Assert.AreEqual(2, pila.NumeroTotalElementos);
        }

        [TestMethod]
        public void PruebaMétodoBorrarDatoNoEncontrado()
        {
            Assert.IsFalse(pila.EstaLlena(), "La lista no está llena");
            Assert.IsTrue(pila.EstaVacía(), "La lista está vacía");
            Assert.AreEqual(0, pila.NumeroTotalElementos);
            pila.Push(1);
            pila.Push(2);
            pila.Push(3);
            Assert.AreEqual(3, pila.NumeroTotalElementos);
            Assert.IsFalse(pila.EstaLlena(), "La lista no está llena");
            Assert.IsFalse(pila.EstaVacía(), "La lista no está vacía");
            Assert.AreEqual(7, pila.Pop(), "Se borra el último elemento");
            Assert.AreEqual(3, pila.NumeroTotalElementos);
            pila.Push(3);
            pila.Push(4);
            pila.Push(5);
            pila.Push(6);
            Assert.AreEqual(6, pila.NumeroTotalElementos);
            Assert.IsTrue(pila.EstaLlena(), "La lista está llena");
            Assert.IsFalse(pila.EstaVacía(), "La lista no está vacía");
            Assert.AreEqual(19, pila.Pop(), "Se borra el último elemento");
            Assert.AreEqual(6, pila.NumeroTotalElementos);
            Assert.IsTrue(pila.EstaLlena(), "La lista está llena");
        }

        [TestMethod]
        public void PruebaMétodoAñadirTexto()
        {
            pilaTexto.Push("Hola");
            pilaTexto.Push("mundo");
            pilaTexto.Push("!");
            Assert.AreEqual(3, pilaTexto.NumeroTotalElementos, "Se añadieron los 3 elementos correctamente");
        }

        [TestMethod]
        public void PruebaMétodoBorrarTexto()
        {
            pilaTexto.Push("Hola");
            pilaTexto.Push("mundo");
            pilaTexto.Push("!");
            Assert.AreEqual(pilaTexto.Pop(), "!", "Se borró el tercer elemento");
            Assert.AreNotEqual(pilaTexto.Pop(), "objeto", "Se borro el segundo elemento correctamente");
            Assert.AreEqual(1, pilaTexto.NumeroTotalElementos, "Se borro el tercer elemento correctamente");
        }
    }
}