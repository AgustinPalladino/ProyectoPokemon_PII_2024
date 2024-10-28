namespace Library.Items;

public class Revivir : Item
{
    public Revivir() : base()
    {
        
    }
    
    public override void funcionItem(Jugador jugador)
    {
        {
            if (jugador.pokemonEnCancha().Vida <= 0)
            {
                jugador.pokemonEnCancha().VidaActual = jugador.pokemonEnCancha().Vida / 2;
                Console.WriteLine($"{jugador.pokemonEnCancha().Nombre} ha sido revivido con {jugador.pokemonEnCancha().Vida} puntos de vida.");
            }
            else
            {
                Console.WriteLine($"{jugador.pokemonEnCancha().Nombre} ya está vivo.");
            }
            Console.WriteLine($"{jugador.pokemonEnCancha().Nombre} se ha restaurado 70 puntos de vida.");
        }
    }
}