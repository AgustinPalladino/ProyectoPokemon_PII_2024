namespace Library;

/// <summary>
/// Estoy utilizando DIP porque mis items principales dependen de la interfaz IItem, no de implementaciones concretas
/// </summary>
public interface IItem
{
    void Usar(Jugador j);
}