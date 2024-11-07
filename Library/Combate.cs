namespace Library;

public class Combate
{
    public void mostrarCatalogo(List<Pokemon> listaPokemon)
    {
        foreach (Pokemon pokemon in listaPokemon)
        {
            Console.WriteLine($"-{pokemon.Nombre}");
        }
    }
    
}