using Ucu.Poo.DiscordBot.Items;

namespace Ucu.Poo.DiscordBot.Domain;

/// <summary>
/// Esta clase representa un jugador en el juego Pokémon.
/// </summary>
public class Trainer
{
    /// <summary>
    /// El nombre de usuario de Discord en el servidor del bot del jugador.
    /// </summary>
    public string DisplayName { get; }
    public List<Pokemon> equipoPokemon = new();
    public List<Pokemon> equipoPokemonDerrotados = new();
    public List<string> nombreCheck = new();
    public List<Item> Mochila = new();

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Trainer"/> con el
    /// nombre de usuario de Discord que se recibe como argumento.
    /// </summary>
    /// <param name="displayName">El nombre de usuario de Discord.</param>
    public Trainer(string displayName)
    {
        this.DisplayName = displayName;
        Mochila.Add(new SuperPocion());
        Mochila.Add(new SuperPocion());
        Mochila.Add(new SuperPocion());
        Mochila.Add(new SuperPocion());
        Mochila.Add(new Revivir());
        Mochila.Add(new CuraTotal()); 
        Mochila.Add(new CuraTotal()); 
    }
    
    public void agregarPokemon(Pokemon pokemon)
    {
        this.equipoPokemon.Add(pokemon);
    }
}
