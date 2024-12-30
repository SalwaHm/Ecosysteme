using System;

namespace AvaloniaApplication1.Models //car la classe Animal fait partie du sous-dossier "Models" du projet AvaloniaApplication1
{
    public class Animal //déclaration de la classe Animal comme étant public afin de permettre d'être utilisée par d'autres classes ou fichiers du projet
    {
        //définition des propriétés de l'animal
        public string Name { get; set; } //Stockage du nom de l'animal dans variable "Name" (avec get qui permet la lecture et set de modifier sa valeur)
        public double X { get; set; } //récupération de la coordonnée en x 
        public double Y { get; set; } //récupération de la coordonnée en y
        public double Width { get; set; } //stockage de la largeur de l'animal
        public double Height { get; set; } //stockage de la hauteur de l'animal

        //constructeur de la classe (méthode appelée automatiquement lors de création d'un objet Animal):
        public Animal(string name, double x, double y, double width, double height) //Exemple d'utilisation: Animal chevre = new Animal("Chevre", 100, 200, 50, 50);
        {
            Name = name;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        //Méthodes pour déplacer l'animal dans une certaine direction:
        public void MoveRight(double step, double canvasWidth)
        {
            X = Math.Min(canvasWidth - Width, X + step);
        }

        public void MoveLeft(double step, double canvasWidth)
        {
            X = Math.Max(0, X - step);
        }

        public void MoveForward(double step, double canvasHeight)
        {
            Y = Math.Min(canvasHeight - Height, Y + step);
        }

        public void MoveBackward(double step, double canvasHeight)
        {
            Y = Math.Max(0, Y - step);
        }

        // Méthode pour choisir un déplacement aléatoire
        public void ChooseRandomlyMove(double step, double canvasWidth, double canvasHeight)
        {
            Random random = new Random();
            int direction = random.Next(4); // Génère un nombre entre 0 et 3

            switch (direction)
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

