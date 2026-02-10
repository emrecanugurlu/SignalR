using Microsoft.AspNetCore.SignalR;

namespace BasicMessageAppServer.Hubs
{
    public class ChatHub: Hub
    {
        public async Task SendMessageAsync(string message, IEnumerable<string> connectionIds)
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

            #region Hub Clients Methods
            #region AllExcept
            //Belirtilen clientler hariç servere bağlı bulunan tüm clientlere bildirimde bulunur.
            await Clients.AllExcept(connectionIds).SendAsync("receiveMessage", message);
            #endregion
            #region Client
            //Sadece belirtilen id değerine sahip cliente mesaj göndermek için kullanılır.
            await Clients.Client(connectionIds.First()).SendAsync("receiveMessage", message);
            #endregion
            #region Clients
            //Belirtilen id değerlerine sahip tüm clientlara bildirimde bulunur.
            await Clients.Clients(connectionIds).SendAsync("receiveMessage", message);
            #endregion
            #region Group
            //Belirtilen gruptaki tüm clientlara bildiride bulunur. 
            #endregion
            #endregion
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }
    }
}
  