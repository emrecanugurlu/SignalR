using Microsoft.AspNetCore.SignalR;

namespace BasicMessageAppServer.Hubs
{
    public class MessageHub: Hub
    {
        static List<string> clients = new List<string>();

        public async Task SendMessageAsync(string username, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",message, username);
        }

        public override async Task OnConnectedAsync()
        {
            clients.Add(Context.ConnectionId);
            await Clients.All.SendAsync("clients", clients);
            await Clients.All.SendAsync("userJoined", Context.ConnectionId);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clients.Remove(Context.ConnectionId);
            await Clients.All.SendAsync("clients", clients);
            await Clients.All.SendAsync("userLeaved", Context.ConnectionId);
        }
    }
}
