using NSubstitute;
using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot.Domain.Tests;

public class HistoriaUsuario2Test
{
    private Jugador jugador1;
    private Jugador jugador2;
    private IInteraccionConUsuario mockInteraccion;
    private Logica logica;

    [Test]
    public void hdUsuario2Test()
    {
        mockInteraccion = Substitute.For<IInteraccionConUsuario>();
        jugador1 = new Jugador("Ash");
        jugador2 = new Jugador("Misty");

        // Configura el Pokémon inicial del jugador.
        var pokemon = new Pokemon("Charizard", "Fuego", 100, 50, 40);
        pokemon.AgregarMovimientos(new List<Movimiento>
        {
            new Movimiento("Lanzallamas", 20, 80, "Fuego", false),
            new Movimiento("Cola Dragón", 15, 90, "Dragón", false)
        });
        jugador1.agregarPokemon(pokemon);

        // Muestra los ataques.
        jugador1.verMovimientos(mockInteraccion);

        // Verifica que los mensajes correspondientes fueron enviados.
        mockInteraccion.Received(1).ImprimirMensaje("-Lanzallamas");
        mockInteraccion.Received(1).ImprimirMensaje("-Cola Dragón");
    }
}