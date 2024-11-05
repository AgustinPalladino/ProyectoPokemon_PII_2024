namespace Library;

public class CreadorDePokemon
{
    private List<Pokemon> listaPokemon = new List<Pokemon>();
    public Pokemon venusaur = new Pokemon("Venusaur", "Planta", 120, 40, 60);
    public Pokemon charizard = new Pokemon("Charizard", "Fuego", 100, 60, 40);
    public Pokemon blastoise = new Pokemon("Blastoise", "Agua", 110, 50, 50);
    public List<Pokemon> ListaPokemon
    {
        get { return this.listaPokemon; }
        set
        {
            listaPokemon.Add(venusaur);
            listaPokemon.Add(charizard);
            listaPokemon.Add(blastoise);
        }
    }
}