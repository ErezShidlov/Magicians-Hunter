using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorLevelTwo : MonoBehaviour
{
    Animator anmControl;
    // Start is called before the first frame update
    void Start()
    {
        anmControl = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerTag" && PlayerArcherOneMovement.haveKey == true)
        {
            anmControl.SetBool("IsOpen", true);
        }
    }
    void EndDoorOpenAnimation()
    {
        anmControl.SetBool("IsOpen", false);
        SceneManager.LoadScene("LevelThree");
    }
}
