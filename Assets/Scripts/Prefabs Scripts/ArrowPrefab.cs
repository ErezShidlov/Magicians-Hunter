using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPrefab : MonoBehaviour
{
    public Transform playerScale;
    bool faceRight;
    void Start()
    {
        playerScale = GameObject.Find("Player (Archer 1)").transform;

        if (playerScale.localScale.x > 0)
        {
            faceRight = true;
        }
        else
        {
            faceRight = false;
        }
    }

    void Update()
    {
        if (faceRight == true)
        {
            transform.Translate(15 * Time.deltaTime, 0, 0);
            transform.localScale = new Vector2(0.35f, transform.localScale.y);
        }
        else
        {
            transform.Translate(-15 * Time.deltaTime, 0, 0);
            transform.localScale = new Vector2(-0.35f, transform.localScale.y);
        }
    }
}
