namespace Library;

public class Combate
{
    public void MostrarCatalogo(List<Pokemon> listaPokemon)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n📜 Catálogo de Pokémon disponibles:");
        Console.ResetColor();

        foreach (Pokemon pokemon in listaPokemon)
        {
            Console.WriteLine($"- {pokemon.Nombre}");
        }
    }

    public void VerMochila(Jugador jugador, CreadorDePokemonYMovimiento creadorDePokemonYMovimiento)
    {
        creadorDePokemonYMovimiento.VerMochila(jugador);
    }

    public void BuclePrincipal(Jugador j1, Jugador j2)
    {
        Logica logica = new Logica();
        CreadorDePokemonYMovimiento creadorDePokemonYMovimiento = new CreadorDePokemonYMovimiento();
        MostrarCatalogo(creadorDePokemonYMovimiento.listaPokemon);

        for (int i = 0; i < 2; i++)
        {
            logica.EscogerEquipo(j1);
            logica.EscogerEquipo(j2);
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n✅ Equipos seleccionados:");
        Console.ResetColor();
        j1.mostrarEquipo();
        j2.mostrarEquipo();

        bool bandera = true;
        bool banderaGlobal = true;

        while (banderaGlobal)
        {
            // Turno del jugador 1
            while (bandera)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n🎮 Turno de {j1.Nombre}. ¿Qué deseas hacer?");
                Console.ResetColor();

                Console.WriteLine("1️⃣ Ver las habilidades de tu Pokémon (No consume turno)");
                Console.WriteLine("2️⃣ Ver la salud de tu Pokémon (No consume turno)");
                Console.WriteLine("3️⃣ Atacar (Consume un turno)");
                Console.WriteLine("4️⃣ Cambiar de Pokémon (Consume un turno)");
                Console.WriteLine("5️⃣ Ver Mochila (No consume turno)");
                Console.WriteLine("6️⃣ Salir Del juego)");


                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        j1.verMovimientos();
                        break;
                    case 2:
                        j1.verSalud();
                        break;
                    case 3:
                        logica.Ataque(j1, j2);
                        if (logica.ChequeoVictoria(j1, j2))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\n🎉 {j1.Nombre} es el ganador!");
                            Console.ResetColor();
                            banderaGlobal = false;
                        }
                        bandera = false;
                        break;
                    case 4:
                        logica.CambiarPokemon(j1);
                        banderaGlobal = false;
                        break;
                    case 5:
                        VerMochila(j1, creadorDePokemonYMovimiento);
                        break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Environment.Exit(0);//acabo con al ejecucion de forma bruta
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("❌ Opción no válida, intenta de nuevo.");
                        Console.ResetColor();
                        break;
                }
                if (!bandera) break;
            }

            if (!banderaGlobal)
            {
                bandera = false;
            }
            else
            {
                bandera = true;
            }

            // Turno del jugador 2
            while (bandera)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n🎮 Turno de {j2.Nombre}. ¿Qué deseas hacer?");
                Console.ResetColor();

                Console.WriteLine("1️⃣ Ver las habilidades de tu Pokémon (No consume turno)");
                Console.WriteLine("2️⃣ Ver la salud de tu Pokémon (No consume turno)");
                Console.WriteLine("3️⃣ Atacar (Consume un turno)");
                Console.WriteLine("4️⃣ Cambiar de Pokémon (Consume un turno)");
                Console.WriteLine("5️⃣ Ver Mochila (No consume turno)");

                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        j2.verMovimientos();
                        break;
                    case 2:
                        j2.verSalud();
                        break;
                    case 3:
                        logica.Ataque(j2, j1);
                        if (logica.ChequeoVictoria(j2, j1))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\n🎉 {j2.Nombre} es el ganador!");
                            Console.ResetColor();
                            banderaGlobal = false;
                        }
                        bandera = false;
                        break;
                    case 4:
                        logica.CambiarPokemon(j2);
                        bandera = false;
                        break;
                    case 5:
                        VerMochila(j2, creadorDePokemonYMovimiento);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("❌ Opción no válida, intenta de nuevo.");
                        Console.ResetColor();
                        break;
                }
                if (!bandera) break;
            }

            bandera = true;
        }
    }
}

