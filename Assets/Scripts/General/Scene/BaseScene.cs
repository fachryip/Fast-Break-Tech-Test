using UnityEngine;
using UnityEngine.Events;

public abstract class BaseScene : MonoBehaviour, IScene
{
    public UnityEvent OnUpdate { get; private set; } = new();

    public abstract void Initialize();
}