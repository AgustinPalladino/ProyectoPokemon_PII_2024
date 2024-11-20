namespace Library;

public static class InteraccionConUsuario
{
    public static int EscogerOpcion(Jugador j)
    {
        Console.WriteLine($"\nTurno de {j.Nombre}. ¿Qué deseas hacer? Seleccione un numero porfavor.");
        Console.WriteLine($"Su pokemon en el combate es: {j.pokemonEnCancha().Nombre}");

        Console.WriteLine("1- Ver las habilidades de tu Pokémon (No consume turno)");
        Console.WriteLine("2- Ver la salud de tu Pokémon (No consume turno)");
        Console.WriteLine("3- Mochila (Solo usar objeto consume un turno)");
        Console.WriteLine("4- Atacar (Consume un turno)");
        Console.WriteLine("5- Cambiar de Pokémon (Consume un turno)");
        return Convert.ToInt32(Console.ReadLine());
    }
    
    public static void AtaqueEfecto(Jugador jEnemigo, Movimiento movimiento)
    {
        Console.WriteLine($"{jEnemigo.pokemonEnCancha().Nombre} ahora está bajo efecto del ataque {movimiento.Nombre}.");
    }

    public static string SeleccionarPokemon(Jugador j)
    {
        Console.Write($"{j.Nombre}, seleccione su pokemon: ");
        return Console.ReadLine();
    }
    
    public static string CambiarPokemon(Jugador j)
    {
        Console.WriteLine($"{j.Nombre}, ingrese el nombre del pokemon que desea elegir o 0 para ir hacia atras");
        return Console.ReadLine();
    }

    public static string ElegirItem(Jugador j)
    {
        Console.WriteLine($"{j.Nombre}, ingrese el nombre del item para usarlo o 0 para salir");
        return Console.ReadLine();
    }


    public static string ElegirMovimiento(Jugador j)
    {
        Console.WriteLine($"\n{j.Nombre}, ingrese el nombre del movimiento desee usar o 0 para salir");
        return Console.ReadLine();
    }
}