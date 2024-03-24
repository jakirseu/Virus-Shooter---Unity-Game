using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject showAboutCanvas;
    public GameObject mainMenuCanvas;


    public void PlayNow()
    {

        SceneManager.LoadScene(1);
        AdManager.HideBanner();
    }

    public void ShowAbout()
    {
        showAboutCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);

    }

    public void ShowMainMenu()
    {
        showAboutCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);

    }

    public void QuitGame()
    {
        Application.Quit();

    }

}