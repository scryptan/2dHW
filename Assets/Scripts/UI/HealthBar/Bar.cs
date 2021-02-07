using System;
using UnityEngine;

namespace UI.HealthBar
{
    public class Bar
    {
        public float MinValue { get; }
        public float MaxValue { get; }
        public float CurrentValue { get; private set; }
        public BarType Type { get; }
        public Action<bool> ValueChanged;

        public Bar(float minValue, float maxValue, float currentValue, BarType type)
        {
            MaxValue = maxValue;
            MinValue = minValue;
            CurrentValue = currentValue;
            Type = type;
        }

        public void AddValue(float value)
        {
            CurrentValue += value;

            if (CurrentValue + value > MaxValue)
                CurrentValue = MaxValue;

            if (CurrentValue + value < MinValue)
                CurrentValue = MinValue;

            ValueChanged?.Invoke(value > 0);
        }
    }
}