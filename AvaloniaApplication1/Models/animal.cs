using System;

namespace AvaloniaApplication1.Models
{
    public class Animal
    {
        public string Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        private Movement _movement;

        public Animal(string name, double x, double y, double width, double height)
        {
            Name = name;
            X = x;
            Y = y;
            Width = width;
            Height = height;

            //Initialisation de la classe Movement
            _movement = new Movement(this);
            _movement.SetRandomDirection(); //on initialise une direction aléatoire
        }

        //Appel aux méthodes definies dans movement pour le déplacement de l'animal
        public void MoveInCurrentDirection(double step, double canvasWidth, double canvasHeight)
        {
            _movement.MoveInCurrentDirection(step, canvasWidth, canvasHeight);
        }

        public void SetRandomDirection()
        {
            _movement.SetRandomDirection();
        }
    }
}
