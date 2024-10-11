namespace Library.Moves;

//Se crea clase Arañazo con interface IMovimiento
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