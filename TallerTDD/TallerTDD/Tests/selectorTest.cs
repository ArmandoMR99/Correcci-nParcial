using TallerBT.BT;
using TallerTDD.BT;

namespace TallerTDD.Tests
{
    [TestFixture] // ✅ Clase pública y con atributo TestFixture
    public class SelectorTests
    {
        // --- Pruebas existentes (mejoradas) ---
        [Test]
        public void Execute_ConUnHijoExitoso_RetornaTrue()
        {
            var selector = new Selector();
            selector.AddChild(new EvenNumberTask(3)); // False
            selector.AddChild(new EvenNumberTask(4)); // True

            Assert.IsTrue(selector.Execute(),
                "Debe retornar true si al menos un hijo tiene éxito");
        }

        [Test]
        public void Execute_ConTodosHijosFallidos_RetornaFalse()
        {
            var selector = new Selector();
            selector.AddChild(new EvenNumberTask(3)); // False
            selector.AddChild(new EvenNumberTask(5)); // False

            Assert.IsFalse(selector.Execute(),
                "Debe retornar false si todos los hijos fallan");
        }

        [Test]
        public void Execute_Vacio_RetornaFalse()
        {
            var selector = new Selector();
            Assert.IsFalse(selector.Execute(),
                "Un Selector vacío debe retornar false");
        }

        // --- Nuevas pruebas críticas ---
        [Test]
        public void Execute_ConTresHijosYElUltimoExitoso_RetornaTrue()
        {
            var selector = new Selector();
            selector.AddChild(new EvenNumberTask(3)); // False
            selector.AddChild(new EvenNumberTask(5)); // False
            selector.AddChild(new EvenNumberTask(4)); // True (éxito en último hijo)

            Assert.IsTrue(selector.Execute(),
                "Debe retornar true al encontrar el primer hijo exitoso (incluso si es el último)");
        }

        [Test]
        public void Execute_SelectorAnidadoEnSelector_RetornaSegunLogica()
        {
            var parentSelector = new Selector();
            var childSelector = new Selector();

            childSelector.AddChild(new EvenNumberTask(3)); // False
            childSelector.AddChild(new EvenNumberTask(4)); // True
            parentSelector.AddChild(childSelector); // True (por el hijo)

            Assert.IsTrue(parentSelector.Execute(),
                "El Selector padre debe retornar true si el Selector hijo tiene éxito");
        }

        [Test]
        public void Execute_SelectorConSequenceComoHijo_RetornaSegunSequence()
        {
            var selector = new Selector();
            var sequence = new Sequence();

            sequence.AddChild(new EvenNumberTask(2)); // True
            sequence.AddChild(new EvenNumberTask(4)); // True
            selector.AddChild(sequence); // True (Sequence exitoso)

            Assert.IsTrue(selector.Execute(),
                "Debe retornar true si el Sequence hijo tiene éxito");
        }
    }
}