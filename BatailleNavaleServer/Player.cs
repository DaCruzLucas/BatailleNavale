using BatailleNavaleLibrary;

namespace BatailleNavaleServer
{
    public class Player
    {
        public readonly string connectionId;

        public DTOGrid Grid = new DTOGrid();
        public DTOGrid ShootingGrid = new DTOGrid();

        public Player(string connectionId)
        {
            this.connectionId = connectionId;
        }

        public void GenerateGrid()
        {
            
        }
        public void GenerateShootingGrid()
        {

        }
    }
}
