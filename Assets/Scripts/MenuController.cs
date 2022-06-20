using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button firstSelected;

    private void Start()
    {
        firstSelected.Select(); // Select the first button in the Scene
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
        Debug.Log("Created by Dwayne CS - 149251970101-160");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
