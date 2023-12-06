using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UISan : MonoBehaviour
{
    public TMP_Text San;
    void Start()
    {
        San.text = "San :"+Convert.ToString(Player.instance.playerSanity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
