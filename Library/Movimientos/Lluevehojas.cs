namespace Library.Moves;

public class Lluevehojas:IMovimiento
{
    public string Nombre
    {
        get { return "Lluevehojas"; }
    }

    public int Ataque
    {
        get { return 110; }
    }
    
    public string Tipo
    {
        get { return "Planta"; }
    }
}