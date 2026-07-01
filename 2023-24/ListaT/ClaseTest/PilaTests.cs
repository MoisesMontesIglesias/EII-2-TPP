namespace Pruebas
{
    [TestClass]
    public class PilaTests
    {
        Pila<int> pila = new Pila<int>(6);
        Pila<string> pilaTexto = new Pila<string>(3);
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
        public void PruebaMétodoBorrarCorrecto()
        {
            Assert.IsFalse(pila.EstaLlena(), "La lista no está llena");
            Assert.IsTrue(pila.EstaVacía(), "La lista está vacía");
            pila.Push(1);
            pila.Push(2);
            pila.Push(3);
            Assert.IsFalse(pila.EstaLlena(), "La lista no está llena");
            Assert.IsFalse(pila.EstaVacía(), "La lista no está vacía");
            Assert.AreEqual(3, pila.Pop(), "Se borra el último elemento");
            pila.Push(3);
            pila.Push(4);
            pila.Push(5);
            pila.Push(6);
            Assert.IsTrue(pila.EstaLlena(), "La lista está llena");
            Assert.IsFalse(pila.EstaVacía(), "La lista no está vacía");
            Assert.AreEqual(6, pila.Pop(), "Se borra el último elemento");
            Assert.IsFalse(pila.EstaLlena(), "La lista no está llena");
        }

        [TestMethod]
        public void PruebaMétodoBorrarDatoNoEncontrado()
        {
            Assert.IsFalse(pila.EstaLlena(), "La lista no está llena");
            Assert.IsTrue(pila.EstaVacía(), "La lista está vacía");
            pila.Push(1);
            pila.Push(2);
            pila.Push(3);
            Assert.IsFalse(pila.EstaLlena(), "La lista no está llena");
            Assert.IsFalse(pila.EstaVacía(), "La lista no está vacía");
            Assert.AreNotEqual(7, pila.Pop(), "Se borra el último elemento");
            pila.Push(3);
            pila.Push(4);
            pila.Push(5);
            pila.Push(6);
            Assert.IsTrue(pila.EstaLlena(), "La lista está llena");
            Assert.IsFalse(pila.EstaVacía(), "La lista no está vacía");
            Assert.AreNotEqual(19, pila.Pop(), "Se borra el último elemento");
            Assert.IsFalse(pila.EstaLlena(), "La lista está llena");
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
        }
    }
}