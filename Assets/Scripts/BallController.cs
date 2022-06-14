using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2          speed;
    public PaddleController paddleLeft;
    public PaddleController paddleRight;
    private Rigidbody2D     _rig;

    private void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        _rig.velocity = speed;
        transform.Translate(speed * Time.deltaTime);
    }

    private void Update()
    {
        if (transform.position.y > 5.5 || transform.position.y < -5.5) // If Ball bugs out and phases pass the wall
            if (transform.position.x > 0) // If ball is on the right side of the middle line
                ResetBall(true);
            else
                ResetBall(false);
    }

    public void ResetBall(bool isRight)
    {
        if (isRight == true) // If ball is on the right
        {
            transform.position = new Vector2(0f, 4f); // Reset ball position
            _rig.velocity = new Vector2(speed.x * -1, speed.y); // Reset ball speed & flip direction
        }
        else // If ball is on the left
        {
            transform.position = new Vector2(0f, 4f); // Reset ball position
            _rig.velocity = new Vector2(speed.x, speed.y); // Reset ball speed & flip direction
        }

        // Reset Paddle Position
        paddleLeft.ResetPaddle();
        paddleRight.ResetPaddle();
    }

    public void ActivatePUSpeedUp(float magnitude)
    {
        _rig.velocity *= magnitude;
    }
}
