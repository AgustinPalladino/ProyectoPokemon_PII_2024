namespace Library
{
    /// <summary>
    /// Clase base abstracta para representar un ítem. Sigue el principio de inversión de dependencias (DIP)
    /// porque las dependencias estarán en la clase base, no en implementaciones concretas.
    /// </summary>
    public abstract class Item
    {
        // Propiedad abstracta 
        public abstract string Nombre { get; }

        // Constructor protegido
        protected Item() { }

        // Método abstracto que obliga a las subclases a definir cómo usar el ítem
        public abstract void Usar(Jugador j);
    }
}
