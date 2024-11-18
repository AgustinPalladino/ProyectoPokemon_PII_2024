namespace Library
{
    public static class OperacionesStatic
    {
        public static int numeroAleatorio(int minimo, int maximo)
        {
            Random random = new Random();
            return random.Next(minimo, maximo + 1);
        }

        private static Random randomDouble = new Random();


        public static double Precision(double precision, int ataqueBase)
        {
            double probabilidad = randomDouble.NextDouble(); /// Devuelve valor entre 0 y 1
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
            if (probabilidad <= probabilidadCritico) // Calculo de que la cantidad sea golpe critico
            {
                Console.WriteLine("¡Golpe crítico!");
                return 1.2; // Multiplicador de 20% mas de daño
            }

            return 1.0; // Sino es critico, pega lo mismo
        }


        /// Diccionario para definir bonificaciones de tipo
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

        public static Dictionary<string, Movimiento> DiccionarioMovimientos = new()
        {
            { "Arañazo", new Movimiento("Arañazo", 5, 80, "Fuego", false) },
            { "Lanzallamas", new Movimiento("Lanzallamas", 20, 80, "Fuego", false) },
            { "Lluevehojas", new Movimiento("Lluevehojas", 20, 100, "Planta", false) },
            { "Hidrocañon", new Movimiento("Hidrocañon", 20, 60, "Agua", false) },
            { "PuñoFuego", new Movimiento("PuñoFuego", 20, 60, "Fuego", false) },
            { "Electrocañon", new Movimiento("Electrocañon", 100, 40, "Eléctrico", false) },
            { "Aéreo", new Movimiento("Aéreo", 15, 60, "Volador", false) },
            { "ColmilloVenenoso", new Movimiento("ColmilloVenenoso", 15, 60, "Veneno", false) },
            { "PuñoDinámico", new Movimiento("PuñoDinámico", 25, 100, "Lucha", false) },
            { "GarraDragon", new Movimiento("GarraDragon", 30, 60, "Lucha", false) },
            { "Confusion", new Movimiento("Confusion", 50, 60, "Psíquico", false) },
            { "lanzarrocas", new Movimiento("lanzarrocas", 20, 80, "Tierra", false) },
            { "Dormir", new Movimiento("Dormir", 0, 100, "Psíquico", true) },
            { "Envenenar", new Movimiento("Envenenar", 0, 100, "Veneno", true) },
            { "Quemar", new Movimiento("Quemar", 0, 100, "Fuego", true) },
            { "Paralizar", new Movimiento("Paralizar", 0, 100, "Eléctrico", true) },
            { "PuñoHielo", new Movimiento("Puño Hielo", 20, 80, "Hielo", false) },
            { "Aguacero", new Movimiento("Aguacero", 20, 60, "Agua", false) },
            { "PuñoEléctrico", new Movimiento("PuñoEléctrico", 20, 60, "Eléctrico", false) },
            { "PuñoAéreo", new Movimiento("PuñoAéreo", 15, 80, "Volador", false) },
            { "HojaAfilada", new Movimiento("HojaAfilada", 25, 60, "Planta", false) },
            { "ColaLarga", new Movimiento("ColaLarga", 25, 60, "Dragón", false) },
            { "PuñoLucha", new Movimiento("PuñoLucha", 25, 60, "Lucha", false) },
            { "Rayo", new Movimiento("Rayo", 20, 100, "Eléctrico", false) }
        };
        
        public static Dictionary<string, Pokemon> DiccionarioPokemon = new()
        {
            {
                "Venusaur", new Pokemon("Venusaur", "Planta", 120, 40, 60).AgregarMovimientos(new List<Movimiento>
                    {
                        DiccionarioMovimientos["Arañazo"],
                        DiccionarioMovimientos["Lluevehojas"],
                        DiccionarioMovimientos["Dormir"],
                        DiccionarioMovimientos["Quemar"]
                    })
            },
            {
                "Charizard", new Pokemon("Charizard", "Fuego", 100, 60, 40).AgregarMovimientos(new List<Movimiento>
                    {
                        DiccionarioMovimientos["Arañazo"],
                        DiccionarioMovimientos["Lanzallamas"],
                        DiccionarioMovimientos["Paralizar"],
                        DiccionarioMovimientos["Quemar"]
                    })
            },
            {
                "Blastoise", new Pokemon("Blastoise", "Agua", 110, 50, 50).AgregarMovimientos(new List<Movimiento>
                    {
                        DiccionarioMovimientos["Arañazo"],
                        DiccionarioMovimientos["Hidrocañon"],
                        DiccionarioMovimientos["Dormir"],
                        DiccionarioMovimientos["Envenenar"]
                    })
            },
            {
                "Pikachu", new Pokemon("Pikachu", "Eléctrico", 80, 55, 40).AgregarMovimientos(new List<Movimiento>
                    {
                        DiccionarioMovimientos["Arañazo"],
                        DiccionarioMovimientos["Electrocañon"],
                        DiccionarioMovimientos["Envenenar"],
                        DiccionarioMovimientos["Paralizar"]
                    })
            },
            {
                "Pidgeot", new Pokemon("Pidgeot", "Volador", 85, 70, 50).AgregarMovimientos(new List<Movimiento>
                    {
                        DiccionarioMovimientos["Aéreo"],
                        DiccionarioMovimientos["Arañazo"],
                        DiccionarioMovimientos["Dormir"],
                        DiccionarioMovimientos["Paralizar"]
                    })
            },
            {
                "Butterfree", new Pokemon("Butterfree", "Bicho", 60, 50, 40).AgregarMovimientos(new List<Movimiento>
                    {
                        DiccionarioMovimientos["ColmilloVenenoso"],
                        DiccionarioMovimientos["Aéreo"],
                        DiccionarioMovimientos["Quemar"],
                        DiccionarioMovimientos["Dormir"]
                    })
            },
            {
                "Dragonite", new Pokemon("Dragonite", "Dragón", 150, 80, 70).AgregarMovimientos(new List<Movimiento>
                    {
                        DiccionarioMovimientos["PuñoFuego"],
                        DiccionarioMovimientos["GarraDragon"],
                        DiccionarioMovimientos["Paralizar"],
                        DiccionarioMovimientos["PuñoAéreo"]
                    })
            },
            {
                "Articuno", new Pokemon("Articuno", "Hielo", 120, 90, 70).AgregarMovimientos(new List<Movimiento>
                    {
                        DiccionarioMovimientos["Arañazo"],
                        DiccionarioMovimientos["Aéreo"],
                        DiccionarioMovimientos["Dormir"],
                        DiccionarioMovimientos["Envenenar"]
                    })
            },
            {
                "Machamp", new Pokemon("Machamp", "Lucha", 130, 100, 60).AgregarMovimientos(new List<Movimiento>
                    {
                        DiccionarioMovimientos["PuñoLucha"],
                        DiccionarioMovimientos["PuñoDinámico"],
                        DiccionarioMovimientos["Paralizar"],
                        DiccionarioMovimientos["Quemar"]
                    })
            },
            {
                "Alakazam", new Pokemon("Alakazam", "Psíquico", 90, 80, 50).AgregarMovimientos(new List<Movimiento>
                    {
                        DiccionarioMovimientos["Arañazo"],
                        DiccionarioMovimientos["Confusion"],
                        DiccionarioMovimientos["Quemar"],
                        DiccionarioMovimientos["Dormir"]
                    })
            },
            {
                "Gengar", new Pokemon("Gengar", "Fantasma", 100, 60, 40).AgregarMovimientos(new List<Movimiento>
                    {
                        DiccionarioMovimientos["Arañazo"],
                        DiccionarioMovimientos["Confusion"],
                        DiccionarioMovimientos["Quemar"],
                        DiccionarioMovimientos["Envenenar"]
                    })
            },
            {
                "Onix", new Pokemon("Onix", "Roca", 110, 50, 50).AgregarMovimientos(new List<Movimiento>
                    {
                        DiccionarioMovimientos["lanzarrocas"],
                        DiccionarioMovimientos["Arañazo"],
                        DiccionarioMovimientos["Dormir"],
                        DiccionarioMovimientos["Envenenar"]
                    })
            },
            {
                "Groudon", new Pokemon("Groudon", "Tierra", 150, 80, 70).AgregarMovimientos(new List<Movimiento>
                    {
                        DiccionarioMovimientos["lanzarrocas"],
                        DiccionarioMovimientos["Arañazo"],
                        DiccionarioMovimientos["Envenenar"],
                        DiccionarioMovimientos["Paralizar"]
                    })
            },
            {
                "Muk", new Pokemon("Muk", "Veneno", 85, 70, 50).AgregarMovimientos(new List<Movimiento>
                    {
                        DiccionarioMovimientos["ColmilloVenenoso"],
                        DiccionarioMovimientos["Confusion"],
                        DiccionarioMovimientos["Dormir"],
                        DiccionarioMovimientos["Quemar"]
                    })
            },
            {
                "Snorlax", new Pokemon("Snorlax", "Normal", 160, 110, 75).AgregarMovimientos(new List<Movimiento>
                    {
                        DiccionarioMovimientos["Arañazo"],
                        DiccionarioMovimientos["PuñoDinámico"],
                        DiccionarioMovimientos["Envenenar"],
                        DiccionarioMovimientos["Rayo"]
                    })
            },
            {
                "Clefable", new Pokemon("Clefable", "Hada", 130, 85, 70).AgregarMovimientos(new List<Movimiento>
                    {
                        DiccionarioMovimientos["Arañazo"],
                        DiccionarioMovimientos["Envenenar"],
                        DiccionarioMovimientos["Dormir"],
                        DiccionarioMovimientos["Quemar"]
                    })
            },
            {
                "Steelix", new Pokemon("Steelix", "Acero", 150, 100, 70).AgregarMovimientos(new List<Movimiento>
                    {
                        DiccionarioMovimientos["lanzarrocas"],
                        DiccionarioMovimientos["Arañazo"],
                        DiccionarioMovimientos["Dormir"],
                        DiccionarioMovimientos["Envenenar"]
                    })
            },
            {
                "Kyogre", new Pokemon("Kyogre", "Agua", 130, 100, 60).AgregarMovimientos(new List<Movimiento>
                    {
                        DiccionarioMovimientos["Hidrocañon"],
                        DiccionarioMovimientos["Arañazo"],
                        DiccionarioMovimientos["Dormir"],
                        DiccionarioMovimientos["Aguacero"]
                    })
            },
            {
                "Roserade", new Pokemon("Roserade", "Planta", 80, 60, 50).AgregarMovimientos(new List<Movimiento>
                    {
                        DiccionarioMovimientos["ColmilloVenenoso"],
                        DiccionarioMovimientos["Confusion"],
                        DiccionarioMovimientos["Quemar"],
                        DiccionarioMovimientos["HojaAfilada"]
                    })
            },
            {
                "Jolteon", new Pokemon("Jolteon", "Eléctrico", 65, 60, 50).AgregarMovimientos(new List<Movimiento>
                    {
                        DiccionarioMovimientos["Arañazo"],
                        DiccionarioMovimientos["Electrocañon"],
                        DiccionarioMovimientos["PuñoEléctrico"],
                        DiccionarioMovimientos["Paralizar"]
                    })
            },
            {
                "Zapdos", new Pokemon("Zapdos", "Eléctrico", 120, 80, 70).AgregarMovimientos(new List<Movimiento>
                    {
                        DiccionarioMovimientos["Rayo"],
                        DiccionarioMovimientos["Aéreo"],
                        DiccionarioMovimientos["PuñoEléctrico"],
                        DiccionarioMovimientos["Dormir"]
                    })
            },
            {
                "Salamence", new Pokemon("Salamence", "Dragón", 130, 100, 70).AgregarMovimientos(new List<Movimiento>
                    {
                        DiccionarioMovimientos["PuñoFuego"],
                        DiccionarioMovimientos["GarraDragon"],
                        DiccionarioMovimientos["ColaLarga"],
                        DiccionarioMovimientos["Dormir"]
                    })
            },
            {
                "Moltres", new Pokemon("Moltres", "Fuego", 125, 85, 75).AgregarMovimientos(new List<Movimiento>
                    {
                        DiccionarioMovimientos["Arañazo"],
                        DiccionarioMovimientos["Aéreo"],
                        DiccionarioMovimientos["Quemar"],
                        DiccionarioMovimientos["PuñoFuego"]
                    })
            }
        };
    }
}


