using System.Collections;
using UnityEngine;

public class GameplayTestScene : BaseScene
{
    private bool _isInitialize = false;
    private GameManagerService _game;

    public IClientManager ClientManager { get; private set; }

    public override void Initialize()
    {
        if (_isInitialize) return;

        _isInitialize = true;
        ClientManager = new ClientLocalManager();
        _game = ServiceLocator.Get<GameManagerService>();

        StartCoroutine(StartDelay());
    }

    private void Update()
    {
        if(!_isInitialize) return;

        OnUpdate.Invoke();
    }

    private IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(0.5f);
        ClientManager.SpawnAllClient();

        yield return new WaitForSeconds(0.5f);
        _game.OnMatchReady.Invoke();
        Debug.Log($"OnMatchReady");
    }
}