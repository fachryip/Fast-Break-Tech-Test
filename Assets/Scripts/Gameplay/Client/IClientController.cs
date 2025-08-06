using UnityEngine;

public interface IClientController : ITickable
{
    PlayerController PlayerController { get; }

    void SpawnPlayer(GameObject playerPrefab, Vector3 position, Quaternion rotation, int index);
}
