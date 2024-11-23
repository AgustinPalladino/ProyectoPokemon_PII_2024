using Library;
using Library.Interaccion;

Combate combate = new Combate(new InteraccionPorConsola());
Jugador j1 = new Jugador("Jugador 1");
Jugador j2 = new Jugador("Jugador 2");
combate.BuclePrincipal(j1,j2);