#Projet Ecosysteme (Matricule : 22110)

Ce projet est une simulation d'un écosystème dans lequel des animaux se promènent, se nourrissent, s'attaquent et meurent une fois leur réserve d'énergie épuisée au cours du temps. Ce projet a été réalisé avec Avalonia UI et codé en C#.

## Fonctionnement de la simulation

Une fois le programme lancé, des animaux et plantes définies au préalable se dépacent sur le plateau de jeu. Les animaux sont soit carnivores ou herbivores et voient leur énergie diminuer au cours du temps. Lorsqu'un animal n'a plus d'énergie, il peut convertir l'une de ses vies en points d'énergies et lorqu'il n'a ni énergie, ni vies, ils meurent. Pour se faire, l'animal en question disparaît pour laisser place à une image de viande. Lorsqu'un carnivore rencontre de la viande (soit un animal mort), il s'en nourrit et voit ainsi ses réserves d'énergie augmenter et la viande disparaît. Lorsq'un herbivore croise une plante sur son chemin, elle se nourrit de cette dernière. Ainsi, la plante disparaît et l'herbivore voir ses points d'énergie augmenter. Lorsque deux animaux se croisent, ils se voient tout les deux perdent des points d'énergie pour représenter le fait qu'ils se soient attaqués. 

## Principes SOLID

## Diagramme de classe du projet

![Diagrammes-4](https://github.com/user-attachments/assets/a5bf0457-a25e-428a-bd1c-1f508d911a5c)

## Diagramme d'activités
![image](https://github.com/user-attachments/assets/5e14e1d1-8753-4ef8-bf02-8a0bd956b9c3)

## Diagramme de Séquences

