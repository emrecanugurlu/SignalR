using Microsoft.AspNetCore.SignalR;

namespace BasicMessageAppServer.Hubs
{
    public class MessageHub: Hub
    {
        public async Task SendMessageAsync(string username, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",message, username);
        }
    }
}
