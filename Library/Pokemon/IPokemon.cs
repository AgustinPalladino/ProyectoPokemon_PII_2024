namespace Library.Pokemon;
using Moves;

public interface IPokemon
{
    public string Name { get; }
    public string Tipo { get; }
    public int Vida { get; }
    public int Defensa { get; }
    public int Ataque { get; }
    bool EstaActivo { get; set; }
}