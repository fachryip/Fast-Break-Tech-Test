using UnityEngine;

[CreateAssetMenu(
    fileName = nameof(DefaultPlayerMovement),
    menuName = FilePath.ScriptableObjectPath + "/Player/" + nameof(DefaultPlayerMovement))]
public class DefaultPlayerMovement : BasePlayerMovement
{
    public override void Move(PlayerController player, Vector2 moveInput)
    {
        var moveValue = moveInput * MovementSpeed;
    }
}