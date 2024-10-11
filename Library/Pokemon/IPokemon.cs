namespace Library.Pokemon;
using Moves;

public interface IPokemon
{
    public string Nombre { get; }
    public string Tipo { get; }
    public int Vida { get; }
    public int Defensa { get; }
    public int Ataque { get; }
    List<IMovimiento> listaMovimientos { get; set; }
    public void verMovimientos();
}