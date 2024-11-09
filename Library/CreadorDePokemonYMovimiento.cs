using System;
using System.Collections.Generic;
using Library.Moves;

namespace Library
{
    public class CreadorDePokemonYMovimiento
    {
        public List<Pokemon> listaPokemon = new();
        
        /// <summary>
        /// Constructor.
        /// </summary>
        public CreadorDePokemonYMovimiento()
        {
            AgregarPokemon();
        }
        /// <summary>
        /// Método para agregar Pokemones con sus respectivos movimientos.
        /// </summary>
        public void AgregarPokemon()
        {
            
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
            //Ataques
            Movimiento Arañazo = new Movimiento("Arañazo", 5, "Fuego", false);
            Movimiento Lanzallamas = new Movimiento("Lanzallamas", 20, "Fuego", false);
            Movimiento Lluevehojas = new Movimiento("Lluevehojas", 20, "Planta", false);
            Movimiento Hidrocañon = new Movimiento("Hidrocañon", 20, "Agua", false);
            Movimiento Puñofuego = new Movimiento("Puñofuego", 20, "Fuego", false);
            Movimiento Electrocañon = new Movimiento("Electrocañon", 20, "Eléctrico", false);
            Movimiento Aéreo = new Movimiento("Aéreo", 15, "Volador", false);
            Movimiento Colmilloveneno = new Movimiento("Colmillo venenoso", 15, "Veneno", false);
            Movimiento Puñodinámico = new Movimiento("Puño dinámico", 25, "Lucha", false);
            Movimiento GarraDragon = new Movimiento("GarraDragon", 30, "Lucha", false);
            Movimiento Confusion = new Movimiento("Confusion",50,"Psiquico",false);
            Movimiento LanzaRocas = new Movimiento("LanzaRocas", 20, "Tierra", false);
            Movimiento Dormir = new Movimiento("Dormir", 0, "Psiquico", true);
            Movimiento Envenenar = new Movimiento("Envenenar", 0, "Veneno", true);
            Movimiento Quemar = new Movimiento("Quemar", 0, "Fuego", true);
            Movimiento Paralizar = new Movimiento("Paralizar", 0, "Electrico", true);
            // Agregar movimientos a los pokemons
            venusaur.agregarMovimiento(Arañazo);
            venusaur.agregarMovimiento(Lluevehojas);
            venusaur.agregarMovimiento(Dormir);
            venusaur.agregarMovimiento(Quemar);
            charizard.agregarMovimiento(Arañazo);
            charizard.agregarMovimiento(Lanzallamas);
            charizard.agregarMovimiento(Paralizar);
            charizard.agregarMovimiento(Quemar);
            blastoise.agregarMovimiento(Arañazo);
            blastoise.agregarMovimiento(Hidrocañon);
            blastoise.agregarMovimiento(Dormir);
            blastoise.agregarMovimiento(Envenenar);
            pikachu.agregarMovimiento(Arañazo);
            pikachu.agregarMovimiento(Electrocañon);
            pikachu.agregarMovimiento(Envenenar);
            pikachu.agregarMovimiento(Paralizar);
            pidgeot.agregarMovimiento(Aéreo);
            pidgeot.agregarMovimiento(Arañazo);
            pidgeot.agregarMovimiento(Dormir);
            pidgeot.agregarMovimiento(Paralizar);
            butterfree.agregarMovimiento(Colmilloveneno);
            butterfree.agregarMovimiento(Aéreo);
            butterfree.agregarMovimiento(Quemar);
            butterfree.agregarMovimiento(Dormir);
            dragonite.agregarMovimiento(Puñofuego);
            dragonite.agregarMovimiento(GarraDragon);
            dragonite.agregarMovimiento(Paralizar);
            dragonite.agregarMovimiento(Paralizar);
            articuno.agregarMovimiento(Arañazo);
            articuno.agregarMovimiento(Aéreo);
            articuno.agregarMovimiento(Dormir);
            articuno.agregarMovimiento(Envenenar);
            machamp.agregarMovimiento(Arañazo);
            machamp.agregarMovimiento(Puñodinámico);
            machamp.agregarMovimiento(Paralizar);
            machamp.agregarMovimiento(Quemar);
            alakazam.agregarMovimiento(Arañazo);
            alakazam.agregarMovimiento(Confusion);
            alakazam.agregarMovimiento(Quemar);
            alakazam.agregarMovimiento(Envenenar);
            gengar.agregarMovimiento(Arañazo);
            gengar.agregarMovimiento(Confusion);
            gengar.agregarMovimiento(Quemar);
            gengar.agregarMovimiento(Envenenar);
            onix.agregarMovimiento(LanzaRocas);
            onix.agregarMovimiento(Arañazo);
            onix.agregarMovimiento(Dormir);
            onix.agregarMovimiento(Envenenar);
            groudon.agregarMovimiento(LanzaRocas);
            groudon.agregarMovimiento(Arañazo);
            groudon.agregarMovimiento(Envenenar);
            groudon.agregarMovimiento(Paralizar);
            muk.agregarMovimiento(Colmilloveneno);
            muk.agregarMovimiento(Confusion);
            muk.agregarMovimiento(Dormir);
            muk.agregarMovimiento(Quemar);
            snorlax.agregarMovimiento(Arañazo);
            snorlax.agregarMovimiento(Puñodinámico);
            snorlax.agregarMovimiento(Envenenar);
            snorlax.agregarMovimiento(Dormir);



            // Agregar los pokemons a la lista
            listaPokemon.Add(venusaur);
            listaPokemon.Add(charizard);
            listaPokemon.Add(blastoise);
            listaPokemon.Add(pikachu);
            listaPokemon.Add(pidgeot);
            listaPokemon.Add(butterfree);
            listaPokemon.Add(dragonite);
            listaPokemon.Add(articuno);
            listaPokemon.Add(machamp);
            listaPokemon.Add(alakazam);
            listaPokemon.Add(gengar);
            listaPokemon.Add(onix);
            listaPokemon.Add(groudon);
            listaPokemon.Add(muk);
            listaPokemon.Add(snorlax);
        }
    }
}
