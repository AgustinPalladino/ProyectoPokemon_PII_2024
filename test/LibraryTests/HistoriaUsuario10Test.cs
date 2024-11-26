using NSubstitute;
using Ucu.Poo.DiscordBot.Interaccion;

namespace Ucu.Poo.DiscordBot.Domain.Tests;

public class HistoriaUsuario10Test
{
    [TearDown]
    public void TearDown()
    {
        Facade.Reset();
    }
     

    [Test]
    public void hdUsuario10Test1()
    {
        string result = Facade.Instance.GetAllTrainersWaiting();
        
        Assert.That(result, Is.EqualTo("No hay nadie esperando"));
    }
    
    [Test]
    public void hdUsuario10Test2()
    {
        Facade.Instance.AddTrainerToWaitingList("user");
        
        string result = Facade.Instance.GetAllTrainersWaiting();
        
        Assert.That(result, Does.Contain("user"));
    }

}
