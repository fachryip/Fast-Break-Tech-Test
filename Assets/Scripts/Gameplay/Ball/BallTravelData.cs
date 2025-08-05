using UnityEngine;

[System.Serializable]
public struct BallTravelData
{
    public Vector3 From;
    public Vector3 To;
    public float Speed;

    public override readonly string ToString()
    {
        return $"From:{From} To:{To} Speed:{Speed}";
    }
}