using System.Collections;
using UnityEngine;

#nullable enable

public class BallRuntimeData : MonoBehaviour
{
    public PlayerController? CurrentPlayer;
    public BallTravelData? TravelData;

    public bool HasPlayer => CurrentPlayer != null;
    public bool HasTravelData => TravelData != null;

    public void Empty()
    {
        CurrentPlayer = null;
        TravelData = null;
    }
}