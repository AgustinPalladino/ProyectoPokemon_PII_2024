using Library.Moves;

namespace Library.Pokemon;

public class Venusaur:IPokemon
{
    public List<IMovimiento> listaMovimientos { get; set; }  = new List<IMovimiento>();
    private int vida = 150;

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

    public string Estado
    {
        get { return "Neutral"; }
        set { this.Estado = value; }
    }
    
    public int Vida
    {
        get { return this.vida; }
    }

    public int VidaActual
    {
        get { return this.VidaActual = Vida; }
        set { this.VidaActual = value; }
    }
    
    public int Ataque
    {
        get { return 45; }
    }
    
    public int Defensa
    {
        get { return 45; }
    }
}