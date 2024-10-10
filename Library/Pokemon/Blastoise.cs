namespace Library.Pokemon;

public class Blastoise:IPokemon
{
    private bool _estaActivo;
    private int vida = 79;
    private int ataque = 85;
    private int defensa = 105;

    public string Name
    {
        get { return "Blastoise"; }
    }

    public string Tipo
    {
        get { return "Agua"; }
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
}