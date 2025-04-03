using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TallerBT.BT
{
    public class Selector : Composite
    {
        public override bool Execute()
        {
            foreach (var child in Children)
            {
                if (child.Execute())
                    return true; // Si un hijo tiene éxito, el selector tiene éxito
            }
            return false; // Retorna false si todos los hijos fallan
        }
    }
}