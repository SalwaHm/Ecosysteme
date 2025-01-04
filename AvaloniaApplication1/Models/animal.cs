using System;

namespace AvaloniaApplication1.Models
{
    public class Animal
    {
        public string Name { get; set; } //get permet de lire la valeur et set permet de modifier la valeur
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Lives { get; set; }
        public double Energy { get; set; }
        public string Species { get; set; }
        public bool IsDead { get; private set; } //Statut de vie/mort

        private Movement _movement; //utilisé uniquement dans la classe Animal et est une instance privée de la classe Movement
        private Energy _energy;
        private Lives _lives;

        public Animal(string name, double x, double y, double width, double height, double lives, double energy, string species)
        {
            Name = name;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Lives = lives;
            Energy = energy;
            Species = species;

            // Initialisation des autres classes
            _movement = new Movement(this);
            _movement.SetRandomDirection();
            _energy = new Energy(this);
            _lives = new Lives(this);
        }

        public void MoveInCurrentDirection(double step, double canvasWidth, double canvasHeight)
        {
            _movement.MoveInCurrentDirection(step, canvasWidth, canvasHeight);
        }

        public void SetRandomDirection()
        {
            _movement.SetRandomDirection();
        }

        public void UseEnergy()
        {
            _energy.LessEnergy();
        }

        public void ConvertingLivesIntoEnergy()
        {
            _lives.ConvertingLifeIntoEnergy();
        }

        public void Die()
        {
            IsDead = true;
        }
    }
}

