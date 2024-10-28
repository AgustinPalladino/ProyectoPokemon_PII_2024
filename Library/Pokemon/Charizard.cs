namespace Library.Pokemon;
using Moves;

public class Charizard:IPokemon
{
    public List<IMovimiento> listaMovimientos { get; set; }  = new List<IMovimiento>();
    private int vida = 140;

    public Charizard()
    {
        listaMovimientos.Add(new Arañazo());
        listaMovimientos.Add(new Lanzallamas());
    }
    
    public string Nombre  
    {
        get { return "Charizard"; }
    }

    public string Tipo
    {
        get { return "Fuego"; }
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
        get { return 70; }
    }
    
    public int Defensa
    {
        get { return 50; }
    }
}