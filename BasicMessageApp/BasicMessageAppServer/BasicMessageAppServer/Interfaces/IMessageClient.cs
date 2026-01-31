namespace BasicMessageAppServer.Interfaces
{
    public interface IMessageClient
    {
        Task Clients(List<string> clients);
        Task UserJoined(string collectionId);
        Task UserLeaved(string collectionId);
    }
}
