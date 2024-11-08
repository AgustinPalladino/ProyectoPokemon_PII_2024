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

    public void buclePrincipal(Jugador j1, Jugador j2)
    {
        Logica logica = new Logica();
        CreadorDePokemonYMovimiento creadorDePokemonYMovimiento = new CreadorDePokemonYMovimiento();
        mostrarCatalogo(creadorDePokemonYMovimiento.listaPokemon);
        for(int i = 0; i < 2; i++)
        {
            logica.EscogerEquipo(j1);
            logica.EscogerEquipo(j2);
        }
        j1.mostrarEquipo();
        j2.mostrarEquipo();
        bool bandera = true;
        while (bandera)
        {
            int opcion = 0;
            //turno jugador 1
            while ((opcion != 3 && bandera == true) || (opcion != 4 && bandera == true))
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
                    logica.Ataque(j1, j2);
                    if (bandera == logica.chequeoVictoria(j2))
                    {
                        bandera = false;
                    }
                    break;
                }
                if (opcion == 4)
                {
                    logica.CambiarPokemon(j1);
                    break;
                }
            }

            //turno jugador 2
            while ((opcion != 3 && bandera == true) || (opcion != 4 && bandera == true))
            {
                Console.WriteLine($"\n ¿{j2.Nombre}, que desea hacer? \n 1-Ver las habilidades de su pokemon(No consume turno) \n 2-Ver la salud de su pokemon(No consume turno) \n 3-Atacar(Consume un turno) \n 4-Cambiar de pokemon(Consume un turno)");
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
                    logica.Ataque(j2, j1);
                    if (bandera == logica.chequeoVictoria(j1))
                    {
                        bandera = false;
                    }

                    break;
                }
                if (opcion == 4)
                {
                    logica.CambiarPokemon(j2);
                    break;
                }
            }
        }
    }
}