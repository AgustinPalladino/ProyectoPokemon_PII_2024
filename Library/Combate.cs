using System.Reflection.Metadata;
using Library.Pokemon;

namespace Library;

public class Combate
{
    public List<IPokemon> listaPokemon = new List<IPokemon>();
    private Dictionary<string, Movimiento> movimientosDisponibles = new Dictionary<string, Movimiento>();

    public void mostrarCatalogo()
    {
        this.listaPokemon.Add(new Venusaur());
        this.listaPokemon.Add(new Charizard());
        this.listaPokemon.Add(new Blastoise());
        foreach (IPokemon pokemon in this.listaPokemon)
        {
            Console.WriteLine($"-{pokemon.Nombre}");
        }
    }

    public void logicaEscogerEquipo(Jugador j)
    {
        for (int i = 1; i <= 2; i++)
        {
            int bandera = 0;
            Console.WriteLine($"{j.Nombre} ingrese el nombre de su pokemon numero {i}");
            string pokeIngresado = Console.ReadLine();
            foreach (IPokemon pokemon in this.listaPokemon)
            {
                if (pokeIngresado == pokemon.Nombre)
                {
                    bandera = 1;
                    if (!j.equipoPokemon.Contains(pokemon))
                    {
                        bandera = 2;
                        j.agregarPokemon(pokemon);
                    }
                }
            }
            if (bandera == 0)
            {
                Console.WriteLine("Pokemon no encontrado seleccione nuevamente");
                i--;
            }
            else if (bandera == 1)
            {
                Console.WriteLine("El pokemon ya esta seleccionado");
                i--;
            }
        }
    }
    
    // Método para inicializar los movimientos y guardarlos en el diccionario, privado para que solo se puedan inicializar en Combate.
    private void InicializarMovimientos()
    {
        movimientosDisponibles["Arañazo"] = new Movimiento("Arañazo", 5, "Fuego", false); 
        movimientosDisponibles["Hidrocañon"] = new Movimiento("Hidrocañon", 20, "Agua", false);
        movimientosDisponibles["Luevehojas"] = new Movimiento("Lluevehojas", 20, "Agua", false);
        movimientosDisponibles["Lanzallama"] = new Movimiento("Lanzallama", 25, "Fuego", false);
        movimientosDisponibles["Dormir"] = new Movimiento("Dormir", 0, "Psíquico", true);
        movimientosDisponibles["Paralizar"] = new Movimiento("Paralizar", 0, "Eléctrico", true);
        movimientosDisponibles["Quemar"] = new Movimiento("Quemar", 0, "Fuego", true);
        movimientosDisponibles["Envenenar"] = new Movimiento("Envenenar", 0, "Veneno", true);
    }

    // Método para asignar movimientos específicos a un Pokémon
    public void AsignarMovimientos(IPokemon pokemon, List<string> nombresMovimientos)
    {
        if (nombresMovimientos.Count > 4)
        {
            Console.WriteLine("Un Pokémon no puede tener más de 4 movimientos."); /// Si se intenta asiganr mas de 4 movimientos salta el mensaje
            return;
        }

        foreach (string nombre in nombresMovimientos)
        {
            if (movimientosDisponibles.ContainsKey(nombre)) /// Si el diccionario contiene el nombre del movimiento
            {
                Movimiento movimiento = movimientosDisponibles[nombre]; /// Se crea nueva variable local, para guardar el mov
                pokemon.listaMovimientos.Add(movimiento); /// Se agrega a la lista de movimientos del pokemon.
            }
            else
            {
                Console.WriteLine($"El movimiento '{nombre}' no existe en los movimientos disponibles.");
            }
        }
    }
    public bool chequeoVictoria(Jugador jEnSuTurno, Jugador jEsperando)
    {
        if (jEsperando.equipoPokemon.Count() == 0)
        {
            Console.WriteLine($"\n El {jEnSuTurno.Nombre} es el ganador");
            return true;
        }

        return false;
    }
}