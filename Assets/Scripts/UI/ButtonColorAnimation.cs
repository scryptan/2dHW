using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonColorAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image source;
    [SerializeField] private Color from;
    [SerializeField] private Color to;
    [SerializeField] private float duration;

    private Tween _tween;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        _tween?.Kill();
        _tween = source.DOColor(to, duration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _tween?.Kill();
        _tween = source.DOColor(from, duration);
    }
}
