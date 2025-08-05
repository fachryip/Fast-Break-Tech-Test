using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private DefaultBallMovement _mechanic;
    [SerializeField] private Rigidbody _rigidbody;

    public BallRuntimeData Data { get; private set; }
    public Rigidbody Rigidbody => _rigidbody;

    // Intentionally left blank for candidate implementation
    public void Initialize()
    {
        Data = gameObject.AddComponent<BallRuntimeData>();
    }

    public void Tick()
    {
        //_mechanic.Tick(this);
    }

    public void TouchPlayer(PlayerController player)
    {
        Data.Empty();
        Data.CurrentPlayer = player;
    }

    public void Travel(PlayerController player, BallTravelData travelData)
    {
        Data.Empty();
        Data.TravelData = travelData;
        _mechanic.Travel(this, player, travelData);
        Debug.Log($"Ball Travel Data:{travelData}");
    }
}