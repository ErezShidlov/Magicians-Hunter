using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArcherOneMovement : MonoBehaviour
{
    public static int playerHP;
    float xPos;
    public float speed;
    public bool canJump;
    Vector2 respawnPosition;
    public GameObject arrowsPrefab;
    Rigidbody2D rb;
    Animator anmControl;
    public static int Coins;
    public static bool haveKey;
    public AudioSource audioS;
    public AudioClip arrowShootingSound;
    public AudioClip coin;
    bool walkRight;

    void Start()
    {
        respawnPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        anmControl = GetComponent<Animator>();
        speed = 7.5f;
        playerHP = 5;
        haveKey = false;
    }

    void Update()
    {
        print(playerHP);
        //WALK
        if (Input.GetKey(KeyCode.RightArrow))
        {
            xPos = 1;
            transform.localScale = new Vector2(0.35f, transform.localScale.y);
            walkRight = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            xPos = -1;
            transform.localScale = new Vector2(-0.35f, transform.localScale.y);
            walkRight = false;
        }
        else
        {
            xPos = 0;
        }
        transform.position = new Vector2(transform.position.x + xPos * speed * Time.deltaTime, transform.position.y);

        if (xPos != 0)
        {
            anmControl.SetBool("IsWalking", true);
        }
        else
        {
            anmControl.SetBool("IsWalking", false);
        }


        //JUMP
        if (Input.GetKey(KeyCode.Space) && canJump == true)
        {
            rb.AddForce(new Vector2(0, 300));
            canJump = false;
            anmControl.SetBool("IsJumping", true);
        
        }

        //SHOOT
        if (Input.GetKeyDown(KeyCode.X))
        {
            anmControl.SetBool("IsShooting", true);
            speed = 5f;
            audioS.PlayOneShot(arrowShootingSound);
        }

        if (playerHP <= 0)
        {
            anmControl.SetBool("IsDying", true);
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tag")
        {
            canJump = true;
            anmControl.SetBool("IsJumping", false);
        }
    }

    public void EndShootingAnimationEvent()
    {
        anmControl.SetBool("IsShooting", false);
        speed = 7.5f;
    }
    public void ArrowsAnimationEvent()
    {
        Instantiate(arrowsPrefab, transform.position, transform.rotation);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyArrows")
        {
            playerHP = playerHP - 1;
            if (walkRight == true)
            {
                rb.AddForce(new Vector2(-200, 0));
            }
            else
            {
                rb.AddForce(new Vector2(200, 0));
            }
        }

        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            Coins = Coins + 1;
            audioS.PlayOneShot(coin);
        }

        if (collision.gameObject.tag == "HP")
        {
            Destroy(collision.gameObject);
            playerHP = playerHP + 1;
            audioS.PlayOneShot(coin);
        }

        if (collision.gameObject.tag == "Key")
        {
            Destroy(collision.gameObject);
            haveKey = true;
            Vector2 newPosition = new Vector2(2.46f, 3.7f);
            audioS.PlayOneShot(coin);
        }
        if (collision.gameObject.tag == "Border")
        {
            transform.position = respawnPosition;
        }

    }
    public void EndDyingAnimationEvent()
    {
        anmControl.SetBool("IsDying", false);
        transform.position = respawnPosition;
        playerHP = 5;
    }
}
