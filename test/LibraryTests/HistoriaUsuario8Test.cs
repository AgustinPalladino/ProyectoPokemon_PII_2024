using NSubstitute;
using Ucu.Poo.DiscordBot.Interaccion;
using Ucu.Poo.DiscordBot.Items;

namespace Ucu.Poo.DiscordBot.Domain.Tests;

public class HistoriaUsuario8Test
{
    private Jugador jugador1;
    private Jugador jugador2;
    private IInteraccionConUsuario mockInteraccion;
    private Logica logica;
    
    
    [Test]
    public void hdUsuario8Test()
    {
        mockInteraccion = Substitute.For<IInteraccionConUsuario>();
        jugador1 = new Jugador("Ash");
        jugador2 = new Jugador("Misty");
        
        // Configuración del jugador y su Pokémon
        var pokemon = new Pokemon("Pikachu", "Eléctrico", 100, 50, 40);
        jugador1.agregarPokemon(pokemon);
        jugador1.pokemonEnCancha().VidaActual = 50;
        // Agregar un ítem de curación a la mochila del jugador
        var pocion = new SuperPocion();
        jugador1.Mochila.Add(pocion);
        int mochilaInicial = jugador1.Mochila.Count;
        
        // Mock de la interacción para seleccionar el ítem
        mockInteraccion.LeerEntrada().Returns("SuperPocion");
        
        // Simula el uso de la mochila
        var logica = new Logica(mockInteraccion);
        logica.Mochila(jugador1);

        // Verifica que el ítem fue utilizado y su efecto aplicado
        //Assert.That(pokemon.VidaActual, Is.EqualTo(100) ); // La vida debería estar completamente curada
        Assert.That(jugador1.Mochila.Count, Is.LessThan(mochilaInicial)); // El ítem debe haberse removido
        

        // Verifica que se muestra el mensaje de curación
        mockInteraccion.Received(1).ImprimirMensaje($"{pokemon.Nombre} se ha restaurado 70 puntos de vida.");
    }
}