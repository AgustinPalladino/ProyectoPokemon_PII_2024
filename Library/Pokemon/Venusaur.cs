namespace Library.Pokemon;

public class Venusaur:IPokemon
{
    private bool _estaActivo;
    private int vida = 80;
    private int ataque = 100;
    private int defensa = 100;

    public string Name
    {
        get { return "Venusaur"; }
    }

    public string Tipo
    {
        get { return "Planta"; }
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