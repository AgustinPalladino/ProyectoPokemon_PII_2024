namespace Library.Pokemon;

public class Blastoise:IPokemon
{
    private string name = "Blastoise";
    private string tipo = "Agua";
    private int vida = 120;
    private int defensa = 70;
    private int ataque = 40;

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