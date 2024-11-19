namespace Library;

public static class InteraccionConsola
{
    public static string ElegirPokemon(Jugador j)
    {
        Console.WriteLine($"{j.Nombre}, ingrese el nombre del pokemon que desea elegir");
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