using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TallerBT.BT;

namespace TallerTDD.Tests
{
    [TestFixture]
    public partial class BehaviourTreeTests
    {
        [Test]
        public void BehaviourTree_HasOnlyOneRoot()
        {
            // Arrange
            BehaviourTree tree = new BehaviourTree();
            Node root1 = new Root();
            Node root2 = new Root();

            tree.SetRoot(root1);

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => tree.SetRoot(root2));
            Assert.That(ex.Message, Is.EqualTo("El árbol de comportamiento solo puede tener un único Root."));
        }
    }
}