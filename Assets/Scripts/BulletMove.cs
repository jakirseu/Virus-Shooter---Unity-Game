using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed = 8;
    Rigidbody2D rigidbody2d;


    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        transform.position += Vector3.right * speed * Time.deltaTime;

    }

}
