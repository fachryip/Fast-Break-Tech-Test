using UnityEngine;
using UnityEngine.Events;

public class GameManagerService : IService
{
    // Intentionally left blank for candidate implementation.
    // Needs to be attached to ServiceLocator
    public BaseScene CurrentScene { get; private set; }

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

        CurrentScene.OnUpdate.AddListener(Update);
    }

    private void Update()
    {
        OnUpdate.Invoke();
    }

    public void Shutdown()
    {
        CurrentScene.OnUpdate.RemoveListener(Update);
    }
}