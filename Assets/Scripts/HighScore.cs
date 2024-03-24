using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public static int highscore;

    void Start()
    {

        highscore = PlayerPrefs.GetInt("highscore", highscore);

        GetComponent<UnityEngine.UI.Text>().text = "High Score: " + highscore.ToString();

    }
}
