using System;
using System.Numerics;
using TallerBT.BT;
using TallerTDD;

partial class Program
{
    static void Main(string[] args)
    {
        Agent agent = new Agent(new Vector2(0, 0));
        Vector2 objetivo = new Vector2(10, 0);
        Vector2 puntoInicio = agent.Posicion;
        float distanciaValida = 1.0f;
        float tiempoEspera = 1.0f;

        // 1. Crear el árbol de comportamiento
        BehaviourTree tree = new BehaviourTree();

        // 2. Construir la estructura del árbol
        Sequence cycleSequence = new Sequence();
        cycleSequence.AddChild(new MoveToTarget(agent, objetivo, distanciaValida));
        cycleSequence.AddChild(new WaitTask(tiempoEspera));
        cycleSequence.AddChild(new MoveToTarget(agent, puntoInicio, distanciaValida));
        cycleSequence.AddChild(new WaitTask(tiempoEspera));

        Root root = new Root();
        root.SetChild(cycleSequence);

        // 3. Asignar el root al árbol (¡ESTE ES EL CAMBIO CLAVE!)
        tree.SetRoot(root);

        Console.WriteLine("=== Ciclo Iniciado ===");
        // ... (resto del código de visualización igual)

        while (true)
        {
            // ... (código de espera igual)

            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                Console.WriteLine("\n=== Ciclo Detenido ===");
                break;
            }

            // 4. Ejecutar el ÁRBOL en lugar del root directamente (¡CAMBIAR ESTO!)
            Console.WriteLine("Ejecutando BehaviourTree...");
            tree.Execute();  // ← Cambia root.Execute() por tree.Execute()
            Thread.Sleep(50);
        }
    }
}