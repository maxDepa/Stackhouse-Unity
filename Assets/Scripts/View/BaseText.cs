using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SH.View {
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class BaseText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        public void SetText(string text) {
            _text.text = text;
        }
    }

}