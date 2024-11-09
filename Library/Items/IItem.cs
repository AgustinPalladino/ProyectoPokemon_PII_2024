namespace Library;

/// <summary>
/// Estoy utilizando DIP porque mis items principales dependen de la interfaz IItem, no de implementaciones concretas
/// </summary>
public interface IItem
{
    public string Nombre { get; }
    void Usar(Jugador j);
}