using System;
using System.Numerics;
using System.Threading; // Necesario para Thread.Sleep

namespace TallerBT.BT
{
    public class MoveToTarget : TaskNode
    {
        private Agent agent;
        private Vector2 objetivo;
        private float distanciaValida;

        public MoveToTarget(Agent agent, Vector2 objetivo, float distanciaValida)
        {
            this.agent = agent;
            this.objetivo = objetivo;
            this.distanciaValida = distanciaValida;
        }

        public override bool Execute()
        {
            while (agent.DistanciaAlObjetivo(objetivo) > distanciaValida)
            {
                agent.MoverHaciaObjetivo(objetivo);
                Thread.Sleep(100); // Espera para visualizar el movimiento
            }
            Console.WriteLine($"[Éxito] ¡Objetivo alcanzado! (Posición: {agent.Posicion})");
            return true;
        }



        public override void Reset()
        {
            // No reiniciar la posición aquí, solo preparar la tarea para una nueva ejecución
            Console.WriteLine("[Reset] Reiniciando MoveToTarget");
        }
    }
}
