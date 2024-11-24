using Library;
using Library.Interaccion;
using NSubstitute;

namespace TestProject;

public class HistoriaUsuario5Test
{
    private Jugador jugador1;
    private Jugador jugador2;
    private IInteraccionConUsuario mockInteraccion;
    private Logica logica;

    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void hdUsuario5Test()
    {
        mockInteraccion = Substitute.For<IInteraccionConUsuario>();
        jugador1 = new Jugador("Ash");
        jugador2 = new Jugador("Misty");
        
        // Configuración inicial
        var combate = new Combate(mockInteraccion);

        // Mockeamos un flujo de turnos
        jugador1.agregarPokemon(new Pokemon("Pikachu", "Eléctrico", 100, 50, 40));
        jugador2.agregarPokemon(new Pokemon("Charizard", "Fuego", 100, 60, 50));

        // Simula el bucle principal de turnos
        combate.BuclePrincipal(jugador1, jugador2);

        // Verifica que el mensaje de turno para el jugador 1 aparece

        if (combate.numActual==1)
        {
            Assert.That(combate.JugadorActual==jugador1);
        }
        if (combate.numActual==2)
        {
            Assert.That(combate.JugadorActual==jugador2);
        }
        
        
        
            mockInteraccion.Received(1).ImprimirMensaje($"\nTurno de {jugador2.Nombre}. ¿Qué deseas hacer? Seleccione un numero porfavor.");    
            mockInteraccion.LeerEntrada().Returns("1");
        
        

        // Verifica que el mensaje de turno para el jugador 2 aparece después
        
    }

    
}