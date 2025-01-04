using System.Collections.Generic; //Nécessaire pour Dictionary
using Avalonia.Controls; //Pour gérer les contrôles graphiques
using Avalonia.Media.Imaging; //Pour gérer les images
using AvaloniaApplication1.Models; //Référence à la classe Animal

namespace AvaloniaApplication1.Utilities //Namespace pour organiser les utilitaires
{
    public class Remove
    {
        private readonly Canvas _canvas; //Référence au canvas principal
        private readonly Dictionary<Animal, Image> _animalImages; //dictionnaire qui associe les animaux à leur images

        // Constructeur
        public Remove(Canvas canvas, Dictionary<Animal, Image> animalImages)
        {
            _canvas = canvas;
            _animalImages = animalImages;
        }

        // Méthode pour remplacer un animal mort par l'image de viande
        public void ReplaceAnimalWithMeat(Animal animal)
        {
            if (_animalImages.TryGetValue(animal, out var animalImage))
            {
                // Supprime l'image de l'animal mort
                _canvas.Children.Remove(animalImage);
                _animalImages.Remove(animal);

                // Ajoute une image de viande à la position finale
                var meatImage = new Image
                {
                    Width = 60,
                    Height = 60,
                    Source = new Bitmap("Assets/meat.png")
                };
                Canvas.SetLeft(meatImage, animal.X);
                Canvas.SetTop(meatImage, animal.Y);
                _canvas.Children.Add(meatImage);
            }
        }
    }
}

