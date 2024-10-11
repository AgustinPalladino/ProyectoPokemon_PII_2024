using Library;
using Library.Pokemon;

Combate combate = new Combate();
Jugador j1 = new Jugador("Jugador 1");
Jugador j2 = new Jugador("Jugador 2");

combate.mostrarCatalogo();
combate.logicaEscogerEquipo(j1);
combate.logicaEscogerEquipo(j2);

Console.WriteLine("\nEquipo del jugador uno:");
j1.mostrarEquipo();
Console.WriteLine("¿Jugador uno, cual va a ser su pokemon en cancha?");
string pokeIngresado1 = Console.ReadLine();
IPokemon pokeJ1 = j1.pokemonEnCancha(pokeIngresado1);

Console.WriteLine("\nEquipo del jugador uno:");
j2.mostrarEquipo();
Console.WriteLine("¿Jugador dos, cual va a ser su pokemon en cancha?");
string pokeIngresado2 = Console.ReadLine();
IPokemon pokeJ2 = j2.pokemonEnCancha(pokeIngresado2);


bool bandera = false;
while (bandera == false)
{
    int opcion = 0;
    for (int i = 0; i <= 1; i++)
    {
        Console.WriteLine($"\n ¿{j1.Nombre}, que desea hacer? \n 1-Ver las habilidades de su pokemon(No consume turno) \n 2-Ver la salud de su pokemon(No consume turno) \n 3-Atacar(Consume un turno) \n 4-Cambiar de pokemon(Consume un turno)");
        opcion = Convert.ToInt32(Console.ReadLine());
        if (opcion == 1)
        {
            j1.verMovimientos(pokeIngresado1);
            i--;
        }
        if (opcion == 2)
        {
            j1.verSalud(pokeIngresado1);
            i--;
        }
        if (opcion == 3)
        {
            j1.atacar(j2,pokeIngresado1,pokeIngresado2);
            combate.ChequeoVictoria(j1,j2,bandera);
            i++;
            if (bandera == true)
            {
                break;
            }
        }

        if (opcion == 4)
        {
            Console.WriteLine("¿A que pokemon desea cambiar?");
            pokeIngresado1 = Console.ReadLine();
            j1.pokemonEnCancha(pokeIngresado1);
            combate.ChequeoVictoria(j1,j2,bandera);
            if (bandera == true)
            {
                break;
            }
            i++;
        }
    }
    opcion = 0;
    for (int i = 0; i <= 1; i++)
    {
        Console.WriteLine($"\n ¿{j2.Nombre}, que desea hacer? \n 1-Ver las habilidades de su pokemon(No consume turno) \n 2-Ver la salud de su pokemon(No consume turno) \n 3-Atacar(Consume un turno) \n 4-Cambiar de pokemon(Consume un turno)");
        opcion = Convert.ToInt32(Console.ReadLine());
        if (opcion == 1)
        {
            j2.verMovimientos(pokeIngresado2);
            i--;
        }
        if (opcion == 2)
        {
            j2.verSalud(pokeIngresado2);
            i--;
        }
        if (opcion == 3)
        {
            j2.atacar(j1,pokeIngresado2,pokeIngresado1);
            combate.ChequeoVictoria(j2,j1,bandera);
            if (bandera == true)
            {
                break;
            }
        }

        if (opcion == 4)
        {
            Console.WriteLine("¿A que pokemon desea cambiar?");
            pokeIngresado2 = Console.ReadLine();
            j1.pokemonEnCancha(pokeIngresado2);
            combate.ChequeoVictoria(j2,j1,bandera);
            if (bandera == true)
            {
                break;
            }
        }
    }
}

