using Library.Interaccion;

namespace Library;

/// <summary>
/// Esta clase como las demas, estaran heredando mi interfaz de Iitems, con su metodo con diferente funcionalidad
/// </summary>
public class Revivir : Item
{
    public override string Nombre => "Revivir";

    public override void Usar(Jugador j, IInteraccionConUsuario interaccion)
    {
        bool bandera = true;
        while (bandera)
        {
            if (j.equipoPokemonDerrotados.Count() == 0)
            {
                interaccion.ImprimirMensaje("No tiene ningun pokemon derrotado");
                bandera = false;
            }
            else
            {
                interaccion.ImprimirMensaje("¿A cual pokemon desea usar el revivir?");

                // Muestra los nombres de los pokemon derrotados
                for (int i = 0; i < j.equipoPokemonDerrotados.Count; i++)
                {
                    interaccion.ImprimirMensaje($"-{j.equipoPokemonDerrotados[i].Nombre}");
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
                            interaccion.ImprimirMensaje($"{j.equipoPokemonDerrotados[i].Nombre} ha sido revivido con {j.equipoPokemonDerrotados[i].VidaActual} puntos de vida.");
                            j.equipoPokemon.Add(j.equipoPokemonDerrotados[i]);
                            j.equipoPokemonDerrotados.Remove(j.equipoPokemonDerrotados[i]);
                            bandera = false;
                        }
                    }
                }

                if (bandera)
                {
                    interaccion.ImprimirMensaje("Pokemon incorrecto, seleccione de nuevo");
                }
            }
        }
    }
}
