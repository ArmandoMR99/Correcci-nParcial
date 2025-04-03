using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerBT.BT
{
    public abstract class Composite : Node
    {
        protected List<Node> Children = new List<Node>();

        public void AddChild(Node child)
        {
            if (child is Root)
                throw new InvalidOperationException("Composite no puede tener Root como hijo.");

            Children.Add(child);
        }
    }
}
