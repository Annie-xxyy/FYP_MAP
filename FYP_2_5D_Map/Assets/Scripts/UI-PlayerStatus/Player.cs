using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public static Player instance;
    public float playerHP=100f;
    public float playerSanity=10f;
    public Slider HPSlider;
    public Image SanImage;
    public Sprite levelNormalSan;
    public Sprite levelMadnessSan;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        HPSlider.maxValue = playerHP;
        HPSlider.value=playerHP;
        SanImage.sprite = levelNormalSan;
    }
    
}
