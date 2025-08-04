using UnityEngine.Events;

public interface IGameplayScene : IInitializable
{
    IClientManager ClientManager { get; }

    UnityEvent OnUpdate { get; }

}