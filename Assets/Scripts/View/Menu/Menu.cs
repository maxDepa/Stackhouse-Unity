using SH.BusinessLogic;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.View {
    public class Menu : UISystem
    {
        private void Start() {
            EventManager.Instance.AddListener(MyEventIndex.OnInputInventory, OnInventoryInput);
        }

        private void OnDestroy() {
            EventManager.Instance.RemoveListener(MyEventIndex.OnInputInventory, OnInventoryInput);
        }

        private void OnInventoryInput(MyEventArgs arg0) {
            EventManager.Instance.RemoveListener(MyEventIndex.OnInputInventory, OnInventoryInput);
            EventManager.Instance.AddListener(MyEventIndex.OnInputCancel, OnCancelInput);
            Activate();
        }

        private void OnCancelInput(MyEventArgs arg0) {
            EventManager.Instance.AddListener(MyEventIndex.OnInputInventory, OnInventoryInput);
            Deactivate();
        }
    }
}
