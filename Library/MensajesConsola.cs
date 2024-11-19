namespace Library;

public static class MensajesConsola
{
    public static void Error()
    {
        Console.WriteLine("Error");
    }
    
    
    public static void VolverAtras()
    {
        Console.WriteLine("Usted regreso hacia atras");
    }

    public static void NoEncontrado()
    {
        Console.WriteLine("No se encontro intente nuevamente");
    }

    public static void Ganador(Jugador j)
    {
        Console.WriteLine($"Felicidades {j.Nombre}! Has ganado la batalla.");
    }
    
    public static void MostrarMochila(Jugador j)
    {
        Console.WriteLine("\nMochila:");
        for (int i = 0; i < j.Mochila.Count; i++)
        {
            Console.WriteLine($"- {j.Mochila[i].Nombre}");
        }
    }

    public static void MochilaVacia()
    {
        Console.WriteLine("Mochila vacia");
    }

    

}