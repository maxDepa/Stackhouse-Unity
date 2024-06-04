using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SH.View {
    [RequireComponent(typeof(Button))]
    public class BaseButton : MonoBehaviour
    {
        [SerializeField] private Button button;
    }
}
