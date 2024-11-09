namespace Library;

public static class OperacionesStatic
{
    public static int numeroAleatorio(int minimo, int maximo)
    {
        Random random = new Random();
        return random.Next(minimo, maximo);
    }
    private static double CalcularCritico(string tipoMovimiento, string tipoPokemonDefensor)
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
    public static double bonificacionTipos(string tipoMovimiento, string tipoPokemonDefensor)
    {
        if (tipoPokemonDefensor == "Agua")
        {
            if (tipoMovimiento == "Eléctrico")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Planta")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Agua")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
            if (tipoMovimiento == "Fuego")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
            if (tipoMovimiento == "Hielo")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
        }
        
        if (tipoPokemonDefensor == "Bicho")
        {
            if (tipoMovimiento == "Fuego")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Roca")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Volador")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Veneno")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Lucha")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
            if (tipoMovimiento == "Planta")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
            if (tipoMovimiento == "Tierra")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
        }
        
        if (tipoPokemonDefensor == "Dragón")
        {
            if (tipoMovimiento == "Dragón")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Hielo")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Agua")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
            if (tipoMovimiento == "Eléctrico")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
            if (tipoMovimiento == "Fuego")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
            if (tipoMovimiento == "Planta")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
        }
        
        if (tipoPokemonDefensor == "Eléctrico")
        {
            if (tipoMovimiento == "Tierra")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Volador")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
            if (tipoMovimiento == "Eléctrico")
            {
                Console.WriteLine("No le afecta ese ataque");
                return 0;
            }
        }
        
        if (tipoPokemonDefensor == "Fantasma")
        {
            if (tipoMovimiento == "Fantasma")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Veneno")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
            if (tipoMovimiento == "Lucha")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
            if (tipoMovimiento == "Normal")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
        }

        if (tipoPokemonDefensor == "Fuego")
        {
            if (tipoMovimiento == "Agua")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Roca")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Tierra")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Bicho")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
            if (tipoMovimiento == "Fuego")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
            if (tipoMovimiento == "Planta")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
        }
        
        if (tipoPokemonDefensor == "Hielo")
        {
            if (tipoMovimiento == "Fuego")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Lucha")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Roca")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Hielo")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
        }
        
        if (tipoPokemonDefensor == "Lucha")
        {
            if (tipoMovimiento == "Psíquico")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Volador")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Bicho")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Roca")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
        }
        
        if (tipoPokemonDefensor == "Normal")
        {
            if (tipoMovimiento == "Lucha")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Fantasma")
            {
                Console.WriteLine("No le afecta ese ataque");
                return 0;
            }
        }
        
        if (tipoPokemonDefensor == "Planta")
        {
            if (tipoMovimiento == "Bicho")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Fuego")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Hielo")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Veneno")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Volador")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Agua")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
            if (tipoMovimiento == "Eléctrico")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
            if (tipoMovimiento == "Planta")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
            if (tipoMovimiento == "Tierra")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
        }
        
        if (tipoPokemonDefensor == "Psíquico")
        {
            if (tipoMovimiento == "Bicho")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Lucha")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Fantasma")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
        }
        
        if (tipoPokemonDefensor == "Roca")
        {
            if (tipoMovimiento == "Agua")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Lucha")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Planta")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Tierra")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Fuego")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
            if (tipoMovimiento == "Normal")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
            if (tipoMovimiento == "Veneno")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
            if (tipoMovimiento == "Volador")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
        }
        
        if (tipoPokemonDefensor == "Tierra")
        {
            if (tipoMovimiento == "Agua")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Hielo")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Planta")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Roca")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Veneno")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Eléctrico")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
        }
        
        if (tipoPokemonDefensor == "Veneno")
        {
            if (tipoMovimiento == "Bicho")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Psíquico")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Tierra")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Lucha")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Planta")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
            if (tipoMovimiento == "Veneno")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
        }
        
        if (tipoPokemonDefensor == "Volador")
        {
            if (tipoMovimiento == "Eléctrico")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Hielo")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Roca")
            {
                Console.WriteLine("Es muy eficaz");
                return 2;
            }
            if (tipoMovimiento == "Bicho")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
            if (tipoMovimiento == "Lucha")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
            if (tipoMovimiento == "Planta")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
            if (tipoMovimiento == "Tierra")
            {
                Console.WriteLine("No es muy eficaz");
                return 0.5;
            }
            
        }
        
        return 1;
    }
    
}