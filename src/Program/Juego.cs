using Ucu.Poo.DiscordBot;
using Ucu.Poo.DiscordBot.Domain;
using Ucu.Poo.DiscordBot.Interaccion;
using Ucu.Poo.DiscordBot.Services;

namespace Program;

/// <summary>
/// Un programa que implementa un bot de Discord.
/// </summary>
internal static class Juego
{
    /// <summary>
    /// Punto de entrada al programa.
    /// </summary>
    private static void Main()
    {
        //Juego por consola:
        /*
        Jugador j1 = new Jugador("Jugador 1");
        Jugador j2 = new Jugador("Jugador 2");
        Combate combate = new Combate(new InteraccionPorConsola());
        combate.BuclePrincipal(j1, j2);
        */
        
        
        // DemoFacade();
        // DemoBot();
    }

    private static void DemoFacade()
    {
        Console.WriteLine(Facade.Instance.AddTrainerToWaitingList("player"));
        Console.WriteLine(Facade.Instance.AddTrainerToWaitingList("opponent"));
        Console.WriteLine(Facade.Instance.GetAllTrainersWaiting());
        Console.WriteLine(Facade.Instance.StartBattle("player", "opponent"));
        Console.WriteLine(Facade.Instance.GetAllTrainersWaiting());
    }

    private static void DemoBot()
    {
        BotLoader.LoadAsync().GetAwaiter().GetResult();
    }
}

//IMPLEMENTACION EN "JUGADOR" DE MI DEFENSA

/*
    public int PokeWinrate(Jugador jugador)
    {
        if (jugador.equipoPokemonDerrotados.Count() == 0)
        {
            return 60;

        }

        if (jugador.equipoPokemonDerrotados.Count() == 6)
        {
            return 0;
        }

        if (jugador.equipoPokemonDerrotados.Count() == 5)
        {
            return 10;
        }

        if (jugador.equipoPokemonDerrotados.Count() == 4)
        {
            return 20;
        }

        if (jugador.equipoPokemonDerrotados.Count() == 3)
        {
            return 30;
        }

        if (jugador.equipoPokemonDerrotados.Count() == 2)
        {
            return 40;
        }

        else 
        {
            return 50;
        }
    }

    /// <summary>
    /// comparacion numero a numero basado en la cantidad base de objetos (en el codigo original eran 7 pero para que quede mas practico deje 5 objetos)
    /// </summary>
    /// <param name="jugador"></param>
    /// <returns></returns>
    public int BackpackWinrate(Jugador jugador)
    {
        if (jugador.Mochila.Count == 5)
        {
            return 30;
        }

        if (jugador.Mochila.Count == 4)
        {
            return 24;
        }

        if (jugador.Mochila.Count == 3)
        {
            return 18;
        }

        if (jugador.Mochila.Count == 2)
        {
            return 12;
        }

        if (jugador.Mochila.Count == 1)
        {
            return 6;
        }

        else 
        {
            return 0;
        }
    }
    /// <summary>
    /// Estado booleano asi que si hay uno el numero/"porcentage de victoria" es automáticamente 0
    /// </summary>
    /// <param name="pokemon"></param>
    /// <param name="jugador"></param>
    /// <returns></returns>
    private int EstadoWinrate(Pokemon pokemon, Jugador jugador)
    {
        if (pokemon.Estado == "Normal")
        {
            return 10;
        }
        else
        {
            return 0;
        }
    }
    /// <summary>
    /// Metodo para calcular el porcentaje total de victoria sumando los tres metodos anteriores (esto en teoria por lo menos)
    /// </summary>
    /// <param name="jugador"></param>
    /// <param name="pokemon"></param>
    /// <returns></returns>

    public string WinrateTotal(Jugador jugador, Pokemon pokemon)
    {
        return $"Probabilidad de ganar De {jugador} es: {(EstadoWinrate(pokemon, jugador) + BackpackWinrate(jugador) + PokeWinrate(jugador))} de 100";
    }
*/