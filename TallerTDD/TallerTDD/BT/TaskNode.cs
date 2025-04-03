using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerBT.BT
{
    public abstract class TaskNode : Node
    {
        public virtual void AddChild(Node child)
        {
            throw new InvalidOperationException("TaskNode no puede tener hijos.");
        }
        public void TaskNode_CannotBeInstantiatedDirectly()
        {
            // Nota: La siguiente línea no compilaría (TaskNode es abstract).
            // var taskNode = new TaskNode(); // ❌ Error de compilación

            // Verificamos que una subclase concreta sí se puede instanciar
            var waitTask = new WaitTask(1.0f);
            Assert.NotNull(waitTask); // ✅
        }
    }
}
    
