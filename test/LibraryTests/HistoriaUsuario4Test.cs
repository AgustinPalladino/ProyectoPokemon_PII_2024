using NSubstitute;
using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot.Domain.Tests;

public class HistoriaUsuario4Test
{
    private Jugador jugador1;
    private Jugador jugador2;
    private IInteraccionConUsuario mockInteraccion;
    private Logica logica;
    
    [Test]
    public void hdUsuario4Test()
    {
        mockInteraccion = Substitute.For<IInteraccionConUsuario>();
        jugador1 = new Jugador("Ash");
        jugador2 = new Jugador("Misty");
        
        // Configuración de los Pokémons
        var pokemonJugador = new Pokemon("Pikachu", "Eléctrico", 100, 50, 40);
        var pokemonOponente = new Pokemon("Blastoise", "Agua", 120, 40, 50);
        jugador1.agregarPokemon(pokemonJugador);
        jugador2.agregarPokemon(pokemonOponente);

        // Configuración del ataque
        var ataque = new Movimiento("Rayo", 20, 100, "Eléctrico", false);

        // Simula el ataque
        jugador1.atacar(jugador2, ataque, mockInteraccion);

        // Verifica que el mensaje de "muy eficaz" se muestra (Eléctrico > Agua)
        mockInteraccion.Received(1).ImprimirMensaje("Es muy eficaz");

        // Verifica que la vida del Pokémon oponente se actualizó correctamente
        double ataqueFinal = DiccionariosYOperacionesStatic.Precision(ataque.Precision, ataque.Ataque, mockInteraccion);
        double bonificacionTipo = DiccionariosYOperacionesStatic.bonificacionTipos(ataque.Tipo, pokemonOponente.Tipo, mockInteraccion);
        double critico = DiccionariosYOperacionesStatic.CalcularCritico(ataque.Precision, mockInteraccion);
        double dañoEsperado = (pokemonJugador.Ataque) * ataqueFinal * ataque.Ataque / pokemonOponente.Defensa;
        dañoEsperado *= bonificacionTipo * critico; // Aplicamos bonificación por tipo y crítico
        Assert.That(pokemonOponente.VidaMax - (int)dañoEsperado, Is.EqualTo(jugador2.pokemonEnCancha().VidaActual));
    }
}