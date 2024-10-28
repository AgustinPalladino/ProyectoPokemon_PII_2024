namespace Library.Pokemon;
using Moves;

public interface IPokemon
{
    //Propiedades de la interface pokemon
    public string Nombre { get; }
    public string Tipo { get; }
    public string Estado { get; set; }
    public int Vida { get; }
    public int VidaActual { get; set; }
    public int Defensa { get; }
    public int Ataque { get; }
    List<IMovimiento> listaMovimientos { get; set; }
}