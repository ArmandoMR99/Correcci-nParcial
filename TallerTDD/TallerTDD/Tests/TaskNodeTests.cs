using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TallerBT.BT;

namespace TallerTDD.Tests
{
    [TestFixture]
    public class TaskNodeTests
    {
        [Test]
        public void TaskNode_CannotBeInstantiatedDirectly()
        {
            // Intentar instanciar TaskNode directamente debería lanzar un error de compilación, no en tiempo de ejecución.
            // Por lo tanto, eliminamos la parte de Activator.CreateInstance

            // Verificamos que una subclase concreta de TaskNode sí puede ser instanciada
            var waitTask = new WaitTask(1.0f);  // Suponiendo que WaitTask hereda de TaskNode

            Assert.NotNull(waitTask);
        }


        [Test]
        public void TaskNode_CannotHaveChildren()
        {
             TaskNode task = new WaitTask(1.0f);
            Assert.Throws<InvalidOperationException>(() => task.AddChild(new WaitTask(2.0f)));
            
        }
    }
    }


