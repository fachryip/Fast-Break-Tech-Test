using UnityEngine;

public class PlayerController : MonoBehaviour, ITickable
{
    // Intentionally left blank for candidate implementation
    [SerializeField] private PlayerView _view;
    [SerializeField] private BasePlayerMovement _movement;
    [SerializeField] private BasePlayerShoot _shoot;
    [SerializeField] private BasePlayerPass _pass;
    [SerializeField] private BasePlayerBallHandler _ballHandler;
    [SerializeField] private ColliderEventTrigger _colliderEventTrigger;

    private bool _isInitialize;

    public PlayerView View => _view;
    public BasePlayerMovement Movement => _movement;
    public BasePlayerShoot Shoot => _shoot;
    public BasePlayerPass Pass => _pass;
    public BasePlayerBallHandler BallHandler => _ballHandler;

    public PlayerRuntimeData RuntimeData { get; private set; }
    public IPlayerInput Input { get; private set; }

    public void Initialize()
    {
        if (_isInitialize) return;

        _isInitialize = true;
        RuntimeData = gameObject.AddComponent<PlayerRuntimeData>();

        Input = new PlayerInput(this);
        Input.OnMove.AddListener(PlayerMove);
        Input.OnShootClicked.AddListener(PlayerShoot);
        Input.OnPassClicked.AddListener(PlayerPass);

        _colliderEventTrigger.OnEventCollisionEnter.AddListener(CollisionEnter);
    }

    public void Tick()
    {
        Input.Tick();
        BallHandler.Tick(this);
    }

    private void PlayerMove(Vector2 moveInput)
    {
        Movement.Move(this, moveInput);
    }

    private void PlayerShoot()
    {
        if (!RuntimeData.HasBall) return;

        var ball = RuntimeData.Ball;
        RuntimeData.Ball = null;
        Shoot.Execute(this, ball);
    }

    private void PlayerPass()
    {
        if (!RuntimeData.HasBall) return;

        var ball = RuntimeData.Ball;
        RuntimeData.Ball = null;
        //Pass.Execute(this, ball);
    }

    private void CollisionEnter(GameObject player, Collision collision)
    {
        var otherObject = collision.gameObject;
        if (otherObject.CompareTag("Ball") &&
            otherObject.TryGetComponent<BallController>(out var ball))
        {
            BallHandler.TouchBall(this, ball);
            ball.TouchPlayer(this);
        }
    }
}