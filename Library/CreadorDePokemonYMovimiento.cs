using Library.Moves;

namespace Library;

public class CreadorDePokemonYMovimiento
{
    public List<Pokemon> listaPokemon = new List<Pokemon>();
    public List<Movimiento> listaMovimiento = new List<Movimiento>();

    public CreadorDePokemonYMovimiento()
    {
        agregarPokemon();
    }
    
    public void agregarPokemon()
    {
        /// Creación de pokemons
        Pokemon venusaur = new Pokemon("Venusaur", "Planta", 120, 40, 60);
        Pokemon charizard = new Pokemon("Charizard", "Fuego", 100, 60, 40);
        Pokemon blastoise = new Pokemon("Blastoise", "Agua", 110, 50, 50);
        
        /// Creación de movimientos
        Movimiento Arañazo = new Movimiento("Arañazo", 5, "Fuego", false);
        Movimiento Lanzallamas = new Movimiento("Lanzallamas", 20, "Fuego", false);
        Movimiento Lluevehojas = new Movimiento("Lluevehojas", 20, "Planta", false);
        Movimiento Hidrocañon = new Movimiento("Hidrocañon", 20, "Agua", false);
        Movimiento Dormir = new Movimiento("Dormir", 0, "Psiquico", true);
        Movimiento Envenenar = new Movimiento("Envenenar", 0, "Veneno", true);
        Movimiento Quemar = new Movimiento("Quemar", 0, "Fuego", true);
        Movimiento Paralizar = new Movimiento("Paralizar", 0, "Electrico", true);
        
        
        
        ///Logica para agregar los movimientos a cada pokemon.
        venusaur.agregarMovimiento(Arañazo);
        venusaur.agregarMovimiento(Dormir);
        venusaur.agregarMovimiento(Quemar);
        venusaur.agregarMovimiento(Lanzallamas);
        charizard.agregarMovimiento(Lluevehojas);
        charizard.agregarMovimiento(Paralizar);
        charizard.agregarMovimiento(Quemar);
        charizard.agregarMovimiento(Hidrocañon);
        blastoise.agregarMovimiento(Arañazo);
        blastoise.agregarMovimiento(Envenenar);
        blastoise.agregarMovimiento(Dormir);
        blastoise.agregarMovimiento(Hidrocañon);
        
        /// Se agregan los pokemon a la lista.
        listaPokemon.Add(venusaur);
        listaPokemon.Add(charizard);
        listaPokemon.Add(blastoise);
        
    }
    
}
