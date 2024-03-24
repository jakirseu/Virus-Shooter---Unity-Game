using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
 

    public void GameOver()
    {
       

        gameOverCanvas.SetActive(true);
     

        AdManager.ShowIntersitial();
        AdManager.ShowBanner();


    }


    public void Replay()
    {
        SceneManager.LoadScene(1);
        AdManager.HideBanner();

    }


    public void mainMenu()
    {
        SceneManager.LoadScene(0);
        AdManager.HideBanner();
    }

    public void Exit()
    {
        Application.Quit();
    }

}
