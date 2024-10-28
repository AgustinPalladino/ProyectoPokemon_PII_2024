namespace Library.Moves;

//Se crea clase Arañazo con interface IMovimiento
public class Arañazo:IMovimiento
{
    public string Nombre
    {
        get { return "Arañazo"; } // Retorna el nombre
    }

    public int Ataque
    {
        get { return 5; } // Retorna valor de ataque
    }

    public string Tipo
    {
        get { return "Fuego"; } // Tipo Fuego
    }
}