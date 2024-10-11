using System.Reflection.Metadata;
using Library.Pokemon;

namespace Library;

public class Combate
{
    public List<IPokemon> listaPokemon = new List<IPokemon>();

    //Se muestra las opciones de los Pokemon que se puede elegir
    public void mostrarCatalogo()
    {
        this.listaPokemon.Add(new Venusaur());
        this.listaPokemon.Add(new Charizard());
        this.listaPokemon.Add(new Blastoise());
        foreach (IPokemon pokemon in this.listaPokemon)
        {
            Console.WriteLine($"-{pokemon.Nombre}"); //Imprime el nombre del pokemon recorriendo listaPokemon
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
                        j.agregarPokemon(pokemon); //Luego de comparar si existe el pokemon ingresado se le agrega al jugador el mismo.
                    }
                }
            }
            if (bandera == 0)
            {
                Console.WriteLine("Pokemon no encontrado seleccione nuevamente"); //Si no se encuentra el pokemon se imprime el mensaje anterior.
                i--;
            }
            else if (bandera == 1)
            {
                Console.WriteLine("El pokemon ya esta seleccionado");
                i--;
            }
        }
    }
//A continuación se crea bonificacionTipos el cual es un multiplicador al valor del ataque, dependiendo de si el Tipo de Movimiento coincide con 
//el Tipo del pokemon
    public double bonificacionTipos(string movimiento, string pokemon)
    {
        if (movimiento == "Fuego")
        {
            if (pokemon == "Agua")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5; //Multiplicador
            }

            if (pokemon == "Planta")
            {
                Console.WriteLine("Es muy eficaz");
                return 2; //Mulitplicador
            }
        }

        if (movimiento == "Agua")
        {
            if (pokemon == "Planta")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5; //Multiplicador
            }

            if (pokemon == "Fuego")
            {
                Console.WriteLine("Es muy eficaz");
                return 2; //Multiplicador
            }
        }

        if (movimiento == "Planta")
        {
            if (pokemon == "Fuego")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5; //Multiplicador
            }

            if (pokemon == "Agua")
            {
                Console.WriteLine("Es muy eficaz");
                return 2; //Multiplicador
            }
        }
        
        return 1; //Multiplicador
    }
    
    public bool chequeoVictoria(Jugador jEnSuTurno, Jugador jEsperando)
    {
        if (jEsperando.equipoPokemon.Count() == 0) //Se chequea cantidad de pokemones disponibles en el equipo rival, si no hay ninguno se da el ganador
        {
            Console.WriteLine($"\n El {jEnSuTurno.Nombre} es el ganador");
            return true;
        }

        return false;
    }
}