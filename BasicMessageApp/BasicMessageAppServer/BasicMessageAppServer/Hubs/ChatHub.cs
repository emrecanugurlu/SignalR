using Microsoft.AspNetCore.SignalR;

namespace BasicMessageAppServer.Hubs
{
    public class ChatHub: Hub
    {
        public async Task SendMessage(string message)
        {
            #region Client Types
            #region All
            //Herkes ile iletişim kurar
            await Clients.All.SendAsync("receiveMessage", message);
            #endregion

            #region Caller
            //Sadece servera bildirim gönderen client ile iletişim kurar.
            await Clients.Caller.SendAsync("receiveMessage", message);
            #endregion

            #region Other
            //Servera bildirim gönderen client haricindeki herkes ile iletişim kurar.
            await Clients.Others.SendAsync("receiveMessage", message);
            #endregion
            #endregion
        }
    }
}
