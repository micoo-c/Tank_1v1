using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI
;
public class CharacterController2 : MonoBehaviour
{ 
    Rigidbody2D body;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    public float runSpeed = 2;
    public float health = 100;
    private float smokeWait = 1.0f;
    float lastSmoke = 0.0f;
    public bool alive = true;

    public GameObject damaged;
    public Sprite destroyed;
    public Transform smokePoint;
    public AudioSource moving;
    public AudioSource idle;
    public AudioSource explosion;
    public AudioSource hit;
    public GameObject fireball;

    public GameManager gameManager;

    SpriteRenderer sr;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        moving.Play();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal2");
        vertical = Input.GetAxisRaw("Vertical2");
    }

    void FixedUpdate()
    {
        if (alive == true)
        {
            if (horizontal == 0 && vertical == 0)
            {
            }
            if (horizontal != 0 && vertical != 0)
            {
                body.velocity = new Vector2((horizontal * runSpeed) * moveLimiter, (vertical * runSpeed) * moveLimiter);

            }
            else
            {
                body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
            }
            Vector2 moveVec = new Vector2(horizontal, vertical);
            body.AddForce(moveVec);

            if (moveVec != Vector2.zero)
            {
                transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVec);
            }
        }
        else
        {
            body.velocity = new Vector2(horizontal * 0, vertical * 0);
        }
        if (health <= 50)
        {
            if (Time.time > smokeWait + lastSmoke)
            {
                GameObject clone = Instantiate(damaged, smokePoint.position, Quaternion.identity);
                Destroy(clone, 1.0f);
                lastSmoke = Time.time;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        hit.Play();
        if (health == 0)
        {
            moving.Stop();
            explosion.Play();
            Instantiate(fireball, smokePoint.position, Quaternion.identity);
            sr.sprite = destroyed;
            runSpeed = 0;
            alive = false;
            new WaitForSeconds(1);
            gameManager.GreenCompletedLevel();
        }
    }
}

