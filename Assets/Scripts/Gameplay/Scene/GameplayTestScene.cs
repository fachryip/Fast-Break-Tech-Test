using System.Collections;
using UnityEngine;

public class GameplayTestScene : BaseScene
{
    private bool _isInitialize = false;
    private GameManagerService _game;

    public override void Initialize()
    {
        if (_isInitialize) return;

        _isInitialize = true;
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
        _game.PrepareMatch();

        yield return new WaitForSeconds(0.5f);
        _game.MatchReady();
    }
}