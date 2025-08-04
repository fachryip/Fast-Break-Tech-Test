using UnityEngine;

[CreateAssetMenu(
    fileName = nameof(DefaultPlayerShoot), 
    menuName = FilePath.ScriptableObjectPath + "/Player/" + nameof(DefaultPlayerShoot))]
public class DefaultPlayerShoot : BasePlayerShoot
{
    public override void Execute(PlayerController player)
    {
        Debug.Log($"Player:{player.name} Shoot with {nameof(DefaultPlayerShoot)}");
    }
}