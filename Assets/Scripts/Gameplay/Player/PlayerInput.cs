using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : IPlayerInput
{
    private PlayerController _player;

    public UnityEvent OnLeftClicked { get; private set; } = new();
    public UnityEvent OnRightClicked { get; private set; } = new();
    public UnityEvent OnUpClicked { get; private set; } = new();
    public UnityEvent OnDownClicked { get; private set; } = new();
    public UnityEvent OnShootClicked { get; private set; } = new();
    public UnityEvent OnPassClicked { get; private set; } = new();
    public UnityEvent<Vector2> OnMove { get; private set; } = new();
    
    public InputData Data { get; private set; }

    public PlayerInput(PlayerController player)
    {
        _player = player;
        Data = _player.gameObject.AddComponent<InputData>();
    }

    public void Tick()
    {
        VerifyInput();
        OnMove.Invoke(new Vector2(Data.HorizontalValue, Data.VerticalValue));
    }

    public void Left(bool isPressed)
    {
        if (isPressed)
        {
            if (Data.IsLeftPressed != isPressed)
            {
                OnLeftClicked.Invoke();
            }
            Data.HorizontalValue = -1;
        }

        Data.IsLeftPressed = isPressed;
    }

    public void Right(bool isPressed)
    {
        if (isPressed)
        {
            if (Data.IsRightPressed != isPressed)
            {
                OnRightClicked.Invoke();
            }
            Data.HorizontalValue = 1;
        }

        Data.IsRightPressed = isPressed;
    }

    public void Up(bool isPressed)
    {
        if (isPressed)
        {
            if (Data.IsUpPressed != isPressed)
            {
                OnUpClicked.Invoke();
            }
            Data.VerticalValue = 1;
        }

        Data.IsUpPressed = isPressed;
    }

    public void Down(bool isPressed)
    {
        if (isPressed)
        {
            if (Data.IsDownPressed != isPressed)
            {
                OnDownClicked.Invoke();
            }
            Data.VerticalValue = -1;
        }

        Data.IsDownPressed = isPressed;
    }

    public void Shoot(bool isPressed)
    {
        if (isPressed && Data.IsShootPressed != isPressed)
        {
            OnShootClicked.Invoke();
        }
        Data.IsShootPressed = isPressed;
    }

    public void Pass(bool isPressed)
    {
        if (isPressed && Data.IsPassPressed != isPressed)
        {
            OnPassClicked.Invoke();
        }
        Data.IsPassPressed = isPressed;
    }

    private void VerifyInput()
    {
        if (Data.IsLeftPressed && Data.IsRightPressed ||
            !Data.IsLeftPressed && !Data.IsRightPressed)
        {
            Data.HorizontalValue = 0;
        }

        if (Data.IsUpPressed && Data.IsDownPressed ||
            !Data.IsUpPressed && !Data.IsDownPressed)
        {
            Data.VerticalValue = 0;
        }
    }
}