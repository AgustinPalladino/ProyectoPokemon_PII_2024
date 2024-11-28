[Test]
public void TestCalcularPuntaje()
{
    var jugador = new Jugador("Jugador1");

    
    jugador.equipoPokemon.AddRange(new List<Pokemon>
    {
        new Pokemon("Charizard", "Fuego", 100, 60, 40),
        new Pokemon("Blastoise", "Agua", 110, 50, 50),
        new Pokemon("Venusaur", "Planta", 120, 40, 60),
        new Pokemon("Pikachu", "Eléctrico", 80, 55, 40),
        new Pokemon("Pidgeot", "Volador", 85, 70, 50),
        new Pokemon("Butterfree", "Bicho", 60, 50, 40)
    });
    jugador.Mochila.AddRange(new List<Item>
    {
        new SuperPocion(), new CuraTotal(), new Revivir(), new SuperPocion(),
        new SuperPocion(), new SuperPocion(), new SuperPocion(), new SuperPocion(),
        new CuraTotal(), new CuraTotal()
    });

    var logica = new Logica(new InteraccionPorConsola());
    double puntaje = logica.CalcularPuntaje(jugador);

    Assert.That(puntaje, Is.EqualTo(90)); 
}
   
