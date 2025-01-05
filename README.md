# Projet Ecosysteme (Matricule : 22110)

Ce projet est une simulation d'un écosystème dans lequel des animaux se promènent, se nourrissent, s'attaquent et meurent une fois leur réserve d'énergie épuisée au cours du temps. Ce projet a été réalisé avec Avalonia UI et codé en C#.

## Fonctionnement de la simulation

Une fois le programme lancé, des animaux et plantes définies au préalable se dépacent sur le plateau de jeu. Les animaux sont soit carnivores ou herbivores et voient leur énergie diminuer au cours du temps. Lorsqu'un animal n'a plus d'énergie, il peut convertir l'une de ses vies en points d'énergies et lorqu'il n'a ni énergie, ni vies, ils meurent. Pour se faire, l'animal en question disparaît pour laisser place à une image de viande. Lorsqu'un carnivore rencontre de la viande (soit un animal mort), il s'en nourrit et voit ainsi ses réserves d'énergie augmenter et la viande disparaît. Lorsq'un herbivore croise une plante sur son chemin, elle se nourrit de cette dernière. Ainsi, la plante disparaît et l'herbivore voir ses points d'énergie augmenter. Lorsque deux animaux se croisent, ils se voient tout les deux perdent des points d'énergie pour représenter le fait qu'ils se soient attaqués. 

## Principes SOLID
Pour mener à bien ce projet, ce dernier s'est nottamment reposé sur les principes SOLID suivants:
1) Single Responsibility Principle:
   Ce principe SOLID s'avère très efficace pour éviter la redondance de code en attribuant qu'une seule tâche aux classe et aux méthodes. Cela permet également d'avoir des classes moins longues en les segmentant suivant ce principe.
   1) Un exemple de classe, qui suit cette règle dans ce projet, est Lives (contenue dans le fichier lives.cs). En effet, on observe que cette classe n'a pour rôle que de gérer les vies des animaux. Pour se faire, elle convertit la vie d'un animal en points d'énergie seulement s'il reste des vies à l'animal.

   3) Un autre exemple pour illustrer ce principe serait celui de la classe Energy. On observe que cette classe n'a elle aussi qu'une seule fonction, celle de la gestion des points d'énergie des animaux. De plus, les deux méthodes que contient cette classe ont chacune qu'un seul rôle à remplir. En effet, la méthode "PlusEnergy" ajoute des points d'énergie à l'animal et la méthode "LessEnergy" lui en fait perdre dans le cas où l'animal possède toujours quelques point d'énergie à perdre (dans le cas contraire, un appel est fait à la méthode "ConvertingLivesIntoEnergy" de la classe "Lives" pour convertir des points de vies en énergie.

2) Open Principle
   Ce principe consiste à faire en sorte que le code soit ouvert aux extensions, autrement dit qu'on puisse y ajouter des fonctionnalités (ou faire en sorte que le code soit fermé au modifications dans le cas du Closed Principle).
   Dans notre cas, la classe "Animal" (contenu dans animal.cs) illustre ce principe. En effet, au cours de la réalisation de ce projet, cette classe s'est vue ajouter une nouvelle méthode à chaque étape. Chacune de ces méthodes étant une nouvelle fonctionnalité de l'animal qui font, en réalité, unqiuement un appel à d'autres classes. Ces méthodes ont pu être ajoutées sans pour autant modifier le contenu initialement présent dans la classe "Animal". 
   
## Diagramme de classe du projet

![Diagrammes-4](https://github.com/user-attachments/assets/a5bf0457-a25e-428a-bd1c-1f508d911a5c)

## Diagramme d'activités
![image](https://github.com/user-attachments/assets/5e14e1d1-8753-4ef8-bf02-8a0bd956b9c3)

## Diagramme de Séquences

