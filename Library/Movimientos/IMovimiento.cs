namespace Library.Moves;

public interface IMovimiento
{
    //Propiedades de la interface:
    string Nombre { get; }
    int Ataque { get; }
    string Tipo { get; }    
}