using System;
using System.Collections.Generic;
using System.IO;

namespace Library
{
    public static class DiccionariosYOperacionesStatic
    {
        // Diccionarios para almacenar Pokémon y movimientos
        public static Dictionary<string, Pokemon> DiccionarioPokemon = new Dictionary<string, Pokemon>();
        public static Dictionary<string, Movimiento> DiccionarioMovimientos = new Dictionary<string, Movimiento>();

        private static Random randomDouble = new Random();

        // Diccionario para definir bonificaciones de tipo
        private static readonly Dictionary<(string tipoMovimiento, string tipoPokemonDefensor), double>
            bonificacionesTipos =
                new Dictionary<(string, string), double>
                {
                    { ("Eléctrico", "Agua"), 2 },
                    { ("Planta", "Agua"), 2 },
                    { ("Agua", "Agua"), 0.5 },
                    { ("Fuego", "Agua"), 0.5 },
                    { ("Hielo", "Agua"), 0.5 },
                    { ("Fuego", "Bicho"), 2 },
                    { ("Roca", "Bicho"), 2 },
                    { ("Volador", "Bicho"), 2 },
                    { ("Veneno", "Bicho"), 2 },
                    { ("Lucha", "Bicho"), 0.5 },
                    { ("Planta", "Bicho"), 0.5 },
                    { ("Tierra", "Bicho"), 0.5 },
                    { ("Dragón", "Dragón"), 2 },
                    { ("Hielo", "Dragón"), 2 },
                    { ("Agua", "Dragón"), 0.5 },
                    { ("Eléctrico", "Dragón"), 0.5 },
                    { ("Fuego", "Dragón"), 0.5 },
                    { ("Planta", "Dragón"), 0.5 },
                    { ("Tierra", "Eléctrico"), 2 },
                    { ("Volador", "Eléctrico"), 0.5 },
                    { ("Eléctrico", "Eléctrico"), 0 },
                    { ("Fantasma", "Fantasma"), 2 },
                    { ("Veneno", "Fantasma"), 0.5 },
                    { ("Lucha", "Fantasma"), 0.5 },
                    { ("Normal", "Fantasma"), 0.5 },
                    { ("Agua", "Fuego"), 2 },
                    { ("Roca", "Fuego"), 2 },
                    { ("Tierra", "Fuego"), 2 },
                    { ("Bicho", "Fuego"), 0.5 },
                    { ("Fuego", "Fuego"), 0.5 },
                    { ("Planta", "Fuego"), 0.5 },
                    { ("Fuego", "Hielo"), 2 },
                    { ("Lucha", "Hielo"), 2 },
                    { ("Roca", "Hielo"), 2 },
                    { ("Hielo", "Hielo"), 0.5 },
                    { ("Psíquico", "Lucha"), 2 },
                    { ("Volador", "Lucha"), 2 },
                    { ("Bicho", "Lucha"), 2 },
                    { ("Roca", "Lucha"), 2 },
                    { ("Lucha", "Normal"), 2 },
                    { ("Fantasma", "Normal"), 0 },
                    { ("Bicho", "Planta"), 2 },
                    { ("Fuego", "Planta"), 2 },
                    { ("Hielo", "Planta"), 2 },
                    { ("Veneno", "Planta"), 2 },
                    { ("Volador", "Planta"), 2 },
                    { ("Agua", "Planta"), 0.5 },
                    { ("Eléctrico", "Planta"), 0.5 },
                    { ("Planta", "Planta"), 0.5 },
                    { ("Tierra", "Planta"), 0.5 },
                    { ("Bicho", "Psíquico"), 2 },
                    { ("Lucha", "Psíquico"), 2 },
                    { ("Fantasma", "Psíquico"), 2 },
                    { ("Agua", "Roca"), 2 },
                    { ("Lucha", "Roca"), 2 },
                    { ("Planta", "Roca"), 2 },
                    { ("Tierra", "Roca"), 2 },
                    { ("Fuego", "Roca"), 0.5 },
                    { ("Normal", "Roca"), 0.5 },
                    { ("Veneno", "Roca"), 0.5 },
                    { ("Volador", "Roca"), 0.5 },
                    { ("Agua", "Tierra"), 2 },
                    { ("Hielo", "Tierra"), 2 },
                    { ("Planta", "Tierra"), 2 },
                    { ("Roca", "Tierra"), 2 },
                    { ("Veneno", "Tierra"), 2 },
                    { ("Eléctrico", "Tierra"), 0.5 },
                    { ("Bicho", "Veneno"), 2 },
                    { ("Psíquico", "Veneno"), 2 },
                    { ("Tierra", "Veneno"), 2 },
                    { ("Lucha", "Veneno"), 2 },
                    { ("Planta", "Veneno"), 0.5 },
                    { ("Veneno", "Veneno"), 0.5 },
                    { ("Eléctrico", "Volador"), 2 },
                    { ("Hielo", "Volador"), 2 },
                    { ("Roca", "Volador"), 2 },
                    { ("Bicho", "Volador"), 0.5 },
                    { ("Lucha", "Volador"), 0.5 },
                    { ("Planta", "Volador"), 0.5 },
                    { ("Tierra", "Volador"), 0.5 }
                };

