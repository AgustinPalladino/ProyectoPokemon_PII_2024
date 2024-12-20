﻿using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot.Items;

/// <summary>
/// Clase base abstracta para representar un ítem. Sigue el principio de inversión de dependencias (DIP)
/// Porque no queremos que los modulos de alto nivel dependan de bajo nivel, sino de abstracciones
/// </summary>
public abstract class Item
{
    // Propiedad abstracta 
    public abstract string Nombre { get; }
    
    public abstract string Descripcion { get; }

    // Método abstracto que obliga a las subclases a definir cómo usar el ítem
    public abstract string Usar(Jugador j, string pokeIngresado);
}