using UnityEngine;

[CreateAssetMenu(
    fileName = nameof(ClientLocalInput),
    menuName = FilePath.ScriptableObjectPath + "/Client/Local/" + nameof(ClientLocalInput))]
public class ClientLocalInput : ScriptableObject
{
    public InputType InputType;
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Shoot;
    public KeyCode Pass;

    public void Tick(PlayerController player)
    {
        var input = player.Input;
        input.Left(Input.GetKey(Left));
        input.Right(Input.GetKey(Right));
        input.Up(Input.GetKey(Up));
        input.Down(Input.GetKey(Down));
        input.Shoot(Input.GetKey(Shoot));
        input.Pass(Input.GetKey(Pass));
    }
}