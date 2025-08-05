using System.Collections;
using UnityEngine;

public abstract class BasePlayerBallHandler : ScriptableObject
{
    public abstract void Tick(PlayerController player);
    public abstract void TouchBall(PlayerController player, BallController ball);
}