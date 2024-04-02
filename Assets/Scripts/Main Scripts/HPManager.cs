using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPManager : MonoBehaviour
{
    public TMP_Text ShowHP; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowHP.text = PlayerArcherOneMovement.playerHP.ToString();
    }
}
