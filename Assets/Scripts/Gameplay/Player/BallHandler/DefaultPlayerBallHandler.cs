using System.Collections;
using UnityEngine;

[CreateAssetMenu(
    fileName = nameof(DefaultPlayerBallHandler),
    menuName = FilePath.ScriptableObjectPath + "/Player/" + nameof(DefaultPlayerBallHandler))]
public class DefaultPlayerBallHandler : BasePlayerBallHandler
{
    public override void Tick(PlayerController player)
    {
        if (!player.RuntimeData.HasBall) return;

        var ball = player.RuntimeData.Ball;
        ball.transform.position = player.View.BallLocation.position;
        ball.transform.rotation = Quaternion.identity;
    }

    public override void TouchBall(PlayerController player, BallController ball)
    {
        if (ball.Data.HasPlayer) return;

        player.RuntimeData.Ball = ball;
        ball.transform.position = player.View.BallLocation.position;
        ball.transform.rotation = Quaternion.identity;
    }
}