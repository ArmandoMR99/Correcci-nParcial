using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TallerBT.BT;
using TallerTDD.BT;

namespace TallerTDD.Tests
{
    [TestFixture]
    public class RootTests
    {
        [Test]
        public void Root_CanOnlyHaveOneChild()
        {
            Root root = new Root();
            Node child1 = new WaitTask(1.0f);
            Node child2 = new WaitTask(2.0f);

            root.SetChild(child1);
            Assert.Throws<InvalidOperationException>(() => root.SetChild(child2));
        }

        [Test]
        public void Root_CannotHaveAnotherRootAsChild()
        {
            Root root = new Root();
            Root anotherRoot = new Root();
            Assert.Throws<InvalidOperationException>(() => root.SetChild(anotherRoot));
        }

        [Test]
        public void Root_Vacio_RetornaFalse()
        {
            // Arrange
            var root = new Root(); // Root sin hijo asignado

            // Act
            bool resultado = root.Execute();

            // Assert
            Assert.IsFalse(resultado, "Un Root vacío debe retornar false");
        }
        [Test]
        public void Root_ConSequence_RetornaSegunHijos()
        {
            var root = new Root();
            var sequence = new Sequence();
            sequence.AddChild(new EvenNumberTask(2)); // True
            sequence.AddChild(new EvenNumberTask(4)); // True

            root.SetChild(sequence);
            Assert.IsTrue(root.Execute()); // True (todos los hijos de Sequence son exitosos)
        }

        [Test]
        public void Root_ConSelector_RetornaSegunHijos()
        {
            var root = new Root();
            var selector = new Selector();
            selector.AddChild(new EvenNumberTask(3)); // False
            selector.AddChild(new EvenNumberTask(4)); // True

            root.SetChild(selector);
            Assert.IsTrue(root.Execute()); // True (al menos un hijo de Selector es exitoso)
        }
    }

}
