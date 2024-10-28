namespace Library.Items;

public class SuperPocion : Item
{
    public SuperPocion() : base()
    {
        
    }
    
    public override void funcionItem(Jugador jugador)
    {
        {
            if (jugador.pokemonEnCancha().Vida > 0)
            {
                jugador.pokemonEnCancha().VidaActual += 70;
                if (jugador.pokemonEnCancha().VidaActual > jugador.pokemonEnCancha().Vida)
                {
                    jugador.pokemonEnCancha().VidaActual = jugador.pokemonEnCancha().Vida;
                }

                Console.WriteLine($"{jugador.pokemonEnCancha().Nombre} se ha restaurado 70 puntos de vida.");
            }
            else
            {
                Console.WriteLine(
                    $"{jugador.pokemonEnCancha().Nombre} no puede ser restaurado porque está incapacitado.");
            }
        }
    }
}