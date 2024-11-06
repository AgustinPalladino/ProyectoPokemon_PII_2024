using System
using System.Formats.Asn1;
using System.Reflection.Metadata;
using Library.Pokemon;

namespace Library;

public class Revivir : Item
{
    
    public override void Usar(Jugador j)
    {
        if (pokemon.vidaActual>0){
             pokemon.Estado = "Normal";
            pokemon.PorcentajeDañoPorTurno = 0;
            pokemon.TurnosDormido = 0;
            console.WriteLine("El pokemon se ha curado de todos sus estados")
        }
        else {
            console.WriteLine("El Pokemon no tiene puntos de salud")
        }
    }
}