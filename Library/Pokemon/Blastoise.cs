using Library.Moves;

namespace Library.Pokemon;

public class Blastoise:IPokemon
{
    public List<IMovimiento> listaMovimientos { get; set; }  = new List<IMovimiento>();
    private int vida = 79;
    private int ataque = 85;
    private int defensa = 105;

    public string Nombre
    {
        get { return "Blastoise"; }
    }

    public string Tipo
    {
        get { return "Agua"; }
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
        listaMovimientos.Add(new Hidrocañon());
        foreach (IMovimiento movimiento in this.listaMovimientos)
        {
            Console.WriteLine(i + "-" + movimiento.Nombre);
            i++;
        }
    }
}