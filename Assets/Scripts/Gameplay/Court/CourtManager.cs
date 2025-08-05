using System.Collections;
using UnityEngine;

#nullable enable

public interface ICourtManager
{
    CourtSpecification CourtSpecification { get; }
    BallController? Ball { get; }

    void PrepareCourt();
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

    ~CourtManager()
    {
        _game.OnUpdate.RemoveListener(Tick);
    }
}