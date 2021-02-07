using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI.HealthBar
{
    [RequireComponent(typeof(Slider))]
    public class BarView : MonoBehaviour
    {
        [SerializeField] private float barValueDurationInSeconds;
        [SerializeField] private float barMinValue;
        [SerializeField] private float barMaxValue = 100;
        [SerializeField] private float barCurrentValue = 50;
        [SerializeField] private BarType barType = BarType.Health;
        [SerializeField] private Slider underFillSlider;

        private Tween _fillSliderTween;
        private Tween _underFillSliderTween;
        private Bar _healthBar;
        private Slider _fillSlider;
        private float _underFillSliderDurationToDown => barValueDurationInSeconds * 3;
        private float _underFillSliderDurationToUp => barValueDurationInSeconds / 3;

        private void Awake()
        {
            _healthBar = new Bar(barMinValue, barMaxValue, barCurrentValue, barType);
            _fillSlider = GetComponent<Slider>();
            _fillSlider.maxValue = barMaxValue;
            _fillSlider.minValue = barMinValue;
            _fillSlider.value = barCurrentValue;

            if (underFillSlider != null)
            {
                underFillSlider.maxValue = barMaxValue;
                underFillSlider.minValue = barMinValue;
                underFillSlider.value = barCurrentValue;
            }
        }

        private void OnEnable()
        {
            _healthBar.ValueChanged += BarValueChanged;
        }

        public void TakeDamage(float damage)
        {
            _healthBar.AddValue(-damage);
        }

        public void TakeHeal(float heal)
        {
            _healthBar.AddValue(heal);
        }

        private void OnDisable()
        {
            _healthBar.ValueChanged += BarValueChanged;
        }

        private void BarValueChanged(bool isAddOperation)
        {
            _fillSliderTween?.Kill();
            _fillSliderTween = _fillSlider.DOValue(_healthBar.CurrentValue, barValueDurationInSeconds);

            if (underFillSlider != null)
            {
                _underFillSliderTween?.Kill();
                _underFillSliderTween = underFillSlider.DOValue(_healthBar.CurrentValue,
                    isAddOperation ? _underFillSliderDurationToUp : _underFillSliderDurationToDown);
            }
        }
    }
}