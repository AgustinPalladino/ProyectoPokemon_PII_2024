namespace Library;

public class Combate
{
    public void MostrarCatalogo(List<Pokemon> listaPokemon)
    {
        foreach (Pokemon pokemon in listaPokemon)
        {
            Console.WriteLine($"-{pokemon.Nombre}");
        }
    }

    public void BuclePrincipal(Jugador j1, Jugador j2)
    {
        Logica logica = new Logica();
        CreadorDePokemonYMovimiento creadorDePokemonYMovimiento = new CreadorDePokemonYMovimiento();
        MostrarCatalogo(creadorDePokemonYMovimiento.listaPokemon);
        
        for(int i = 0; i < 2; i++)
        {
            logica.EscogerEquipo(j1);
            logica.EscogerEquipo(j2);
        }
        
        j1.mostrarEquipo();
        j2.mostrarEquipo();
        bool bandera = true;
        bool banderaGlobal = true;
        while (banderaGlobal)
        {
            // Turno del jugador 1
            while (bandera)
            {
                Console.WriteLine($"\n ¿{j1.Nombre}, que desea hacer? \n 1-Ver las habilidades de su pokemon(No consume turno) \n 2-Ver la salud de su pokemon(No consume turno) \n 3-Atacar(Consume un turno) \n 4-Cambiar de pokemon(Consume un turno)");
                int opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    
                    case 1: // Opcion 1 para ver los movimientos de su pokemon
                        j1.verMovimientos();
                        break;
                    
                    case 2: // Opcion 2 para ver la salud
                        j1.verSalud();
                        break;
                    
                    case 3: // Si presiona la opcion 3 ataca y sale del bucle
                        logica.Ataque(j1, j2);
                        if (logica.ChequeoVictoria(j1, j2)) // Si gano se finaliza la bandera global y termina el programa
                        {
                            Console.WriteLine($"\n {j1.Nombre} es el ganador");
                            banderaGlobal = false;
                        }
                        bandera = false;
                        break;
                    
                    case 4: //Si presiona la opcion 4 cambia de pokemon y sale del bucle
                        logica.CambiarPokemon(j1);
                        bandera = false;
                        break;
                    
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
                if (!bandera) break;
            }
            
            // Si la bandera global esta en false, significa que el jugador 2 perdio, por lo que la bandera de su while, estara en false y no podra entrar
            if (banderaGlobal == false)
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
                Console.WriteLine($"\n ¿{j2.Nombre}, que desea hacer? \n 1-Ver las habilidades de su pokemon(No consume turno) \n 2-Ver la salud de su pokemon(No consume turno) \n 3-Atacar(Consume un turno) \n 4-Cambiar de pokemon(Consume un turno)");
                int opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    
                    case 1: // Opcion 1 para ver los movimientos de su pokemon
                        j2.verMovimientos();
                        break;
                    
                    case 2: // Opcion 2 para ver la salud
                        j2.verSalud();
                        break;
                    
                    case 3: // Si presiona la opcion 3 ataca y sale del bucle
                        logica.Ataque(j2, j1);
                        if (logica.ChequeoVictoria(j2, j1))
                        {
                            Console.WriteLine($"\n {j2.Nombre} es el ganador");
                            banderaGlobal = false;

                        }
                        bandera = false;
                        break;

                    case 4: // Si presiona la opcion 4 cambia de pokemon y sale del bucle
                        logica.CambiarPokemon(j2);
                        bandera = false;
                        break;
                    
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }
                if (!bandera) break;
            }
            
            //setea la bandera en true
            bandera = true;
            
        }
    }
}