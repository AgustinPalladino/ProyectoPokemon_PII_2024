namespace Library.Moves;

/// <summary>
/// Se crea clase Movimiento, con sus métodos, atributos y constructor.
/// </summary>
public class Movimiento
{
    public string Nombre { get; }
    public int Ataque { get; }
    public string Tipo { get; }
    public bool EsEspecial { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="nombre"></param>
    /// <param name="ataque"></param>
    /// <param name="tipo"></param>
    /// <param name="esEspecial"></param>
    public  Movimiento (string nombre, int ataque, string tipo, bool esEspecial)
    {
        this.Nombre = nombre;
        this.Ataque = ataque;
        this.Tipo = tipo;
        this.EsEspecial = esEspecial;
    }

    /// <summary>
    /// Método abstracto para aplicar el ataque especial
    /// </summary>
    /// <param name="pokemonEnemigo"></param>
    public void AplicarAtaquesEspeciales(Pokemon pokemonEnemigo)
    {
        if (!EsEspecial) return; /// Con el ! implica que cuando es EsEspecial es falso, se ejecuta el return, saliendo del método. 

        switch (Nombre.ToLower()) /// Se compara en minusculas, con el fin de evitar diferencias de mayusculas y minusculas
        {
            case "dormir":
                if (pokemonEnemigo.Estado == null)
                {
                    pokemonEnemigo.Estado = "Dormido";
                    pokemonEnemigo.TurnosDormido = new Random().Next(1, 5);
                    Console.WriteLine($"{pokemonEnemigo.Nombre} ha sido dormido por {pokemonEnemigo.TurnosDormido} turnos.");
                }
                break;

            case "quemar":
                if (pokemonEnemigo.Estado == null)
                {
                    pokemonEnemigo.Estado = "Quemado";
                    Console.WriteLine($"{pokemonEnemigo.Nombre} ha sido quemado y perderá un 10% de su HP por turno.");
                }
                break;

            case "paralizar":
                if (pokemonEnemigo.Estado == null)
                {
                    pokemonEnemigo.Estado = "Paralizado";
                    Console.WriteLine($"{pokemonEnemigo.Nombre} ha sido paralizado.");
                }
                break;

            case "envenenar":
                if (pokemonEnemigo.Estado == null)
                {
                    pokemonEnemigo.Estado = "Envenenado";
                    Console.WriteLine($"{pokemonEnemigo.Nombre} ha sido envenenado y perderá un 5% de su HP por turno.");
                }
                break;

            default:
                Console.WriteLine($"{Nombre} no tiene un efecto especial definido.");
                break;
        }
    }
}