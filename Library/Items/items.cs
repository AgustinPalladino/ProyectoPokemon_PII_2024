using System.Formats.Asn1;
using System.Reflection.Metadata;
using Library.Pokemon;

namespace Library;

public class items{
    public void UseItem(string itemName, IPokemon pokemon) {
        switch (itemName.ToLower())
        {
            case "revivir":
            RevivePokemon(pokemon);
            break;
            case "superpocion":
            SuperPocion(pokemon);
            break;
            case "curatotal":
            CuracionTotal(pokemon);
            break;
        }
    }
    private void RevivePokemon(IPokemon pokemon)
    {
        if (pokemon.Vida <= 0)
        {
                        
            int vida = pokemon.VidaMaxima; 
            pokemon.Vida = vida / 2; // Revive con el 50% de su vida máxima
            Console.WriteLine($"{pokemon.Nombre} ha sido revivido con {pokemon.Vida} puntos de vida.");
        }
        else
        {
            Console.WriteLine($"{pokemon.Nombre} ya está vivo.");
        }
         Console.WriteLine($"{pokemon.Nombre} se ha restaurado 70 puntos de vida.");
    }
    private void SuperPocion(IPokemon pokemon)
    {
        if (pokemon.Vida>0)
        {
            pokemon.Vida+=70;
            if( pokemon.Vida>pokemon.VidaMaxima)
            {
                 pokemon.Vida = pokemon.VidaMaxima;
            }
             Console.WriteLine($"{pokemon.Nombre} se ha restaurado 70 puntos de vida.");
        }
        else
        {
        Console.WriteLine($"{pokemon.Nombre} no puede ser restaurado porque está incapacitado.");
        }
        
    }
    private void CuracionTotal(IPokemon pokemon)
    {

    }
    

}