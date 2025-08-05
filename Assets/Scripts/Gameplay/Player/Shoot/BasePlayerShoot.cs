using UnityEngine;

public abstract class BasePlayerShoot : ScriptableObject
{
    public float ShootSpeed;

    public abstract void Execute(PlayerController player, BallController ball);
}