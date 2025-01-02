using Avalonia.Controls;
using Avalonia.Media.Imaging;

namespace AvaloniaApplication1.Models
{
    public class Dead
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string ImageSource { get; set; }

        public Dead(double x, double y, string imageSource)
        {
            X = x;
            Y = y;
            ImageSource = imageSource;
        }

        // Méthode pour afficher l'image "meat.png" à la position donnée
        public void DisplayMeat(Canvas gameCanvas)
        {
            var meatImage = new Image
            {
                Source = new Bitmap(ImageSource),
                Width = 100,  // Ajuster selon la taille de l'animal
                Height = 100  // Ajuster selon la taille de l'animal
            };

            // Ajouter l'image à la position donnée sur le Canvas
            gameCanvas.Children.Add(meatImage);
            Canvas.SetLeft(meatImage, X);
            Canvas.SetTop(meatImage, Y);
        }
    }
}
