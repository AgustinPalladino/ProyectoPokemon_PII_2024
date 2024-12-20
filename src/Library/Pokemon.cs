﻿using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot;

/// <summary>
/// Se crea la clase "Pokemon" encargada de representar a un Pokémon con sus atributos básicos,
/// habilidades y comportamientos en el juego.
/// </summary>
public class Pokemon
{
    private string nombre;
    private string tipo;
    private int vidaMax;
    private int vidaActual;
    private int ataque;
    private int defensa;
    private string estado = "Normal";
    private double porcentajeDañoPorTurno;
    private int turnosDormido;
    public List<Movimiento> listaMovimientos { get; set; }  = new();

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
    }

    public string Tipo
    {
        get { return this.tipo; }
    }

    public int VidaMax
    {
        get { return this.vidaMax; }
    }

    public int VidaActual
    {
        get { return this.vidaActual; }
        set { this.vidaActual = value; }
    }

    public int Ataque
    {
        get { return this.ataque; }
    }
    
    public int Defensa
    {
        get { return this.defensa; }
    }

    public string Estado
    {
        get { return this.estado; }
        set { this.estado = value; }
    }
    
    public int TurnosDormido
    {
        get { return this.turnosDormido; }
        set { this.turnosDormido = value; }
    }

    
    public Pokemon Clonar()
    {
        return new Pokemon(this.Nombre, this.Tipo, this.VidaMax, this.Ataque, this.Defensa)
        {
            listaMovimientos = this.listaMovimientos.Select(m => m.Clonar()).ToList(),
            Estado = this.Estado
        };
    }
    
    
    public double PorcentajeDañoPorTurno
    {
        get { return this.porcentajeDañoPorTurno; }
        set { this.porcentajeDañoPorTurno = value; }
    }

    public Pokemon AgregarMovimientos(List<Movimiento> movimiento)
    {
        listaMovimientos.AddRange(movimiento);
        return this;
    }

    public void aplicarDañoRecurrente(IInteraccionConUsuario interaccion)
    {
        if (Estado == "Envenenado" || Estado == "Quemado")
        {
            int danio = (int)(VidaMax * PorcentajeDañoPorTurno);
            VidaActual -= danio;
            interaccion.ImprimirMensaje($"{Nombre} sufre {danio} puntos de daño por estar {Estado}. Vida restante: {VidaActual}");
        }
    }
    public bool puedeAtacar(IInteraccionConUsuario interaccion)
    {
        if (Estado == "Dormido")
        {
            if (TurnosDormido>0)
            {
                TurnosDormido--;
                interaccion.ImprimirMensaje($"{Nombre} está dormido y no puede atacar. Turnos restantes dormido: {TurnosDormido}");
                return false;
            }
            else
            {
                Estado = "Normal";
                interaccion.ImprimirMensaje($"{Nombre} ha despertado.");
            }
        }
        else if (Estado == "Paralizado")
        {
            bool puedeAtacar = new Random().Next(1) == 0; // 100% de probabilidades
            if (!puedeAtacar)
            {
                interaccion.ImprimirMensaje($"{Nombre} está paralizado y no puede atacar.");
            }
            return puedeAtacar;
        }
        return true;
    }
}