namespace Library;

public static class OperacionesStatic
{
    public static int numeroAleatorio(int minimo, int maximo)
    {
        Random random = new Random();
        return random.Next(minimo, maximo);
    }

    public static double CalcularCritico(string tipoMovimiento, string tipoPokemonDefensor)
    {
           
        int probabilidad = numeroAleatorio(1, 101); //Numero entre 1 y 100
        if (probabilidad <= 10) // 10% de probabilidad d golpe critico
        {
            Console.WriteLine("¡Golpe crítico!");
            return 1.2; // Multiplicador de 20% más de daño
        }
        return 1.0; // Sin crítico, el daño es normal
    }
    
    //A continuación se crea bonificacionTipos el cual es un multiplicador al valor del ataque, dependiendo si hay efectividad de tipo o no.
    //Discutir que se podría hacer envez de muchos ifs
    



    
    private static readonly Dictionary<string, Dictionary<string, (double multiplier, string message)>> tipoBonificaciones =
        new Dictionary<string, Dictionary<string, (double, string)>>()
        {
            {
                "Agua", new Dictionary<string, (double, string)>
                {
                    { "Eléctrico", (2, "Es muy eficaz") },
                    { "Planta", (2, "Es muy eficaz") },
                    { "Agua", (0.5, "No es muy eficaz") },
                    { "Fuego", (0.5, "No es muy eficaz") },
                    { "Hielo", (0.5, "No es muy eficaz") }
                }
            },
            {
                "Bicho", new Dictionary<string, (double, string)>
                {
                    { "Fuego", (2, "Es muy eficaz") },
                    { "Roca", (2, "Es muy eficaz") },
                    { "Volador", (2, "Es muy eficaz") },
                    { "Veneno", (2, "Es muy eficaz") },
                    { "Lucha", (0.5, "No es muy eficaz") },
                    { "Planta", (0.5, "No es muy eficaz") },
                    { "Tierra", (0.5, "No es muy eficaz") }
                }
            },
            {
                "Dragón", new Dictionary<string, (double, string)>
                {
                    { "Dragón", (2, "Es muy eficaz") },
                    { "Hielo", (2, "Es muy eficaz") },
                    { "Agua", (0.5, "No es muy eficaz") },
                    { "Eléctrico", (0.5, "No es muy eficaz") },
                    { "Fuego", (0.5, "No es muy eficaz") },
                    { "Planta", (0.5, "No es muy eficaz") }
                }
            },
            {
                "Eléctrico", new Dictionary<string, (double, string)>
                {
                    { "Tierra", (2, "Es muy eficaz") },
                    { "Volador", (0.5, "No es muy eficaz") },
                    { "Eléctrico", (0, "No le afecta ese ataque") }
                }
            },
            {
                "Fantasma", new Dictionary<string, (double, string)>
                {
                    { "Fantasma", (2, "Es muy eficaz") },
                    { "Veneno", (0.5, "No es muy eficaz") },
                    { "Lucha", (0.5, "No es muy eficaz") },
                    { "Normal", (0.5, "No es muy eficaz") }
                }
            },
            {
                "Fuego", new Dictionary<string, (double, string)>
                {
                    { "Agua", (2, "Es muy eficaz") },
                    { "Roca", (2, "Es muy eficaz") },
                    { "Tierra", (2, "Es muy eficaz") },
                    { "Bicho", (0.5, "No es muy eficaz") },
                    { "Fuego", (0.5, "No es muy eficaz") },
                    { "Planta", (0.5, "No es muy eficaz") }
                }
            },
            {
                "Hielo", new Dictionary<string, (double, string)>
                {
                    { "Fuego", (2, "Es muy eficaz") },
                    { "Lucha", (2, "Es muy eficaz") },
                    { "Roca", (2, "Es muy eficaz") },
                    { "Hielo", (0.5, "No es muy eficaz") }
                }
            },
            {
                "Lucha", new Dictionary<string, (double, string)>
                {
                    { "Psíquico", (2, "Es muy eficaz") },
                    { "Volador", (2, "Es muy eficaz") },
                    { "Bicho", (2, "Es muy eficaz") },
                    { "Roca", (2, "Es muy eficaz") }
                }
            },
            {
                "Normal", new Dictionary<string, (double, string)>
                {
                    { "Lucha", (2, "Es muy eficaz") },
                    { "Fantasma", (0, "No le afecta ese ataque") }
                }
            },
            {
                "Planta", new Dictionary<string, (double, string)>
                {
                    { "Bicho", (2, "Es muy eficaz") },
                    { "Fuego", (2, "Es muy eficaz") },
                    { "Hielo", (2, "Es muy eficaz") },
                    { "Veneno", (2, "Es muy eficaz") },
                    { "Volador", (2, "Es muy eficaz") },
                    { "Agua", (0.5, "No es muy eficaz") },
                    { "Eléctrico", (0.5, "No es muy eficaz") },
                    { "Planta", (0.5, "No es muy eficaz") },
                    { "Tierra", (0.5, "No es muy eficaz") }
                }
            },
            {
                "Psíquico", new Dictionary<string, (double, string)>
                {
                    { "Bicho", (2, "Es muy eficaz") },
                    { "Lucha", (2, "Es muy eficaz") },
                    { "Fantasma", (2, "Es muy eficaz") }
                }
            },
            {
                "Roca", new Dictionary<string, (double, string)>
                {
                    { "Agua", (2, "Es muy eficaz") },
                    { "Lucha", (2, "Es muy eficaz") },
                    { "Planta", (2, "Es muy eficaz") },
                    { "Tierra", (2, "Es muy eficaz") },
                    { "Fuego", (0.5, "No es muy eficaz") },
                    { "Normal", (0.5, "No es muy eficaz") },
                    { "Veneno", (0.5, "No es muy eficaz") },
                    { "Volador", (0.5, "No es muy eficaz") }
                }
            },
            {
                "Tierra", new Dictionary<string, (double, string)>
                {
                    { "Agua", (2, "Es muy eficaz") },
                    { "Hielo", (2, "Es muy eficaz") },
                    { "Planta", (2, "Es muy eficaz") },
                    { "Roca", (2, "Es muy eficaz") },
                    { "Veneno", (2, "Es muy eficaz") },
                    { "Eléctrico", (0.5, "No es muy eficaz") }
                }
            },
            {
                "Veneno", new Dictionary<string, (double, string)>
                {
                    { "Bicho", (2, "Es muy eficaz") },
                    { "Psíquico", (2, "Es muy eficaz") },
                    { "Tierra", (2, "Es muy eficaz") },
                    { "Lucha", (2, "Es muy eficaz") },
                    { "Planta", (0.5, "No es muy eficaz") },
                    { "Veneno", (0.5, "No es muy eficaz") }
                }
            },
            {
                "Volador", new Dictionary<string, (double, string)>
                {
                    { "Eléctrico", (2, "Es muy eficaz") },
                    { "Hielo", (2, "Es muy eficaz") },
                    { "Roca", (2, "Es muy eficaz") },
                    { "Bicho", (0.5, "No es muy eficaz") },
                    { "Lucha", (0.5, "No es muy eficaz") },
                    { "Planta", (0.5, "No es muy eficaz") },
                    { "Tierra", (0.5, "No es muy eficaz") }
                }
            }
        };

    public static double bonificacionTipos(string tipoMovimiento, string tipoPokemonDefensor)
    {
        if (tipoBonificaciones.TryGetValue(tipoPokemonDefensor, out var tipoMovimientos) &&
            tipoMovimientos.TryGetValue(tipoMovimiento, out var bonificacion))
        {
            Console.WriteLine(bonificacion.message);
            return bonificacion.multiplier;
        }

        return 1;
    }
}
