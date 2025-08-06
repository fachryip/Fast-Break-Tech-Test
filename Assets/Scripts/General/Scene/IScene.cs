using UnityEngine.Events;

public interface IScene : IInitializable
{
    UnityEvent OnUpdate { get; }
}