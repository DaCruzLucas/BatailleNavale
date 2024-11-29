namespace BatailleNavaleServer
{
    public class Game
    {
        string[] lettre = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
        string[] number = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        public int tour = 0;

        Player? player1;
        Player? player2;

        public Game()
        {

        }

        public bool AddPlayer(string connectionId)
        {
            if (player1 != null)
            {
                player1 = new Player(connectionId);
                return true;
            }
            else if (player2 != null)
            {
                player2 = new Player(connectionId);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void InitialisePlayers()
        {
            player1?.GenerateGrid();
            player1?.GenerateShootingGrid();

            player2?.GenerateGrid();
            player2?.GenerateShootingGrid();
        }
    }
}
