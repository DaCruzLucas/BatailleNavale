namespace BatailleNavaleLibrary
{
    public class DTOGrid
    {
        public string[,] grille;
        public int taille = 10;
        public string state = "";

        public DTOGrid()
        {
            grille = new string[taille, taille];

            for (int i = 0; i < taille; i++)
            {
                for (int j = 0; j < taille; j++)
                {
                    grille[i, j] = "~";
                }
            }
        }
    }
}
