using System.Collections;
using UnityEngine;

#nullable enable

public class PlayerRuntimeData : MonoBehaviour
{
    public BallController? Ball;

    public bool HasBall => Ball != null;
}