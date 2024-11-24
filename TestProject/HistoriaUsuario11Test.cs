using Library;
using Library.Interaccion;
using NSubstitute;

namespace TestProject;

public class HistoriaUsuario11Test
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
    public void hdUsuario11Test()
    {
        mockInteraccion = Substitute.For<IInteraccionConUsuario>();
        jugador1 = new Jugador("Ash");
        jugador2 = new Jugador("Misty");
        logica = new Logica(mockInteraccion);
        
        // Simula una lista de espera
        var listaDeEspera = new List<string> { "Ash", "Misty" };

        // Método para iniciar una batalla
        string IniciarBatalla(List<string> listaDeEspera)
        {
            if (listaDeEspera.Count >= 2)
            {
                string jugador1 = listaDeEspera[0];
                string jugador2 = listaDeEspera[1];
                listaDeEspera.RemoveRange(0, 2);

                // Notifica a los jugadores
                mockInteraccion.ImprimirMensaje($"Jugador {jugador1} y {jugador2} han iniciado una batalla.");
            
                // Determina el primer turno aleatoriamente
                string primerTurno = DiccionariosYOperacionesStatic.numeroAleatorio(1, 2) == 1 ? jugador1 : jugador2;
                mockInteraccion.ImprimirMensaje($"El jugador {primerTurno} comenzará primero.");
            
                return primerTurno;
            }
            else
            {
                mockInteraccion.ImprimirMensaje("No hay suficientes jugadores en la lista de espera.");
                return null;
            }
        }

        // Llama al método para iniciar la batalla
        string turnoInicial = IniciarBatalla(listaDeEspera);

        // Verifica que ambos jugadores fueron notificados
        mockInteraccion.Received(1).ImprimirMensaje("Jugador Ash y Misty han iniciado una batalla.");

        // Verifica que se asignó un turno inicial y que se notificó correctamente
        Assert.IsNotNull(turnoInicial);
        mockInteraccion.Received(1).ImprimirMensaje(Arg.Is<string>(s => s.Contains($"El jugador {turnoInicial} comenzará primero.")));

        // Verifica que los jugadores fueron removidos de la lista de espera
        Assert.IsFalse(listaDeEspera.Contains("Ash"));
        Assert.IsFalse(listaDeEspera.Contains("Misty"));
    }

    
}