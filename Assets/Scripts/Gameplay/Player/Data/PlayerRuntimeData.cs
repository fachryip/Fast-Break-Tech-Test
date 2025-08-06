using System.Collections;
using UnityEngine;

#nullable enable

public class PlayerRuntimeData : MonoBehaviour
{
    public int Index;
    public BallController? Ball;

    public bool HasBall => Ball != null;
}