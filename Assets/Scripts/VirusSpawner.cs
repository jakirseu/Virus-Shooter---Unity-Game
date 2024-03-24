using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawner : MonoBehaviour
{
    public float maxTime = 2;
    public GameObject[] virus;

    private float timer;
    public float height;

    Rigidbody2D rb2d;



    float  bigCountdown = 20; // 30 seconds is  half minutes
    float currentBigTime = 0;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (timer > maxTime)
        {
          
            GameObject newVirus = Instantiate(virus[Random.Range(0, virus.GetLength(0))],
                new Vector3(rb2d.position.x, rb2d.position.y + Random.Range(-height, height)), Quaternion.identity);

            Destroy(newVirus, 10);
            timer = 0;
        }

        // increase spawn rate. it we will increase spawn rate after 30 seconds 

        currentBigTime += Time.deltaTime;

        if (currentBigTime> bigCountdown)
        {
            currentBigTime = 0;
            if (maxTime > .6f)
            {
                maxTime -= .2f;
            }
           

        }

        timer += Time.deltaTime;

    }
}
