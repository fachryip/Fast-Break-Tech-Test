using UnityEngine;

public abstract class BasePlayerPass : ScriptableObject
{
    public float PassSpeed;

    public abstract void Execute(PlayerController player, PlayerController otherPlayer, BallController ball);
}