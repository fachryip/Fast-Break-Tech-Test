using UnityEngine;

[CreateAssetMenu(
    fileName = nameof(DefaultBallMovement),
    menuName = FilePath.ScriptableObjectPath + "/Ball/" + nameof(DefaultBallMovement))]
public class DefaultBallMovement : ScriptableObject
{
    public virtual void Tick(BallController ball)
    {
        if (!ball.Data.HasTravelData) return;

        var data = ball.Data.TravelData.Value;
        var direction = data.To - ball.transform.position;
        ball.transform.position = Vector3.Lerp(ball.transform.position, direction, data.Speed * Time.deltaTime);
    }

    public virtual void Travel(BallController ball, PlayerController player, BallTravelData data)
    {
        var direction = (data.To - data.From) * data.Speed;
        ball.Rigidbody.AddForce(direction, ForceMode.Impulse);
    }
}
