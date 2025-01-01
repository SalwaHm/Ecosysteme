using Avalonia.Controls;
using Avalonia.Media.Imaging;
using System;

namespace AvaloniaApplication1.Models
{
    public class Meat
    {
        public string meat_image; 

        // Constructeur
        public Meat(string meat_image)
        {
            meat_image = "Assets/meat.png";
        }

        //méthode pour transformer un animal en viande
        public void TransformToMeat(Image animalImage)
        {
            if (animalImage != null)
            {
                // Remplace l'image actuelle par l'image de viande
                animalImage.Source = new Bitmap(meat_image);
            }
        }
    }
}
