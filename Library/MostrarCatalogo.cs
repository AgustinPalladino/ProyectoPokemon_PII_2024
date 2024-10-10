using Library.Pokemon;
namespace Library;

public class MostrarCatalogo
{
    public List<IPokemon> listaPokemon = new List<IPokemon>();
    
    public void crearCatalogo()
    {
        int i = 1;
        this.listaPokemon.Add(new Venusaur());
        this.listaPokemon.Add(new Charizard());
        this.listaPokemon.Add(new Blastoise());
        foreach (IPokemon pokemon in this.listaPokemon)
        {
            Console.WriteLine(i + "-" + pokemon.Name);
            i++;
        }
    }
}