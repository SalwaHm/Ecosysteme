using System; //Nécessaire pour EventArgs et TimeSpan
using Avalonia.Controls; //Pour les contrôles de l'interface
using Avalonia.Threading; //Nécessaire pour DispatcherTimer
using AvaloniaApplication1.Models; //Référence à la classe Animal

namespace AvaloniaApplication1.Views //on définit ici le namespace auquel appartient la classe MainWindow --> cette classe fait donc partie de la section Views du projet AvaloniaApplication1
{
    public partial class MainWindow : Window //MainWindow=classe principale de la fenêtre définie dans le fichier XAML associé (hérite de la classe Window qui représente une fenêtre graphique dans Avalonia)
    {
        private Animal _chevre; //stockage d'une instance de la classe Animal (ici qui représente la chèvre)
        private Animal _loup; //stockage d'une instance de la classe Animal (ici qui représente le loup)
        private DispatcherTimer _timer; //stockage d'une instance de DispatcherTimer utilisé pour exécuter une tâche périodiquement

        private int _currentStepChevre; //suivi du pas actuel pour la chèvre
        private int _currentStepLoup;   //suivi du pas actuel pour le loup

        //Constructeur de la classe (appelé lors de la création de la fenêtre)
        public MainWindow()
        {
            InitializeComponent(); //initialise les composants qui sont définis dans le fichier XAML (images, canvas, ...)

            //Initialisation de la chèvre avec sa position de départ (cf position décrite dans canvas)
            _chevre = new Animal("Chevre", 200, 150, 100, 100);
            _loup = new Animal("Loup", 400, 300, 120, 120);

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

        // Méthode appelée à chaque tick du timer
        private void OnTimerTick(object sender, EventArgs e)
        {
            //chaque animal va effectué trois pas (à chaque seconde) dans chacune des directions choisies
            if (_currentStepChevre < 3)
            {
                MoveAnimal(_chevre, "Chevre", _currentStepChevre);
                _currentStepChevre++; //on incrémente le compteur de pas
            }
            else
            {
                _chevre.SetRandomDirection(); //nouvelle direction après les trois pas
                _currentStepChevre = 0;// on réinitialise le compteur de pas à 0
            }

            
            if (_currentStepLoup < 3)
            {
                MoveAnimal(_loup, "Loup", _currentStepLoup);
                _currentStepLoup++;
            }
            else
            {
                _loup.SetRandomDirection(); 
                _currentStepLoup = 0;
            }
        }

        //Méthode pour déplacer un animal 
        private void MoveAnimal(Animal animal, string animalName, int stepIndex)
        {
            double canvasWidth = GameCanvas.Bounds.Width; //récupération de la largeur du canvas
            double canvasHeight = GameCanvas.Bounds.Height; //récupération de la hauteur du canvas
            double step = (stepIndex + 1) * 10; //taille du pas pour le déplacement en cours

            //déplace l'animal dans la direction courante
            animal.MoveInCurrentDirection(step, canvasWidth, canvasHeight);

            //Met à jour la position de l'image associée sur le canvas
            var animalImage = this.FindControl<Image>(animalName);
            if (animalImage != null)
            {
                Canvas.SetLeft(animalImage, animal.X); //Met à jour la position X
                Canvas.SetTop(animalImage, animal.Y);  //Met à jour la position Y
            }
        }
    }
}

