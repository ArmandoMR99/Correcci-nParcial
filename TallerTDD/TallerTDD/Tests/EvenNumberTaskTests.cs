using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TallerTDD.BT;

namespace TallerTDD.Tests
{
    [TestFixture]
    public class EvenNumberTaskTests
    {
        [Test]
        public void EvenNumberTask_ReturnsTrueForEvenNumbers()
        {
            EvenNumberTask task = new EvenNumberTask(4);
            Assert.IsTrue(task.Execute());
        }

        [Test]
        public void EvenNumberTask_ReturnsFalseForOddNumbers()
        {
            EvenNumberTask task = new EvenNumberTask(3);
            Assert.IsFalse(task.Execute());
        }
    }
}
