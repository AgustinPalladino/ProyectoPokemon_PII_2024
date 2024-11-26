using NSubstitute;
using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot.Domain.Tests;

public class HistoriaUsuario11Test
{
    [TearDown]
    public void TearDown()
    {
        Facade.Reset();
    }

    [Test]
    public void hdUsuario11Test1()
    {
        Facade.Instance.AddTrainerToWaitingList("opponent");
        
        string result = Facade.Instance.StartBattle("user", "opponent");
        
        Assert.That(result, Is.EqualTo("Comienza user vs opponent"));
    }
    
    
}