
using UnityEngine;

public class ClientLocalManager : IClientManager
{
    private bool _isReady;

    private GameManagerService _game;

    public IClientController[] ActiveClients { get; private set; }

    public ClientLocalManager()
    {
        _game = ServiceLocator.Get<GameManagerService>();
        _game.OnUpdate.AddListener(Tick);
        _game.OnMatchReady.AddListener(OnMatchReady);
    }

    public void Tick()
    {
        if (!_isReady) return;
        if (ActiveClients == null) return;

        for (int i = 0; i < ActiveClients.Length; i++)
        {
            ActiveClients[i].Tick();
        }
    }

    public void SpawnAllClient()
    {
        var courtSpecification = _game.CourtManager.CourtSpecification;
        int maxPlayerCount = courtSpecification.MaxPlayerCount;
        ActiveClients = new IClientController[maxPlayerCount];

        // player active
        SpawnClient(0, Resources.Load<ClientLocalInput>(FilePath.ClientLocalInputWasd));
        SpawnClient(1, Resources.Load<ClientLocalInput>(FilePath.ClientLocalInputArrow));
        // --

        // other player
        SpawnClient(2, null);
        SpawnClient(3, null);
        // --
    }

    private void SpawnClient(int index, ClientLocalInput input)
    {
        var courtSpecification = _game.CourtManager.CourtSpecification;

        var client = new ClientLocalController(this, input);
        var location = courtSpecification.PlayerSpawnLocations[index];
        client.SpawnPlayer(courtSpecification.PlayerPrefab, location.Position, location.Rotation);

        ActiveClients[index] = client;
    }

    private void OnMatchReady()
    {
        _isReady = true;
    }

    ~ClientLocalManager()
    {
        _game.OnUpdate.RemoveListener(Tick);
        _game.OnMatchReady.RemoveListener(OnMatchReady);
    }
}
