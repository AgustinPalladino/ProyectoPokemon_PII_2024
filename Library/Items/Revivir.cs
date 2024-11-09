using System;

namespace Library;

/// <summary>
/// Esta clase como las demas, estaran heredando mi interfaz de Iitems, con su metodo con diferente funcionalidad
/// </summary>
public class Revivir : IItem
{
    private string nombre;

    public string Nombre
    {
        get { return this.nombre = "Revivir"; }
    }

    public void Usar(Jugador j)
    {
        bool bandera = true;
        while (bandera)
        {
            Console.WriteLine("¿A cual pokemon desea usar el revivir?");

            // Muestra los nombres de los pokemon derrotados
            for (int i = 0; i < j.equipoPokemonDerrotados.Count; i++)
            {
                Console.WriteLine($"-{j.equipoPokemonDerrotados[i].Nombre}");
            }
            string pokeIngresado = Console.ReadLine();
            
            for (int i = 0; i < j.equipoPokemonDerrotados.Count; i++)
            {
                if (pokeIngresado == j.equipoPokemonDerrotados[i].Nombre)
                {
                    if (j.equipoPokemonDerrotados[i].VidaActual <= 0)
                    {
                        j.equipoPokemonDerrotados[i].VidaActual = j.equipoPokemonDerrotados[i].VidaMax / 2; // Revive con el 50% de su vida máxima
                        j.equipoPokemonDerrotados[i].Estado = "Normal";
                        Console.WriteLine($"{j.equipoPokemonDerrotados[i].Nombre} ha sido revivido con {j.equipoPokemonDerrotados[i].VidaActual} puntos de vida.");
                        j.equipoPokemon.Add(j.equipoPokemonDerrotados[i]);
                        bandera = false;
                    }
                }
            }

            if (bandera)
            {
                Console.WriteLine("Pokemon incorrecto, seleccione de nuevo");
            }
        }
    }
}
