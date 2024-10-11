using Library.Moves;

namespace Library.Pokemon;

public class Venusaur:IPokemon
{
    public List<IMovimiento> listaMovimientos { get; set; }  = new List<IMovimiento>();
    private int vida = 100;

    public Venusaur()
    {
        listaMovimientos.Add(new Lluevehojas());
    }
    
    public string Nombre
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
        get { return 100; }
    }
    
    public int Defensa
    {
        get { return 100; }
    }
}