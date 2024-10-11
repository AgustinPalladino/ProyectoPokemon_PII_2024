using Library;
using Library.Pokemon;

Combate combate = new Combate();
Jugador j1 = new Jugador("Jugador 1");
Jugador j2 = new Jugador("Jugador 2");

combate.mostrarCatalogo();
combate.logicaEscogerEquipo(j1);
combate.logicaEscogerEquipo(j2);

j1.mostrarEquipo();
Console.WriteLine("¿Jugador uno, cual va a ser su pokemon en cancha?");
string pokeIngresado1 = Console.ReadLine();
IPokemon hola = j1.pokemonEnCancha(pokeIngresado1);

j2.mostrarEquipo();
Console.WriteLine("¿Jugador dos, cual va a ser su pokemon en cancha?");
string pokeIngresado2 = Console.ReadLine();
IPokemon hola2 = j2.pokemonEnCancha(pokeIngresado2);

Console.WriteLine(hola.Nombre);
Console.WriteLine(hola2.Nombre);

