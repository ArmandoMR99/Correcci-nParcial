using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerBT.BT;

namespace TallerTDD.BT
{
    public class EvenNumberTask : TaskNode
    {
        private int number;

        public EvenNumberTask(int num) => number = num;

        public override bool Execute()
        {
            return number % 2 == 0;
        }
    }
}
