using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefab : MonoBehaviour
{
    public GameObject enemyArrowsPrefab;
    Transform playerTransform;
    float shootingDistance;
    float distanceToPlayer;
    Animator anmControl;
    bool isShooting;
    int enemyHP;
    Rigidbody2D rb;
    void Start()
    {
        enemyHP = 3;
        isShooting = false;
        anmControl = GetComponent<Animator>();
        playerTransform = GameObject.Find("Player (Archer 1)").transform;
        shootingDistance = 5f;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.x < playerTransform.position.x)
        {
            transform.Translate(1.5f * Time.deltaTime, 0, 0);
            transform.localScale = new Vector2(0.3f, transform.localScale.y);
        }
        else
        {
            transform.Translate(-1.5f * Time.deltaTime, 0, 0);
            transform.localScale = new Vector2(-0.3f, transform.localScale.y);
        }

        distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer < shootingDistance && isShooting == false)
        {
            anmControl.SetBool("IsAttacking", true);
            Instantiate(enemyArrowsPrefab, transform.position, transform.rotation);
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
