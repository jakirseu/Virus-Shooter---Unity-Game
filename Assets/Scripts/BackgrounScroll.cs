using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgrounScroll : MonoBehaviour
{
    public float speed = .2f;


    void Update()
    {

        GetComponent<Renderer>().material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 1f); ;

    }
}
