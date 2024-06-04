using SH.BusinessLogic;
using SH.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.View {
    public class DialoguePanel : MonoBehaviour, IActivable
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private BaseText talker, message;
        private Coroutine buildMessage;

        private void Start() {
            EventManager.Instance.AddListener(MyEventIndex.OnDialogueStart, OnDialogueStart);
        }

        private void OnDestroy() {
            EventManager.Instance.RemoveListener(MyEventIndex.OnDialogueStart, OnDialogueStart);
        }

        private void OnDialogueStart(MyEventArgs arg0) {
            EventManager.Instance.RemoveListener(MyEventIndex.OnDialogueStart, OnDialogueStart);
            EventManager.Instance.AddListener(MyEventIndex.OnInputConfirm, OnConfirm);
            DialogueEntry entry = arg0.additionalDialogueEntry;
            panel.SetActive(true);
            talker.SetText(entry.Talker);
            message.SetText(entry.Message);
            buildMessage = StartCoroutine(BuildMessageCo(entry.Message));
        }

        private void OnConfirm(MyEventArgs arg0) {
            EventManager.Instance.AddListener(MyEventIndex.OnDialogueStart, OnDialogueStart);
            EventManager.Instance.RemoveListener(MyEventIndex.OnInputConfirm, OnConfirm);
            Deactivate();
        }

        private IEnumerator BuildMessageCo(string message) {
            for(int i = 0; i < message.Length; i++) {
                this.message.SetTextVisibility(i);
                yield return new WaitForSeconds(0.05f);
            }
        }

        public void Activate() {
            throw new NotImplementedException();
        }

        public void Deactivate() {
            if (buildMessage != null)
                StopCoroutine(buildMessage);
            panel.SetActive(false);
        }
    }
}
