using Library;

class Program
{
    static void Main(string[] args)
    {
        // Ruta correcta a los archivos
        string rutaPokemon = @"../Pokemones.txt";
        string rutaMovimientos = @"../Movimientos.txt";

        // Cargar los archivos de Pokémon y movimientos
        DiccionariosYOperacionesStatic.CargarPokemonDesdeArchivo(rutaPokemon);
        DiccionariosYOperacionesStatic.CargarMovimientosDesdeArchivo(rutaMovimientos);

        // Crear jugadores y combate
        Combate combate = new Combate();
        Jugador j1 = new Jugador("Jugador 1");
        Jugador j2 = new Jugador("Jugador 2");

        // Iniciar el combate
        combate.BuclePrincipal(j1, j2);
    }
}
