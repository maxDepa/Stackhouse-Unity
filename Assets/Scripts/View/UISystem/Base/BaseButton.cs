using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SH.View {
    [RequireComponent(typeof(Button))]
    public class BaseButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private GameObject highlight;

        [SerializeField] private UnityEvent OnSelect = new UnityEvent();
        [SerializeField] private UnityEvent OnDeselect = new UnityEvent();


        public void Click() { 
            button.onClick?.Invoke();
        }

        public void Select() {
            highlight.SetActive(true);
            OnSelect?.Invoke();
        }

        public void Deselect() {
            highlight.SetActive(false);
            OnDeselect?.Invoke();
        }
    }
}
