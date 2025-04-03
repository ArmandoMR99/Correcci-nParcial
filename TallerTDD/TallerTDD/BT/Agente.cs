using System.Numerics;

namespace TallerBT.BT
{
    public class Agent
    {

        private Vector2 posicionInicial;
        public Vector2 Posicion { get; internal set; }


        public Agent(Vector2 posicionInicial)
        {
            this.posicionInicial = posicionInicial;
            this.Posicion = posicionInicial; 
        }
        public float DistanciaAlObjetivo(Vector2 objetivo)
        {
            return Vector2.Distance(Posicion, objetivo);
        }

        public void MoverHaciaObjetivo(Vector2 objetivo)
        {
            // Imprime antes y después para ver si cambia la posición
            Console.WriteLine($"[Antes] Posición del agente: {Posicion}");
            Posicion = Vector2.Lerp(Posicion, objetivo, 0.1f); // Movimiento gradual
            Console.WriteLine($"[Después] Posición del agente: {Posicion}");
        }

    }
}