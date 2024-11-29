namespace BatailleNavaleServer
{
    public class Game
    {
        string[] lettre = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
        string[] number = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        public int tour = 0;

        public readonly int Id;

        public Player player1 = new Player("");
        public Player player2 = new Player("");

        public Game(int id)
        {
            Id = id;
        }

        public bool AddPlayer(string connectionId)
        {
            if (player1.connectionId == "")
            {
                player1 = new Player(connectionId);
                return true;
            }
            else if (player2.connectionId == "")
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
            player1.GenerateGrid();
            player1.GenerateShootingGrid();

            player2.GenerateGrid();
            player2.GenerateShootingGrid();
        }
    }
}
