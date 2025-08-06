using System.Collections;
using UnityEngine;

#nullable enable

public interface ICourtManager
{
    CourtSpecification CourtSpecification { get; }
    BallController? Ball { get; }

    void PrepareCourt();
    PlayerController GetOtherPlayer(PlayerController player);
}

public class CourtManager : ICourtManager
{
    private readonly GameManagerService _game;

    public CourtSpecification CourtSpecification { get; private set; }
    public BallController? Ball { get; private set; }

    public CourtManager()
    {
        _game = ServiceLocator.Get<GameManagerService>();
        CourtSpecification = Resources.Load<CourtSpecification>(FilePath.DefaultCourtSpecification);

        _game.OnUpdate.AddListener(Tick);
    }

    private void Tick()
    {
        if (Ball != null)
        {
            Ball.Tick();
        }
    }

    public void PrepareCourt()
    {
        var prefab = CourtSpecification.BallPrefab;
        var location = CourtSpecification.BallSpawnLocation;
        var ballObject = Object.Instantiate(prefab, location.Position, location.Rotation);
        Ball = ballObject.GetComponent<BallController>();
        Ball.Initialize();
    }

    public PlayerController GetOtherPlayer(PlayerController player)
    {
        var activePlayers = _game.ClientManager.ActiveClients;
        var maxPlayerCount = CourtSpecification.MaxPlayerCount;
        var isLowerIndex = player.RuntimeData.Index < (maxPlayerCount / 2);
        var from = isLowerIndex ? 0 : maxPlayerCount / 2;
        var to = isLowerIndex ? maxPlayerCount / 2 : maxPlayerCount;
        for (var i = from; i < to; i++)
        {
            if (activePlayers[i].PlayerController != player)
            {
                return activePlayers[i].PlayerController;
            }
        }

        throw new System.Exception("Other player not found from active client list.");
    }

    ~CourtManager()
    {
        _game.OnUpdate.RemoveListener(Tick);
    }
}