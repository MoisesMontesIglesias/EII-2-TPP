
namespace TestProject1
{
    [TestClass]
    public class ListaPruebas
    {
        Lista lista = new Lista();
        Lista listaTexto = new Lista();
        [TestMethod]
        public void inicializarLista()
        {
            lista.Añadir(1);
            lista.Añadir(2);
            lista.Añadir(3);
            lista.Añadir(4);
            lista.Añadir(5);
            lista.Añadir(6);
            listaTexto.Añadir("Hola");
            listaTexto.Añadir("mundo");
            listaTexto.Añadir("!");
        }

        [TestMethod]
        public void PruebaMétodoAñadirCorrecto()
        {
            lista.Añadir(1);
            lista.Añadir(2);
            lista.Añadir(3);
            lista.Añadir(4);
            lista.Añadir(5);
            lista.Añadir(6);
            int nuevo = 7;
            lista.Añadir(nuevo);
            Assert.AreEqual(nuevo, lista.NumeroElementos, "Se añadió un nuevo elemento");
            lista.Añadir(8);
            Assert.AreEqual(8, lista.NumeroElementos, "Se añadió un nuevo elemento");
        }

        [TestMethod]
        public void PruebaMétodoAñadirDatoNull()
        {
            lista.Añadir(1);
            lista.Añadir(2);
            lista.Añadir(3);
            lista.Añadir(4);
            lista.Añadir(5);
            lista.Añadir(6);
            lista.Añadir(null);
            Assert.AreEqual(6, lista.NumeroElementos, "No se añadió ningún elemento");
        }

        [TestMethod]
        public void PruebaMétodoBorrarCorrecto()
        {
            lista.Añadir(1);
            lista.Añadir(2);
            lista.Añadir(3);
            lista.Añadir(4);
            lista.Añadir(5);
            lista.Añadir(6);
            Assert.IsTrue(lista.Borrar(6), "Se borró un elemento correctamente");
            Assert.IsTrue(lista.Borrar(4), "Se borro otro elemento");
            Assert.IsTrue(lista.Borrar(2), "Se borro otro elemento");
        }

        [TestMethod]
        public void PruebaMétodoBorrarDatoNull()
        {
            lista.Añadir(1);
            lista.Añadir(2);
            lista.Añadir(3);
            lista.Añadir(4);
            lista.Añadir(5);
            lista.Añadir(6);
            Assert.IsFalse(lista.Borrar(null), "No se borró ningún elemento");
            Assert.AreEqual(6, lista.NumeroElementos, "El número de elementos sigue siendo el mismo");
        }

        [TestMethod]
        public void PruebaMétodoBorrarDatoNoEncontrado()
        {
            lista.Añadir(1);
            lista.Añadir(2);
            lista.Añadir(3);
            lista.Añadir(4);
            lista.Añadir(5);
            lista.Añadir(6);
            Assert.IsFalse(lista.Borrar(17), "No se borró ningún elemento porque no se encontró");
            Assert.IsFalse(lista.Borrar(10), "No se borró ningún elemento porque no se encontró");
            Assert.IsFalse(lista.Borrar(1000), "No se borró ningún elemento porque no se encontró");
            Assert.AreEqual(6, lista.NumeroElementos, "Ningún elemento fue borrado");
        }

        [TestMethod]
        public void PruebaMétodoAñadirTexto()
        {
            listaTexto.Añadir("Hola");
            listaTexto.Añadir("mundo");
            listaTexto.Añadir("!");
            Assert.AreEqual(3, listaTexto.NumeroElementos, "Se añadieron los 3 elementos correctamente");
        }

        [TestMethod]
        public void PruebaMétodoBorrarTexto()
        {
            listaTexto.Añadir("Hola");
            listaTexto.Añadir("mundo");
            listaTexto.Añadir("!");
            Assert.IsTrue(listaTexto.Borrar("!"), "Se borró el tercer elemento");
            Assert.AreEqual(2, listaTexto.NumeroElementos, "Se borro el tercer elemento correctamente");
        }

        [TestMethod]
        public void PruebaMétodoContiene()
        {
            listaTexto.Añadir("Hola");
            listaTexto.Añadir("mundo");
            listaTexto.Añadir("!");
            Assert.IsTrue(listaTexto.Contiene("!"), "Si contiene el texto !");
            Assert.IsFalse(listaTexto.Contiene("HolaMundo"), "No contiene el texto HolaMundo");
        }

        [TestMethod]
        public void PruebaMétodoContieneNull()
        {
            listaTexto.Añadir("Hola");
            listaTexto.Añadir("mundo");
            listaTexto.Añadir("!");
            Assert.IsFalse(listaTexto.Contiene(null), "No contiene Null");
        }
    }
}