public abstract class Node
{
    protected List<Node> children = new List<Node>();

    public abstract bool Execute();

    public virtual void Reset() { }

    public void AddChild(Node child)
    {
        children.Add(child);
    }

    public bool ExecuteWithLogging()
    {
        Console.WriteLine($"Ejecutando nodo: {GetType().Name}");
        bool result = Execute();
        Console.WriteLine($"Resultado de {GetType().Name}: {(result ? "Éxito" : "Fallo")}");
        return result;
    }
}
