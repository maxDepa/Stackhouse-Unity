using SH.BusinessLogic;
using SH.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.View {
    public class BaseScreen : MonoBehaviour, IActivable
    {
        [SerializeField] private UISystem uiSystem;
        [SerializeField] private BaseScreen previousScreen;
        [SerializeField] private List<BaseButton> buttons = new List<BaseButton>();

        private int cursor;

        public void Activate() {
            gameObject.SetActive(true);

            if(TryGetCurrentButton(out BaseButton currentButton)) {
                currentButton.Select();
            }

            EventManager.Instance.AddListener(MyEventIndex.OnInputConfirm, OnConfirm);
            EventManager.Instance.AddListener(MyEventIndex.OnInputCancel, OnCancel);
            EventManager.Instance.AddListener(MyEventIndex.OnInputUpArrow, OnArrowUp);
            EventManager.Instance.AddListener(MyEventIndex.OnInputDownArrow, OnArrowDown);
        }

        public void Deactivate() {
            gameObject.SetActive(false);
            EventManager.Instance.RemoveListener(MyEventIndex.OnInputConfirm, OnConfirm);
            EventManager.Instance.RemoveListener(MyEventIndex.OnInputCancel, OnCancel);
            EventManager.Instance.RemoveListener(MyEventIndex.OnInputUpArrow, OnArrowUp);
            EventManager.Instance.RemoveListener(MyEventIndex.OnInputDownArrow, OnArrowDown);
        }

        public void NextButton() {
            if (!TryGetCurrentButton(out BaseButton currentButton))
                return;
            currentButton.Deselect();
            cursor = cursor == buttons.Count - 1 ? 0 : cursor + 1;
            if (!TryGetCurrentButton(out currentButton))
                return;
            currentButton.Select();
        }

        public void PreviousButton() {
            if (!TryGetCurrentButton(out BaseButton currentButton))
                return;
            currentButton.Deselect();
            cursor = cursor == 0 ? buttons.Count - 1 : cursor - 1;
            if (!TryGetCurrentButton(out currentButton))
                return;
            currentButton.Select();
        }

        private bool TryGetCurrentButton(out BaseButton currentButton) {
            if (cursor < buttons.Count) {
                currentButton = buttons[cursor];
                return true;
            }
            currentButton = null;
            return false;
        }

        private void OnConfirm(MyEventArgs arg0) {
            if (!TryGetCurrentButton(out BaseButton currentButton))
                return;
            currentButton.Click();
        }

        private void OnArrowDown(MyEventArgs arg0) {
            NextButton();
        }

        private void OnArrowUp(MyEventArgs arg0) {
            PreviousButton();
        }

        private void OnCancel(MyEventArgs arg0) {
            if (previousScreen)
                uiSystem.ActivateScreen(previousScreen);
            else
                uiSystem.Deactivate();
            //ActivateScreen UISystem
        }



    }
}
