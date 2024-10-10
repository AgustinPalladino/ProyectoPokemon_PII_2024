using Library;
using Library.Pokemon;

MostrarCatalogo mostrarCatalogo = new MostrarCatalogo();
Combate combate = new Combate();
Jugador j1 = new Jugador("Jugador 1");
Jugador j2 = new Jugador("Jugador 2");

mostrarCatalogo.crearCatalogo();
combate.logicaEscogerEquipo(j1);
j1.mostrarEquipo();
combate.logicaEscogerEquipo(j2);
j2.mostrarEquipo();

