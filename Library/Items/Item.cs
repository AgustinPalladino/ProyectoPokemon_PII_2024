namespace Library.Items;

public abstract class Item
{
    public string Name { get; }
    
    public Item()
    {
        
    }
    
    public abstract void funcionItem(Jugador jugador);
}