using UnityEngine;

[CreateAssetMenu(
    fileName = nameof(DefaultPlayerMovement),
    menuName = FilePath.ScriptableObjectPath + "/Player/" + nameof(DefaultPlayerMovement))]
public class DefaultPlayerMovement : BasePlayerMovement
{
    public override void Move(PlayerController player, Vector2 moveInput)
    {
        if (moveInput == Vector2.zero) return;

        Movement(player, moveInput);
        Rotation(player, moveInput);
    }

    private void Movement(PlayerController player, Vector2 moveInput)
    {
        var value = moveInput * MovementSpeed * Time.deltaTime;
        var direction = new Vector3(value.x, player.transform.position.y, value.y);
        player.transform.position += direction;
    }

    private void Rotation(PlayerController player, Vector2 moveInput)
    {
        var speed = RotationSpeed * Time.deltaTime;
        var moveForward = new Vector3(moveInput.x, 0f, moveInput.y);
        player.transform.forward = Vector3.Lerp(player.transform.forward, moveForward, speed);
    }
}