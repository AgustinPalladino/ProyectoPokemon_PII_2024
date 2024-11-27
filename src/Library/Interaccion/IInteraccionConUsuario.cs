namespace Ucu.Poo.DiscordBot.Interaccion;
/// <summary>
/// Una interfaz que recibe interacciones segun con que programa va a interactuar, usamos el principio dip de solid,
/// Que las clases de alto nivel no dependan de bajo nivel, sino de abstracciones
/// </summary>
public interface IInteraccionConUsuario
{
    public void ImprimirMensaje(string mensaje);

    public string LeerEntrada();
}