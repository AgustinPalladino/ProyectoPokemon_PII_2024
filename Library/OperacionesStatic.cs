namespace Library
{
    public static class OperacionesStatic
    {
        public static int numeroAleatorio(int minimo, int maximo)
        {
            Random random = new Random();
            return random.Next(minimo, maximo);
        }

        public static double CalcularCritico(string tipoMovimiento, string tipoPokemonDefensor)
        {
            int probabilidad = numeroAleatorio(1, 101); // Número entre 1 y 100
            if (probabilidad <= 10) // 10% de probabilidad de golpe crítico
            {
                Console.WriteLine("¡Golpe crítico!");
                return 1.2; // Multiplicador de 20% más de daño
            }
            return 1.0; // Sin crítico, el daño es normal
        }

        /// Diccionario para definir bonificaciones de tipo
        private static readonly Dictionary<(string tipoMovimiento, string tipoPokemonDefensor), double> bonificacionesTipos =
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
                Console.WriteLine(bonificacion == 2 ? "Es muy eficaz" : bonificacion == 0.5 ? "No es muy eficaz" : "No le afecta ese ataque");
                return bonificacion;
            }

            return 1; /// Si no hay bonificación específica, el daño es normal
        }

        public static string ajustarPalabra(string palabra)
        {
            palabra = palabra.ToLower();
            palabra = palabra.Trim();
            return palabra;
        }
    }
}
