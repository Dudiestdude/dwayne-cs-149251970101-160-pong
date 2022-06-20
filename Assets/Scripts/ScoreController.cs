using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text         leftScore;
    public Text         rightScore;

    public ScoreManager manager;

    private void Update()
    {
        // Press Esc to return to Menu
        if (Input.GetKey(KeyCode.Escape))
            manager.BackToMenu();
        leftScore.text  = manager.leftScore.ToString();
        rightScore.text = manager.rightScore.ToString();
    }
}
