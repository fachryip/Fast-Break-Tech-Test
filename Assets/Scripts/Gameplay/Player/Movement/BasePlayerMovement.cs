using System.Collections;
using UnityEngine;

public abstract class BasePlayerMovement : ScriptableObject
{
    public float MovementSpeed;
    public float RotationSpeed;

    public abstract void Move(PlayerController player, Vector2 moveInput);
}