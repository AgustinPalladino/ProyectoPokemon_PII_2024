using System;
using System.Collections.Generic;
using Library.Moves;

namespace Library
{
    public class CreadorDePokemonYMovimiento
    {
        public Dictionary<string, Pokemon> diccionarioPokemon = new();
        public Dictionary<string, Movimiento> diccionarioMovimientos = new();

        /// <summary>
        /// Constructor.
        /// </summary>
        public CreadorDePokemonYMovimiento()
        {
            AgregarPokemonYMovimientos();
        }

        /// <summary>
        /// Método para agregar Pokemones con sus respectivos movimientos.
        /// </summary>
        public void AgregarPokemonYMovimientos()
        {
            // Crear los Pokemones
            Pokemon venusaur = new Pokemon("Venusaur", "Planta", 120, 40, 60);
            Pokemon charizard = new Pokemon("Charizard", "Fuego", 100, 60, 40);
            Pokemon blastoise = new Pokemon("Blastoise", "Agua", 110, 50, 50);
            Pokemon pikachu = new Pokemon("Pikachu", "Eléctrico", 80, 55, 40);
            Pokemon pidgeot = new Pokemon("Pidgeot", "Volador", 85, 70, 50);
            Pokemon butterfree = new Pokemon("Butterfree", "Bicho", 60, 50, 40);
            Pokemon dragonite = new Pokemon("Dragonite", "Dragón", 150, 80, 70);
            Pokemon articuno = new Pokemon("Articuno", "Hielo", 120, 90, 70);
            Pokemon machamp = new Pokemon("Machamp", "Lucha", 130, 100, 60);
            Pokemon alakazam = new Pokemon("Alakazam", "Psíquico", 90, 80, 50);
            Pokemon gengar = new Pokemon("Gengar", "Fantasma", 110, 75, 65);
            Pokemon onix = new Pokemon("Onix", "Roca", 80, 60, 50);
            Pokemon groudon = new Pokemon("Groudon", "Tierra", 150, 100, 80);
            Pokemon muk = new Pokemon("Muk", "Veneno", 120, 60, 60);
            Pokemon snorlax = new Pokemon("Snorlax", "Normal", 160, 85, 70);
            Pokemon clefable = new Pokemon("Clefable", "Hada", 95, 70, 65);
            Pokemon steelix = new Pokemon("Steelix", "Acero", 120, 150, 70);
            Pokemon kyogre = new Pokemon("Kyogre", "Agua", 150, 100, 80);
            Pokemon roserade = new Pokemon("Roserade", "Planta", 80, 65, 75);
            Pokemon jolteon = new Pokemon("Jolteon", "Eléctrico", 80, 65, 50);
            Pokemon zapdos = new Pokemon("Zapdos", "Eléctrico", 120, 90, 60);
            Pokemon salamence = new Pokemon("Salamence", "Dragón", 140, 110, 80);
            Pokemon moltres = new Pokemon("Moltres", "Fuego", 130, 100, 70);

            // Crear los movimientos
            Movimiento Arañazo = new Movimiento("Arañazo", 5, 80, "Fuego", false);
            Movimiento Lanzallamas = new Movimiento("Lanzallamas", 20, 80, "Fuego", false);
            Movimiento Lluevehojas = new Movimiento("Lluevehojas", 20, 100, "Planta", false);
            Movimiento Hidrocañon = new Movimiento("Hidrocañon", 20, 60, "Agua", false);
            Movimiento Puñofuego = new Movimiento("Puñofuego", 20, 60, "Fuego", false);
            Movimiento Electrocañon = new Movimiento("Electrocañon", 100, 40, "Eléctrico", false);
            Movimiento Aéreo = new Movimiento("Aéreo", 15, 60, "Volador", false);
            Movimiento Colmilloveneno = new Movimiento("Colmillo venenoso", 15, 60, "Veneno", false);
            Movimiento Puñodinámico = new Movimiento("Puño dinámico", 25, 100, "Lucha", false);
            Movimiento GarraDragon = new Movimiento("GarraDragon", 30, 60, "Lucha", false);
            Movimiento Confusion = new Movimiento("Confusion", 50, 60, "Psiquico", false);
            Movimiento LanzaRocas = new Movimiento("LanzaRocas", 20, 80, "Tierra", false);
            Movimiento Dormir = new Movimiento("Dormir", 0, 100, "Psiquico", true);
            Movimiento Envenenar = new Movimiento("Envenenar", 0, 100, "Veneno", true);
            Movimiento Quemar = new Movimiento("Quemar", 0, 100, "Fuego", true);
            Movimiento Paralizar = new Movimiento("Paralizar", 0, 100, "Electrico", true);
            Movimiento PuñoHielo = new Movimiento("PuñoHielo", 20, 80, "Hielo", false);
            Movimiento Aguacero = new Movimiento("Aguacero", 20, 60, "Agua", false);
            Movimiento PuñoElectrico = new Movimiento("PuñoEléctrico", 20, 60, "Eléctrico", false);
            Movimiento PuñoAereo = new Movimiento("PuñoAéreo", 15, 80, "Volador", false);
            Movimiento HojaAfilada = new Movimiento("Hoja Afilada", 25, 60, "Planta", false);
            Movimiento ColaLarga = new Movimiento("Cola Larga", 25, 60, "Dragón", false);
            Movimiento PuñoLucha = new Movimiento("Puño Lucha", 25, 60, "Lucha", false);
            Movimiento PuñoFuego = new Movimiento("Puño Fuego", 20, 80, "Fuego", false);
            Movimiento Rayo = new Movimiento("Rayo", 20, 100, "Electrico", false);

            // Agregar los movimientos a un diccionario
            diccionarioMovimientos.Add("Arañazo", Arañazo);
            diccionarioMovimientos.Add("Lanzallamas", Lanzallamas);
            diccionarioMovimientos.Add("Lluevehojas", Lluevehojas);
            diccionarioMovimientos.Add("Hidrocañon", Hidrocañon);
            diccionarioMovimientos.Add("Puñofuego", Puñofuego);
            diccionarioMovimientos.Add("Electrocañon", Electrocañon);
            diccionarioMovimientos.Add("Aéreo", Aéreo);
            diccionarioMovimientos.Add("Colmillo venenoso", Colmilloveneno);
            diccionarioMovimientos.Add("Puño dinámico", Puñodinámico);
            diccionarioMovimientos.Add("GarraDragon", GarraDragon);
            diccionarioMovimientos.Add("Confusion", Confusion);
            diccionarioMovimientos.Add("LanzaRocas", LanzaRocas);
            diccionarioMovimientos.Add("Dormir", Dormir);
            diccionarioMovimientos.Add("Envenenar", Envenenar);
            diccionarioMovimientos.Add("Quemar", Quemar);
            diccionarioMovimientos.Add("Paralizar", Paralizar);
            diccionarioMovimientos.Add("PuñoHielo", PuñoHielo);
            diccionarioMovimientos.Add("Aguacero", Aguacero);
            diccionarioMovimientos.Add("PuñoEléctrico", PuñoElectrico);
            diccionarioMovimientos.Add("PuñoAéreo", PuñoAereo);
            diccionarioMovimientos.Add("Hoja Afilada", HojaAfilada);
            diccionarioMovimientos.Add("Cola Larga", ColaLarga);
            diccionarioMovimientos.Add("Puño Lucha", PuñoLucha);
            diccionarioMovimientos.Add("Puño Fuego", PuñoFuego);
            diccionarioMovimientos.Add("Rayo", Rayo);

            // Agregar los pokemons al diccionario
            diccionarioPokemon.Add("Venusaur", venusaur);
            diccionarioPokemon.Add("Charizard", charizard);
            diccionarioPokemon.Add("Blastoise", blastoise);
            diccionarioPokemon.Add("Pikachu", pikachu);
            diccionarioPokemon.Add("Pidgeot", pidgeot);
            diccionarioPokemon.Add("Butterfree", butterfree);
            diccionarioPokemon.Add("Dragonite", dragonite);
            diccionarioPokemon.Add("Articuno", articuno);
            diccionarioPokemon.Add("Machamp", machamp);
            diccionarioPokemon.Add("Alakazam", alakazam);
            diccionarioPokemon.Add("Gengar", gengar);
            diccionarioPokemon.Add("Onix", onix);
            diccionarioPokemon.Add("Groudon", groudon);
            diccionarioPokemon.Add("Muk", muk);
            diccionarioPokemon.Add("Snorlax", snorlax);
            diccionarioPokemon.Add("Clefable", clefable);
            diccionarioPokemon.Add("Steelix", steelix);
            diccionarioPokemon.Add("Kyogre", kyogre);
            diccionarioPokemon.Add("Roserade", roserade);
            diccionarioPokemon.Add("Jolteon", jolteon);
            diccionarioPokemon.Add("Zapdos", zapdos);
            diccionarioPokemon.Add("Salamence", salamence);
            diccionarioPokemon.Add("Moltres", moltres);
        }
    }
}
