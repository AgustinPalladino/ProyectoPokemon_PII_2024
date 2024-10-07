namespace Library.Moves;
using Pokemon;
using Tipos;

public class Ember:IMoves,IFuego
{
    private string tipo = "Fuego";

    public string Tipo
    {
        get { return this.tipo; }
        set { this.tipo = value; }
    }
}