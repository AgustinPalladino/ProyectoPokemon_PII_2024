namespace Library.Pokemon;
using Moves;

public class Charizard:IPokemon
{
    private bool _estaActivo;
    private int vida = 78;
    private int ataque = 109;
    private int defensa = 85;

    public string Name
    {
        get { return "Charizard"; }
    }

    public string Tipo
    {
        get { return "Fuego"; }
    }

    public int Vida
    {
        get { return this.vida; }
        set { this.vida = value; }
    }

    public int Ataque
    {
        get { return this.ataque; }
        set { this.ataque = value; }
    }
    
    public int Defensa
    {
        get { return this.defensa; }
        set { this.defensa = value; }
    }

    bool IPokemon.EstaActivo
    {
        get => _estaActivo;
        set => _estaActivo = value;
    }

    public void sumarAtaque()
    {
        this.Ataque += 30;
    }

    public void mostrarAtaque()
    {
        Console.Write(this.Ataque + "\n");
    }
}