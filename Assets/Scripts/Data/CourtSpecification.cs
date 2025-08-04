using UnityEngine;

[CreateAssetMenu(
    fileName = nameof(CourtSpecification),
    menuName = FilePath.ScriptableObjectPath + "/Court/" + nameof(CourtSpecification))]
public class CourtSpecification : ScriptableObject
{
    public int MaxPlayerCount;
    public Location[] PlayerLocations;

    public GameObject PlayerPrefab;
    public GameObject BallPrefab;

    [System.Serializable]
    public struct Location
    {
        public Vector3 Position;
        public Quaternion Rotation;
    }
}