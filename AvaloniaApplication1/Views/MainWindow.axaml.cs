using System; //Nécessaire pour EventArgs et TimeSpan
using System.IO; //Nécessaire pour vérifier si le fichier existe
using Avalonia.Controls; //Pour les contrôles de l'interface
using Avalonia.Media.Imaging; //Pour gérer les images
using Avalonia.Threading; //Nécessaire pour DispatcherTimer
using AvaloniaApplication1.Models; //Référence à la classe Animal
using System.Collections.Generic; //Nécessaire pour utiliser Dictionary

namespace AvaloniaApplication1.Views //on définit ici le namespace auquel appartient la classe MainWindow --> cette classe fait donc partie de la section Views du projet AvaloniaApplication1
{
    public partial class MainWindow : Window //MainWindow=classe principale de la fenêtre définie dans le fichier XAML associé (hérite de la classe Window qui représente une fenêtre graphique dans Avalonia)
    {
        private Animal _chevre; //stockage d'une instance de la classe Animal (ici qui représente la chèvre)
        private Animal _loup; //stockage d'une instance de la classe Animal (ici qui représente le loup)
        private DispatcherTimer _timer; //stockage d'une instance de DispatcherTimer utilisé pour exécuter une tâche périodiquement

        private int _currentStepChevre; //suivi du pas actuel pour la chèvre
        private int _currentStepLoup;   //suivi du pas actuel pour le loup

        // Dictionnaire pour gérer les images associées aux animaux
        private readonly Dictionary<Animal, Image> _animalImages;

        //Constructeur de la classe (appelé lors de la création de la fenêtre)
        public MainWindow()
        {
            InitializeComponent(); //initialise les composants qui sont définis dans le fichier XAML (images, canvas, ...)

            //Initialisation des animaux
            _chevre = new Animal("Chevre", 200, 150, 100, 100, 3, 500, "Herbivore");
            _loup = new Animal("Loup", 400, 300, 120, 120, 3, 500, "Carnivore");

            // Initialisation du dictionnaire pour associer les images
            _animalImages = new Dictionary<Animal, Image>();

            // Ajout des animaux avec leurs images respectives
            AddAnimalToCanvas(_chevre, "Assets/chevre_.png");
            AddAnimalToCanvas(_loup, "Assets/loup_.png");

            //Initialisation des compteurs
            _currentStepChevre = 0;
            _currentStepLoup = 0;

            //Initialisation du Timer
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1) //définition de l'intervalle à 1 seconde (=> timer se déclenche toutes les secondes)
            };
            _timer.Tick += OnTimerTick; // Attache l'événement Tick
            _timer.Start(); // Démarre le timer
        }

        // Méthode pour ajouter un animal au canvas avec son image
        private void AddAnimalToCanvas(Animal animal, string imagePath)
        {
            // Vérifiez si le fichier existe
            if (!File.Exists(imagePath))
            {
                throw new FileNotFoundException($"Le fichier image est introuvable : {imagePath}");
            }

            // Création et configuration de l'image
            var animalImage = new Image
            {
                Width = animal.Width,
                Height = animal.Height,
                Source = new Bitmap(imagePath)
            };

            // Positionnement sur le canvas
            Canvas.SetLeft(animalImage, animal.X); //position X initiale
            Canvas.SetTop(animalImage, animal.Y); //position Y initiale

            // Ajout de l'image au canvas
            GameCanvas.Children.Add(animalImage);

            // Stockage dans le dictionnaire pour utilisation ultérieure
            _animalImages[animal] = animalImage;
        }

        // Méthode appelée à chaque tick du timer
        private void OnTimerTick(object sender, EventArgs e)
        {
            //chaque animal va effectuer trois pas (à chaque seconde) dans chacune des directions choisies
            if (_currentStepChevre < 3)
            {
                MoveAnimal(_chevre, _currentStepChevre);
                _currentStepChevre++; //on incrémente le compteur de pas
            }
            else
            {
                _chevre.SetRandomDirection(); //nouvelle direction après les trois pas
                _currentStepChevre = 0; // on réinitialise le compteur de pas à 0
            }

            if (_currentStepLoup < 3)
            {
                MoveAnimal(_loup, _currentStepLoup);
                _currentStepLoup++;
            }
            else
            {
                _loup.SetRandomDirection(); 
                _currentStepLoup = 0;
            }
        }

        // Méthode pour remplacer un animal mort par une image de viande
        private void ReplaceAnimalWithMeat(Animal animal)
        {
            if (_animalImages.TryGetValue(animal, out var animalImage))
            {
                // Supprime l'image de l'animal mort
                GameCanvas.Children.Remove(animalImage);
                _animalImages.Remove(animal);

                // Ajoute une image de viande à la position finale
                var meatImage = new Image
                {
                    Width = animal.Width,
                    Height = animal.Height,
                    Source = new Bitmap("Assets/meat.png")
                };
                Canvas.SetLeft(meatImage, animal.X);
                Canvas.SetTop(meatImage, animal.Y);
                GameCanvas.Children.Add(meatImage);
            }
        }

        //Méthode pour déplacer un animal (modifiée pour ne pas déplacer les animaux morts)
        private void MoveAnimal(Animal animal, int stepIndex)
        {
            if (animal.IsDead)
            {
                return; // Si l'animal est mort, ne pas le déplacer
            }

            double canvasWidth = GameCanvas.Bounds.Width; //récupération de la largeur du canvas
            double canvasHeight = GameCanvas.Bounds.Height; //récupération de la hauteur du canvas
            double step = (stepIndex + 1) * 10; //taille du pas pour le déplacement en cours

            //déplace l'animal dans la direction courante
            animal.MoveInCurrentDirection(step, canvasWidth, canvasHeight);

            // Utilisation de l'énergie après le mouvement
            animal.UseEnergy();

            if (animal.IsDead)
            {
                ReplaceAnimalWithMeat(animal);
                return;
            }

            //Met à jour la position de l'image associée sur le canvas
            if (_animalImages.TryGetValue(animal, out var animalImage))
            {
                Canvas.SetLeft(animalImage, animal.X); //Met à jour la position X
                Canvas.SetTop(animalImage, animal.Y);  //Met à jour la position Y
            }
        }
    }
}



