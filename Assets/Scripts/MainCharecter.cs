using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharecter : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public GameObject bulletPrefab;
    Collider2D collider2d;


    public GameManager gameManager;
    private ParticleSystem particle;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    private AudioSource audioSource;


    private float jumpForce =  5f;
    float forwardForce = 0f;


    private float bulletTime = 0f;
    private float bulletMaxTime = .4f;


    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;

        particle = GetComponentInChildren<ParticleSystem>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();

        collider2d = GetComponent<Collider2D>();

    }


    void Update()
    {

        if (Input.GetKeyDown("c"))
        {
            Jump();
        }

        if (Input.GetMouseButtonDown(0))
        {
            LaunchBullet();
        }

        CheckForJump();


        bulletTime += Time.deltaTime;



    }


    void CheckForJump()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            var wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            var touchPosition = new Vector2(wp.x, wp.y);

            if (collider2d == Physics2D.OverlapPoint(touchPosition))
            {

                
                    Jump();
               

            }

        }

    }


    public void Jump()
    {
        if (rb2d.velocity.y == 0)
        {

            forwardForce = 0f;
            rb2d.velocity = new Vector2(forwardForce, jumpForce);

            }
    }




    void LaunchBullet()
    {

        if(bulletTime > bulletMaxTime)
        {
        GameObject newBullet = Instantiate(bulletPrefab, new Vector3(rb2d.position.x + 1f, rb2d.position.y - .4f, 0f), Quaternion.identity);
        Destroy(newBullet, 10);

        bulletTime = 0f;

        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Virus")
        {

            StartCoroutine(Break());
            Destroy(other.gameObject);


        }


    }

    private IEnumerator Break()
    {
       particle.Play();
        audioSource.Play();
        spriteRenderer.enabled = false;
        boxCollider2D.enabled = false;

        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);

        gameManager.GameOver();



    }
}
