using UnityEngine;

public class PlayerController : MonoBehaviour, ITickable
{
    // Intentionally left blank for candidate implementation
    [SerializeField] private PlayerConfiguration Configuration;

    private bool _isInitialize;

    public IPlayerInput Input { get; private set; }
    public BasePlayerMovement Movement => Configuration.Movement;
    public BasePlayerShoot Shoot => Configuration.Shoot;
    public BasePlayerPass Pass => Configuration.Pass;

    public void Initialize()
    {
        if (_isInitialize) return;

        _isInitialize = true;
        Input = new PlayerInput(this);

        Input.OnMove.AddListener(PlayerMove);
        Input.OnShootClicked.AddListener(PlayerShoot);
        Input.OnPassClicked.AddListener(PlayerPass);
    }

    public void Tick()
    {
        Input.Tick();
    }

    private void PlayerMove(Vector2 moveInput)
    {
        Movement.Move(this, moveInput);
    }

    private void PlayerShoot()
    {
        Shoot.Execute(this);
    }

    private void PlayerPass()
    {
        Pass.Execute(this);
    }
}