using System;

namespace AvaloniaApplication1.Models
{
    public class Energy
    {
        private readonly Animal _animal; //variable _animal

        public Energy(Animal animal)
        {
            _animal = animal;
        }
        public void PlusEnergy()
        {
            _animal.Energy += 100; //Gain d'énergie (+100)
        }
        public void LessEnergy()
        {
            if (_animal.Energy > 0)
            {
                _animal.Energy -= 100; //Perte d'énergie
            }
            else
            {
                //Appel à la classe Lives pour convertir une vie en énergie
                _animal.ConvertingLivesIntoEnergy();// définit dans class Animal et est une méthode qui fait appel à la classe Lives pour convertir uen vie en points d'énergie
            }
        }
    }
}
