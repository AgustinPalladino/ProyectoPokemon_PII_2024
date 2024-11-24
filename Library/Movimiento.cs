using Library.Interaccion;

namespace Library;

/// <summary>
/// Se crea clase Movimiento, con sus métodos, atributos y constructor.
/// </summary>
public class Movimiento
{
    public string Nombre { get; }
    public int Ataque { get; }
    public string Tipo { get; }
    
    public int Precision { get; }
    public bool EsEspecial { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="nombre"></param>
    /// <param name="ataque"></param>
    /// <param name="tipo"></param>
    /// <param name="esEspecial"></param>
    public  Movimiento (string nombre, int ataque,int precision, string tipo, bool esEspecial)
    {
        this.Nombre = nombre;
        this.Ataque = ataque;
        this.Tipo = tipo;
        this.Precision = precision;
        this.EsEspecial = esEspecial;
    }

    
    public Movimiento Clonar()
    {
        // Crea una nueva instancia con los mismos atributos
        return new Movimiento(this.Nombre, this.Ataque, this.Precision,this.Tipo, this.EsEspecial);
    }
    
    /// <summary>
    /// Método abstracto para aplicar el ataque especial
    /// </summary>
    /// <param name="pokemonEnemigo"></param>
    public void AplicarAtaquesEspeciales(Pokemon pokemonEnemigo, IInteraccionConUsuario interaccion)
    {
        if (!EsEspecial) return; /// Con el ! implica que cuando es EsEspecial es falso, se ejecuta el return, saliendo del método. 

        switch (Nombre.ToLower()) /// Se compara en minusculas, con el fin de evitar diferencias de mayusculas y minusculas
        {
            case "dormir":
                if (pokemonEnemigo.Estado == "Normal")
                {
                    pokemonEnemigo.Estado = "Dormido";
                    pokemonEnemigo.TurnosDormido = new Random().Next(1, 5);
                    interaccion.ImprimirMensaje($"{pokemonEnemigo.Nombre} ha sido dormido por {pokemonEnemigo.TurnosDormido} turnos.");
                }
                break;

            case "quemar":
                if (pokemonEnemigo.Estado == "Normal")
                {
                    pokemonEnemigo.Estado = "Quemado";
                    interaccion.ImprimirMensaje($"{pokemonEnemigo.Nombre} ha sido quemado y perderá un 10% de su HP por turno.");
                }
                break;

            case "paralizar":
                if (pokemonEnemigo.Estado == "Normal")
                {
                    pokemonEnemigo.Estado = "Paralizado";
                    interaccion.ImprimirMensaje($"{pokemonEnemigo.Nombre} ha sido paralizado.");
                }
                break;

            case "envenenar":
                if (pokemonEnemigo.Estado == "Normal")
                {
                    pokemonEnemigo.Estado = "Envenenado";
                    interaccion.ImprimirMensaje($"{pokemonEnemigo.Nombre} ha sido envenenado y perderá un 5% de su HP por turno.");
                }
                break;

            default:
                interaccion.ImprimirMensaje($"{Nombre} no tiene un efecto especial definido.");
                break;
        }
    }
}