        /// <summary>
        /// Método para obtener la bonificación de tipo
        /// </summary>
        /// <param name="tipoMovimiento"></param>
        /// <param name="tipoPokemonDefensor"></param>
        /// <returns></returns>
        public static double bonificacionTipos(string tipoMovimiento, string tipoPokemonDefensor)
        {
            if (bonificacionesTipos.TryGetValue((tipoMovimiento, tipoPokemonDefensor), out double bonificacion))
            {
                Console.WriteLine(bonificacion == 2 ? "Es muy eficaz" :
                    bonificacion == 0.5 ? "No es muy eficaz" : "No le afecta ese ataque");
                return bonificacion;
            }

            return 1; /// Si no hay bonificación específica, el daño es normal
        }

        // Método para cargar Pokémon desde un archivo
        public static void CargarPokemonDesdeArchivo(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo))
            {
                Console.WriteLine($"El archivo {rutaArchivo} no existe.");
                return;
            }

            var lineas = File.ReadAllLines(rutaArchivo);
            foreach (var linea in lineas)
            {
                var datos = linea.Split(';');
                if (datos.Length != 5)
                {
                    Console.WriteLine($"Formato incorrecto en línea: {linea}");
                    continue;
                }

                var pokemon = new Pokemon(datos[0], datos[1], int.Parse(datos[2]), int.Parse(datos[3]), int.Parse(datos[4]));
                DiccionarioPokemon[datos[0]] = pokemon; // Usar el nombre como clave
            }
        }

        // Método para cargar movimientos desde un archivo
        public static void CargarMovimientosDesdeArchivo(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo))
            {
                Console.WriteLine($"El archivo {rutaArchivo} no existe.");
                return;
            }

            var lineas = File.ReadAllLines(rutaArchivo);
            foreach (var linea in lineas)
            {
                var datos = linea.Split(';');
                if (datos.Length != 5)
                {
                    Console.WriteLine($"Formato incorrecto en línea: {linea}");
                    continue;
                }

                var movimiento = new Movimiento(datos[0], int.Parse(datos[1]), int.Parse(datos[2]), datos[3], bool.Parse(datos[4]));
                DiccionarioMovimientos[datos[0]] = movimiento; // Usar el nombre como clave
            }
        }

        // Métodos adicionales
        public static int numeroAleatorio(int minimo, int maximo)
        {
            Random random = new Random();
            return random.Next(minimo, maximo + 1);
        }

        public static double Precision(double precision, int ataqueBase)
        {
            double probabilidad = randomDouble.NextDouble(); // Devuelve valor entre 0 y 1
            if (probabilidad <= precision)
            {
                return ataqueBase;
            }
            else
            {
                Console.WriteLine("El ataque falló");
                return 0;
            }
        }

        public static double CalcularCritico(int precisionMovimiento)
        {
            int probabilidad = numeroAleatorio(0, precisionMovimiento);
            double probabilidadCritico = precisionMovimiento / 10;
            if (probabilidad <= probabilidadCritico) // Cálculo de golpe crítico
            {
                Console.WriteLine("¡Golpe crítico!");
                return 1.2; // Multiplicador de 20% más de daño
            }

            return 1.0; // Sino es crítico, pega lo mismo
        }
    }
}
