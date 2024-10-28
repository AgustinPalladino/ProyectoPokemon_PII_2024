using Library;
// Nuestra fachada es el Program, es decir el usuario interactua directamente con el Program

//Dinamica de seleccion de pokemones
Combate combate = new Combate();
Jugador j1 = new Jugador("Jugador 1");
Jugador j2 = new Jugador("Jugador 2");

combate.mostrarCatalogo();
combate.logicaEscogerEquipo(j1);
combate.logicaEscogerEquipo(j2);

//Dinamica de seleccion de pokemon en cancha
Console.WriteLine("\nEquipo del jugador uno:");
j1.mostrarEquipo();
Console.WriteLine("¿Jugador uno, cual va a ser su pokemon en cancha?");
string pokeIngresado1 = Console.ReadLine();
j1.pokemonEnCancha();

Console.WriteLine("\nEquipo del jugador dos:");
j2.mostrarEquipo();
Console.WriteLine("¿Jugador dos, cual va a ser su pokemon en cancha?");
string pokeIngresado2 = Console.ReadLine();
j2.pokemonEnCancha();


bool bandera = false;
while (bandera == false)
{
    int opcion = 0;
    while (opcion != 3 || opcion != 4)
    {
        if (j1.pokemonEnCancha() == null)
        {
            Console.WriteLine($"{j1.Nombre}. su pokemon se encuentra derrotado, debe cambiar");
            pokeIngresado1 = Console.ReadLine();
            j1.cambiarPokemon(pokeIngresado1);
            bandera = combate.chequeoVictoria(j1,j2);
            opcion = 5;
        }
        else
        {
            Console.WriteLine($"\n ¿{j1.Nombre}, que desea hacer? \n 1-Ver las habilidades de su pokemon(No consume turno) \n 2-Ver la salud de su pokemon(No consume turno) \n 3-Atacar(Consume un turno) \n 4-Cambiar de pokemon(Consume un turno)");
            opcion = Convert.ToInt32(Console.ReadLine());
            if (opcion == 1)
            {
                j1.verMovimientos();
            }
            if (opcion == 2)
            {
                j1.verSalud();
            }
            if (opcion == 3)
            {
                j1.atacar(j2);
                opcion = 5;
                bandera = combate.chequeoVictoria(j1,j2);
                
                break;
            }
            if (opcion == 4)
            {
                Console.WriteLine("¿A que pokemon desea cambiar?");
                pokeIngresado1 = Console.ReadLine();
                j1.cambiarPokemon(pokeIngresado1);
                opcion = 5;
                bandera = combate.chequeoVictoria(j1,j2);
                break;
            }
        }
    }

    while ((opcion != 3 && bandera == false) || (opcion != 4 && bandera == false)) 
    {
        if (j2.pokemonEnCancha() == null)
        {
            Console.WriteLine($"{j2.Nombre}. su pokemon se encuentra derrotado, debe cambiar");
            Console.WriteLine("¿A que pokemon desea cambiar?");
            pokeIngresado2 = Console.ReadLine();
            j2.cambiarPokemon(pokeIngresado2);
            bandera = combate.chequeoVictoria(j2, j1);
            opcion = 5;
        }
        else
        {
            Console.WriteLine(
                $"\n ¿{j2.Nombre}, que desea hacer? \n 1-Ver las habilidades de su pokemon(No consume turno) \n 2-Ver la salud de su pokemon(No consume turno) \n 3-Atacar(Consume un turno) \n 4-Cambiar de pokemon(Consume un turno)");
            opcion = Convert.ToInt32(Console.ReadLine());
            if (opcion == 1)
            {
                j2.verMovimientos();
            }

            if (opcion == 2)
            {
                j2.verSalud();
            }

            if (opcion == 3)
            {
                j2.atacar(j1);
                bandera = combate.chequeoVictoria(j2, j1);
                break;
            }

            if (opcion == 4)
            {
                Console.WriteLine("¿A que pokemon desea cambiar?");
                pokeIngresado2 = Console.ReadLine();
                j2.cambiarPokemon(pokeIngresado2);
                bandera = combate.chequeoVictoria(j2, j1);
                break;
            }
        }
    }
}

