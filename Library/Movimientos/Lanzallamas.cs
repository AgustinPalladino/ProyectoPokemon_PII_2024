namespace Library.Moves;

public class Lanzallamas:IMovimiento
{
    public string Nombre
    {
        get { return "Lanzallamas"; }
    }

    public int Ataque
    {
        get { return 100; }
    }

    public string Tipo
    {
        get { return "Fuego"; }
    }
}