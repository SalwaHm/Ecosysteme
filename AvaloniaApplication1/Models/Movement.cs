using System;

namespace AvaloniaApplication1.Models
{
    public class Movement
    {
        private readonly Animal _animal;//readonly => pour garantir que valeur non modifié après création objet Movement
        private int _currentDirection;

        public Movement(Animal animal)
        {
            _animal = animal;
        }

        public void MoveRight(double step, double canvasWidth)
        {
            _animal.X = Math.Min(canvasWidth - _animal.Width, _animal.X + step); //pour s'assurer de ne pas sortir du plateau
        }

        public void MoveLeft(double step, double canvasWidth)
        {
            _animal.X = Math.Max(0, _animal.X - step);
        }

        public void MoveForward(double step, double canvasHeight)
        {
            _animal.Y = Math.Min(canvasHeight - _animal.Height, _animal.Y + step);
        }

        public void MoveBackward(double step, double canvasHeight)
        {
            _animal.Y = Math.Max(0, _animal.Y - step);
        }

        public void SetRandomDirection()
        {
            Random random = new Random();
            _currentDirection = random.Next(4); //génère un nombre entre 0 et 3
        }

        public void MoveInCurrentDirection(double step, double canvasWidth, double canvasHeight)
        {
            switch (_currentDirection)
            {
                case 0:
                    MoveRight(step, canvasWidth);
                    break;
                case 1:
                    MoveLeft(step, canvasWidth);
                    break;
                case 2:
                    MoveForward(step, canvasHeight);
                    break;
                case 3:
                    MoveBackward(step, canvasHeight);
                    break;
            }
        }
    }
}
