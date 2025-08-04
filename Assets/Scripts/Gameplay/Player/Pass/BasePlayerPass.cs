using UnityEngine;

public abstract class BasePlayerPass : ScriptableObject
{
    public abstract void Execute(PlayerController player);
}