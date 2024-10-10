namespace Library.Moves;

public interface IMovimiento
{
    string Nombre { get; }
    int Ataque { get; }
    string Tipo { get; }    
}