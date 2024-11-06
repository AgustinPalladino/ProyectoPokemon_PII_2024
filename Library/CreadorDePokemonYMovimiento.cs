namespace Library;

public class CreadorDePokemonYMovimiento
{
    public List<Pokemon> listaPokemon = new List<Pokemon>();

    public CreadorDePokemonYMovimiento()
    {
        agregarPokemon();
    }
    
    public void agregarPokemon()
    {
        Pokemon venusaur = new Pokemon("Venusaur", "Planta", 120, 40, 60);
        Pokemon charizard = new Pokemon("Charizard", "Fuego", 100, 60, 40);
        Pokemon blastoise = new Pokemon("Blastoise", "Agua", 110, 50, 50);
        listaPokemon.Add(venusaur);
        listaPokemon.Add(charizard);
        listaPokemon.Add(blastoise);
    }
}