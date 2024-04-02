using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float xPos;
    public float speed;
    Rigidbody2D rb;
    public bool canJump;
    Animator anmControl;
    static bool Attacking;
    void Start()
    {
        speed = 7.5f;
        rb = GetComponent<Rigidbody2D>();
        anmControl = GetComponent<Animator>();
    }

 
    void Update()
    {


        //Player Movement
        if (Input.GetKey(KeyCode.RightArrow))
        {
            xPos = 1;
            transform.localScale = new Vector2 (0.35f, transform.localScale.y);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            xPos = -1;
            transform.localScale = new Vector2 (-0.35f, transform.localScale.y);
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



        //Player Jumping
        if (Input.GetKey(KeyCode.Space) && canJump == true)
        {
            rb.AddForce(new Vector2(0, 300));
            canJump = false;
            anmControl.SetBool("IsJumping", true);
        }





        //Player Attacking
        if (Input.GetKey(KeyCode.D))
        {
            speed = 1;
            Attacking = true;
            anmControl.SetBool("isAttacking", true);
        }
        else
        {
            Attacking = false;
          
        }
       
        if (Attacking == false)
        {
            anmControl.SetBool("isAttacking", false);
            speed = 3;
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
}
