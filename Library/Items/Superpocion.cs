using System;

namespace Library
{
    public class SuperPocion : IItem
    {
        private string nombre;

        public string Nombre
        {
            get { return this.nombre = "Superpocion"; }
        }
        
        public void Usar(Jugador j)
        {
            var pokemon = j.pokemonEnCancha();
            
            if (pokemon.VidaActual > 0)
            {
                pokemon.VidaActual += 70;
                
                if (pokemon.VidaActual > pokemon.VidaMax)
                {
                    pokemon.VidaActual = pokemon.VidaMax;
                }
                
                Console.WriteLine($"{pokemon.Nombre} se ha restaurado 70 puntos de vida.");
            }
            if(pokemon.VidaActual==100)
            {
                Console.WriteLine($"{pokemon.Nombre} No puedes restaurar mas vida ya que ya esta al maximo.");
            }
        }
    }
}
