using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int leftScore;
    public int rightScore;
    public int maxScore;

    private bool _isRight;

    public BallController ball;

    public void AddLeftScore(int increment)
    {
        _isRight = true;
        ball.ResetBall(_isRight); // Reset ball position and speed
        leftScore += increment;
        if (leftScore >= maxScore)
            LeftWon(); // Go to Left Win Scene
    }

    public void AddRightScore(int increment)
    {
        _isRight = false;
        ball.ResetBall(_isRight); // Reset ball position and speed
        rightScore += increment;
        if (rightScore >= maxScore)
            RightWon(); // Go to Right Win Scene
    }

    public void LeftWon()
    {
        SceneManager.LoadScene("LeftWon");
        Debug.Log("Left Wins");
    }

    public void RightWon()
    {
        SceneManager.LoadScene("RightWon");
        Debug.Log("Right Wins");
    }
}
