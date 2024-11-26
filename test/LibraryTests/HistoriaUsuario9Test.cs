using NSubstitute;
using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot.Domain.Tests;

public class HistoriaUsuario9Test
{
    [TearDown]
    public void TearDown()
    {
        Facade.Reset();
    }
    
    [Test]
    public void hdUsuario9Test1()
    {
        string result = Facade.Instance.AddTrainerToWaitingList("user");
        
        Assert.That(result, Is.EqualTo("user agregado a la lista de espera"));
    }
    
}