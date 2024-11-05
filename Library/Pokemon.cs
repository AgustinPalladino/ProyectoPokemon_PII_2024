using Library.Moves;

namespace Library;

public class Pokemon
{
    private string nombre;
    private string tipo;
    private int vidaMax;
    private int vidaActual;
    private int ataque;
    private int defensa;
    private string estado = "Neutral";
    public List<IMovimiento> listaMovimientos { get; set; }  = new List<IMovimiento>();

    public Pokemon(string nombre, string tipo, int vidaMax, int ataque, int defensa)
    {
        this.nombre = nombre;
        this.tipo = tipo;
        this.vidaMax = vidaMax;
        this.ataque = ataque;
        this.defensa = defensa;
        this.vidaActual = vidaMax;
    }
    
    public string Nombre
    {
        get { return this.nombre; }
        set { this.nombre = value; }
    }

    public string Tipo
    {
        get { return this.tipo; }
        set { this.tipo = value; }
    }

    public int VidaMax
    {
        get { return this.vidaMax; }
        set { this.vidaMax = value; }
    }

    public int VidaActual
    {
        get { return this.vidaActual; }
        set { this.vidaActual = value; }
    }

    public int Ataque
    {
        get { return this.ataque; }
        set { this.Ataque = value; }
    }
    
    public int Defensa
    {
        get { return this.defensa; }
        set { this.defensa = value; }
    }

    public string Estado
    {
        get { return this.estado; }
        set { this.estado = value; }
    }

    public void agregarMovimiento(Movimiento movimiento)
    {
        listaMovimientos.Add(movimiento);
    }
}