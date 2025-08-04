
using UnityEngine;
using UnityEngine.Events;

public interface IPlayerInput : ITickable
{
    UnityEvent OnLeftClicked { get; }
    UnityEvent OnRightClicked { get; }
    UnityEvent OnUpClicked { get; }
    UnityEvent OnDownClicked { get;}
    UnityEvent OnShootClicked { get; }
    UnityEvent OnPassClicked { get; }
    UnityEvent<Vector2> OnMove { get; }

    void Left(bool isPressed);
    void Right(bool isPressed);
    void Up(bool isPressed);
    void Down(bool isPressed);
    void Shoot(bool isPressed);
    void Pass(bool isPressed);
}