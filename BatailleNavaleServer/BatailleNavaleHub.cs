using Microsoft.AspNetCore.SignalR;

namespace BatailleNavaleServer
{
    public class BatailleNavaleHub : Hub
    {
        private readonly BatailleNavaleService bns;
        
        public BatailleNavaleHub(BatailleNavaleService bns)
        {
            this.bns = bns;
        }

        public override async Task OnConnectedAsync()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Client " + Context.ConnectionId + " has connected");
            Console.ResetColor();

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Client " + Context.ConnectionId + " has disconnected");
            Console.ResetColor();

            await base.OnDisconnectedAsync(exception);
        }
    }
}
