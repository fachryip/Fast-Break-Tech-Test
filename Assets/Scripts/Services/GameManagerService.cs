using UnityEngine;
using UnityEngine.Events;

public class GameManagerService : IService
{
    // Intentionally left blank for candidate implementation.
    // Needs to be attached to ServiceLocator
    public BaseScene CurrentScene { get; private set; }

    public IClientManager ClientManager { get; private set; }
    public ICourtManager CourtManager { get; private set; }

    public UnityEvent OnMatchReady { get; private set; } = new();
    public UnityEvent OnUpdate { get; private set; } = new();

    public string GetServiceName()
    {
        return nameof(GameManagerService);
    }

    public void Initialize()
    {
        CurrentScene = Object.FindAnyObjectByType<BaseScene>();
        CurrentScene.Initialize();

        ClientManager = new ClientLocalManager();
        CourtManager = new CourtManager();

        CurrentScene.OnUpdate.AddListener(Update);
    }

    private void Update()
    {
        OnUpdate.Invoke();
    }

    public void PrepareMatch()
    {
        ClientManager.SpawnAllClient();
        CourtManager.PrepareCourt();
    }

    public void MatchReady()
    {
        OnMatchReady.Invoke();
        Debug.Log($"OnMatchReady");
    }

    public void Shutdown()
    {
        CurrentScene.OnUpdate.RemoveListener(Update);
    }
}