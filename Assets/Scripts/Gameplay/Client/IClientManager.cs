public interface IClientManager : ITickable
{
    IClientController[] ActiveClients { get; }

    void SpawnAllClient();
}