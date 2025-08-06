using UnityEngine;

#nullable enable

public class ClientLocalController : IClientController
{
    private readonly IClientManager _clientManager;
    private readonly ClientLocalInput? _input;

    public PlayerController? PlayerController { get; private set; }

    public ClientLocalController(IClientManager clientManager, ClientLocalInput? input)
    {
        _clientManager = clientManager; 
        _input = input;
    }

    public void Tick()
    {
        if (_input != null)
        {
            _input.Tick(PlayerController);
        }

        if (PlayerController != null)
        {
            PlayerController.Tick();
        }
    }

    public void SpawnPlayer(GameObject playerPrefab, Vector3 position, Quaternion rotation, int index)
    {
        var playerObject = Object.Instantiate(playerPrefab, position, rotation);
        PlayerController = playerObject.GetComponent<PlayerController>();
        PlayerController.Initialize(index);
    }
}