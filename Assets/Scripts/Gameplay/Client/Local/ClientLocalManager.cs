
using UnityEngine;

public class ClientLocalManager : IClientManager
{
    private bool _isReady;

    private GameManagerService _game;
    private CourtSpecification _courtSpecification;

    public IClientController[] ActiveClients { get; private set; }

    public ClientLocalManager()
    {
        _game = ServiceLocator.Get<GameManagerService>();
        _game.OnUpdate.AddListener(Tick);
        _game.OnMatchReady.AddListener(OnMatchReady);

        PreLoadObject();
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
        int maxPlayerCount = _courtSpecification.MaxPlayerCount;
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

    private void PreLoadObject()
    {
        _courtSpecification = Resources.Load<CourtSpecification>(FilePath.DefaultCourtSpecification);
    }

    private void SpawnClient(int index, ClientLocalInput input)
    {
        var client = new ClientLocalController(this, input);
        var location = _courtSpecification.PlayerLocations[index];
        client.SpawnPlayer(_courtSpecification.PlayerPrefab, location.Position, location.Rotation);

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
