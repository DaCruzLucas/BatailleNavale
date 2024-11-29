using Microsoft.AspNetCore.SignalR;

namespace BatailleNavaleServer
{
    public class BatailleNavaleService
    {
        private readonly IHubContext<BatailleNavaleHub> hub;

        public Dictionary<int, Game> games = new Dictionary<int, Game>();

        public int id = 0;

        public BatailleNavaleService(IHubContext<BatailleNavaleHub> hub)
        {
            this.hub = hub;
        }

        public int CreateGame(string connectionId)
        {
            id++;
            games.Add(id, new Game(connectionId, ""));
            return id;
        }

        public int FindGame()
        {
            

            return -1;
        }
    }
}
