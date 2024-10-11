namespace Library.Moves;

public class Hidrocañon:IMovimiento
{
    public string Nombre
    {
        get { return "Hidrocañon"; }
    }

    public int Ataque
    {
        get { return 20; }
    }

    public string Tipo
    {
        get { return "Agua"; }
    }
}