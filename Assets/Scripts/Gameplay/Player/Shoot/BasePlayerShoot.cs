using UnityEngine;

public abstract class BasePlayerShoot : ScriptableObject
{
    public abstract void Execute(PlayerController player);
}