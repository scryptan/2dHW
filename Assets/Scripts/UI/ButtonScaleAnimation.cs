using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScaleAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Vector3 toScale;
    [SerializeField] private float durability;

    private Vector3 _originalScale;
    private Tween _tween;

    private void Awake()
    {
        _originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _tween?.Kill();
        _tween = transform.DOScale(toScale, durability);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _tween?.Kill();
        _tween = transform.DOScale(_originalScale, durability);
    }
}
