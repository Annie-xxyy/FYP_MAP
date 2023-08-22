using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
public class ToolTip : MonoBehaviour
{
    private TMP_Text toolTipText;
    private TMP_Text contentText;
    private CanvasGroup _canvasGroup;
    public float targetAlpha = 0;
    public float smoothing = 1f;

    private void Start()
    {
        toolTipText = GetComponent<TMP_Text>();
        contentText = transform.Find("Content").GetComponent<TMP_Text>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if (_canvasGroup.alpha != targetAlpha)
        {
            _canvasGroup.alpha = Mathf.Lerp(_canvasGroup.alpha, targetAlpha, smoothing * Time.deltaTime);
            if (Mathf.Abs(_canvasGroup.alpha - targetAlpha) < 0.01f)
            {
                _canvasGroup.alpha = targetAlpha;
            }
        }
    }

    public void Show(string text)
    {
        toolTipText.text = text;
        contentText.text = text;
        targetAlpha = 1;
    }

    public void Hide()
    {
        targetAlpha = 0;
    }

    public void SetLocalPosition(Vector3 postion)
    {
        transform.localPosition = postion;
    }
}
