using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using AvaloniaApplication1.Models;
using AvaloniaApplication1.Utilities;

namespace AvaloniaApplication1.Models
{
    public class Eat
    {
        private readonly Animal _animal;
        private readonly Dictionary<Animal, Image> _animalImages;
        private readonly Canvas _canvas;
        private readonly Remove _removeUtility;

        public Eat(Animal animal, Dictionary<Animal, Image> animalImages, Canvas canvas, Remove removeUtility)
        {
            _animal = animal;
            _animalImages = animalImages;
            _canvas = canvas;
            _removeUtility = removeUtility;
        }

        public void SameLocalisation()
        {
            // Vérifie si deux animaux sont au même endroit et leur fait perdre de l'énergie
            foreach (var otherAnimal in _animalImages.Keys)
            {
                if (_animal == otherAnimal) 
                    continue;

                if (AreAnimalsAtSamePosition(_animal, otherAnimal))
                {
                    _animal.UseEnergy();
                    otherAnimal.UseEnergy();
                }
            }

            // Vérifie si un carnivore est au même endroit qu'une viande et lui fait gagner de l'énergie
            if (_animal.Species == "Carnivore" && IsCarnivoreTouchingMeat(_animal))
            {
                _animal.GainEnergy();
                RemoveImageAtPosition(_animal.X, _animal.Y, "Assets/meat.png");
            }

            // Vérifie si un herbivore est au même endroit qu'une plante et lui fait gagner de l'énergie
            if (_animal.Species == "Herbivore" && IsImageAtAnimalPosition(_animal, "Assets/plante.png"))
            {
                _animal.GainEnergy();
                RemoveImageAtPosition(_animal.X, _animal.Y, "Assets/plante.png");
            }
        }

        // Vérifie si un carnivore touche la viande
        private bool IsCarnivoreTouchingMeat(Animal animal)
        {
            foreach (var child in _canvas.Children.OfType<Image>())
            {
                if (child.Source is Bitmap bitmap && bitmap.ToString().EndsWith("meat.png"))
                {
                    double imageX = Canvas.GetLeft(child);
                    double imageY = Canvas.GetTop(child);

                    // Vérifier la superposition entre l'image du carnivore et celle de la viande
                    if (IsOverlap(animal.X, animal.Y, animal.Width, animal.Height, imageX, imageY, 60, 60)) // 60x60 est la taille de l'image de viande
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // Vérifie si deux rectangles se superposent (même légèrement)
        private bool IsOverlap(double animalX, double animalY, double animalWidth, double animalHeight, double imageX, double imageY, double imageWidth, double imageHeight)
        {
            // Vérification de l'overlap même d'un pixel
            return !(animalX + animalWidth < imageX || 
                     animalX > imageX + imageWidth || 
                     animalY + animalHeight < imageY || 
                     animalY > imageY + imageHeight);
        }

        // Vérifie si deux animaux sont à la même position
        private bool AreAnimalsAtSamePosition(Animal animal1, Animal animal2)
        {
            return Math.Abs(animal1.X - animal2.X) < 5 && Math.Abs(animal1.Y - animal2.Y) < 5;
        }

        // Vérifie si une image spécifique est à la position d'un animal
        private bool IsImageAtAnimalPosition(Animal animal, string imagePath)
        {
            foreach (var child in _canvas.Children.OfType<Image>())
            {
                if (child.Source is Bitmap bitmap && bitmap.ToString().EndsWith(imagePath))
                {
                    double imageX = Canvas.GetLeft(child);
                    double imageY = Canvas.GetTop(child);

                    if (Math.Abs(animal.X - imageX) < 5 && Math.Abs(animal.Y - imageY) < 5)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // Supprime une image spécifique au niveau d'une position donnée
        private void RemoveImageAtPosition(double x, double y, string imagePath)
        {
            foreach (var child in _canvas.Children.OfType<Image>().ToList())
            {
                if (child.Source is Bitmap bitmap && bitmap.ToString().EndsWith(imagePath))
                {
                    double imageX = Canvas.GetLeft(child);
                    double imageY = Canvas.GetTop(child);

                    if (Math.Abs(x - imageX) < 5 && Math.Abs(y - imageY) < 5)
                    {
                        _canvas.Children.Remove(child);
                        break;
                    }
                }
            }
        }
    }
}
