using Library.Moves;

namespace Library.Pokemon;

public class Blastoise:IPokemon
{
    public List<IMovimiento> listaMovimientos { get; set; }  = new List<IMovimiento>();
    private int vida = 145;

    public Blastoise()
    {
        listaMovimientos.Add(new Hidrocañon());
    }
    
    public string Nombre
    {
        get { return "Blastoise"; }
    }

    public string Tipo
    {
        get { return "Agua"; }
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
        get { return 50; }

    }
    
    public int Defensa
    {
        get { return 60; }
    }
}