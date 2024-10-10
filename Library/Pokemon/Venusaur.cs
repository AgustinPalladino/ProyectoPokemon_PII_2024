namespace Library.Pokemon;

public class Venusaur:IPokemon
{
    private string name = "Venusaur";
    private string tipo = "Planta";
    private int vida = 100;
    private int defensa = 50;
    private int ataque = 85;

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