using SH.BusinessLogic;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SH.View {
    [RequireComponent(typeof(Slider))]
    public class HpBar : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private Gradient gradient;
        [SerializeField] private Image bar;

        private void Start() {
            EventManager.Instance.AddListener(MyEventIndex.OnPlayerInitialized, OnPlayerInitialized);
            EventManager.Instance.AddListener(MyEventIndex.OnPlayerDamaged, OnPlayerDamaged);
        }

        private void OnDestroy() {
            EventManager.Instance.RemoveListener(MyEventIndex.OnPlayerInitialized, OnPlayerInitialized);
            EventManager.Instance.RemoveListener(MyEventIndex.OnPlayerDamaged, OnPlayerDamaged);
        }

        private void OnPlayerInitialized(MyEventArgs arg0) {
            Initialize(arg0.additionalVector2.x, arg0.additionalVector2.y);
            UpdateValue(arg0.additionalVector2.y);
        }

        private void OnPlayerDamaged(MyEventArgs arg0) {
            UpdateValue(arg0.additionalInt);
        }

        public void Initialize(int minValue, int maxValue) { 
            slider.minValue = minValue;
            slider.maxValue = maxValue;
        }

        public void UpdateValue(int currentValue) {
            slider.value = currentValue;
            bar.color = gradient.Evaluate(slider.value / slider.maxValue);
        }
    }
}
