namespace TallerBT.BT
{
    public class Root : Node
    {
        public Node Child { get; private set; }

        public void SetChild(Node child)
        {
            if (child is Root)
                throw new InvalidOperationException("El Root no puede tener otro Root como hijo.");

            if (Child != null)
                throw new InvalidOperationException("El Root solo puede tener un hijo.");

            Child = child;
        }

        public override bool Execute()
        {
            if (Child == null)
                return false; // 👈 Más claro para propósitos de documentación

            return Child.Execute();
        }
    }
}


