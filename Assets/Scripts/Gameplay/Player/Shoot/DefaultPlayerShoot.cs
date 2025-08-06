using UnityEngine;

[CreateAssetMenu(
    fileName = nameof(DefaultPlayerShoot), 
    menuName = FilePath.ScriptableObjectPath + "/Player/" + nameof(DefaultPlayerShoot))]
public class DefaultPlayerShoot : BasePlayerShoot
{
    public float Forward;
    public float Up;

    public override void Execute(PlayerController player, BallController ball)
    {
        var direction = player.transform.forward * Forward + player.transform.up * Up;
        
        BallTravelData travelData = new()
        {
            From = player.transform.position,
            To = player.transform.position + direction,
            Speed = ShootSpeed
        };
        ball.Travel(player, travelData);
        Debug.Log($"Player:{player.name} Shoot with data:{travelData} with {nameof(DefaultPlayerShoot)}");
    }
}