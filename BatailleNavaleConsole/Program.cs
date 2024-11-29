using BatailleNavaleConsole;

Grid joueur = new Grid(); // grille du joueur 
Grid fire = new Grid(); // grille qui affiche les tirs effectués et les bateaux touchés
Grid adversaire = new Grid(); // grille qui stocke les bateaux de l'adversaire (jamais affichée)

string[] lettre = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
string[] number = { "0","1", "2", "3", "4", "5", "6", "7", "8", "9"};

string position = "";
char posX;
char posY;

string positionX;
string positionY;

double coupJoue = 0;
double touchedBoat = 0;
double score = 0;

// Place les bateaux pour l'utilisateur
joueur.boatPlacementAuto();

// Place les bateaux pour l'ordinateur
adversaire.boatPlacementAuto();

do
{
    // Calcule le score à chaque coup
    if (coupJoue == 0)
    {
        score = 0; // Au début le score vaut 0
    }
    else if (coupJoue == touchedBoat)
    {
        score = 100; // s'il touche autant de bateaux que de coups, alors il le score maximal
    }
    else
    {
        score = (touchedBoat / coupJoue) * 100;
    }

    Console.Clear();

    // Affichage des titres et données

    // Affichage du titre
    Console.WriteLine("Bataille navale : ");
    Console.WriteLine("==================");
    Console.WriteLine();

    // Affiche les coups joués
    Console.WriteLine("Vous avez joué " + coupJoue + " coup(s)");
    // Affiche le nbre de coups bien tirés
    Console.WriteLine("Vous avez touché " + touchedBoat + " fois des bateaux");
    Console.WriteLine();
    // Affiche le score (touchedBoat - coupJoue) / 100
    Console.WriteLine("Votre score est de : " + Math.Round(score, 2) + " sur 100");
    Console.WriteLine();

    // Affichage la grille de l'utilisateur
    Console.WriteLine("Votre grille : ");
    joueur.afficherNotreGrille();

    Console.WriteLine();

    // Affichage de la grille de progression
    Console.WriteLine("Vos tirs : ");
    fire.afficherGrille();

    // Attaque
    Console.WriteLine();
    Console.WriteLine("Procedez à l'attaque");

    do // demande la position du tire
    {
        Console.WriteLine();
        Console.Write("Position de votre tir (a-j)(0-9) : ");
        position = Console.ReadLine();
        
        if (position.Length != 2)
        {
            position = "  "; // définie la valeur à null
        }

        posX = position[0];
        posY = position[1];

        positionX = posX.ToString();
        positionY = posY.ToString();

        if (!lettre.Contains(positionX)) // regarde si la valeur correspond aux conditions
        {
            Console.WriteLine();
            Console.WriteLine("Veuillez entrer une valeur valable");
        }
        else if (!number.Contains(positionY)) // regarde si la valeur correspond aux conditions
        {
            Console.WriteLine();
            Console.WriteLine("Veuillez entrer une valeur valable");
        }
        else
        {
            coupJoue++;
            break;
        }
    } while (true);


    for (int x = 0; x < lettre.Length; x++) // Convertit la lettre entrée en chiffre (string)
    {
        if (positionX == lettre[x])
        {
            positionX = number[x];
        }
    }

    string state = adversaire.tirer(int.Parse(positionX), int.Parse(positionY)); // on tire, et vérifie le résultat (grille adversaire)

    touchedBoat = fire.afficherTire(int.Parse(positionX), int.Parse(positionY), state); // stock le résultat du tir (grille fire) + prend le nombre de coups
    fire.afficherGrille();

    fire.victory();
}while (true);