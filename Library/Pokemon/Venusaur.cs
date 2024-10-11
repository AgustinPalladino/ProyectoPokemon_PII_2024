using Library.Moves;

namespace Library.Pokemon;

public class Venusaur:IPokemon
{
    public List<IMovimiento> listaMovimientos { get; set; }  = new List<IMovimiento>();
    private int vida = 80;
    private int ataque = 100;
    private int defensa = 100;

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
        get { return this.ataque; }
        set { this.ataque = value; }
    }
    
    public int Defensa
    {
        get { return this.defensa; }
        set { this.defensa = value; }
    }
    public void verMovimientos()
    {
        int i = 1;
        listaMovimientos.Add(new Lluevehojas());
        foreach (IMovimiento movimiento in this.listaMovimientos)
        {
            Console.WriteLine(i + "-" + movimiento.Nombre);
            i++;
        }
    }
}