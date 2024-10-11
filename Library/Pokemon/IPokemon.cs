namespace Library.Pokemon;
using Moves;

public interface IPokemon
{
    public string Nombre { get; }
    public string Tipo { get; }
    public int Vida { get; set; }
    public int Defensa { get; }
    public int Ataque { get; set; }
    List<IMovimiento> listaMovimientos { get; set; }
    public void verMovimientos();
}