using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTWOprefab : MonoBehaviour
{
    Transform playerTransform;
    float shootingDistance;
    float distanceToPlayer;
    Animator anmControl;
    bool isShooting;
    int enemyHP;
    public GameObject enemyArrows2;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.Find("Player (Archer 1)").transform;
        enemyHP = 3;
        isShooting = false;
        anmControl = GetComponent<Animator>();
        shootingDistance = 7.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < playerTransform.position.x)
        {
            transform.localScale = new Vector2(0.35f, transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(-0.35f, transform.localScale.y);
        }

        distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);



        if (distanceToPlayer < shootingDistance && isShooting == false)
        {
            anmControl.SetBool("IsAttacking", true);
            Instantiate(enemyArrows2, transform.position, transform.rotation);
            isShooting = true;
        }
        if (enemyHP == 0)
        {
            anmControl.SetBool("IsDying", true);
        }












    }

    public void EnemyEndShootingAnimationEvent()
    {
        anmControl.SetBool("IsAttacking", false);
        isShooting = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerArrows")
        {
            enemyHP = enemyHP - 1;
            if (transform.position.x < playerTransform.position.x)
            {
                rb.AddForce(new Vector2(-350, 0));
            }
            else
            {
                rb.AddForce(new Vector2(350, 0));
            }
        }
    }
    public void EnemyEndDyingAnimationEvent()
    {
        anmControl.SetBool("IsDying", false);
        Destroy(gameObject);
    }

}
