using Library;

class Program
{
    static void Main(string[] args)
    {
        // Ruta correcta a los archivos
        string rutaPokemon = @"C:\Users\rf4tc\Desktop\Proyecto p2\ProyectoPokemon_PII_2024\pokemones.txt";
        string rutaMovimientos = @"C:\Users\rf4tc\Desktop\Proyecto p2\ProyectoPokemon_PII_2024\movimientos.txt";

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
