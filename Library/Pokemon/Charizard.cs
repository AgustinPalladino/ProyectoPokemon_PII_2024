namespace Library.Pokemon;
using Moves;

public class Charizard:IPokemon
{
    public List<IMovimiento> listaMovimientos { get; set; }  = new List<IMovimiento>();
    private int vida = 78;
    private int ataque = 30;
    private int defensa = 85;

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
        listaMovimientos.Add(new Arañazo());
        listaMovimientos.Add(new Lanzallamas());
        foreach (IMovimiento movimiento in this.listaMovimientos)
        {
            Console.WriteLine(i + "-" + movimiento.Nombre);
            i++;
        }
    }
    public void sumarAtaque()
    {
        this.Ataque += 30;
    }

    public void mostrarAtaque()
    {
        Console.Write(this.Ataque + "\n");
    }
}