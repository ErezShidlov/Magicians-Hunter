using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrowsAnimation : MonoBehaviour
{
    Transform playerPosition;
    bool shootRight;
    void Start()
    {
        playerPosition = GameObject.Find("Player (Archer 1)").transform;
        if (playerPosition.position.x > transform.position.x)
        {
            shootRight = true;
        }
        else
        {
            shootRight = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shootRight == true)
        {
            transform.Translate(12 * Time.deltaTime, 0, 0);
 
        }
        else if (shootRight == false)
        {
            transform.Translate(-12 * Time.deltaTime, 0, 0);

        }

    }
  
}
