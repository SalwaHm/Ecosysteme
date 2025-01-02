using System;

namespace AvaloniaApplication1.Models //Animal appartient au dossier Models
{
    //propriétés de l'animal (récupération de son nom, coordonnées, taille, largeur et variable Movement)
    public class Animal //classe Animal
    {
        public string Name { get; set; } //get permet de lire la valeur et set permet de modifier la valeur
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        private Movement _movement; //utilisé uniquement dans la classe Animal et est une instance privé de la classe Movement

        public Animal(string name, double x, double y, double width, double height) //constructeur (initialise les propiétés Name, x et y, Width, Height)
        {
            Name = name;
            X = x;
            Y = y;
            Width = width;
            Height = height;

            //initialisation de la classe Movement
            _movement = new Movement(this); //this permet à la classe Movement d'accéder et de modifier les propriétés X et Y, ... de l'objet crée
            _movement.SetRandomDirection(); //appelle à la méthode de déplacement aléatoire (contenu dans MOVEMENT) pour initialiser une direction aléatoire
        }

        //Appel aux méthodes definies dans movement pour le déplacement de l'animal
        public void MoveInCurrentDirection(double step, double canvasWidth, double canvasHeight)
        {
            _movement.MoveInCurrentDirection(step, canvasWidth, canvasHeight);
        }

        public void SetRandomDirection() //pour générer un nouveau deplacement aléatoire (l'appel à cette méthode publique est fait dans le code Main)-> cette méthode elle-meme fait appel à setrandomdirection contenu dans Moveemnt
        {
            _movement.SetRandomDirection();
        }
    }
}
