namespace Library.Pokemon;
using Moves;

public class Charizard:IPokemon
{
    public List<IMovimiento> listaMovimientos { get; set; }  = new List<IMovimiento>();
    private int vida = 100;

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

    public int Vida
    {
        get { return this.vida; }
        set { this.vida = value; }
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