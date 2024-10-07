namespace Library.Pokemon;

public class Jolteon:IPokemon
{
    private string name = "Jolteon";
    private string tipo = "Electrico";
    private int vida = 80;
    private int defensa = 40;
    private int ataque = 110;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }
    public string Tipo
    {
        get { return this.tipo; }
        set { this.tipo = value; }
    }
    
    public int Vida
    {
        get { return this.vida; }
        set { this.vida = value; }
    }

    public int Defensa
    {
        get { return this.defensa; }
        set { this.defensa = value; }
    }

    public int Ataque
    {
        get { return this.ataque; }
        set { this.ataque = value; }
    }
}