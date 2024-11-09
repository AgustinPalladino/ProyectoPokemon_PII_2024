using System;
using System.Collections.Generic;
using Library.Moves;

namespace Library
{
    public class CreadorDePokemonYMovimiento
    {
        public List<Pokemon> listaPokemon = new();

        public CreadorDePokemonYMovimiento()
        {
            AgregarPokemon();
        }

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
            // Agregar movimientos a los pokemons
            venusaur.agregarMovimiento(Arañazo);
            venusaur.agregarMovimiento(Lluevehojas);
            charizard.agregarMovimiento(Arañazo);
            charizard.agregarMovimiento(Lanzallamas);
            blastoise.agregarMovimiento(Arañazo);
            blastoise.agregarMovimiento(Hidrocañon);
            pikachu.agregarMovimiento(Arañazo);
            pikachu.agregarMovimiento(Electrocañon);
            pidgeot.agregarMovimiento(Aéreo);
            pidgeot.agregarMovimiento(Arañazo);
            butterfree.agregarMovimiento(Colmilloveneno);
            butterfree.agregarMovimiento(Aéreo);
            dragonite.agregarMovimiento(Puñofuego);
            dragonite.agregarMovimiento(GarraDragon);
            articuno.agregarMovimiento(Arañazo);
            articuno.agregarMovimiento(Aéreo);
            machamp.agregarMovimiento(Arañazo);
            machamp.agregarMovimiento(Puñodinámico);
            alakazam.agregarMovimiento(Arañazo);
            alakazam.agregarMovimiento(Confusion);
            gengar.agregarMovimiento(Arañazo);
            gengar.agregarMovimiento(Confusion);
            onix.agregarMovimiento(LanzaRocas);
            onix.agregarMovimiento(Arañazo);
            groudon.agregarMovimiento(LanzaRocas);
            groudon.agregarMovimiento(Arañazo);
            muk.agregarMovimiento(Colmilloveneno);
            muk.agregarMovimiento(Confusion);
            snorlax.agregarMovimiento(Arañazo);
            snorlax.agregarMovimiento(Puñodinámico);



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
