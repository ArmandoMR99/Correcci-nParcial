using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerBT.BT;

//namespace TallerTDD
namespace TallerBT.BT
{
    public class BehaviourTree
    {
        private Node root;

        /// <summary>
        /// Obtiene el nodo raíz del árbol (solo lectura)
        /// </summary>
        public Node Root => root;

        /// <summary>
        /// Establece el nodo raíz del árbol
        /// </summary>
        /// <param name="newRoot">Nodo raíz a asignar</param>
        /// <exception cref="ArgumentNullException">Si newRoot es null</exception>
        /// <exception cref="ArgumentException">Si ya existe un root asignado</exception>
        public void SetRoot(Node newRoot)
        {
            if (newRoot == null)
                throw new ArgumentNullException(nameof(newRoot));

            if (root != null)
                throw new ArgumentException("El árbol de comportamiento solo puede tener un único Root.");

            root = newRoot;
        }

        /// <summary>
        /// Ejecuta el árbol de comportamiento completo
        /// </summary>
        /// <returns>True si la ejecución fue exitosa, false en caso contrario</returns>
        public bool Execute() => root?.Execute() ?? false;
    }
}
