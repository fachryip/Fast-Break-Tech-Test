using UnityEngine;

[CreateAssetMenu(
    fileName = nameof(DefaultPlayerPass),
    menuName = FilePath.ScriptableObjectPath + "/Player/" + nameof(DefaultPlayerPass))]
public class DefaultPlayerPass : BasePlayerPass
{
    public override void Execute(PlayerController player, PlayerController otherPlayer, BallController ball)
    {
        BallTravelData travelData = new()
        {
            From = player.transform.position,
            To = otherPlayer.transform.position,
            Speed = PassSpeed
        };
        ball.Travel(player, travelData);

        Debug.Log($"Player:{player.name} Pass to {otherPlayer.name} with {nameof(DefaultPlayerPass)}");
    }
}