namespace BatailleNavaleConsole
{
    public class Grid
    {
        private string[,] grille;  // La grille est une matrice 10x10 de cases.
        private int taille = 10;

        Random rnd = new Random();
        string state = "";

        public int touchedBoat = 0;

        public Grid()
        {
            grille = new string[taille, taille];
            InitialiserGrille();
        }

        // Initialiser la grille avec des cases vides
        private void InitialiserGrille()
        {
            for (int i = 0; i < taille; i++)
            {
                for (int j = 0; j < taille; j++)
                {
                    grille[i, j] = "~";
                }
            }
        }

        public void afficherNotreGrille()
        {
            Console.Write("    ");

            for (int k = 0; k < taille; k++)
            {
                Console.Write(k + " ");
            }

            Console.WriteLine();
            Console.Write("    ");

            for (int k = 0; k < taille; k++)
            {
                Console.Write("- ");
            }

            Console.WriteLine();

            for (int i = 0; i < taille; i++)
            {
                string[] letter = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };

                string lettre = letter[i];

                Console.Write(lettre + " | ");
                for (int j = 0; j < taille; j++)
                {
                    Console.Write(grille[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void afficherGrille()
        {
            Console.Write("    ");

            for (int k = 0; k < taille; k++)
            {
                Console.Write(k + " ");
            }

            Console.WriteLine();
            Console.Write("    ");

            for (int k = 0; k < taille; k++)
            {
                Console.Write("- ");
            }

            Console.WriteLine();

            for (int i = 0; i < taille; i++)
            {
                string[] letter = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };

                string lettre = letter[i];

                Console.Write(lettre + " | ");
                for (int j = 0; j < taille; j++)
                {
                    if (grille[i, j] == "$")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (grille[i, j] == "O")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    Console.Write(grille[i, j] + " ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }



        public void boatPlacementAuto()
        {
            bool rand = false; // X ou Y --> true = X, false = Y

            for (int i = 2; i < 6; i++)
            {
                int x = rnd.Next(0, 10);
                int y = rnd.Next(0, 10);
                bool inversion = false; // Utiliser pour inversion le sens du bateau s'il touche le bord
                bool verif = true; // Utiliser pour la vérification de toutes les cellules

                do // Vérif des cases environnantes
                {
                    verif = true;

                    // Pour les X
                    if (rand && x - 1 >= 0 && x + i + 1 < 9)
                    {
                        for (int d = x - 1; d <= x + i; d++) // Fixe la borne supérieure
                        {
                            if (y + 1 < 9 && d >= 0 && grille[y + 1, d] != "~") // Vérifie la ligne d'au-dessus
                            {
                                verif = false;
                                x = rnd.Next(2, 10 - i);
                                y = rnd.Next(0, 10);
                                break; // Sort du `for`
                            }
                            else if (d >= 0 && grille[y, d] != "~") // Vérifie la ligne principale
                            {
                                verif = false;
                                x = rnd.Next(2, 10 - i);
                                y = rnd.Next(0, 10);
                                break;
                            }
                            else if (y - 1 >= 1 && d >= 0 && grille[y - 1, d] != "~") // Vérifie la ligne d'en-dessous
                            {
                                verif = false;
                                x = rnd.Next(2, 10 - i);
                                y = rnd.Next(0, 10);
                                break;
                            }
                        }
                    }
                    // Pour les Y
                    else if (!rand && y - 1 >= 0 && x - 1 >= 0 && x + 1 <= 9 && y + i + 1 < 9)
                    {
                        for (int e = y - 1; e <= y + i; e++) // Fixe la borne supérieure
                        {
                            if (e >= 0 && grille[e, x - 1] != "~") // Vérifie la colonne à gauche
                            {
                                verif = false;
                                x = rnd.Next(0, 9);
                                y = rnd.Next(2, 10 - i);
                                break;
                            }
                            else if (e >= 0 && grille[e, x] != "~") // Vérifie la colonne principale
                            {
                                verif = false;
                                x = rnd.Next(0, 9);
                                y = rnd.Next(2, 10 - i);
                                break;
                            }
                            else if (e >= 0 && grille[e, x + 1] != "~") // Vérifie la colonne à droite
                            {
                                verif = false;
                                x = rnd.Next(0, 9);
                                y = rnd.Next(2, 10 - i);
                                break;
                            }
                        }
                    }
                    else
                    {
                        verif = false;
                        if (rand) // pour les X
                        {
                            x = rnd.Next(2, 9 - i);
                            y = rnd.Next(2, 9);
                        }
                        else
                        {
                            x = rnd.Next(0, 9);
                            y = rnd.Next(2, 10 - i);
                        }
                    }
                } while (!verif);



                for (int j = 1; j < i + 1; j++)
                {
                    grille[y, x] = "X"; // la grille est inversée x, y

                    if (rand)
                    {
                        if (x >= 9)
                        {
                            x = x - j;
                            inversion = true;
                        }
                        else
                        {
                            if (inversion)
                            {
                                x--;
                            }
                            else
                            {
                                x++;
                            }
                        }
                    }
                    else
                    {
                        if (y >= 9)
                        {
                            y = y - j;
                            inversion = true;
                        }
                        else
                        {
                            if (inversion)
                            {
                                y--;
                            }
                            else
                            {
                                y++;
                            }
                        }
                    }
                }
                rand = !rand;
            }
        }

        // Vérifier si un coup touche un bateau
        public string tirer(int x, int y)
        {
            // Verifie si la case est touché
            if (grille[x, y] != "~" && grille[x, y] == "X")
            {
                state = "touche";
            }
            // Vérifie si la case c'est de l'eau
            else if (grille[x, y] == "~")
            {
                state = "eau";
            }
            // Vérifie si la case à déja été touchée
            else if (grille[x, y] == "$")
            {
                state = "deja";
            }

            return state;
        }

        public double afficherTire(int x, int y, string state)
        {
            if (state == "touche")
            {
                Console.WriteLine();
                Console.WriteLine("Touché");
                Console.WriteLine();
                grille[x, y] = "$";  // Marquer la case comme "touchée".
                touchedBoat++;
            }
            else if (state == "eau")
            {
                Console.WriteLine();
                Console.WriteLine("Eau ! Aucun bateau touché.");
                Console.WriteLine();
                grille[x, y] = "O";  // Marquer la case comme "manquée".
            }
            else if (state == "deja")
            {
                Console.WriteLine();
                Console.WriteLine("Vous avez déjà touché ce bateau");
            }
            return touchedBoat;
        }

        public void victory()
        {
            int nbreX = 0;

            foreach (string cell in grille)
            {
                if (cell == "$")
                {
                    nbreX++;
                }
            }

            if (nbreX == 14)
            {
                Console.WriteLine("Vous avez gagné");
                Environment.Exit(0);
            }
        }
    }
}
