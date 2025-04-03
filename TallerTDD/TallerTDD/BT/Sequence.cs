using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerBT.BT;

public class Sequence : Composite
{
    public override bool Execute()
    {
        foreach (var child in Children)
        {
            if (!child.Execute())
                return false; // Si un hijo falla, toda la secuencia falla
        }
        return Children.Count > 0; // Retorna true solo si tiene hijos y todos fueron exitosos
    }
}

