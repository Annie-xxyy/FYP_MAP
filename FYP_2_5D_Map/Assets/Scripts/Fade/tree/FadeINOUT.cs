using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FadeINOUT : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void FadeIn()
    {
        Color targetColor = new Color(1,1,1,1);
        _spriteRenderer.DOColor(targetColor, Fadesetting.fadeDuration);
    }

    public void FadeOut()
    {
        Color targetColor = new Color(1,1,1,Fadesetting.targetAlpha);
        _spriteRenderer.DOColor(targetColor, Fadesetting.fadeDuration);
    }

    private void OnTriggerEnter(Collider other)
    {
        FadeOut();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FadeIn();
        }
    }
}
