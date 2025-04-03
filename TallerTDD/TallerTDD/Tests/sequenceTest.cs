using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerBT.BT;
using TallerTDD.BT;

namespace TallerTDD.Tests
{
    [TestFixture]
    public class SequenceTests
    {
        [Test]
        public void Execute_ConUnHijoFallido_RetornaFalse()
        {
            var sequence = new Sequence();
            sequence.AddChild(new EvenNumberTask(2)); // True
            sequence.AddChild(new EvenNumberTask(3)); // False

            Assert.IsFalse(sequence.Execute(),
                "Debe fallar si al menos un hijo falla");
        }

        [Test]
        public void Execute_ConTodosHijosExitosos_RetornaTrue()
        {
            var sequence = new Sequence();
            sequence.AddChild(new EvenNumberTask(2)); // True
            sequence.AddChild(new EvenNumberTask(4)); // True

            Assert.IsTrue(sequence.Execute(),
                "Debe retornar true si todos los hijos son exitosos");
        }

        [Test]
        public void Execute_Vacio_RetornaFalse()
        {
            var sequence = new Sequence();
            Assert.IsFalse(sequence.Execute(),
                "Un Sequence vacío debe retornar false");
        }

        [Test]
        public void Execute_ConTresHijosYElSegundoFalla_RetornaFalse()
        {
            var sequence = new Sequence();
            sequence.AddChild(new EvenNumberTask(2)); // True
            sequence.AddChild(new EvenNumberTask(3)); // False
            sequence.AddChild(new EvenNumberTask(4)); // No se evalúa

            Assert.IsFalse(sequence.Execute(),
                "Debe fallar en el primer hijo que falle y no evaluar el resto");
        }

        [Test]
        public void Execute_SequenceAnidadoEnSequence_RetornaSegunLogica()
        {
            var parentSequence = new Sequence();
            var childSequence = new Sequence();

            childSequence.AddChild(new EvenNumberTask(2)); // True
            childSequence.AddChild(new EvenNumberTask(3)); // False
            parentSequence.AddChild(childSequence); // False

            Assert.IsFalse(parentSequence.Execute(),
                "El Sequence padre debe fallar si el Sequence hijo falla");
        }

        [Test]
        public void Execute_SequenceConSelectorComoHijo_RetornaSegunSelector()
        {
            var sequence = new Sequence();
            var selector = new Selector();

            selector.AddChild(new EvenNumberTask(3)); // False
            selector.AddChild(new EvenNumberTask(5)); // False
            sequence.AddChild(selector); // False

            Assert.IsFalse(sequence.Execute(),
                "Debe fallar si el Selector hijo falla");
        }
    }
}