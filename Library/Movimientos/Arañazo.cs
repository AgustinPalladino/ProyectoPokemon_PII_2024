namespace Library.Moves;

public class Arañazo:IMovimiento
{
    public string Nombre
    {
        get { return "Arañazo"; }
    }

    public int Ataque
    {
        get { return 45; }
    }

    public string Tipo
    {
        get { return "Fuego"; }
    }
}