using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonRotationAnimation : MonoBehaviour, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField] private Vector3 rotationAngle;
    [SerializeField] private float rotationDurability;

    private Tween _tween;
    private Vector3 _originalRotation;

    private void Awake()
    {
        _originalRotation = transform.localRotation.eulerAngles;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _tween = transform.DOLocalRotate(rotationAngle, rotationDurability).SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Incremental);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _tween?.Kill();
        transform.DOLocalRotate(_originalRotation, rotationDurability / 2);
    }
}