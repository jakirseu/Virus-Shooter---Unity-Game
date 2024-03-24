using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int score = 0;

    void Start()
    {
        score = 0;
    }


    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = score.ToString();


        if (Score.score > HighScore.highscore)
        {
            HighScore.highscore = Score.score;

        }
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("highscore", HighScore.highscore);
        PlayerPrefs.Save();
    }

}