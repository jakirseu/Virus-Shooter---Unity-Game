using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusMove : MonoBehaviour
{
    public ParticleSystem particle;
    public float speed = 2;
    public float roation = -100;


    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    private AudioSource audioSource; 

    
    bool hit;

    float frequency = 10.0f; // Speed of sine movement
    float magnitude = 0.8f; //  Size of sine movement
    Vector3 pos;
    Vector3 axis;





    private void Awake()
    {

        hit = false;

        pos = transform.position;
        axis = ChooseRandomAxis(Random.Range(1, 5)); // getting a random axis


        particle = GetComponentInChildren<ParticleSystem>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
        
    }




    void Update()
    {
       
        // checking is hit, so particle will not rotate or move.
        if (!hit)
        {
            pos += Vector3.left * Time.deltaTime * speed;
            transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
            transform.Rotate(0, 0, roation * Time.deltaTime);

        }

    }





    void OnCollisionEnter2D(Collision2D other)
    {

        if ((other.gameObject.tag == "Bullet"))
        {
              Score.score++;

            hit = true;

            Destroy(other.gameObject);
            StartCoroutine(Break());

        } 


    }


    private IEnumerator Break()
    {
        audioSource.Play();

       
        
        particle.Play();

       
        // so bullet will not hit again

        spriteRenderer.enabled = false;
        boxCollider2D.enabled = false;

        yield return new WaitForSeconds(1);


        Destroy(gameObject);

    }



    Vector3 ChooseRandomAxis(int random)
    {

        if (random == 1){
            return transform.right;
        }
        else if (random == 2) {
            return transform.up;
        } else if (random == 3){
            return transform.position * .2f;
        }
        else{
            return transform.position * 0;

        }
        

    }


}
