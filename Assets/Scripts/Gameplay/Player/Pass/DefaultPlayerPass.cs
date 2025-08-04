using UnityEngine;

[CreateAssetMenu(
    fileName = nameof(DefaultPlayerPass),
    menuName = FilePath.ScriptableObjectPath + "/Player/" + nameof(DefaultPlayerPass))]
public class DefaultPlayerPass : BasePlayerPass
{
    public override void Execute(PlayerController player)
    {
        Debug.Log($"Player:{player.name} Pass with {nameof(DefaultPlayerPass)}");
    }
}