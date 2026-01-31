using BasicMessageAppServer.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace BasicMessageAppServer.Business
{
    public class MyBusiness
    {

        readonly IHubContext<MessageHub> _hubContext;

        public MyBusiness(IHubContext<MessageHub> hubContext)
        {
            _hubContext = hubContext;
        }


        public async Task SendMessageAsync(string username, string message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", message, username);
        }
    }
}
