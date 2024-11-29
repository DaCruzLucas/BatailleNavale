using Microsoft.AspNetCore.SignalR;

namespace BatailleNavaleServer
{
    public class BatailleNavaleService
    {
        private readonly IHubContext<BatailleNavaleHub> hub;

        public Dictionary<int, Game> Games = new Dictionary<int, Game>();

        private int id = 0;

        public BatailleNavaleService(IHubContext<BatailleNavaleHub> hub)
        {
            this.hub = hub;
        }

        public int CreateGame(string connectionId)
        {
            id++;
            Games.Add(id, new Game(id));
            return id;
        }

        public int FindGame(string connectionId)
        {
            try
            {
                for (int i = 0; i < Games.Count; i++)
                {
                    if (Games[i].AddPlayer(connectionId))
                    {
                        return Games[i].Id;
                    }
                }

                return -1;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e);
                Console.ResetColor();

                return -1;
            }
        }
    }
}