using Library;
using Library.Pokemon;

Combate combate = new Combate();
Jugador j1 = new Jugador("Jugador 1");
Jugador j2 = new Jugador("Jugador 2");

combate.mostrarCatalogo();
combate.escogerEquipo(j1);
j1.mostrarEquipo();
combate.escogerEquipo(j2);
j2.mostrarEquipo();
