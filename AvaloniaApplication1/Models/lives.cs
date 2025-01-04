using System;

namespace AvaloniaApplication1.Models
{
    public class Lives
    {
        private readonly Animal _animal;
        public Lives(Animal animal)
        {
            _animal = animal; 
        }
        public void ConvertingLifeIntoEnergy()
        {
            if (_animal.Lives > 0)
            {
                _animal.Lives -= 1; //Perte d'une vie
                _animal.Energy += 100; //Gain d'énergie (+100 points)
            }
            if (_animal.Lives == 0)//si l'animal a perdu toutes ses vies
            {
                //on déclare l'animal comme mort
                _animal.Die();//appel méthode Die définit dans classe Animal
            }
        }
    }
}
